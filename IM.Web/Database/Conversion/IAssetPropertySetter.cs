using IM.Web.Database.Entity;
using IM.Web.Model;

namespace IM.Web.Database.Conversion
{
    public interface IAssetPropertySetter
    {
        void SetPropertyOfAssetEntity(SetPropertyForAssetRequestModel propertyForAssetRequestModel, AssetEntity entity);
    }
}
