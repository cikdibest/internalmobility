using IM.Core.Contract;
using IM.Core.Model;
using IM.Database.Entity;
using IM.Database.Repository.Contract;
using System;
using System.Collections.Generic;
using System.Text;

namespace IM.Database.Repository
{
    public class AssetRepository : IAssetRepository
    {
        public IList<long> GetAssetsByProperty(AssetProperty assetProperty)
        {
            throw new NotImplementedException();
        }

        public void InsertAssets(IList<AssetEntity> assetEntities)
        {
            throw new NotImplementedException();
        }

        public void SetPropertyForAsset(AssetPropertySetRequestModel model)
        {
            throw new NotImplementedException();
        }
    }
}
