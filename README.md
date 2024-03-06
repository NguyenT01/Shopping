# ASP NET CORE with Redis Cache #
## 1/ Setup ##
Make sure you have established **MSSQL Server** and also import **CurrentDBProject.sql** file from **.Archives folder** before running this project.
    - If you import this DB file unsuccessfully, you need to create a Database with its name is **Shopping**.

Afterwards, run **Redis Server and its CLI** from the following steps:
- Step 1: Run (double-click) **redis-server.exe**
- Step 2: Run (double-click) **redis-cli.exe**

## 2/ Run the project ##
Just hit **F5 button** to run this project if you are using Visual Studio.

## 3/ Testing ##
Call the API: **https://localhost:8888/v2/customer** with **GET method** to query the list of customers.
(Using **Postman** to test this API or any equivalent programs)
After calling it successfully, the list of the customers from DB will be return to the client side.

After that, from **Redis CLI**, type these commands below:
**GET customer** : get the list of customers from the cache.
**TTL customer** : The time that the customer data will be disposed of the cache after the remaining time.

You can call this API again, note that the *Response time* has been reduced due to using Reddis cache.

You can also using other APIs from Customer (or MasterData) which I definded.
- Another API to get a customer from a specific ID: *GET method*: **https://localhost:8888/v2/customer/_customerId_** (Replace **_customerId_** with an ID of the Customer you were inserted from the database).

Create a new Customer:
- *POST method* : **https://localhost:8888/v2/customer**
- *Inside Body* : 
{
    "firstName": "FirstName",
    "lastName": "LastName",
    "email": "exmaple1@gmail.com",
    "address": "Random Street, Earth"
}