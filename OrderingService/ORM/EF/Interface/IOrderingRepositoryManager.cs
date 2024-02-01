namespace OrderingService.ORM.EF.Interface
{
    public interface IOrderingRepositoryManager
    {
        IOrderRepository Order { get; }
        Task SaveAsync();
    }
}
