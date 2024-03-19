namespace _6282App.core.Models
{
    public class Order: BaseEntity
    {
        public long Id { get; set; }
        public string? Name { get; set; }
        public string Status { get; set; }
        public ICollection<OrderDetail>? OrderDetails { get; set; }
    }
}