using IM.CsvConverter;
using IM.Web.Exceptions;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Linq;

namespace IM.Tests.UnitTests
{
    [TestClass]
    public class CsvAssetReaderTests
    {
        private Mock<ILogger<CsvAssetReader>> loggerMock;
        private CsvAssetReader csvAssetReader;

        [TestInitialize]
        public void Init()
        {
            loggerMock = new Mock<ILogger<CsvAssetReader>>();
            csvAssetReader = new CsvAssetReader(loggerMock.Object);
        }

        [TestMethod]
        public void When_ReadCSVFileCalledWithProperCsvFile_Expect_AssetModelList()
        {
            var returnModel = csvAssetReader.ReadCSVFile(new Web.Model.ProcessCsvFileRequestModel
            {
                Path = ".\\TestCsvs\\valid1.csv",
                BatchSize = 100
            });

            var assetList = returnModel.Assets;

            Assert.IsTrue(assetList.Count() == 3);

            Assert.IsTrue(assetList.Any(a => a.Id == 1));

            Assert.IsTrue(assetList.Any(a => a.Id == 3));

            Assert.IsTrue(assetList.Any(a => a.Id == 4));

            var firstAsset = assetList.Single(a => a.Id == 1);
            Assert.IsTrue(firstAsset.IsCash);
            Assert.IsFalse(firstAsset.IsConvertible);
            Assert.IsFalse(firstAsset.IsFixIncome);
            Assert.IsFalse(firstAsset.IsFuture);
            Assert.IsFalse(firstAsset.IsSwap);
            Assert.IsTrue(firstAsset.TimeStamp == new System.DateTime(2020, 7, 1, 16, 32, 32));

            var secondAsset = assetList.Single(a => a.Id == 3);
            Assert.IsFalse(secondAsset.IsCash);
            Assert.IsFalse(secondAsset.IsConvertible);
            Assert.IsFalse(secondAsset.IsFixIncome);
            Assert.IsFalse(secondAsset.IsFuture);
            Assert.IsFalse(secondAsset.IsSwap);
            Assert.IsTrue(secondAsset.TimeStamp == new System.DateTime(2020, 8, 2, 16, 32, 32));


            var thirdAsset = assetList.Single(a => a.Id == 4);
            Assert.IsTrue(secondAsset.IsConvertible);
            Assert.IsFalse(secondAsset.IsCash);
            Assert.IsFalse(secondAsset.IsFixIncome);
            Assert.IsFalse(secondAsset.IsFuture);
            Assert.IsFalse(secondAsset.IsSwap);
            Assert.IsTrue(secondAsset.TimeStamp == DateTime.MinValue);
        }

        [TestMethod]
        public void When_ReadCSVFileCalledWithBrokenCsvFile_Expect_CsvFileException()
        {
            try
            {
                var returnModel = csvAssetReader.ReadCSVFile(new Web.Model.ProcessCsvFileRequestModel
                {
                    Path = ".\\TestCsvs\\broken1.csv",
                    BatchSize = 100
                });
                Assert.Fail("For an invalid file csvfilereader did not throw an exception");
            }
            catch (CsvFileException ex)
            {

            }

        }
    }
}
