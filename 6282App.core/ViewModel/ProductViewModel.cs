namespace _6282App.core.ViewModel;

public class ProductViewModel
{
    public string? Name { get; set; }
    public decimal? Price { get; set; }
    public string? Image { get; set; }
    public long[]? CategoryIds { get; set; }
    public long? SupplierId { get; set; }
}