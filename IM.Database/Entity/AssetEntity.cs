using System;
using System.Collections.Generic;
using System.Text;

namespace IM.Database.Entity
{
    public class AssetEntity
    {
        public long AssetId { get; set; }

        public string Name { get; set; }

        public IList<AssetPropertyEntity> Properties { get; set; }

        public DateTime TimeStamp { get; set; }
    }
}
