namespace Shopping.API.Dto
{
    public record ProductCreationDTO : PriceCreationDTO
    {
        public string? Name { get; init; }
        public string? Description { get; init; }
    }
}
