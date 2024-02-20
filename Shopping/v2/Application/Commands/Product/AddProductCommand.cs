using AutoMapper;
using MediatR;
using Shopping.API.Dto;
using Shopping.API.Protos.Manager;

namespace Shopping.API.v2.Application.Commands.Product
{
    public class AddProductCommand : IRequest<ProductDTO>
    {
        public ProductCreationDTO? productCreationDTO;
    }

    public class AddProductHandler : IRequestHandler<AddProductCommand, ProductDTO>
    {
        private readonly IMapper _mapper;
        private readonly IProtosManager Protos;

        public AddProductHandler(IMapper mapper, IProtosManager protos)
        {
            _mapper = mapper;
            Protos = protos;
        }

        public async Task<ProductDTO> Handle(AddProductCommand request, CancellationToken cancellationToken)
        {
            var productRequest = _mapper.Map<AddProductRequest>(request.productCreationDTO);
            var product = await Protos.Product.AddProductAsync(productRequest);

            request.productCreationDTO!.ProductId = Guid.Parse(product.ProductId);

            if (request.productCreationDTO.StartDate.Equals(DateTime.MinValue))
                request.productCreationDTO.StartDate = DateTime.Now;
            if (request.productCreationDTO.EndDate.Equals(DateTime.MinValue))
                request.productCreationDTO.EndDate = DateTime.MaxValue;

            var priceRequest = _mapper.Map<PriceCreationRequest>(request.productCreationDTO);
            var price = await Protos.Price.CreateNewPriceAsync(priceRequest);

            var productDTO = _mapper.Map<ProductDTO>(product);
            productDTO = _mapper.Map(price, productDTO);

            return productDTO;
        }
    }

}
