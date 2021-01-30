using System;

namespace IM.Web.Model
{
    public class AssetModel
    {
        public long Id { get; set; }
        public bool IsCash { get; set; }
        public bool IsFixIncome { get; set; }
        public bool IsConvertible { get; set; }
        public bool IsSwap { get; set; }
        public bool IsFuture { get; set; }
        public string Name { get; set; }
        public DateTime TimeStamp { get; set; }
    }
}
