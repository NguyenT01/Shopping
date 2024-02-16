namespace Shopping.API.Dto
{
    public record PriceDTO : PriceCreationDTO
    {
        public Guid PriceId { get; init; }
    }
}
