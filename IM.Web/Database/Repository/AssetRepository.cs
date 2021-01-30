using IM.Web.Database.Context;
using IM.Web.Database.Conversion;
using IM.Web.Database.Entity;
using IM.Web.Database.Repository.Contract;
using IM.Web.Model;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IM.Web.Database.Repository
{
    public class AssetRepository : IAssetRepository
    {
        private readonly ILogger<AssetRepository> logger;
        private readonly IMDbContext imDbContext;
        private readonly IAssetPropertySetter assetPropertySetter;

        public AssetRepository(ILogger<AssetRepository> logger, IMDbContext imDbContext, IAssetPropertySetter assetPropertySetter)
        {
            this.logger = logger;
            this.imDbContext = imDbContext;
            this.assetPropertySetter = assetPropertySetter;
        }

        public async Task<IList<long>> GetAssetsByProperty(Func<AssetEntity, bool> pred)
        {
            return await Task.Run(() => imDbContext.Assets.Where(pred).Select(a => a.AssetId).ToList());
        }

        public async Task InsertAssets(IEnumerable<AssetEntity> assetEntities)
        {
            foreach (var asset in assetEntities)
            {
                var currentAsset = imDbContext.Assets.AsQueryable().SingleOrDefault(a => a.AssetId == asset.AssetId);
                if (currentAsset == null)
                {
                    logger.LogError($"AssetId can not be found {asset.AssetId}");
                }
                else if (currentAsset.TimeStamp > asset.TimeStamp)
                {
                    logger.LogWarning($"Asset has smaller timestamp so skipping. AssetID : {asset.AssetId}");
                }
                else
                {
                    imDbContext.Assets.Remove(currentAsset);
                    imDbContext.Assets.Add(asset);
                }
            }
            await imDbContext.SaveChangesAsync();
        }

        public async Task SetPropertyForAsset(SetPropertyForAssetRequestModel model)
        {
            var currentAsset = imDbContext.Assets.SingleOrDefault(a => a.AssetId == model.AssetId);
            if (currentAsset == null)
            {
                logger.LogError($"AssetId can not be found {model.AssetId}");
            }
            else if (currentAsset.TimeStamp > model.TimeStamp)
            {
                logger.LogWarning($"Asset has smaller timestamp so skipping. AssetID : {model.AssetId}");
            }
            else
            {
                assetPropertySetter.SetPropertyOfAssetEntity(model, currentAsset);
            }
            imDbContext.Update(currentAsset);
            await imDbContext.SaveChangesAsync();
        }
    }
}
