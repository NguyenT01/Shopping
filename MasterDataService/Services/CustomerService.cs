using AutoMapper;
using Grpc.Core;
using MasterDataService.ErrorModel;
using MasterDataService.ORM.EF.Interface;

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
    public override async Task<CustomerResponse> GetCustomerById(CustomerIdRequest request, ServerCallContext context)
    {
        Guid id;
        bool parseId = Guid.TryParse(request.CustomerId, out id);
        if (parseId == false)
            throw new IDInvalidException("ID format is not valid");

        var result = await _repository.Customer.GetCustomerAsync(Guid.Parse(request.CustomerId), request.Tracking);

        if (result is null)
            throw new CustomerNotFoundException(id);

        var customerResponse = _mapper.Map<CustomerResponse>(result);

        return customerResponse;
    }
}