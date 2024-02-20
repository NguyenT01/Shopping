using AutoMapper;
using MediatR;
using Shopping.API.Protos.Manager;

namespace Shopping.API.v2.Application.Commands.Product
{
    public record DeleteProductCommand : IRequest<Unit>
    {
        public Guid pid;
    }

    public class DeleteProductHandler : IRequestHandler<DeleteProductCommand, Unit>
    {
        private readonly IMapper _mapper;
        private readonly IProtosManager Protos;

        public DeleteProductHandler(IMapper mapper, IProtosManager protos)
        {
            _mapper = mapper;
            Protos = protos;
        }
        public async Task<Unit> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var productIDRequest = new SingleProductIdRequest()
            {
                ProductId = request.pid.ToString()
            };

            await Protos.Price.DeletePriceByProductIdAsync(productIDRequest);

            var productIdRequest2 = _mapper.Map<DeleteProductRequest>(productIDRequest);

            await Protos.Product.DeleteProductAsync(productIdRequest2);

            return Unit.Value;
        }
    }

}
