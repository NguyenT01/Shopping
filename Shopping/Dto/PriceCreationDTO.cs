namespace Shopping.API.Dto
{
    public record PriceCreationDTO
    {
        public Guid? ProductId { get; set; }
        public double PriceValue { get; init; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
