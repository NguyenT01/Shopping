Console.OutputEncoding = System.Text.Encoding.UTF8;

#region Product Init
/*
var channel = GrpcChannel.ForAddress("https://localhost:7102");
var client = new ProductProto.ProductProtoClient(channel);

var IdRequest = new ProductIdRequest
{
    ProductId = "BCDA33A3-476E-40A0-B558-0C14E7C70ED0",
    Tracking = false
};

var product = new AddProductRequest
{
    Name = "Táo",
    Description = " Táo là 1 loại quả"
};

var productIdDelete = new DeleteProductRequest
{
    ProductId = "A838D111-0964-4934-7EAC-08DC213F301F"
};

var updateProduct = new UpdateProductRequest
{
    ProductId = "BCDA33A3-476E-40A0-B558-0C14E7C70ED0",
    Name = "Khoai tây"
};
*/
#endregion

#region GET MANY
/*
try
{
    var serverReplyList = await client.GetProductListAsync(new Empty());
    foreach (var serverReply in serverReplyList.Products)
    {
        Console.WriteLine($"{serverReply.ProductId} | {serverReply.Name} | {serverReply.Description}");
    }
    Console.ReadLine();
}
catch (Exception e)
{
    Console.WriteLine(e.Message);
}
*/
#endregion

#region UPDATE 1
/*
try
{
    await client.UpdateProductAsync(updateProduct);
    Console.WriteLine($"ProductID {updateProduct.ProductId} updated successfully");
    Console.ReadLine();
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
    var serverReply = await client.DeleteProductAsync(productIdDelete);
    Console.WriteLine($"ProductID {productIdDelete.ProductId} deleted successfully");
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
    var serverReply = await client.AddProductAsync(product);
    Console.WriteLine($"{serverReply.ProductId} | {serverReply.Name} | {serverReply.Description}");
    Console.ReadKey();
}
catch (Exception e)
{
    Console.WriteLine(e.Message);
}
*/
#endregion

#region GET 1
/*
try
{
    var serverReply = await client.GetProductByIdAsync(IdRequest);
    Console.WriteLine($"{serverReply.ProductId} | {serverReply.Name} | {serverReply.Description}");
}
catch (Exception e)
{
    Console.WriteLine(e.Message);
}
*/
#endregion


//--------
#region Customer Init
/*
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
*/
#endregion

#region GET MANY
/*
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
*/
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
}
*/
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