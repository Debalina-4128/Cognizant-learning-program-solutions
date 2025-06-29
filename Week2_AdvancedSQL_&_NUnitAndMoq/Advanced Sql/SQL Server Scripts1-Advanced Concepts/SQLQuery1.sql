CREATE TABLE Customers (
    CustomerID INT PRIMARY KEY,
    Name VARCHAR(100),
    Region VARCHAR(50)
);

CREATE TABLE Products (
    ProductID INT PRIMARY KEY,
    ProductName VARCHAR(100),
    Category VARCHAR(50),
    Price DECIMAL(10, 2)
);

CREATE TABLE Orders (
    OrderID INT PRIMARY KEY,
    CustomerID INT,
    OrderDate DATE,
    FOREIGN KEY (CustomerID) REFERENCES Customers(CustomerID)
);

CREATE TABLE OrderDetails (
    OrderDetailID INT PRIMARY KEY,
    OrderID INT,
    ProductID INT,
    Quantity INT,
    FOREIGN KEY (OrderID) REFERENCES Orders(OrderID),
    FOREIGN KEY (ProductID) REFERENCES Products(ProductID)
);

INSERT INTO Customers (CustomerID, Name, Region) VALUES
(1, 'Alice', 'North'),
(2, 'Bob', 'South'),
(3, 'Charlie', 'East'),
(4, 'David', 'West');

INSERT INTO Products (ProductID, ProductName, Category, Price) VALUES
(1, 'Laptop', 'Electronics', 1200.00),
(2, 'Smartphone', 'Electronics', 800.00),
(3, 'Tablet', 'Electronics', 600.00),
(4, 'Headphones', 'Accessories', 150.00);

INSERT INTO Orders (OrderID, CustomerID, OrderDate) VALUES
(1, 1, '2023-01-15'),
(2, 2, '2023-02-20'),
(3, 3, '2023-03-25'),
(4, 4, '2023-04-30');

INSERT INTO OrderDetails (OrderDetailID, OrderID, ProductID, Quantity) VALUES
(1, 1, 1, 1),
(2, 2, 2, 2),
(3, 3, 3, 1),
(4, 4, 4, 3);


Select *
from (
    Select *,
        ROW_NUMBER() OVER(PARTITION BY Category ORDER BY Price DESC) AS RowNum
    FROM Products
) ranked
WHERE RowNum <=3;

Select *
from(
    Select * ,
        RANK() OVER(PARTITION BY Category ORDER BY Price DESC) AS RankNum
    FROM Products
) ranked
WHERE RankNum <= 3;


Select *
from (
    Select *, DENSE_RANK() OVER(PARTITION BY Category ORDER BY Price DESC) AS DenseRank
    FROM Products
) ranked
WHERE DenseRank <= 3;


Select SUM(od.Quantity) AS TotalQuantity, c.Region, p.Category
From Orders o JOIN OrderDetails od ON o.OrderID = od.OrderID
JOIN Customers c ON o.CustomerID = c.CustomerID
JOIN Products p ON od.ProductID = p.ProductID
GROUP BY GROUPING SETS ((c.Region,p.Category),(c.Region),(p.Category));

Select SUM(od.Quantity) AS TotalQuantity, c.Region, p.Category
From Orders o JOIN OrderDetails od ON o.OrderID = od.OrderID
JOIN Customers c ON o.CustomerID = c.CustomerID
JOIN Products p ON od.ProductID = p.ProductID
GROUP BY ROLLUP (c.Region,p.Category);


Select SUM(od.Quantity) AS TotalQuantity, c.Region, p.Category
From Orders o JOIN OrderDetails od ON o.OrderID = od.OrderID
JOIN Customers c ON o.CustomerID = c.CustomerID
JOIN Products p ON od.ProductID = p.ProductID
GROUP BY CUBE (c.Region,p.Category);


WITH Calendar AS (
    SELECT CAST('2025-01-01' AS DATE) AS CalendarDate
    UNION ALL
    SELECT DATEADD(DAY,1,CalendarDate)
    FROM Calendar
    WHERE CalendarDate < '2025-01-31'
)
SELECT * FROM Calendar
OPTION (MAXRECURSION 100);


CREATE TABLE StagingProducts (
    ProductID INT PRIMARY KEY,
    ProductName VARCHAR(100),
    Category VARCHAR(50),
    Price DECIMAL(10, 2)
);
INSERT INTO StagingProducts VALUES
(1, 'Laptop', 'Electronics', 1350.00),
(6, 'Keyboard', 'Electronics', 1000.00);

MERGE INTO Products AS Target
USING StagingProducts AS Source
ON Target.ProductID = Source.ProductID

WHEN MATCHED THEN
    UPDATE SET Target.ProductName = Source.ProductName,
    Target.Category = Source.Category,
    Target.Price = Source.Price

WHEN NOT MATCHED THEN
    INSERT (ProductID, ProductName, Category, Price)
    VALUES (Source.ProductID, Source.ProductName, Source.Category, Source.Price);


CREATE TABLE Sales (
    SaleID INT PRIMARY KEY,
    ProductID INT,
    OrderDate DATE,
    Quantity INT
);

INSERT INTO Sales (SaleID, ProductID, OrderDate, Quantity) VALUES
(1, 101, '2025-01-10', 100),
(2, 101, '2025-01-20', 150),
(3, 101, '2025-02-05', 300),
(4, 102, '2025-01-15', 200),
(5, 102, '2025-03-01', 90),
(6, 103, '2025-02-10', 120),
(7, 103, '2025-03-11', 130);

SELECT ProductID, FORMAT(OrderDate, 'yyyy-MM') AS SalesMonth,
SUM(Quantity) AS TotalQuantity FROM Sales GROUP BY ProductID, FORMAT(OrderDate, 'yyyy-MM');


SELECT *
FROM (
    SELECT 
        ProductID,
        FORMAT(OrderDate, 'yyyy-MM') AS SaleMonth,
        Quantity
    FROM Sales
) AS SourceTable
PIVOT (
    SUM(Quantity)
    FOR SaleMonth IN ([2025-01], [2025-02], [2025-03])
) AS PivotTable;

SELECT 
    ProductID,SaleMonth,Quantity
FROM (
    SELECT 
        ProductID,[2025-01], [2025-02], [2025-03]
    FROM (
        SELECT 
            ProductID,FORMAT(OrderDate, 'yyyy-MM') AS SaleMonth,Quantity
        FROM Sales
    ) AS SourceTable
    PIVOT (
        SUM(Quantity)
        FOR SaleMonth IN ([2025-01], [2025-02], [2025-03])
    ) AS PivotTable
) AS PivotedData
UNPIVOT (
    Quantity FOR SaleMonth IN ([2025-01], [2025-02], [2025-03])
) AS UnpivotedData;



WITH CustomerOrderCount AS(
    SELECT CustomerID, COUNT(*) AS OrderCount
    FROM Orders GROUP BY CustomerID
)
SELECT c.CustomerID, c.Name, o.OrderCount
FROM CustomerOrderCount o JOIN Customers c ON c.CustomerID = o.CustomerID WHERE o.OrderCount > 3;