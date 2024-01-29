
using Google.Protobuf.WellKnownTypes;
using Grpc.Net.Client;
using gRPCTesting;

var id = new CustomerIdRequest
{
    CustomerId = "41D1726C-86F0-4C8C-B715-5CB5ED6E238C",
    Tracking = false
};

var channel = GrpcChannel.ForAddress("https://localhost:7101");
var client = new CustomerProto.CustomerProtoClient(channel);

var customer = new CustomerCreationRequest
{
    Address = "727 South East Street, AU 22108",
    Email = "example22@gmail.com",
    FirstName = "Duong",
    LastName = "Qua"
};

var customerUpdate = new CustomerUpdateRequest
{
    CustomerId = "A941BF44-4232-4FE8-D295-08DC207203E0",
    Address = "666 Hang Bai HN",
    Email = "pltk453@gmail.com",
    Tracking = true
};

#region GET MANY
try
{
    var response = await client.GetCustomerListAsync(new Empty());
    foreach (var c in response.Customers)
    {
        Console.WriteLine($"{c.CustomerId} | {c.FirstName} | {c.LastName} |" +
            $"{c.Address} | {c.Email}");
    }
    Console.ReadLine();
}
catch (Exception e)
{
    Console.WriteLine(e.Message);
}
#endregion

#region UPDATE 1
/*
try
{
    await client.UpdateCustomerAsync(customerUpdate);
    Console.WriteLine(id.CustomerId + " update sucessfully");
    Console.ReadKey();
}
catch (Exception e)
{
    Console.WriteLine(e.Message);
}
*/
#endregion

#region DELETE 1
/*
try
{
    var serverReply = await client.DeleteCustomerAsync(id);
    Console.WriteLine(id.CustomerId + " delete sucessfully");
    Console.ReadKey();
}
catch (Exception e)
{
    Console.WriteLine(e.Message);
}
*/

#endregion

#region CREATE 1
/*
try
{
    var serverReply = client.CreateCustomer(customer);
    Console.WriteLine($"{serverReply.CustomerId} | {serverReply.FirstName} | {serverReply.LastName}" +
       $"{serverReply.Address} | {serverReply.Email}");
    Console.ReadLine();
}
catch (Exception e)
{
    Console.WriteLine(e.Message);
}*/
#endregion

#region GET 1
/*try
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
}*/
#endregion