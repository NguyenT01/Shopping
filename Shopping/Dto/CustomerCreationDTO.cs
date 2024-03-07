using FluentValidation;

namespace Shopping.API.Dto
{
    public record CustomerCreationDTO
    {
        public string? FirstName { get; init; }
        public string? LastName { get; init; }
        public string? Email { get; init; }
        public string? Address { get; init; }
    }
    public class CustomerCreationValidator : AbstractValidator<CustomerCreationDTO>
    {
        public CustomerCreationValidator()
        {
            RuleFor(x => x.FirstName).NotNull();
            RuleFor(x => x.LastName).NotNull();
            RuleFor(x => x.Email).EmailAddress().NotEmpty();
            RuleFor(x => x.Address).NotEmpty();
        }
    }
}
