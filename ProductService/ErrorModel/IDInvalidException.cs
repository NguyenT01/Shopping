using Grpc.Core;

namespace ProductServiceNamespace.ErrorModel
{
    public class IDInvalidException : RpcException
    {
        public IDInvalidException(string message) : base(new Status(StatusCode.InvalidArgument, message)) { }
    }
}
