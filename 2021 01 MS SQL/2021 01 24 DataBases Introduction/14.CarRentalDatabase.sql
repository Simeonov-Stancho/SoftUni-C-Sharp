--CREATE DATABASE CarRental

--USE CarRental

CREATE TABLE Categories
(
	Id INT PRIMARY KEY IDENTITY,
	CategoryName NVARCHAR(20) NOT NULL,
	DailyRate DECIMAL(3,2) NOT NULL,
	WeeklyRate DECIMAL(3,2) NOT NULL,
	MonthlyRate DECIMAL(3,2) NOT NULL,
	WeekendRate DECIMAL(3,2) NOT NULL
)

CREATE TABLE Cars
(
	Id INT PRIMARY KEY IDENTITY,
	PlateNumber NVARCHAR(15) NOT NULL,
	Manufacturer NVARCHAR(20) NOT NULL,
	Model NVARCHAR(20) NOT NULL,
	CarYear DATE NOT NULL, 
	CategoryId INT FOREIGN KEY REFERENCES Categories(Id),
	Doors TINYINT NOT NULL, 
	Picture VARBINARY(MAX),
	Condition NVARCHAR(50),
	Available BIT NOT NULL
)

CREATE TABLE Employees
(
	Id INT PRIMARY KEY IDENTITY,
	FirstName NVARCHAR(15) NOT NULL,
	LastName NVARCHAR(15) NOT NULL,
	Title NVARCHAR(15) NOT NULL,
	Notes NVARCHAR(MAX)
)

CREATE TABLE Customers
(
	Id INT PRIMARY KEY IDENTITY,
	DriverLicenceNumber INT NOT NULL,
	FullName NVARCHAR(15) NOT NULL,
	[Address] NVARCHAR(300) NOT NULL,
	City NVARCHAR(50) NOT NULL,
	ZIPCode NVARCHAR(30) NOT NULL,
	Notes NVARCHAR(MAX)
)

CREATE TABLE RentalOrders
(
	Id INT PRIMARY KEY IDENTITY,
	EmployeeId INT FOREIGN KEY REFERENCES Employees(Id),
	CustomerId INT FOREIGN KEY REFERENCES Customers(Id),
	CarId INT FOREIGN KEY REFERENCES Cars(Id), 
	TankLevel INT NOT NULL ,
	KilometrageStart INT NOT NULL,
	KilometrageEnd INT NOT NULL,
	TotalKilometrage AS KilometrageEnd-KilometrageStart,
	StartDate DATE NOT NULL, 
	EndDate DATE NOT NULL, 
	TotalDays AS DATEDIFF(DAY,StartDate,EndDate),
	RateApplied DECIMAL(3,2) NOT NULL, 
	TaxRate DECIMAL(3,2) NOT NULL, 
	OrderStatus NVARCHAR(10) NOT NULL, 
	Notes NVARCHAR(MAX)
)

INSERT INTO Categories (CategoryName, DailyRate, WeeklyRate, MonthlyRate, WeekendRate)
VALUES
('SUV', 5.55, 6.00, 6.95, 7.13),
('Muscle', 6.55, 6.50, 5.95, 7.13), 
('Sedan', 7.55, 6.40, 5.95, 7.15)

INSERT INTO Cars (PlateNumber, Manufacturer, Model, CarYear, CategoryId,
Doors, Picture, Condition, Available)
VALUES
('V7777VV', 'BMW', 'X5', '2015-01-07', 1, 5, NULL, 'Used', 1),
('B6666BB', 'OREL', '100', '1912-05-08', 3, 2, NULL, 'Used', 1),
('OV4AR', 'AUDI', 'R7', '2020-05-05', 2, 3, NULL, 'Used', 0)

INSERT INTO Employees (FirstName, LastName, Title, Notes)
VALUES
('Dimitrichko', 'Goshev', 'Mr', 'Be nice'),
('Pesho', 'Peshev', 'Mr', NULL),
('Goshko', 'Goshev', 'Mr', NULL)

INSERT INTO Customers (DriverLicenceNumber, FullName, [Address], City, ZIPCode, Notes)
VALUES
(61245, 'Ivan Ivanov', 'str. First', 'Varna', '9000', NULL),
(7017, 'Josh Smith', 'str. First', 'London', 'IR5 6DG', NULL),
(1, 'Georgi Ivanov', 'str. Second', 'Sofia', '1000', NULL)

INSERT INTO RentalOrders (EmployeeId, CustomerId, CarId, TankLevel, KilometrageStart, 
KilometrageEnd, StartDate, EndDate, RateApplied, TaxRate, OrderStatus, Notes)
VALUES
(1, 1, 1, 60, 10, 110, '2021-01-01', '2021-01-10', 5.5, 2.15, 'Ordered', NULL),
(2, 2, 2, 55, 140000, 210158, '2021-01-01', '2021-01-25', 2.5, 3.55, 'PreOrdered', NULL),
(3, 3, 3, 70, 1010, 1100, '2021-01-01', '2021-01-7', 3.5, 3.15, 'Delivered', NULL)