using IM.Web.Conversion.Imp;
using IM.Web.Model;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;

namespace IM.Tests.UnitTests
{
    [TestClass]
    public class AssetConverterTests
    {
        private Mock<ILogger<AssetConverter>> loggerMock;
        private AssetConverter assetConverter;
        [TestInitialize]
        public void Init()
        {
            loggerMock = new Mock<ILogger<AssetConverter>>();

            assetConverter = new AssetConverter(loggerMock.Object);
        }

        [TestMethod]
        public void When_ConvertToAssetCalledWithProperAsset_Expect_ProperAssetEntity()
        {
            long id = new Random().Next(1, 50000);
            bool iscash = new Random().Next(2) == 0;
            bool isFixIncome = new Random().Next(2) == 0;
            bool isConvertible = new Random().Next(2) == 0;
            bool isSwap = new Random().Next(2) == 0;
            bool isFuture = new Random().Next(2) == 0;
            string name = "testNameForAsset";
            DateTime timeStamp = DateTime.Now;

            var assetToBeTested = new AssetModel
            {
                Id = id,
                IsCash = iscash,
                IsConvertible = isConvertible,
                IsFixIncome = isFixIncome,
                IsFuture = isFuture,
                IsSwap = isSwap,
                Name = name,
                TimeStamp = timeStamp
            };

            var entity = assetConverter.ConvertToAssetEntity(assetToBeTested);

            Assert.AreEqual(id, assetToBeTested.Id);

            Assert.AreEqual(iscash, entity.IsCash);
            Assert.AreEqual(isConvertible, entity.IsConvertible);
            Assert.AreEqual(isFixIncome, entity.IsFixIncome);
            Assert.AreEqual(isFuture, entity.IsFuture);
            Assert.AreEqual(isSwap, entity.IsSwap);
            Assert.AreEqual(name, entity.Name);
            Assert.AreEqual(timeStamp, entity.TimeStamp);
        }


        [TestMethod]
        public void When_ConvertToAssetCalledWithNullAsset_Expect_NullEntity()
        {

            try
            {
                Assert.IsNull(assetConverter.ConvertToAssetEntity(null));
                Assert.Fail();
            }
            catch
            {

            }
            
        }
    }
}
