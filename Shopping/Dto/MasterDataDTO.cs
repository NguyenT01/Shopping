namespace Shopping.API.Dto;

public record MasterDataDTO
{
    public Guid CustomerId { get; init; }
    public string? FirstName { get; init; }
    public string? LastName { get; init; }
    public string? Email { get; init; }
    public string? Address { get; init; }
}
