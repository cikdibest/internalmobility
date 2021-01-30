using IM.Web.Database.Entity;
using IM.Web.Model;

namespace IM.Web.Conversion.Contract
{
    public interface IAssetConverter
    {
        AssetEntity ConvertToAssetEntity(AssetModel model);
    }
}
