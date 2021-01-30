using IM.Web.Conversion.Imp;
using IM.Web.Database.Entity;
using IM.Web.Model;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Linq;

namespace IM.Tests.UnitTests
{
    [TestClass]
    public class AssetSearchPredicateConverterTests
    {
        private Mock<ILogger<AssetSearchPredicateConverter>> loggerMock;
        private AssetSearchPredicateConverter assetPredicateConverter;

        [TestInitialize]
        public void Init()
        {
            loggerMock = new Mock<ILogger<AssetSearchPredicateConverter>>();
            assetPredicateConverter = new AssetSearchPredicateConverter(loggerMock.Object);
        }

        [TestMethod]
        public void When_ConvertToPredicateCalledWithProperSearchRequestWithValueTrue_Expect_PredicateWithTrue()
        {
            Test_AssetSearchPredicateConverterWithValue(true);
        }

        [TestMethod]
        public void When_ConvertToPredicateCalledWithProperSearchRequestWithValueFalse_Expect_PredicateWithFalse()
        {
            Test_AssetSearchPredicateConverterWithValue(false);
        }

        public void Test_AssetSearchPredicateConverterWithValue(bool value)
        {
            var iscashrequestModel = new GetAssetByPropertyValueRequestModel
            {
                Property = "is cash",
                Value = value
            };
            var predicate = assetPredicateConverter.Convert(iscashrequestModel);

            var iscashentityList = new List<AssetEntity>() { new AssetEntity
            {
                IsCash = value
            } };
            Assert.IsTrue(iscashentityList.Where(predicate).Count() == 1);


            var isconvertiblerequestModel = new GetAssetByPropertyValueRequestModel
            {
                Property = "is convertible",
                Value = value
            };
            predicate = assetPredicateConverter.Convert(isconvertiblerequestModel);

            var isconvertibleentityList = new List<AssetEntity>() { new AssetEntity
            {
                IsConvertible = value
            } };
            Assert.IsTrue(isconvertibleentityList.Where(predicate).Count() == 1);


            var isswaprequestModel = new GetAssetByPropertyValueRequestModel
            {
                Property = "is swap",
                Value = value
            };
            predicate = assetPredicateConverter.Convert(isswaprequestModel);

            var isswapentityList = new List<AssetEntity>() { new AssetEntity
            {
                IsSwap = value
            } };
            Assert.IsTrue(isswapentityList.Where(predicate).Count() == 1);


            var isfixincomerequestModel = new GetAssetByPropertyValueRequestModel
            {
                Property = "is fixincome",
                Value = value
            };
            predicate = assetPredicateConverter.Convert(isfixincomerequestModel);

            var isfixincomeentityList = new List<AssetEntity>() { new AssetEntity
            {
                IsFixIncome = value
            } };
            Assert.IsTrue(isfixincomeentityList.Where(predicate).Count() == 1);


            var isfuturerequestModel = new GetAssetByPropertyValueRequestModel
            {
                Property = "is future",
                Value = value
            };
            predicate = assetPredicateConverter.Convert(isfuturerequestModel);

            var isfutureentityList = new List<AssetEntity>() { new AssetEntity
            {
                IsFuture = value
            } };
            Assert.IsTrue(isfutureentityList.Where(predicate).Count() == 1);
        }
    }
}
