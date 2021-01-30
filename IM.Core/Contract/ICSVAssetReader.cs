using IM.Core.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace IM.Core.Contract
{
    public interface ICSVAssetReader
    {
        IList<AssetModel> ReadCSVFile(string path);
    }
}
