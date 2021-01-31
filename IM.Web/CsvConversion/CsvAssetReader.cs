using IM.Web.Database.Entity;
using IM.Web.Exceptions;
using IM.Web.Model;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using IM.Web.Extensions;

namespace IM.CsvConverter
{
    public class CsvAssetReader : ICsvAssetReader
    {

        private readonly ILogger<CsvAssetReader> logger;

        public CsvAssetReader(ILogger<CsvAssetReader> logger)
        {
            this.logger = logger;
        }
        public CsvAssetReaderReturnModel ReadCSVFile(ProcessCsvFileRequestModel requestModel)
        {
            var modelToReturn = new CsvAssetReaderReturnModel();

            var assetList = new List<AssetModel>();

            var batches = new List<BatchEntity>();

            string[] lines = System.IO.File.ReadAllLines(requestModel.Path);
            lines = lines.Skip(1).ToArray();

            foreach (var line in lines)
            {
                var asset = GetAssetFromLine(line);
                if (asset == null)
                {
                    throw new CsvFileException("Could not read the file");
                }
                assetList.Add(asset);
            }

            modelToReturn.Assets = assetList;
            var listOfBatches = lines.ToList().Split(requestModel.BatchSize);

            foreach (var batch in listOfBatches)
            {
                batches.Add(new BatchEntity
                {
                    Content = string.Join(Environment.NewLine, batch)
                });
            }
            modelToReturn.Batches = batches;
            return modelToReturn;
        }

        private AssetModel GetAssetFromLine(string line)
        {
            var assetToReturn = new AssetModel();
            line = line.Trim('”').Replace("”", "");
            var props = line.Split(",");
            int parsedAssetId;
            DateTime parsedDate = DateTime.MinValue;
            if (int.TryParse(props[0], out parsedAssetId))
            {
                assetToReturn.Id = parsedAssetId;

                if (props[1] == "is cash")
                {
                    assetToReturn.IsCash = bool.Parse(props[2]);
                }
                else if (props[1] == "is convertible")
                {
                    assetToReturn.IsConvertible = bool.Parse(props[2]);
                }
                else if (props[1] == "is fixincome")
                {
                    assetToReturn.IsFixIncome = bool.Parse(props[2]);
                }
                else if (props[1] == "is future")
                {
                    assetToReturn.IsFuture = bool.Parse(props[2]);
                }
                else if (props[1] == "is swap")
                {
                    assetToReturn.IsSwap = bool.Parse(props[2]);
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return null;
            }
            if (props.Count() == 4)
            {
                DateTime.TryParse(props[3], out parsedDate);
            }
            assetToReturn.TimeStamp = parsedDate;
            return assetToReturn;
        }
    }
}

