using IM.Web.Database.Conversion;
using IM.Web.Database.Entity;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace IM.Tests.UnitTests
{
    [TestClass]
    public class AssetPropertySetterTests
    {
        private Mock<ILogger<AssetPropertySetter>> loggerMock;
        private AssetPropertySetter assetPropertySetter;

        [TestInitialize]
        public void Init()
        {
            loggerMock = new Mock<ILogger<AssetPropertySetter>>();
            assetPropertySetter = new AssetPropertySetter(loggerMock.Object);
        }

        [TestMethod]
        public void When_SetPropertyOfAssetEntityCalledWithTruePropertyValue_Expect_PropertyToBeSetToTrue()
        {
            Test_SetPropertyWithNewValue(true);
        }
        [TestMethod]
        public void When_SetPropertyOfAssetEntityCalledWithFalsePropertyValue_Expect_PropertyToBeSetToFalse()
        {
            Test_SetPropertyWithNewValue(false);
        }


        private void Test_SetPropertyWithNewValue(bool newValue)
        {
            var requestModel = new Web.Model.SetPropertyForAssetRequestModel
            {
                AssetId = 1,
                Property = "is cash",
                Value = newValue
            };

            var asset = new AssetEntity
            {
                AssetId = 1,
                IsCash = !newValue,
            };

            assetPropertySetter.SetPropertyOfAssetEntity(requestModel, asset);

            Assert.IsTrue(asset.IsCash == newValue);


            requestModel = new Web.Model.SetPropertyForAssetRequestModel
            {
                AssetId = 1,
                Property = "is fixincome",
                Value = newValue
            };

            asset = new AssetEntity
            {
                AssetId = 1,
                IsFixIncome = !newValue,
            };

            assetPropertySetter.SetPropertyOfAssetEntity(requestModel, asset);

            Assert.IsTrue(asset.IsFixIncome == newValue);



            requestModel = new Web.Model.SetPropertyForAssetRequestModel
            {
                AssetId = 1,
                Property = "is convertible",
                Value = newValue
            };

            asset = new AssetEntity
            {
                AssetId = 1,
                IsFixIncome = !newValue,
            };

            assetPropertySetter.SetPropertyOfAssetEntity(requestModel, asset);

            Assert.IsTrue(asset.IsConvertible == newValue);


            requestModel = new Web.Model.SetPropertyForAssetRequestModel
            {
                AssetId = 1,
                Property = "is swap",
                Value = newValue
            };

            asset = new AssetEntity
            {
                AssetId = 1,
                IsFixIncome = !newValue,
            };

            assetPropertySetter.SetPropertyOfAssetEntity(requestModel, asset);

            Assert.IsTrue(asset.IsSwap == newValue);

            requestModel = new Web.Model.SetPropertyForAssetRequestModel
            {
                AssetId = 1,
                Property = "is future",
                Value = newValue
            };

            asset = new AssetEntity
            {
                AssetId = 1,
                IsFixIncome = !newValue,
            };

            assetPropertySetter.SetPropertyOfAssetEntity(requestModel, asset);

            Assert.IsTrue(asset.IsFuture == newValue);
        }

    }
}
