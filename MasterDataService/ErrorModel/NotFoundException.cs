using Grpc.Core;

namespace MasterDataService.ErrorModel
{
    public abstract class NotFoundException : RpcException
    {
        protected NotFoundException(string message) : base(new Status(StatusCode.NotFound, message)) { }
    }
}
