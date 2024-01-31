namespace MasterDataService.ORM.EF.Model;

public partial class Product
{
    public Guid ProductId { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public Guid? CreatedUser { get; set; }

    public DateTime? CreatedDate { get; set; }

    public Guid? UpdatedUser { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

    public virtual ICollection<Price> Prices { get; set; } = new List<Price>();
}
