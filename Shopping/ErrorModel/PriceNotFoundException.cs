using Shopping.API.ErrorModel;

namespace ProductService.ErrorModel;

public class PriceNotFoundException : NotFoundException
{
    public PriceNotFoundException(Guid id) :
        base($"PriceID {id} not found")
    { }
}
