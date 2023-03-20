namespace Domain.Entities;

public partial class Product : BaseEntity
{
    public string Name { get; set; } = null!;

    public string Brand { get; set; } = null!;

    public string? Description { get; set; }

    public double Price { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public int? Stock { get; set; }

    public int CategoryId { get; set; }

    public virtual Category Category { get; set; } = null!;
}
