using System.ComponentModel.DataAnnotations;

namespace ASP.NET_Homework8.Dtos
{
    public class OrderExtendedDto
    {
        [Required]
        public DateTime? OrderDate { get; set; } = DateTime.Now;
        [Required]
        public int ProductId { get; set; }
        [Required]
        public int CustomerId { get; set; }
    }
}
