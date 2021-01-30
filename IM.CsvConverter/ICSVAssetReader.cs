using System;
using System.Collections.Generic;
using System.Text;

namespace IM.CsvConverter
{
    public interface ICSVAssetReader
    {
        public IList<AssetModel> ReadCSVFile(string path)
    }
}
