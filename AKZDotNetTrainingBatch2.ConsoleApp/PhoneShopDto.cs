
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AKZDotNetTrainingBatch2.ConsoleApp
{
    [Table("Tbl_PhoneShop")]
    internal class PhoneShopDto
    {
        [Key]
        public int id { get; set; }
        public string name { get; set; }
        public string price { get; set; }
        public string quantity { get; set; }
    }
}
