--CREATE DATABASE Hotel

--USE Hotel

CREATE TABLE Employees 
(
	Id INT PRIMARY KEY IDENTITY,
	FirstName NVARCHAR(15) NOT NULL,
	LastName NVARCHAR(15) NOT NULL,
	Title NVARCHAR(15),
	Notes NVARCHAR(MAX)
)

CREATE TABLE Customers 
(
	AccountNumber NVARCHAR(31) PRIMARY KEY NOT NULL,
	FirstName NVARCHAR(15) NOT NULL,
	LastName NVARCHAR(15) NOT NULL, 
	PhoneNumber NVARCHAR(30) NOT NULL,
	EmergencyName NVARCHAR(15) NOT NULL,
	EmergencyNumber NVARCHAR(15) NOT NULL,
	Notes NVARCHAR(MAX)
)

CREATE TABLE RoomStatus
(
	RoomStatus NVARCHAR(10) PRIMARY KEY NOT NULL, 
	Notes VARCHAR(MAX)
)

CREATE TABLE RoomTypes 
(
	RoomType NVARCHAR(15) PRIMARY KEY NOT NULL,
	Notes VARCHAR(MAX)
)

CREATE TABLE BedTypes 
(
	BedType NVARCHAR(15) PRIMARY KEY,
	Notes VARCHAR(MAX)
)

CREATE TABLE Rooms
(
	RoomNumber INT PRIMARY KEY IDENTITY,
	RoomType NVARCHAR(15) FOREIGN KEY REFERENCES RoomTypes(RoomType),
	BedType NVARCHAR(15) FOREIGN KEY REFERENCES BedTypes(BEdType),
	Rate DECIMAL(3,2),
	RoomStatus NVARCHAR(10) FOREIGN KEY REFERENCES RoomStatus(RoomStatus),
	Notes VARCHAR(MAX)
)

CREATE TABLE Payments 
(
	Id INT PRIMARY KEY IDENTITY,
	EmployeeId INT FOREIGN KEY REFERENCES Employees(Id),
	PaymentDate DATE NOT NULL,
	AccountNumber NVARCHAR(31) FOREIGN KEY REFERENCES Customers(AccountNumber), 
	FirstDateOccupied DATE NOT NULL, 
	LastDateOccupied DATE NOT NULL,
	TotalDays AS DATEDIFF(DAY, LastDateOccupied,FirstDateOccupied),
	AmountCharged DECIMAL(10,2) NOT NULL,
	TaxRate DECIMAL(4,2) NOT NULL, 
	TaxAmount AS AmountCharged * TaxRate,
	PaymentTotal DECIMAL(10,2) NOT NULL,
	Notes NVARCHAR(MAX)
)

CREATE TABLE Occupancies
(
	Id INT PRIMARY KEY IDENTITY,
	EmployeeId INT FOREIGN KEY REFERENCES Employees(Id),
	DateOccupied DATE NOT NULL, 
	AccountNumber NVARCHAR(31) FOREIGN KEY REFERENCES Customers(AccountNumber), 
	RoomNumber INT FOREIGN KEY REFERENCES Rooms(RoomNumber), 
	RateApplied DECIMAL(3,2), 
	PhoneCharge DECIMAL(10,2), 
	Notes NVARCHAR(MAX)
)

INSERT INTO Employees (FirstName, LastName, Title, Notes)
VALUES
('Dimitrichko', 'Dimov', 'Director', NULL),
('Pesho', 'Ivanov', 'Staff', NULL),
('Goshko', 'Peshev', 'DrinkerOnWork', NULL)

INSERT INTO Customers (AccountNumber, FirstName, LastName, PhoneNumber, EmergencyName, EmergencyNumber, Notes)
VALUES
('BG65UNCR763010654112', 'Ivan', 'Ivanov', '0887', 'Gosho', '0888', NULL),
('BG77PRCB763010654112', 'Dragan', 'Strashni', '08873', 'Goshoko', '088843434', NULL),
('BG91RZZB763010654112', 'Petkan', 'Patkanov', '088723', 'Goshokoto', '0882228', NULL)

INSERT INTO RoomStatus (RoomStatus, Notes)
VALUES
('Free', NULL),
('FOR CLEAN', NULL),
('EMPTY', NULL)

INSERT INTO RoomTypes  (RoomType, Notes)
VALUES
('SINGLE', NULL),
('DOUBLE', NULL),
('Appartmant', NULL)

INSERT INTO BedTypes  (BedType, Notes)
VALUES
('One person', NULL),
('Two person', NULL),
('Orgy', NULL)

INSERT INTO Rooms(RoomType, BedType, Rate, RoomStatus, Notes)
VALUES
('SINGLE', 'One person', 9.90, 'Free', NULL),
('DOUBLE', 'Two person', 5.90, 'FOR CLEAN', NULL),
('Appartmant', 'Orgy', 3.90, 'EMPTY', NULL)

INSERT INTO Payments (EmployeeId, PaymentDate, AccountNumber, FirstDateOccupied, LastDateOccupied,
AmountCharged, TaxRate, PaymentTotal, Notes)
VALUES
(1, '2020-01-15', 'BG65UNCR763010654112', '2020-01-01', '2020-01-15', 320.50, 9, 400.1, NULL ),
(2, '2020-07-01', 'BG77PRCB763010654112', '2020-07-01', '2020-07-15', 220.50, 20, 450.51, NULL ),
(3, '2020-10-01', 'BG91RZZB763010654112', '2020-10-01', '2020-10-15', 720.50, 15.7, 900.17, NULL )

INSERT INTO Occupancies (EmployeeId, DateOccupied, AccountNumber, RoomNumber, 
RateApplied, PhoneCharge, Notes)
VALUES
(1, '2020-01-15', 'BG65UNCR763010654112', 1, 5.2, NULL, NULL),
(1, '2020-07-15', 'BG77PRCB763010654112', 2, 9.2, 10.5, NULL),
(1, '2020-10-15', 'BG91RZZB763010654112', 3, 4.2, 17.66, NULL)