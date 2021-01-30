using IM.Web.Database.Context;
using IM.Web.Database.Conversion;
using IM.Web.Database.Entity;
using IM.Web.Database.Repository;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MockQueryable.Moq;

namespace IM.Tests.UnitTests
{
    [TestClass]
    public class AssetRepositoryTests
    {
        private Mock<ILogger<AssetRepository>> logger;
        private Mock<ILogger<AssetPropertySetter>> propertySetterLogger;
        private Mock<IMDbContext> imDbContext;
        private IAssetPropertySetter assetPropertySetter;
        private AssetRepository assetRepository;

        [TestInitialize]
        public void Init()
        {
            logger = new Mock<ILogger<AssetRepository>>();
            propertySetterLogger = new Mock<ILogger<AssetPropertySetter>>();
            imDbContext = new Mock<IMDbContext>();
            assetPropertySetter = new Mock<AssetPropertySetter>(propertySetterLogger.Object).Object;
            assetRepository = new AssetRepository(logger.Object, imDbContext.Object, assetPropertySetter);
        }

        [TestMethod]
        public async Task When_InsertAssetsIsCalledWithANonExistentAsset_Expect_LoggersLogErrorMethodToBeCalled()
        {
            //2 - build mock by extension
            var mock = new List<AssetEntity>().AsQueryable().BuildMockDbSet();

            //LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter

            imDbContext.Setup(s => s.Assets).Returns(mock.Object);
            await assetRepository.InsertAssets(new List<AssetEntity> { new AssetEntity { AssetId = 1 } });
            //logger.Setup(s => s.Log<It.IsAnyType>(It.IsAny<LogLevel>(), It.IsAny<EventId>(), It.IsAny<It.IsAnyType>(), It.IsAny<Exception>(), null)).Verifiable();

            logger.Verify(f => f.Log(
    It.IsAny<LogLevel>(),
    It.IsAny<EventId>(),
    It.IsAny<It.IsAnyType>(),
    It.IsAny<Exception>(),
    (Func<It.IsAnyType, Exception, string>)It.IsAny<object>()), Times.Once);
        }

    }
}
