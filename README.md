# Sample ASP.NET Core API project with Microservices
This is a sample ASP.NET Core project that I have been working on during my self-study period😊.

It implements a simple backend for managing an online store (e-commerce).There are 4 main attributes: **Customer, Product, Order and Price**.

At the moment, there are 3 branches in this project. Each branch has its own features and also uses typical situation.
- **main**: *(You are here ⬆️)*. It is the main branch. It only focus on how a microservice communicates with ASP.NET Core API.
- **[redis🟥](https://github.com/NguyenT01/Shopping/tree/redis)**: This branch focuses on how to use and store cache data in Redis and how to apply it in ASP.NET Core API.
- **[docker-deployment🐳](https://github.com/NguyenT01/Shopping/tree/docker-deployment)**: This branch focuses on how to deploy this project in Docker.

## Which technologies or libraries did I use for this project? 🔍
I will list in chronological order the things I have done starting from when I began this project.

- ASP.NET Core 8.0
- Entity Framework Core
- SQL Server 2022
- MediatR
- gRPC
- FluentValidation

## Which resources did I learn from? 📕
Reading books is my cup of tea. Therefore, there are some books and online docs which I read during self-learning:

For learning C# basic knowledge.
- **[1] [C# 12 and .NET 8 – Modern Cross-Platform Development Fundamentals.](https://www.amazon.com/12-NET-Cross-Platform-Development-Fundamentals/dp/1837635870) - Mark J. Price** *(Chapter 1 - 12).*

For learning ASP.NET Core API.
- **[2] [Ultimate ASP.NET Core Web API - From Zero To Six-Figure Backend Developer (2nd edition).](https://code-maze.com/ultimate-aspnetcore-webapi-second-edition/) - Marinko Spasojevic**

- **[3] [ASP.NET Core in Action, 3rd Edition.](https://www.manning.com/books/asp-net-core-in-action-third-edition) - Andrew Lock**

- **[4] [gRPC on ASP.NET Core 8.0](https://learn.microsoft.com/en-us/aspnet/core/grpc/?view=aspnetcore-8.0)** (Microsoft Docs).

- **[5] [Protobuf Buffers Docs](https://protobuf.dev/)** (For learning how to use Protobuf and its variables and types).

- **[6] [FluentValidation Docs](https://docs.fluentvalidation.net/en/latest/aspnet.html)**

## How to run this project? 🚀
### 1. Setup environments 🦖
**ASP.NET Core**
- Download and Install [Visual Studio.](https://visualstudio.microsoft.com/downloads/)
- Open Visual Studio Installer, in Installed tab, click Modify button.
- In **Workloads tab**, Select (tick) ASP.NET and web development and .NET Desktop Development.
- In **Individual components tab**, Select (tick) .NET 6.0 and .NET 8.0 Runtime
- Finally, Click **Modify** button at the bottom of the dialog.

**SQL Server**
- Download and install [SQL Server Express.](https://www.microsoft.com/en-us/sql-server/sql-server-downloads)
- Download and install [SQL Server Management Studio - SSMS](https://learn.microsoft.com/en-us/sql/ssms/download-sql-server-management-studio-ssms?view=sql-server-ver16).

- Open SSMS and import Database structure in this project from ***.Archives/CurrentDBProject.sql*** (inside .Archives Folder).

- You need to add some sample data by using SQL Command 
``INSERT INTO _TABLE_NAME VALUES (value1, value2, value3, ...)`` in SSMS.
- If you don't know how to use SQL Command, just learn from [this](https://www.w3schools.com/sql/sql_syntax.asp).

**Postman**
- In this project, I use [Postman✒️](https://www.postman.com/downloads/) to test APIs.

### 2. Run the project ▶️
- Open Visual Studio and open this project.
- Click **Run ▶ button** or hit **F5 button** to run this project.
- You will be see 4 terminals appear while running this project.

To provide more detailed explanation, there are 4 projects running simultaneously and they are:
- **MasterDataService**: Listen to the port ``localhost:7101``. It will be used to provide Customer data to the client.
- **ProductService**: Listen to the port ``localhost:7102``. It will be used to provide Product and Price data to the client.
- **OrderService**: Listen to the port ``localhost:7103``. It will be used to provide Order and OrderItem data to the client.
- **Shopping.API**: Listen to the port ``https://localhost:8888``. It will be used to get Request and return Response to the client. Furthermore, it plays a key role in communicating with 3 services above.

### 3. Test the project 🧪
You can test the APIs by using **Postman✒️**.
Here are some sample APIs that you can test with:
- ```GET``` ```https://localhost:8888/v2/customer```: Get a list of the Customers in the database.
- ```GET``` ```https://localhost:8888/v2/customer/_customerID_```: Retrieve Customer information based on their ID.
- ```GET``` ```https://localhost:8888/v2/product```: Get a list of the Products in the database.
- ```POST``` ```https://localhost:8888/v2/customer```: Create a new Customer. 
Inside the **body of the request**, you need to provide the following information:
```json
{ 
    "firstName": "Johnny", 
    "lastName": "Depp", 
    "email": "example1@gmail.com", 
    "address": "Random Street, Earth" 
}
```
- Moreover, ```Shopping.API``` project has a multitude of APIs waiting to be discovered. You can explore them by locating the ```Controller``` files in either the ```v1``` and ```v2``` folders. 🎁⛏️
