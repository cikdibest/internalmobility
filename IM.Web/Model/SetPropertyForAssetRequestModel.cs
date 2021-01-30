using System;

namespace IM.Web.Model
{
    public class SetPropertyForAssetRequestModel
    {
        public long AssetId { get; set; }
        public string Property { get; set; }
        public bool Value { get; set; }
        public DateTime TimeStamp { get; set; }
    }
}
