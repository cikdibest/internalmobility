using System.ComponentModel.DataAnnotations;

namespace IM.Web.Database.Entity
{
    public class BatchEntity
    {
        [Key]
        public int Id { get; set; }

        public string Content { get; set; }
    }
}
