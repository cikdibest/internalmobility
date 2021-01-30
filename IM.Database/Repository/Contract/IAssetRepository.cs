using IM.Core.Model;
using IM.Database.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace IM.Database.Repository.Contract
{
    public interface IAssetRepository
    {
        IList<long> GetAssetsByProperty(string propertyName,bool value);

        void SetPropertyForAsset(AssetPropertySetRequestModel model);

        void InsertAssets(IList<AssetEntity> assetEntities);
    }
}
