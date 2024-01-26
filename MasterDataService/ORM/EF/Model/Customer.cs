
using System.ComponentModel.DataAnnotations.Schema;

namespace MasterDataService.ORM.EF.Model;

public class Customer
{
    [Column("CustomerId")]
    public Guid CustomerId { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Email { get; set; }
    public string? Address { get; set; }
}