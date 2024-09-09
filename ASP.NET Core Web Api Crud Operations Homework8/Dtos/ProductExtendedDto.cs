using System.ComponentModel.DataAnnotations;

namespace ASP.NET_Homework8.Dtos
{
    public class ProductExtendedDto
    {
        [Required]
        public string? Name { get; set; }
        [Required]
        public int Price { get; set; }
        [Required]
        public int Discount { get; set; }
    }
}
