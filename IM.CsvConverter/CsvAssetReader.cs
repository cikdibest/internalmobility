using IM.Core.Contract;
using IM.Core.Model;
using System;
using System.Collections.Generic;

namespace IM.CsvConverter
{
    public class CsvAssetReader : ICSVAssetReader
    {

        public CsvAssetReader()
        {
        }

        public IList<AssetModel> ReadCSVFile(string path)
        {
            throw new NotImplementedException();
        }
    }
}
