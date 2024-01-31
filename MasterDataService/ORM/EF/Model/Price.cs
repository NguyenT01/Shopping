namespace MasterDataService.ORM.EF.Model;

public partial class Price
{
    public Guid PriceId { get; set; }

    public Guid? ProductId { get; set; }

    public decimal? PriceValue { get; set; }

    public DateTime? StartDate { get; set; }

    public DateTime? EndDate { get; set; }

    public Guid? CreatedUser { get; set; }

    public DateTime? CreatedDate { get; set; }

    public Guid? UpdatedUser { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public virtual Product? Product { get; set; }
}
