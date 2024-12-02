DROP DATABASE OnlineStore;

CREATE DATABASE OnlineStore;
USE OnlineStore;

CREATE TABLE Category
(
    ID INT IDENTITY(1,1) PRIMARY KEY,
    CategoryName NVARCHAR(200) NOT NULL,
    CategoryDescription NVARCHAR(MAX) 
)

CREATE TABLE Product(
    Id INT IDENTITY (1,1) PRIMARY KEY,
    ProductName NVARCHAR(200) NOT NULL,
    ProductDescription NVARCHAR(MAX),
    PriceWithoutVat NUMERIC(9, 2) NOT NULL,
    PriceWithVat NUMERIC(9, 2) NOT NULL,
    CategoryID INT NOT NULL,
    IsActive BIT NOT NULL,
    FOREIGN KEY (CategoryID) REFERENCES Category(CategoryID)
);

CREATE TABLE Stock
(
    ID INT IDENTITY(1,1) PRIMARY KEY,
    ProductID INT NOT NULL,
    Quantity INT NOT NULL,
    FOREIGN KEY (ProductID) REFERENCES Product(ProductID)
)

CREATE TABLE Supplier
(
    ID INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(200) NOT NULL
)

CREATE TABLE ProductSupplier
(
    ID INT IDENTITY(1,1) PRIMARY KEY,
    ProductID INT NOT NULL,
    SupplierID INT NOT NULL,
    FOREIGN KEY (ProductID) REFERENCES Product(ProductID),
    FOREIGN KEY (SupplierID) REFERENCES Supplier(SupplierID)
)

CREATE TABLE "User"
(
    ID INT IDENTITY(1,1) PRIMARY KEY,
    UserName NVARCHAR(50) NOT NULL,
    "Password" NVARCHAR(50) NOT NULL,
    Email NVARCHAR(100) NOT NULL  
)

CREATE TABLE Customer (
    ID INT IDENTITY (1,1) PRIMARY KEY,
    FirstName NVARCHAR(150) NOT NULL,
    LastName NVARCHAR(150) NOT NULL,
    DateOfBirth DATETIME NULL, 
    Email NVARCHAR(200) NOT NULL,
    PhoneNumber NVARCHAR(20) NOT NULL,
    VatNumber NVARCHAR(30) NULL,
    UserID INT NOT NULL,
    FOREIGN KEY (UserID) REFERENCES "User"(UserID)
);

CREATE TABLE Address (
    ID INT IDENTITY (1,1) PRIMARY KEY,
    CustomerID INT NOT NULL,
    City NVARCHAR(100) NOT NULL,
    Street NVARCHAR(150) NOT NULL,
    StreetNumber NVARCHAR(50) NOT NULL,
    PostalCode NVARCHAR(25) NOT NULL,
    Country NVARCHAR(50) NOT NULL,
    FOREIGN KEY (CustomerID) REFERENCES Customer(CustomerID)
);

CREATE TABLE "Order" (
    ID INT IDENTITY (1,1) PRIMARY KEY,
    CustomerID INT NOT NULL,
    OrderDate DATETIME NOT NULL,
    TotalAmountWithoutVat NUMERIC(10, 2) NOT NULL,
    TotalAmountWithVat NUMERIC(10, 2) NOT NULL,
    Remarks NVARCHAR(MAX),
    FOREIGN KEY (CustomerID) REFERENCES Customer(CustomerID)
);

CREATE TABLE OrderLine (
    ID INT IDENTITY (1,1) PRIMARY KEY,
    OrderID INT NOT NULL,
    ProductID INT NOT NULL,
    Quantity INT NOT NULL,
    PriceWithVat NUMERIC(10, 2) NOT NULL,
    PriceWithoutVat NUMERIC(10, 2) NOT NULL,
    FOREIGN KEY (OrderID) REFERENCES "Order"(OrderID),
    FOREIGN KEY (ProductID) REFERENCES Product(ProductID)
);

CREATE TABLE Invoice (
    ID INT IDENTITY (1,1) PRIMARY KEY,
    OrderID INT NOT NULL,
    CustomerID INT NOT NULL,
    InvoiceDate DATETIME NOT NULL,
    InvoiceNumber NVARCHAR(100),
    TotalAmountWithoutVat NUMERIC(10, 2) NOT NULL,
    TotalAmountWithVat NUMERIC(10, 2) NOT NULL,
    FOREIGN KEY (OrderID) REFERENCES "Order"(OrderID),
    FOREIGN KEY (CustomerID) REFERENCES Customer(CustomerID)
);

CREATE TABLE PaymentMethod
(
    ID INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(100) NOT NULL,
    Description NVARCHAR(250)
)

CREATE TABLE Payment
(
    ID INT IDENTITY(1,1) PRIMARY KEY,
    InvoiceID INT NOT NULL,
    PaymentDate DATETIME NOT NULL,
    PaymentMethodID INT NOT NULL,
    IsSuccessful BIT NOT NULL,
    FOREIGN KEY (InvoiceID) REFERENCES Invoice(InvoiceID),
    FOREIGN KEY (PaymentMethodID) REFERENCES PaymentMethod(PaymentMethodID)
)

CREATE TABLE Cart
(
    ID INT IDENTITY(1,1) PRIMARY KEY,
    UserID INT NULL,
    FOREIGN KEY (UserID) REFERENCES "User"(UserID)
)

CREATE TABLE CartItem
(
    ID INT IDENTITY(1,1) PRIMARY KEY,
    CartID INT NOT NULL,
    ProductID INT NOT NULL,
    Quantity INT NOT NULL,
    FOREIGN KEY (CartID) REFERENCES Cart(CartID),
    FOREIGN KEY (ProductID) REFERENCES Product(ProductID)
)