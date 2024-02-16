using Grpc.Core;

namespace Shopping.API.ErrorModel
{
    public class IDInvalidException : RpcException
    {
        public IDInvalidException(string message) : base(new Status(StatusCode.InvalidArgument, message)) { }
    }
}
