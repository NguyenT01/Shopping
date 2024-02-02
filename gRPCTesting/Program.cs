using Grpc.Net.Client;
using gRPCTestings;

Console.OutputEncoding = System.Text.Encoding.UTF8;

#region GET 1 ORDER ITEM
/*
var channel = GrpcChannel.ForAddress("https://localhost:7103");
var client = new OrderItemProto.OrderItemProtoClient(channel);

var orderRequest = new GetItemRequest
{
    OrderId = "4C91274B-25A6-4F76-9E5E-AA4C07623052",
    ProductId = "BCDA33A3-476E-40A0-B558-0C14E7C70ED0"
};

try
{
    var serverReply = await client.GetItemAsync(orderRequest);
    Console.WriteLine($"{serverReply.OrderId} | {serverReply.ProductId} | {serverReply.Quantity}");
    Console.ReadKey();
}
catch (Exception e)
{
    Console.WriteLine(e.Message);
    Console.ReadKey();
}
*/
#endregion

#region GET ITEM LIST FROM 1 ORDER
/*
var channel = GrpcChannel.ForAddress("https://localhost:7103");
var client = new OrderItemProto.OrderItemProtoClient(channel);

var orderItemRequest = new OrderItemIdRequest
{
    OrderId = "4C91274B-25A6-4F76-9E5E-AA4C07623052",
};

try
{
    var serverReplies = await client.GetItemsFromOrderAsync(orderItemRequest);
    foreach (var serverReply in serverReplies.Items)
    {
        Console.WriteLine($"{serverReply.OrderId} | {serverReply.ProductId} | {serverReply.Quantity}");

    }
    Console.ReadKey();
}
catch (Exception e)
{
    Console.WriteLine(e.Message);
    Console.ReadKey();
}
*/
#endregion

#region ADD 1
/*
var channel = GrpcChannel.ForAddress("https://localhost:7103");
var client = new OrderItemProto.OrderItemProtoClient(channel);

var orderItemRequest = new OrderItemCreationRequest
{
    OrderId = "4C91274B-25A6-4F76-9E5E-AA4C07623052",
    ProductId = "DE2018FD-4E94-4A9C-83F4-E41B5114064C",
    Quantity = 55
};

try
{
    var serverReply = await client.CreateOrderItemAsync(orderItemRequest);

    Console.WriteLine($"{serverReply.OrderId} has been created");
    Console.ReadKey();
}
catch (Exception e)
{
    Console.WriteLine(e.Message);
    Console.ReadKey();
}
*/
#endregion

#region DELETE 1
/*
var channel = GrpcChannel.ForAddress("https://localhost:7103");
var client = new OrderItemProto.OrderItemProtoClient(channel);

var itemDeletRequest = new OrderItemDeletionRequest
{
    OrderId = "4C91274B-25A6-4F76-9E5E-AA4C07623052",
    ProductId = "DE2018FD-4E94-4A9C-83F4-E41B5114064C"
};

try
{
    var serverReply = await client.DeleteOrderItemAsync(itemDeletRequest);

    Console.WriteLine($"{itemDeletRequest.OrderId} - {itemDeletRequest.OrderId} has been delete");
    Console.ReadKey();
}
catch (Exception e)
{
    Console.WriteLine(e.Message);
    Console.ReadKey();
}
*/
#endregion

#region UPDATE 1
/*
var channel = GrpcChannel.ForAddress("https://localhost:7103");
var client = new OrderItemProto.OrderItemProtoClient(channel);

var itemUpdate = new OrderItemUpdateRequest
{
    OrderId = "4C91274B-25A6-4F76-9E5E-AA4C07623052",
    ProductId = "BCDA33A3-476E-40A0-B558-0C14E7C70ED0",
    Quantity = 13
};

try
{
    var serverReply = await client.UpdateOrderItemAsync(itemUpdate);

    Console.WriteLine($"{itemUpdate.OrderId} - {itemUpdate.OrderId} has been updated");
    Console.ReadKey();
}
catch (Exception e)
{
    Console.WriteLine(e.Message);
    Console.ReadKey();
}
*/
#endregion

#region INCREASE QUANTITY BY 1
/*
var channel = GrpcChannel.ForAddress("https://localhost:7103");
var client = new OrderItemProto.OrderItemProtoClient(channel);

var itemUpdateBy1 = new ItemRequest
{
    OrderId = "4C91274B-25A6-4F76-9E5E-AA4C07623052",
    ProductId = "BCDA33A3-476E-40A0-B558-0C14E7C70ED0"
};

try
{
    var serverReply = await client.IncreaseQuantityOrderItemBy1Async(itemUpdateBy1);

    Console.WriteLine($"{serverReply.OrderId} | {serverReply.ProductId} | {serverReply.Quantity}");
    Console.ReadKey();
}
catch (Exception e)
{
    Console.WriteLine(e.Message);
    Console.ReadKey();
}
*/
#endregion

#region DECREASE QUANTITY BY 1
var channel = GrpcChannel.ForAddress("https://localhost:7103");
var client = new OrderItemProto.OrderItemProtoClient(channel);

var itemUpdateBy1 = new ItemRequest
{
    OrderId = "4C91274B-25A6-4F76-9E5E-AA4C07623052",
    ProductId = "E2A85F91-DDAB-427D-91EB-4C8C74A487FF"
};

try
{
    var serverReply = await client.DecreaseQuantityOrderItemBy1Async(itemUpdateBy1);

    if (serverReply.IsNull)
        Console.WriteLine($"{itemUpdateBy1.OrderId} | {itemUpdateBy1.ProductId} has been deleted");
    else
        Console.WriteLine($"{serverReply.OrderId} | {serverReply.ProductId} | {serverReply.Quantity}");

    Console.ReadKey();
}
catch (Exception e)
{
    Console.WriteLine(e.Message);
    Console.ReadKey();
}

#endregion
//GetItemsFromOrder

//------------
#region GET 1 ORDER
/*
var channel = GrpcChannel.ForAddress("https://localhost:7103");
var client = new OrderProto.OrderProtoClient(channel);

var orderRequest = new OrderIdRequest
{
    OrderId = "4C91274B-25A6-4F76-9E5E-AA4C07623052"
};

try
{
    var serverReply = await client.GetOrderAsync(orderRequest);
    Console.WriteLine($"{serverReply.OrderId} | {serverReply.CustomerId} | {serverReply.OrderDate}");
    Console.ReadKey();
}
catch (Exception e)
{
    Console.WriteLine(e.Message);
    Console.ReadKey();
}
*/
#endregion

#region GET ORDER LIST
/*
var channel = GrpcChannel.ForAddress("https://localhost:7103");
var client = new OrderProto.OrderProtoClient(channel);
var cusId = new OrderCustomerIdRequest
{
    CustomerId = "A941BF44-4232-4FE8-D295-08DC207203E0"
};

try
{
    var serverLs = await client.GetOrdersAsync(cusId);
    foreach (var serverReply in serverLs.Orders)
    {
        Console.WriteLine($"{serverReply.OrderId} | {serverReply.CustomerId} | {serverReply.OrderDate}");
    }
    Console.ReadLine();
}
catch (Exception e)
{
    Console.WriteLine(e);
    Console.ReadKey();
}
*/
#endregion

#region CREATE ORDER
/*
var channel = GrpcChannel.ForAddress("https://localhost:7103");
var client = new OrderProto.OrderProtoClient(channel);

var orderCreate = new OrderCreationRequest
{
    CustomerId = "A941BF44-4232-4FE8-D295-08DC207203E0",
    OrderDate = Timestamp.FromDateTime(new DateTime(2024, 2, 2, 16, 54, 44, 22, DateTimeKind.Utc))
};

try
{
    var serverReply = await client.CreateOrderAsync(orderCreate);
    Console.WriteLine($"{serverReply.OrderId} has been created");
    Console.ReadKey();
}
catch (Exception e)
{
    Console.WriteLine(e.Message);
    Console.ReadKey();
}
*/
#endregion

#region DELETE ORDER
/*
var channel = GrpcChannel.ForAddress("https://localhost:7103");
var client = new OrderProto.OrderProtoClient(channel);

var orderRequest = new OrderIdRequest
{
    OrderId = "E9D79C67-F13F-4B33-8FF5-AE2AB42A401E"
};

try
{
    var serverReply = await client.DeleteOrderAsync(orderRequest);
    Console.WriteLine($"{orderRequest.OrderId} deleted successfully");
    Console.ReadKey();
}
catch (Exception e)
{
    Console.WriteLine(e.Message);
    Console.ReadKey();
}
*/
#endregion

#region UPDATE ORDER
/*
var channel = GrpcChannel.ForAddress("https://localhost:7103");
var client = new OrderProto.OrderProtoClient(channel);
var itemPrice = new OrderUpdateRequest
{
    OrderId = "4C91274B-25A6-4F76-9E5E-AA4C07623052",
    OrderDate = Timestamp.FromDateTime(new DateTime(2024, 02, 4, 7, 7, 7, 252, DateTimeKind.Utc))
};
try
{
    var serverReply = await client.UpdateOrderAsync(itemPrice);
    Console.WriteLine($"{itemPrice.OrderId} has been updated");
    Console.ReadLine();
}
catch (Exception e)
{
    Console.WriteLine(e);
    Console.ReadLine();
}
*/
#endregion

//--------------
#region GET 1 BY PRICE ID
/*
var priceId = new PriceIdRequest
{
    PriceId = "58000B10-9F32-44BF-B93D-DDEB22D991A9"
};

var channel = GrpcChannel.ForAddress("https://localhost:7102");
var client = new PriceProto.PriceProtoClient(channel);

try
{
    var serverReply = await client.GetPriceAsync(priceId);
    Console.WriteLine($"{serverReply.PriceId} | {serverReply.ProductId} | {serverReply.PriceValue} " +
        $"| {serverReply.StartDate} | {serverReply.EndDate}");
    Console.WriteLine(serverReply.StartDate.ToDateTime());
    Console.ReadKey();
}
catch (Exception e)
{
    Console.WriteLine(e.Message);
}
*/

#endregion

#region GET PREVIOUS PRICE LIST
/*
var channel = GrpcChannel.ForAddress("https://localhost:7102");
var client = new PriceProto.PriceProtoClient(channel);

var productId = new SingleProductIdRequest
{
    ProductId = "BCDA33A3-476E-40A0-B558-0C14E7C70ED0"
};

try
{
    var serverReplyLs = await client.GetHistoryPriceListOfProductAsync(productId);
    foreach (var serverReply in serverReplyLs.PriceList)
    {
        Console.WriteLine($"{serverReply.PriceId} | {serverReply.ProductId} | {serverReply.PriceValue} " +
        $"| {serverReply.StartDate} | {serverReply.EndDate}");
        Console.WriteLine("--> " + serverReply.StartDate.ToDateTime());
    }
    Console.ReadKey();
}
catch (Exception e)
{
    Console.WriteLine(e);
    Console.ReadKey();
}
*/
#endregion

#region GET PRICE BY RANGE TIME
/*
var channel = GrpcChannel.ForAddress("https://localhost:7102");
var client = new PriceProto.PriceProtoClient(channel);
var rangeRequest = new PriceRangeTimeRequest
{
    ProductId = "BCDA33A3-476E-40A0-B558-0C14E7C70ED0",
    StartDate = Timestamp.FromDateTime(new DateTime(2024, 1, 31, 19, 9, 9, 9, DateTimeKind.Utc)),
    EndDate = Timestamp.FromDateTime(new DateTime(2024, 2, 4, 8, 7, 14, 22, DateTimeKind.Utc))
};

try
{
    var ls = await client.GetPriceByRangeTimeAsync(rangeRequest);
    Console.WriteLine(rangeRequest.StartDate);
    Console.WriteLine(rangeRequest.EndDate);
    Console.WriteLine(rangeRequest.StartDate.ToDateTime());
    Console.WriteLine(rangeRequest.EndDate.ToDateTime());
    foreach (var serverReply in ls.PriceList)
    {
        Console.WriteLine($"{serverReply.PriceId} | {serverReply.ProductId} | {serverReply.PriceValue} " +
        $"| {serverReply.StartDate} | {serverReply.EndDate}");
        Console.WriteLine("--> " + serverReply.StartDate.ToDateTime());
    }

    Console.ReadLine();
}
catch (Exception e)
{
    Console.WriteLine(e);
    Console.ReadLine();
}
*/
#endregion

#region GET CURRENT PRICE
/*
var channel = GrpcChannel.ForAddress("https://localhost:7102");
var client = new PriceProto.PriceProtoClient(channel);
var ProductIdRes = new SingleProductIdRequest
{
    ProductId = "BCDA33A3-476E-40A0-B558-0C14E7C70ED0"
};

try
{
    Console.WriteLine(DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Utc));
    var serverReply = await client.GetCurrentPriceAsync(ProductIdRes);
    Console.WriteLine($"{serverReply.PriceId} | {serverReply.ProductId} | {serverReply.PriceValue} " +
        $"| {serverReply.StartDate} | {serverReply.EndDate}");
    Console.ReadLine();
}
catch (Exception e)
{
    Console.WriteLine(e);
    Console.ReadLine();
}
*/
#endregion

#region CREATE PRICE
/*
var channel = GrpcChannel.ForAddress("https://localhost:7102");
var client = new PriceProto.PriceProtoClient(channel);

var itemPrice = new PriceCreationRequest
{
    ProductId = "BCDA33A3-476E-40A0-B558-0C14E7C70ED0",
    PriceValue = 312.5,
    StartDate = Timestamp.FromDateTime(new DateTime(2024, 02, 02, 4, 4, 4, 222, DateTimeKind.Utc)),
    EndDate = Timestamp.FromDateTime(new DateTime(2024, 03, 17, 5, 13, 24, 456, DateTimeKind.Utc))
};

try
{
    var serverReply = await client.CreateNewPriceAsync(itemPrice);
    Console.WriteLine($"{serverReply.PriceId} | {serverReply.ProductId} | {serverReply.PriceValue} " +
    $"| {serverReply.StartDate} | {serverReply.EndDate}");
    Console.WriteLine(serverReply.StartDate.ToDateTime());
    Console.ReadKey();
}
catch (Exception e)
{
    Console.WriteLine(e);
    Console.ReadLine();
}
*/
#endregion

#region DELETE PRICE
/*
var priceId = new PriceIdRequest
{
    PriceId = "58000B10-9F32-44BF-B93D-DDEB22D991A9"
};

var channel = GrpcChannel.ForAddress("https://localhost:7102");
var client = new PriceProto.PriceProtoClient(channel);

try
{
    var serverReply = client.DeletePrice(priceId);
    Console.WriteLine($"{priceId.PriceId} has been deleted");
    Console.ReadLine();
}
catch (Exception e)
{
    Console.WriteLine(e);
    Console.ReadLine();
}
*/
#endregion

#region UPDATE PRICE
/*
var channel = GrpcChannel.ForAddress("https://localhost:7102");
var client = new PriceProto.PriceProtoClient(channel);
var itemPrice = new PriceUpdateRequest
{
    PriceId = "37F4CE4B-3365-41C9-B994-B1A5DF23EC4E",
    PriceValue = 377.81,
    EndDate = Timestamp.FromDateTime(new DateTime(2024, 02, 26, 8, 8, 8, 456, DateTimeKind.Utc))
};
try
{
    var serverReply = await client.UpdatePriceAsync(itemPrice);
    Console.WriteLine($"{itemPrice.PriceId} has been updated");
    Console.ReadLine();
}
catch (Exception e)
{
    Console.WriteLine(e);
    Console.ReadLine();
}
*/
#endregion

// -----------
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