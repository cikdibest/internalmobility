using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IM.Web.Database.Entity
{
    public class AssetEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long AssetId { get; set; }
        public string Name { get; set; }
        public bool IsCash { get; set; }
        public bool IsFixIncome { get; set; }
        public bool IsConvertible { get; set; }
        public bool IsSwap { get; set; }
        public bool IsFuture { get; set; }
        public DateTime TimeStamp { get; set; }
    }
}
