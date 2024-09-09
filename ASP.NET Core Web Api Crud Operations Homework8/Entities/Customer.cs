using System.Text.Json.Serialization;

namespace ASP.NET_Homework8.Entities
{
    public class Customer
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        [JsonIgnore]
        public virtual ICollection<Order>? Orders { get; set; }
    }
}
