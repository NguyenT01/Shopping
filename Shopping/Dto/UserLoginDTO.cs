namespace Shopping.API.Dto
{
    public record UserLoginDTO
    {
        public string? username { get; init; }
        public string? password { get; init; }
    }
}
