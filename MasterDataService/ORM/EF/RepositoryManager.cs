using MasterDataService.ORM.EF.Interface;

namespace MasterDataService.ORM.EF;

public class RepositoryManager : IRepositoryManager
{
    private readonly MasterDataRepositoryContext _repositoryContext;
    private readonly ICustomerRepository _customerRepository;

    public RepositoryManager(MasterDataRepositoryContext context)
    {
        _repositoryContext = context;
        _customerRepository = new CustomerRepository(context);
    }

    public ICustomerRepository Customer => _customerRepository;

    public async Task SaveAsync()
        => await _repositoryContext.SaveChangesAsync();
}
