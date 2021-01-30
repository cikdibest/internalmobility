using IM.Web.Database.Entity;
using IM.Web.Model;
using System;

namespace IM.Web.Conversion.Contract
{
    public interface IAssetSearchPredicateConverter
    {
        Func<AssetEntity, bool> Convert(GetAssetByPropertyValueRequestModel model);
    }
}
