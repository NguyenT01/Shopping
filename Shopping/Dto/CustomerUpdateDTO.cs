using FluentValidation;

namespace Shopping.API.Dto
{
    public record CustomerUpdateDTO
    {
        public Guid CustomerId { get; init; }
        public string? FirstName { get; init; }
        public string? LastName { get; init; }
        public string? Email { get; init; }
        public string? Address { get; init; }
    }

    public class CustomerUpdateValidator : AbstractValidator<CustomerUpdateDTO>
    {
        public CustomerUpdateValidator()
        {
            RuleFor(x => x.CustomerId).NotEmpty();
        }
    }
}
