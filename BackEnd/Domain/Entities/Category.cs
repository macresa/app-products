namespace Domain.Entities;

public partial class Category : BaseEntity
{
    public string Name { get; set; } = null!;

    public virtual ICollection<Product> Products { get; } = new List<Product>();
}