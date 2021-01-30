using IM.Web.Conversion.Contract;
using IM.Web.Database.Entity;
using IM.Web.Exceptions;
using IM.Web.Model;
using Microsoft.Extensions.Logging;

namespace IM.Web.Conversion.Imp
{
    public class AssetConverter : IAssetConverter
    {
        private readonly ILogger<AssetConverter> logger;

        public AssetConverter(ILogger<AssetConverter> logger)
        {
            this.logger = logger;
        }

        public AssetEntity ConvertToAssetEntity(AssetModel model)
        {
            if (model == null)
            {
                logger.LogError("Model is null. Can not convert to entity");
                throw new ConversionException("Asset model is null");
            }
            return new AssetEntity
            {
                TimeStamp = model.TimeStamp,
                AssetId = model.Id,
                IsCash = model.IsCash,
                IsConvertible = model.IsConvertible,
                IsFixIncome = model.IsFixIncome,
                IsFuture = model.IsFuture,
                IsSwap = model.IsSwap,
                Name = model.Name
            };
        }
    }
}
