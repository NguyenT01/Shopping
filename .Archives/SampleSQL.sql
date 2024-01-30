CREATE TABLE Price (
    PriceID INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
    ProductID INT,
    Value DECIMAL(10, 2),
    StartDate DateTime,
    EndDate DateTime,
	CreatedUser varchar(50),
	CreatedDate DateTime DEFAULT getdate(),
	UpdatedUser varchar(50),
	UpdatedDate DateTime,
    FOREIGN KEY (ProductID) REFERENCES Product(ProductID)
);

-- Creating Customer Table
CREATE TABLE Customer (
    CustomerID INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
    FirstName NVARCHAR(250),
    LastName NVARCHAR(250),
    Email VARCHAR(100) UNIQUE,
	CreatedUser varchar(50),
	CreatedDate DateTime  DEFAULT getdate(),
	UpdatedUser varchar(50),
	UpdatedDate DateTime,
    Address NVarchar(1000)
);

-- Creating Product Table
CREATE TABLE Product (
    ProductID INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
    Name NVARCHAR(255),
    Description NTEXT,
	CreatedUser varchar(50),
	CreatedDate DateTime  DEFAULT getdate(),
	UpdatedUser varchar(50),
	UpdatedDate DateTime,
);


-- Creating Order Table
CREATE TABLE [Order] (
    OrderID INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
    CustomerID INT,
    OrderDate DateTime,
	CreatedUser varchar(50),
	CreatedDate DateTime,
	UpdatedUser varchar(50),
	UpdatedDate DateTime,
    FOREIGN KEY (CustomerID) REFERENCES Customer(CustomerID)
);

-- Creating OrderItem Table to represent products in each order
CREATE TABLE OrderItem (
    OrderItemID INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
    OrderID INT,
    ProductID INT,
    Quantity INT,
	CreatedUser varchar(50),
	CreatedDate DateTime,
	UpdatedUser varchar(50),
	UpdatedDate DateTime,
    FOREIGN KEY (OrderID) REFERENCES [Order](OrderID),
    FOREIGN KEY (ProductID) REFERENCES Product(ProductID)
);