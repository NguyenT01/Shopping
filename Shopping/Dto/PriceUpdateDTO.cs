using FluentValidation;

namespace Shopping.API.Dto
{
    public class PriceUpdateDTO
    {
        public Guid? PriceId { get; set; }
        public double PriceValue { get; init; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }

    public class PriceUpdateValidator : AbstractValidator<PriceUpdateDTO>
    {
        public PriceUpdateValidator()
        {
            RuleFor(x => x.PriceId).NotEmpty();
            RuleFor(x => x.PriceValue).GreaterThan(0);
        }
    }
}
