using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dasync.Collections;
using IM.CsvConverter;
using IM.Web.Conversion.Contract;
using IM.Web.Database.Repository.Contract;
using IM.Web.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace IM.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AssetController : ControllerBase
    {
        private readonly ILogger<AssetController> logger;
        private readonly IAssetRepository assetRepository;
        private readonly ICsvAssetReader csvAssetReader;
        private readonly IAssetConverter assetConverter;
        private readonly IAssetSearchPredicateConverter assetSearchPredicateConverter;
        private readonly IBatchRepository batchRepository;

        public AssetController(ILogger<AssetController> logger, IAssetRepository assetRepository,
            ICsvAssetReader csvAssetReader, IAssetConverter assetConverter,
            IAssetSearchPredicateConverter assetSearchPredicateConverter,
            IBatchRepository batchRepository)
        {
            this.logger = logger;
            this.assetRepository = assetRepository;
            this.csvAssetReader = csvAssetReader;
            this.assetConverter = assetConverter;
            this.assetSearchPredicateConverter = assetSearchPredicateConverter;
            this.batchRepository = batchRepository;
        }

        [HttpPost]
        [Route("ProcessCsv")]
        public async Task ProcessCsvFile(ProcessCsvFileRequestModel request)
        {
            var csvReadContent = csvAssetReader.ReadCSVFile(request);

            var assetEntityList = csvReadContent.Assets.Select(assetConverter.ConvertToAssetEntity);

            await assetRepository.InsertAssets(assetEntityList);

            await csvReadContent.Batches.ParallelForEachAsync(batch => batchRepository.InsertBatch(batch));
        }


        [HttpPost]
        [Route("AssetsByPropertyValues")]
        public async Task<IList<long>> GetAssetsByPropertyValues([FromBody]GetAssetByPropertyValueRequestModel model)
        {
            var predicate = assetSearchPredicateConverter.Convert(model);
            return await assetRepository.GetAssetsByProperty(predicate);
        }

        [HttpPost]
        [Route("SetPropertyForAsset")]
        public async Task SetPropertyForAsset(SetPropertyForAssetRequestModel model)
        {
            await assetRepository.SetPropertyForAsset(model);
        }
    }
}
