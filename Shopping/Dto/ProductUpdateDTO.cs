using FluentValidation;

namespace Shopping.API.Dto
{
    public class ProductUpdateDTO : ProductDTO
    {

    }
    public class ProductUpdateValidator : AbstractValidator<ProductUpdateDTO>
    {
        public ProductUpdateValidator()
        {
            RuleFor(x => x.ProductId).NotEmpty();
            RuleFor(x => x.PriceValue).GreaterThan(0);
        }
    }
}
