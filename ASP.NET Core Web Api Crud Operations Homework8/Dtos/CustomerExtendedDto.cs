using System.ComponentModel.DataAnnotations;

namespace ASP.NET_Homework8.Dtos
{
    public class CustomerExtendedDto
    {
        [Required]
        public string? Name { get; set; }
        [Required]
        public string? Surname { get; set; }
    }
}
