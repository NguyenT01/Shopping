
using Grpc.Net.Client;
using gRPCTesting;
using MasterDataService.ErrorModel;

var id = new CustomerIdRequest
{
    CustomerId = "41D1726C-86F0-4C8C-B715-5CB5ED6E238C",
    Tracking = false
};

var channel = GrpcChannel.ForAddress("https://localhost:7101");
var client = new CustomerProto.CustomerProtoClient(channel);
try
{
    var serverReply = await client.GetCustomerByIdAsync(id);
    Console.WriteLine($"{serverReply.CustomerId} | {serverReply.FirstName} | {serverReply.LastName}" +
        $"{serverReply.Address} | {serverReply.Email}");
    Console.ReadLine();
}
catch (CustomerNotFoundException ce)
{
    Console.WriteLine(ce.Message);
    Console.ReadLine();
}
