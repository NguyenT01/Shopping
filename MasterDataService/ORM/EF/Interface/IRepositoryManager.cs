namespace MasterDataService.ORM.EF.Interface;

public interface IRepositoryManager
{
    ICustomerRepository Customer { get; }
    Task SaveAsync();
}
