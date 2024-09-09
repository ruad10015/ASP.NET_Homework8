using System.Text.Json.Serialization;

namespace ASP.NET_Homework8.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime? OrderDate { get; set; } = DateTime.Now;
        public int ProductId { get; set; }
        [JsonIgnore]
        public virtual Product? Product { get; set; }
        public int CustomerId { get; set; }
        [JsonIgnore]
        public virtual Customer? Customer { get; set; }
    }
}
