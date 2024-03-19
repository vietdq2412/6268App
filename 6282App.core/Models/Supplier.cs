namespace _6282App.core.Models
{
    public class Supplier: BaseEntity
    {
        public long Id { get; set; }
        public string? Name { get; set; }
        public string? Address { get; set; }
        public ICollection<Product>? Products { get; set; }
    }
}
