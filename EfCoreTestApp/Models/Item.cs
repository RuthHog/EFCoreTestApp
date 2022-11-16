using System.ComponentModel.DataAnnotations;

namespace EfCoreTestApp.Models
{
    public class Item
    {
        [Key]
        public string ItemNo { get; set; }
        public string Data { get; set; }

        public virtual ICollection<Item> Children { get; set; } = new List<Item>();



    }
}
