using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_CommerceSite.Models
{
    public class Sizes
    {
        [Key]
        public int SizeId { get; set; }

        public required string Size { get; set; }

        [ForeignKey("Products")]
        public int P_ID { get; set; } 
        public  Products? Products { get; set; }
    }
}
