using Grpc.Core;

namespace MasterDataService.ErrorModel
{
    public class IDInvalidException : RpcException
    {
        public IDInvalidException(string message) : base(new Status(StatusCode.InvalidArgument, message)) { }
    }
}
