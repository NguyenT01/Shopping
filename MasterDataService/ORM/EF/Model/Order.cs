namespace MasterDataService.ORM.EF.Model;

public partial class Order
{
    public Guid OrderId { get; set; }

    public Guid CustomerId { get; set; }

    public DateTime? OrderDate { get; set; }

    public Guid? CreatedUser { get; set; }

    public DateTime? CreatedDate { get; set; }

    public Guid? UpdatedUser { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public virtual Customer Customer { get; set; } = null!;

    public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
}
