# Sample ASP.NET Core API project with Microservices
This is a sample ASP.NET Core project that I have been working on during my self-study period😊.

It implements a simple backend for managing an online store (e-commerce).There are 4 main attributes: **Customer, Product, Order and Price**.

At the moment, there are 3 branches in this project. Each branch has its own features and also uses typical situation.
- **[main🌿](https://github.com/NguyenT01/Shopping)**: It is the main branch. It only focus on how a microservice communicates with ASP.NET Core API.
- **redis** *(You are here ⬆️)*: This branch focuses on how to use and store cache data in Redis and how to apply it in ASP.NET Core API.
- **[docker-deployment🐳](https://github.com/NguyenT01/Shopping/tree/docker-deployment)**: This branch focuses on how to deploy this project in Docker.

## Which technologies or libraries did I use for this project? 🔍
I will list in chronological order the things I have done starting from when I began this project.

- ASP.NET Core 8.0
- Entity Framework Core
- SQL Server 2022
- MediatR
- gRPC
- **Redis**

## Which resources did I learn from? 📕
Reading books is my cup of tea. Therefore, there are some books and online docs which I read during self-learning:

**For learning C# basic knowledge.**
- **[1] [C# 12 and .NET 8 – Modern Cross-Platform Development Fundamentals.](https://www.amazon.com/12-NET-Cross-Platform-Development-Fundamentals/dp/1837635870) - Mark J. Price** *(Chapter 1 - 12).*

**For learning ASP.NET Core API.**
- **[2] [Ultimate ASP.NET Core Web API - From Zero To Six-Figure Backend Developer (2nd edition).](https://code-maze.com/ultimate-aspnetcore-webapi-second-edition/) - Marinko Spasojevic**

- **[3] [ASP.NET Core in Action, 3rd Edition.](https://www.manning.com/books/asp-net-core-in-action-third-edition) - Andrew Lock**

- **[4] [gRPC on ASP.NET Core 8.0](https://learn.microsoft.com/en-us/aspnet/core/grpc/?view=aspnetcore-8.0)** (Microsoft Docs).

- **[5] [Protobuf Buffers Docs](https://protobuf.dev/)** (For learning how to use Protobuf and its variables and types).

**For learning Redis**
- **[6] [Redis Deployment](https://www.c-sharpcorner.com/article/easily-use-redis-cache-in-asp-net-6-0-web-api/) - C-sharpcorner**

- **[7] [Redis CLI Playground](https://try.redis.io/)** (For learning Redis CLI and its commands).

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

**Redis**

Run **Redis Server and its CLI** from the following steps:
- Step 1: Run (double-click) **redis-server.exe**
- Step 2: Run (double-click) **redis-cli.exe**

Please note that, Redis Server will listen to the port ```localhost:6379```.

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

Call the API: ```GET``` ```https://localhost:8888/v2/customer``` to query the list of customers.
(Using **Postman** to test this API or any equivalent programs)
After calling it successfully, the list of the customers from DB will be return to the client side.

After that, from **Redis CLI**, type these commands below:

```GET customer``` : get the list of customers from the cache.

```TTL customer``` : The time at which the customer data will be removed from the cache after the remaining time (in seconds).

You can call this API again, note that the *Response time* has been reduced due to using Reddis cache.

You can also using other APIs from Customer (or MasterData) which I definded.
- Another API to get a customer from a specific ID: 
```GET ```  ```https://localhost:8888/v2/customer/_customerId_``` 
(Replace ```_customerId_``` with an ID of the Customer you inserted from the database).

Create a new Customer:
- ```POST``` ```https://localhost:8888/v2/customer```

**Inside Body:**  
```json
{ 
    "firstName": "Johnny", 
    "lastName": "Depp", 
    "email": "example1@gmail.com", 
    "address": "Random Street, Earth" 
}
```

