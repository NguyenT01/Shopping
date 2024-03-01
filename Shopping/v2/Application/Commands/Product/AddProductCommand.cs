using AutoMapper;
using MediatR;
using Shopping.API.Dto;

namespace Shopping.API.v2.Application.Commands.Product
{
    public class AddProductCommand : IRequest<ProductDTO>
    {
        public ProductCreationDTO? productCreationDTO;
    }

    public class AddProductHandler : IRequestHandler<AddProductCommand, ProductDTO>
    {
        private readonly IMapper _mapper;
        private readonly ProductProto.ProductProtoClient productProto;
        private readonly PriceProto.PriceProtoClient priceProto;

        public AddProductHandler(IMapper mapper, ProductProto.ProductProtoClient productProto, PriceProto.PriceProtoClient priceProto)
        {
            _mapper = mapper;
            this.productProto = productProto;
            this.priceProto = priceProto;
        }

        public async Task<ProductDTO> Handle(AddProductCommand request, CancellationToken cancellationToken)
        {
            var productRequest = _mapper.Map<AddProductRequest>(request.productCreationDTO);
            var product = await productProto.AddProductAsync(productRequest);

            request.productCreationDTO!.ProductId = Guid.Parse(product.ProductId);

            if (request.productCreationDTO.StartDate.Equals(DateTime.MinValue))
                request.productCreationDTO.StartDate = DateTime.Now;
            if (request.productCreationDTO.EndDate.Equals(DateTime.MinValue))
                request.productCreationDTO.EndDate = DateTime.MaxValue;

            var priceRequest = _mapper.Map<PriceCreationRequest>(request.productCreationDTO);
            var price = await priceProto.CreateNewPriceAsync(priceRequest);

            var productDTO = _mapper.Map<ProductDTO>(product);
            productDTO = _mapper.Map(price, productDTO);

            return productDTO;
        }
    }

}
