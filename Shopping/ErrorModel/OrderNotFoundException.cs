namespace Shopping.API.ErrorModel;

public class OrderNotFoundException : NotFoundException
{
    public OrderNotFoundException(Guid id) :
        base($"OrderID {id} not found")
    { }
}
