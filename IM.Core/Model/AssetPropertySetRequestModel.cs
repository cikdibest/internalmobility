using System;
using System.Collections.Generic;
using System.Text;

namespace IM.Core.Model
{
    public class AssetPropertySetRequestModel
    {
        public long AssetId { get; set; }
        public string Property { get; set; }
        public bool Value { get; set; }
        public DateTime TimeStamp { get; set; }
    }
}
