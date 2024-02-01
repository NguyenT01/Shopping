namespace OrderingService.ORM.EF.Model;

public partial class Customer
{
    public Guid CustomerId { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? Email { get; set; }

    public string? Address { get; set; }

    public Guid? CreatedUser { get; set; }

    public DateTime? CreatedDate { get; set; }

    public Guid? UpdatedUser { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
