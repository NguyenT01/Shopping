using FluentValidation;

namespace Shopping.API.Dto
{
    public class OrderCreationDTO
    {
        public Guid CustomerId { get; init; }
        public IEnumerable<OrderItemCreationWithoutOrderId>? Items { get; set; }

    }

    public class OrderCreationValidator : AbstractValidator<OrderCreationDTO>
    {
        public OrderCreationValidator()
        {
            RuleFor(x => x.CustomerId).NotEmpty();
            RuleFor(x => x.Items).NotEmpty()
                .WithMessage("Items attribute cannot empty. Each order must have at least 1 item");

            RuleForEach(x => x.Items)
                .ChildRules(child =>
                {
                    child.RuleFor(childAtt => childAtt.ProductId).NotNull();
                    child.RuleFor(childAtt => childAtt.Quantity).GreaterThan(0);
                });
        }
    }
}
