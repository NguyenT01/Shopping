using AutoMapper;
using Google.Protobuf.WellKnownTypes;
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

    private readonly DateTime DEFAULT_TIME = new DateTime(1, 1, 1);

    public PriceService(IRepositoryManager repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public override async Task<Empty> DeletePriceByProductId(SingleProductIdRequest request, ServerCallContext context)
    {
        Guid pid = parseGuid(request.ProductId);
        await checkProductExists(pid, true);
        var prices = await _repository.Price.GetPrices(pid, true);

        _repository.Price.DeletePriceByProductId(prices);
        await _repository.SaveAsync();

        return new Empty();
    }

    public override async Task<Empty> UpdatePrice(PriceUpdateRequest request, ServerCallContext context)
    {
        var priceEntity = await checkAndGetPrice(parseGuid(request.PriceId), true);
        _mapper.Map(request, priceEntity);
        await _repository.SaveAsync();

        return new Empty();
    }
    public override async Task<Empty> DeletePrice(PriceIdRequest request, ServerCallContext context)
    {
        var priceEntity = await checkAndGetPrice(parseGuid(request.PriceId), false);
        _repository.Price.DeletePrice(priceEntity);
        await _repository.SaveAsync();

        return new Empty();
    }
    public override async Task<PriceResponse> CreateNewPrice(PriceCreationRequest request, ServerCallContext context)
    {
        await checkProductExists(parseGuid(request.ProductId), false);

        var priceEntity = _mapper.Map<Price>(request);
        _repository.Price.CreatePrice(priceEntity);
        await _repository.SaveAsync();

        return _mapper.Map<PriceResponse>(priceEntity);
    }
    public override async Task<PriceResponse> GetCurrentPrice(SingleProductIdRequest request, ServerCallContext context)
    {
        Guid id = parseGuid(request.ProductId);
        var priceEntity = await _repository.Price.GetCurrentPrice(id, false);
        if (priceEntity is null)
        {
            priceEntity = new Price()
            {
                PriceValue = 999_999_999,
                ProductId = id,
                StartDate = DEFAULT_TIME,
                EndDate = DEFAULT_TIME,
            };
        }
        return _mapper.Map<PriceResponse>(priceEntity);
    }

    public override async Task<PriceListResponse> GetPriceByRangeTime(PriceRangeTimeRequest request, ServerCallContext context)
    {
        Guid id = parseGuid(request.ProductId);
        var priceEntities = await _repository.Price.GetPriceByRangeTime(id, false,
            request.StartDate.ToDateTime(), request.EndDate.ToDateTime());

        var priceList = _mapper.Map<IEnumerable<PriceResponse>>(priceEntities);

        var response = new PriceListResponse();
        response.PriceList.AddRange(priceList);

        return response;
    }

    public override async Task<PriceListResponse> GetHistoryPriceListOfProduct(SingleProductIdRequest request, ServerCallContext context)
    {
        Guid id = parseGuid(request.ProductId);
        var priceEntity = await _repository.Price.GetPrices(id, false);
        var priceList = _mapper.Map<IEnumerable<PriceResponse>>(priceEntity);

        var response = new PriceListResponse();
        response.PriceList.AddRange(priceList);

        return response;
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
    private async Task checkProductExists(Guid productId, bool tracking)
    {
        var productEntity = await _repository.Product.GetProduct(productId, tracking);
        if (productEntity is null)
            throw new ProductNotFoundException(productId);
    }
}
