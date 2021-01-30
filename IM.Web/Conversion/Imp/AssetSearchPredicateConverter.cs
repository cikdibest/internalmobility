using IM.Web.Conversion.Contract;
using IM.Web.Database.Entity;
using IM.Web.Exceptions;
using IM.Web.Model;
using Microsoft.Extensions.Logging;
using System;

namespace IM.Web.Conversion.Imp
{
    public class AssetSearchPredicateConverter : IAssetSearchPredicateConverter
    {
        private readonly ILogger<AssetSearchPredicateConverter> logger;

        public AssetSearchPredicateConverter(ILogger<AssetSearchPredicateConverter> logger)
        {
            this.logger = logger;
        }
        public Func<AssetEntity, bool> Convert(GetAssetByPropertyValueRequestModel model)
        {
            var value = model.Value;

            if (model.Property == "is cash")
            {
                return new Func<AssetEntity, bool>(s => s.IsCash == value);
            }

            if (model.Property == "is convertible")
            {
                return new Func<AssetEntity, bool>(s => s.IsConvertible == value);
            }

            if (model.Property == "is fixincome")
            {
                return new Func<AssetEntity, bool>(s => s.IsFixIncome == value);
            }

            if (model.Property == "is swap")
            {
                return new Func<AssetEntity, bool>(s => s.IsSwap == value);
            }

            if (model.Property == "is future")
            {
                return new Func<AssetEntity, bool>(s => s.IsFuture == value);
            }
            else
            {
                logger.LogError("Could not convert the search parameter to a valid predicate!");
                throw new ConversionException("Could not convert the search parameter to a valid predicate!");
            }
        }
    }
}
