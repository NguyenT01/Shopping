using FluentValidation;

namespace Shopping.API.Dto
{
    public class OrderItemDTO
    {
        public Guid? OrderId { get; set; }
        public Guid ProductId { get; init; }
        public int Quantity { get; init; }
    }
    public class OrderItemCreationDTO : OrderItemDTO { }
    public class OrderItemUpdateDTO : OrderItemCreationWithoutOrderId { }
    public class OrderItemCreationWithoutOrderId
    {
        public Guid ProductId { get; init; }
        public int Quantity { get; init; }
    }

    #region Validator
    public class OrderItemCreationWithoutOrderIdValidator : AbstractValidator<OrderItemCreationWithoutOrderId>
    {
        public OrderItemCreationWithoutOrderIdValidator()
        {
            RuleFor(x => x.ProductId).NotEmpty();
            RuleFor(x => x.Quantity).GreaterThan(0);
        }
    }
    public class OrderItemUpdateValidator : AbstractValidator<OrderItemUpdateDTO>
    {
        public OrderItemUpdateValidator()
        {
            RuleFor(x => x.ProductId).NotEmpty();
            RuleFor(x => x.Quantity).GreaterThan(0);
        }
    }

    #endregion
}
