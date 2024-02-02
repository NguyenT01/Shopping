namespace OrderingService.ORM.EF.Interface
{
    public interface IOrderingRepositoryManager
    {
        IOrderRepository Order { get; }
        IOrderItemRepository OrderItem { get; }
        Task SaveAsync();
    }
}
