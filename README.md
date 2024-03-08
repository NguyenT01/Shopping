# Sample .NET Core API project with Microservices
This is a sample .NET Core project that I have been working on during my self-study period😊.

It implements a simple backend for managing an online store (e-commerce).There are 4 main attributes: **Customer, Product, Order and Price**.

At the moment, there are 3 branches in this project. Each branch has its own features and also uses typical situation.
- **[main🌿](https://github.com/NguyenT01/Shopping)**: It is the main branch. It only focus on how a microservice communicates with .NET Core API.
- **[redis🟥](https://github.com/NguyenT01/Shopping/tree/redis)**: This branch focuses on how to use and store cache data in Redis and how to apply it in .NET Core API.
- **docker-deployment** *(You are here ⬆️)*: This branch focuses on how to deploy this project in Docker.

## Which technologies or libraries did I use for this project? 🔍
I will list in chronological order the things I have done starting from when I began this project.

- .NET Core 8.0
- Entity Framework Core
- SQL Server 2022
- MediatR
- gRPC
- **Docker**
- **Consul by HashiCorp**

## Which resources did I learn from? 📕
Reading books is my cup of tea. Therefore, there are some books and online docs which I read during self-learning:

**For learning C# basic knowledge.**
- **[1] [C# 12 and .NET 8 – Modern Cross-Platform Development Fundamentals.](https://www.amazon.com/12-NET-Cross-Platform-Development-Fundamentals/dp/1837635870) - Mark J. Price** *(Chapter 1 - 12).*

**For learning .NET Core API.**
- **[2] [Ultimate ASP.NET Core Web API - From Zero To Six-Figure Backend Developer (2nd edition).](https://code-maze.com/ultimate-aspnetcore-webapi-second-edition/) - Marinko Spasojevic**

- **[3] [ASP.NET Core in Action, 3rd Edition.](https://www.manning.com/books/asp-net-core-in-action-third-edition) - Andrew Lock**

- **[4] [gRPC on ASP.NET Core 8.0](https://learn.microsoft.com/en-us/aspnet/core/grpc/?view=aspnetcore-8.0)** (Microsoft Docs).

- **[5] [Protobuf Buffers Docs](https://protobuf.dev/)** (For learning how to use Protobuf and its variables and types).

**For learning Docker and Consul**
- **[6] [Docker with ASP.NET](https://learn.microsoft.com/vi-vn/aspnet/core/host-and-deploy/docker/building-net-docker-images?view=aspnetcore-1.1)** *(Microsoft Docs).*
- **[7] [Containerize a .NET app](https://learn.microsoft.com/en-us/dotnet/core/docker/build-container?tabs=windows&pivots=dotnet-8-0)** *(Microsoft Docs).*
- **[8] [Docker Official Docs](https://docs.docker.com/get-started/overview/)**
- **[9] [Consul with .NET](https://www.linkedin.com/pulse/using-consul-net-core-microservice-architecture-sepehr-safaei)**
- **[10] [Consul in .NET - A service mesh solution](https://medium.com/@KeivanDamirchi/consul-in-net-a-service-mesh-solution-and-service-discovery-tool-eff18292c771)**
- **[11] [Usage of Consul in .NET Core](https://dev.to/engincanv/usage-of-consul-in-net-core-configuration-management-39h5)**


## How to run this project? 🚀
### 1. Setup environments 🦖
**.NET Core**
- Download and Install [Visual Studio.](https://visualstudio.microsoft.com/downloads/)
- Open Visual Studio Installer, in Installed tab, click Modify button.
- In **Workloads tab**, Select (tick) ASP.NET and web development and .NET Desktop Development.
- In **Individual components tab**, Select (tick) .NET 6.0 and .NET 8.0 Runtime
- Finally, Click **Modify** button at the bottom of the dialog.

**Docker 🐳**
- Download **[Docker Desktop](https://docs.docker.com/desktop/install/windows-install/)**.
- You need to select **WSL 2** feature if you are using Windows. 

**Postman ✒️**
- In this project, I use [Postman✒️](https://www.postman.com/downloads/) to test APIs.

**SQL Server**
In progress

### 2. Run the project ▶️
In progress

### 3. Test the project 🧪
In progress
