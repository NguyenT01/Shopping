namespace Shopping.API.Dto
{
    public class PriceUpdateDTO
    {
        public Guid? PriceId { get; set; }
        public double PriceValue { get; init; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
