namespace ProductServiceNamespace.ErrorModel;

public class PriceNotFoundException : NotFoundException
{
    public PriceNotFoundException(Guid id) :
        base($"PriceID {id} not found")
    { }
}
