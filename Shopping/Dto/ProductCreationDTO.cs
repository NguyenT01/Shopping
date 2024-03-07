using FluentValidation;

namespace Shopping.API.Dto
{
    public record ProductCreationDTO : PriceCreationDTO
    {
        public string? Name { get; init; }
        public string? Description { get; init; }
    }

    public class ProductCreationValidator : AbstractValidator<ProductCreationDTO>
    {
        public ProductCreationValidator()
        {
            RuleFor(x => x.Name).NotNull().Length(1, 25);
            RuleFor(x => x.Description).NotNull();
            RuleFor(x => x.PriceValue).GreaterThan(0);
        }
    }
}
