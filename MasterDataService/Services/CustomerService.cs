using AutoMapper;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using MasterDataService.ErrorModel;
using MasterDataService.ORM.EF.Interface;
using MasterDataService.ORM.EF.Model;
using MasterDataService.Redis;

namespace MasterDataService.Services;

public class CustomerService : CustomerProto.CustomerProtoBase
{
    private readonly ILogger<CustomerService> _logger;
    private readonly IMapper _mapper;
    private readonly IRepositoryManager _repository;
    private readonly ICacheService _cacheService;
    private readonly IConfiguration _config;
    public CustomerService(ILogger<CustomerService> logger, IMapper mapper, IRepositoryManager repository, ICacheService cache,
        IConfiguration config)
    {
        _logger = logger;
        _mapper = mapper;
        _repository = repository;
        _cacheService = cache;
        _config = config;
    }

    public override async Task<CustomerListResponse> GetCustomerList(Empty request, ServerCallContext context)
    {
        // get cache data
        var cacheData = _cacheService.GetData<IEnumerable<CustomerResponse>>(_config["RedisCacheKey"]!);

        var response = new CustomerListResponse();

        if (cacheData is not null)
        {
            response.Customers.AddRange(cacheData);
        }
        else
        {
            // set expiration time for saving caching
            var expirationTime = DateTimeOffset.Now.AddMinutes(5);

            var customersEntity = await _repository.Customer.GetAllCustomersAsync(false);
            var customers = _mapper.Map<IEnumerable<CustomerResponse>>(customersEntity);

            // set data collected to the redis cache
            _cacheService.SetData(_config["RedisCacheKey"]!, customers, expirationTime);

            response.Customers.AddRange(customers);
        }
        return response;
    }

    public override async Task<Empty> UpdateCustomer(CustomerUpdateRequest request, ServerCallContext context)
    {
        Guid id = parseToGuid(request.CustomerId);
        var customerEntity = await GetCustomerAndCheckIfExists(id, request.Tracking);

        // delete cache if a new instance updated in db. (the cache is now outdated,
        // we need to delete it in redis)
        deleteCacheIfEntityExists(customerEntity, _config["RedisCacheKey"]!);

        _mapper.Map(request, customerEntity);
        await _repository.SaveAsync();
        return new Empty();
    }

    public override async Task<Empty> DeleteCustomer(CustomerIdRequest request, ServerCallContext context)
    {
        Guid id = parseToGuid(request.CustomerId);

        var customerEntity = await GetCustomerAndCheckIfExists(id, request.Tracking);

        // delete cache if a new instance removed in db. (the cache is now outdated,
        // we need to delete it in redis)
        deleteCacheIfEntityExists(customerEntity, _config["RedisCacheKey"]!);

        _repository.Customer.DeleteCustomer(customerEntity!);
        await _repository.SaveAsync();

        return new Empty();
    }
    public override async Task<CustomerResponse> CreateCustomer(CustomerCreationRequest request, ServerCallContext context)
    {
        // delete cache if a new instance created in db. (the cache is now outdated,
        // we need to delete it in redis)
        _cacheService.RemoveData(_config["RedisCacheKey"]!);

        var customerEntity = _mapper.Map<Customer>(request);
        _repository.Customer.CreateCustomer(customerEntity);
        await _repository.SaveAsync();

        var customerReturn = _mapper.Map<CustomerResponse>(customerEntity);
        return customerReturn;
    }
    public override async Task<CustomerResponse> GetCustomerById(CustomerIdRequest request, ServerCallContext context)
    {
        // get cache data from redis
        var cacheData = _cacheService.GetData<IEnumerable<CustomerResponse>>(_config["RedisCacheKey"]!);
        if (cacheData is not null)
        {
            var filterData = cacheData.Where(cus => cus.CustomerId.Equals(request.CustomerId)).FirstOrDefault();
            if (filterData is not null)
                return filterData;
        }

        Guid id = parseToGuid(request.CustomerId);
        var result = await GetCustomerAndCheckIfExists(id, request.Tracking);
        var customerResponse = _mapper.Map<CustomerResponse>(result);

        return customerResponse;
    }

    #region Private methods
    // PRIVATE METHODS
    private async Task<Customer> GetCustomerAndCheckIfExists(Guid id, bool tracking)
    {
        var customerEntity = await _repository.Customer.GetCustomerAsync(id, tracking);

        if (customerEntity is null)
            throw new CustomerNotFoundException(id);
        return customerEntity;
    }
    private Guid parseToGuid(string id)
    {
        Guid guid;
        bool parseId = Guid.TryParse(id, out guid);
        if (!parseId)
            throw new IDInvalidException("ID format is not valid");
        return guid;
    }
    private void deleteCacheIfEntityExists(Customer? customerEntity, string cacheKey)
    {
        if (customerEntity is not null)
            _cacheService.RemoveData(cacheKey);
    }
    #endregion
}