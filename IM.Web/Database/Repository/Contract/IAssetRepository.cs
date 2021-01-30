using IM.Web.Database.Entity;
using IM.Web.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IM.Web.Database.Repository.Contract
{
    public interface IAssetRepository
    {
        Task<IList<long>> GetAssetsByProperty(Func<AssetEntity, bool> pred);

        Task SetPropertyForAsset(SetPropertyForAssetRequestModel model);

        Task InsertAssets(IEnumerable<AssetEntity> assetEntities);
    }
}
