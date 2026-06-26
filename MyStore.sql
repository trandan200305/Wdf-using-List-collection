select * from Categories
select * from Products

CREATE TABLE Categories
(
CategoryID int IDENTITY(1,1) PRIMARY KEY,
CategoryName NVARCHAR(15) NOT NULL
)

CREATE TABLE Products
(
ProductID INT IDENTITY(1,1) PRIMARY KEY,
ProductName NVARCHAR(40) NOT NULL,
UnitPrice MONEY NOT NULL,
UnitsInStock SMALLINT NOT NULL,
CategoryID INT NOT NULL,
CONSTRAINT FK_Products_Categories
        FOREIGN KEY (CategoryID)
        REFERENCES Categories(CategoryID)
);

INSERT INTO Categories (CategoryName)
VALUES
('Beverages'),
('Condiments'),
('Confections'),
('Dairy Products'),
('Grains/Cereals'),
('Meat/Poultry'),
('Produce'),
('Seafood');

INSERT INTO Products (ProductName, UnitPrice, UnitsInStock, CategoryID)
VALUES
('Genen Shouyu', 50.00, 39, 1),
('Alice Mutton', 30.00, 17, 1),
('Aniseed Syrup', 40.00, 13, 3),
('Perth Pasties', 22.00, 53, 2),
('Carnarvon Tigers', 21.35, 0, 4),
('Gula Malacca', 25.00, 120, 2),
('Steeleye Stout', 30.00, 15, 7),
('Chocolade', 40.00, 6, 5),
('Mishi Kobe Niku', 97.00, 29, 6),
('Ikura', 31.00, 31, 8);