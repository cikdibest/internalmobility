using System;
using System.Collections.Generic;
using System.Text;

namespace IM.Core.Model
{
    public class AssetModel
    {
        public long ID { get; set; }
        public string Name { get; set; }
        public DateTime TimeStamp { get; set; }
        public IList<AssetProperty> Properties { get; set; }
    }
}
