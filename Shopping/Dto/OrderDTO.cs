namespace Shopping.API.Dto
{
    public class OrderDTO
    {
        public Guid? OrderId { get; set; }
        public Guid CustomerId { get; init; }
        public DateTime? OrderDate { get; set; }
    }
}
