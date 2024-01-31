using AutoMapper;
using Grpc.Core;
using ProductServiceNamespace.ErrorModel;
using ProductServiceNamespace.ORM.EF.Interface;
using ProductServiceNamespace.ORM.EF.Model;
using ProductServiceNamespace.Protos;

namespace ProductServiceNamespace.Services;

public class PriceService : PriceProto.PriceProtoBase
{
    private readonly IRepositoryManager _repository;
    private readonly IMapper _mapper;

    public PriceService(IRepositoryManager repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public override async Task<PriceListResponse> GetHistoryPriceListOfProduct(SingleProductIdRequest request, ServerCallContext context)
    {
        Guid id = parseGuid(request.ProductId);
        var priceEntity = await _repository.Price.GetPrices(id, false);
        // add mapper

        return null;
    }

    public override async Task<PriceResponse> GetPrice(PriceIdRequest request, ServerCallContext context)
    {
        Guid pid = parseGuid(request.PriceId);
        var priceEntity = await checkAndGetPrice(pid, false);
        var priceReturn = _mapper.Map<PriceResponse>(priceEntity);
        return priceReturn;
    }



    // PRIVATE METHODS
    private Guid parseGuid(string id)
    {
        Guid guid;
        if (!Guid.TryParse(id, out guid))
        {
            throw new IDInvalidException("ID format is not valid");
        }
        return guid;
    }
    private async Task<Price> checkAndGetPrice(Guid priceId, bool tracking)
    {
        var priceEntity = await _repository.Price.GetPrice(priceId, tracking);
        if (priceEntity is null)
            throw new PriceNotFoundException(priceId);
        return priceEntity;
    }
}
