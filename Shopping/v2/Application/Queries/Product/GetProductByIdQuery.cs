using AutoMapper;
using MediatR;
using Shopping.API.Dto;
using Shopping.API.Protos.Manager;

namespace Shopping.API.v2.Application.Queries.Product
{
    public class GetProductByIdQuery : IRequest<ProductDTO>
    {
        public Guid pid;
    }

    public class GetProductByIdHandler : IRequestHandler<GetProductByIdQuery, ProductDTO>
    {
        private readonly IMapper _mapper;
        private readonly IProtosManager Protos;

        public GetProductByIdHandler(IMapper mapper, IProtosManager protos)
        {
            _mapper = mapper;
            Protos = protos;
        }

        public async Task<ProductDTO> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            var productId = new ProductIdRequest()
            {
                ProductId = request.pid.ToString(),
                Tracking = false
            };

            var product = await Protos.Product.GetProductByIdAsync(productId);
            var price = await Protos.Price.GetCurrentPriceAsync(_mapper.Map<SingleProductIdRequest>(productId));

            var productDTO = _mapper.Map<ProductResponse, ProductDTO>(product);
            productDTO = _mapper.Map(price, productDTO);

            return productDTO;
        }
    }
}
