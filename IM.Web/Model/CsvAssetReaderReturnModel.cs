using IM.Web.Database.Entity;
using System.Collections.Generic;

namespace IM.Web.Model
{
    public class CsvAssetReaderReturnModel
    {
        public IEnumerable<AssetModel> Assets { get; set; }
        public IEnumerable<BatchEntity> Batches { get; set; }
    }
}
