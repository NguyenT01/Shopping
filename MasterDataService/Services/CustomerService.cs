using AutoMapper;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using MasterDataService.ErrorModel;
using MasterDataService.ORM.EF.Interface;
using MasterDataService.ORM.EF.Model;

namespace MasterDataService.Services;

public class CustomerService : CustomerProto.CustomerProtoBase
{
    private readonly ILogger<CustomerService> _logger;
    private readonly IMapper _mapper;
    private readonly IRepositoryManager _repository;
    public CustomerService(ILogger<CustomerService> logger, IMapper mapper, IRepositoryManager repository)
    {
        _logger = logger;
        _mapper = mapper;
        _repository = repository;
    }

    public override async Task<CustomerListResponse> GetCustomerList(Empty request, ServerCallContext context)
    {
        var customersEntity = await _repository.Customer.GetAllCustomersAsync(false);
        var customers = _mapper.Map<IEnumerable<CustomerResponse>>(customersEntity);

        var response = new CustomerListResponse();
        response.Customers.AddRange(customers);
        return response;
    }

    public override async Task<Empty> UpdateCustomer(CustomerUpdateRequest request, ServerCallContext context)
    {
        Guid id = parseToGuid(request.CustomerId);
        var customerEntity = await GetCustomerAndCheckIfExists(id, request.Tracking);
        _mapper.Map(request, customerEntity);
        await _repository.SaveAsync();
        return new Empty();
    }

    public override async Task<Empty> DeleteCustomer(CustomerIdRequest request, ServerCallContext context)
    {
        Guid id = parseToGuid(request.CustomerId);

        var customerEntity = await GetCustomerAndCheckIfExists(id, request.Tracking);

        _repository.Customer.DeleteCustomer(customerEntity);
        await _repository.SaveAsync();

        return new Empty();
    }
    public override async Task<CustomerResponse> CreateCustomer(CustomerCreationRequest request, ServerCallContext context)
    {
        var customerEntity = _mapper.Map<Customer>(request);
        _repository.Customer.CreateCustomer(customerEntity);
        await _repository.SaveAsync();

        var customerReturn = _mapper.Map<CustomerResponse>(customerEntity);
        return customerReturn;
    }
    public override async Task<CustomerResponse> GetCustomerById(CustomerIdRequest request, ServerCallContext context)
    {
        Guid id = parseToGuid(request.CustomerId);

        var result = await GetCustomerAndCheckIfExists(id, request.Tracking);

        var customerResponse = _mapper.Map<CustomerResponse>(result);

        return customerResponse;
    }

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
}