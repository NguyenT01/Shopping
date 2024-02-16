using Grpc.Core;

namespace Shopping.API.ErrorModel
{
    public abstract class NotFoundException : RpcException
    {
        protected NotFoundException(string message) : base(new Status(StatusCode.NotFound, message)) { }
    }
}
