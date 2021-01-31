using IM.CsvConverter;
using IM.Web.Controllers;
using IM.Web.Conversion.Contract;
using IM.Web.Database.Entity;
using IM.Web.Database.Repository.Contract;
using IM.Web.Model;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IM.Tests.UnitTests
{
    [TestClass]
    public class AssetControllerTests
    {


        private ILogger<AssetController> assetControllerLogger;
        private Mock<IAssetRepository> assetRepository;
        private Mock<ICsvAssetReader> csvAssetReader;
        private Mock<IAssetConverter> assetConverter;
        private Mock<IAssetSearchPredicateConverter> assetSearchPredicateConverter;
        private Mock<IBatchRepository> batchRepository;

        [TestInitialize]
        public void Init()
        {
            assetControllerLogger = new Mock<ILogger<AssetController>>().Object;
            assetRepository = new Mock<IAssetRepository>();
            csvAssetReader = new Mock<ICsvAssetReader>();
            assetConverter = new Mock<IAssetConverter>();
            assetSearchPredicateConverter = new Mock<IAssetSearchPredicateConverter>();
            batchRepository = new Mock<IBatchRepository>();
        }


        [TestMethod]
        public async Task When_ProcessCsvFileIsCalledWithProperCsvFile_Expect_InsertAssetsAndInsertBatchIsCalled()
        {
            var csvAssetReaderReturnValue = new CsvAssetReaderReturnModel()
            {
                Assets = new List<AssetModel>() { new AssetModel {
            Id = 1,
            TimeStamp = DateTime.Now} },
                Batches = new List<BatchEntity>() { new BatchEntity { Content = "123" } }
            };

            var convertedAssetEntity = new AssetEntity
            {
                AssetId = 1
            };

            csvAssetReader.Setup(s => s.ReadCSVFile(It.IsAny<ProcessCsvFileRequestModel>())).Returns(csvAssetReaderReturnValue);

            assetConverter.Setup(s => s.ConvertToAssetEntity(It.IsAny<AssetModel>())).Returns(convertedAssetEntity);

            var controller = new AssetController(assetControllerLogger, assetRepository.Object, csvAssetReader.Object, assetConverter.Object, assetSearchPredicateConverter.Object, batchRepository.Object);

            await controller.ProcessCsvFile(new ProcessCsvFileRequestModel
            {
                BatchSize = 10,
                Path = "Test"
            });

            assetRepository.Verify(s => s.InsertAssets(It.IsAny<IEnumerable<AssetEntity>>()), Times.Once);

            batchRepository.Verify(s => s.InsertBatch(It.IsAny<BatchEntity>()), Times.Once);
        }
    }
}
