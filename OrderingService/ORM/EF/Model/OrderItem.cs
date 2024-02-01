namespace OrderingService.ORM.EF.Model;

public partial class OrderItem
{
    public Guid OrderId { get; set; }

    public Guid ProductId { get; set; }

    public int? Quantity { get; set; }

    public Guid? CreatedUser { get; set; }

    public DateTime? CreatedDate { get; set; }

    public Guid? UpdatedUser { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public virtual Order Order { get; set; } = null!;

    public virtual Product Product { get; set; } = null!;
}
