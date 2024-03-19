namespace _6282App.core.Models
{
    public class Category : BaseEntity
    {
        public long Id { get; set; }
        public string? Name { get; set; }
        public ICollection<Product>? Products { get; set; } = null;

    }
}