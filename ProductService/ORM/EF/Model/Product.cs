using System.ComponentModel.DataAnnotations.Schema;

namespace ProductService.ORM.EF.Model
{
    public class Product
    {
        [Column("ProductId")]
        public Guid ProductId { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
    }
}
