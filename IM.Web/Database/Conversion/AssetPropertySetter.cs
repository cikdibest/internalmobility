using IM.Web.Database.Entity;
using IM.Web.Exceptions;
using IM.Web.Model;
using Microsoft.Extensions.Logging;

namespace IM.Web.Database.Conversion
{
    public class AssetPropertySetter : IAssetPropertySetter
    {
        private readonly ILogger<AssetPropertySetter> logger;
        public AssetPropertySetter(ILogger<AssetPropertySetter> logger)
        {
            this.logger = logger;
        }

        public void SetPropertyOfAssetEntity(SetPropertyForAssetRequestModel propertyForAssetRequestModel, AssetEntity entity)
        {
            var prop = propertyForAssetRequestModel.Property;

            if (prop == "is cash")
            {
                entity.IsCash = propertyForAssetRequestModel.Value;
            }

            else if (prop == "is fixincome")
            {
                entity.IsFixIncome = propertyForAssetRequestModel.Value;
            }

            else if (prop == "is convertible")
            {
                entity.IsConvertible = propertyForAssetRequestModel.Value;
            }

            else if (prop == "is swap")
            {
                entity.IsSwap = propertyForAssetRequestModel.Value;
            }

            else if (prop == "is future")
            {
                entity.IsFuture = propertyForAssetRequestModel.Value;
            }
            else
            {
                logger.LogError($"Model property could not be found in AssetPropertySetter  {prop}");
                throw new PropertySetException($"Property of {prop} could not be found");
            }
        }
    }
}
