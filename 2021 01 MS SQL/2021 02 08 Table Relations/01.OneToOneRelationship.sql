CREATE DATABASE TableRelations

USE TableRelations

--for judge from here
CREATE TABLE Passports
(
	PassportID INT PRIMARY KEY,
	PassportNumber NVARCHAR(50) UNIQUE NOT NULL
)

CREATE TABLE Persons
(
	PersonID INT PRIMARY KEY IDENTITY,
	FirstName NVARCHAR(30) NOT NULL,
	Salary DECIMAL(15,2) NOT NULL,
	PassportID INT FOREIGN KEY REFERENCES Passports(PassportID)
)

-- to here

INSERT INTO Persons(FirstName, Salary, PassportID)
	VALUES
	('Roberto', 43300.00, 102),
	('Tom', 56100.00, 103),
	('Yana', 60200.00, 101)

	
INSERT INTO Passports(PassportID, PassportNumber)
	VALUES
	(101, 'N34FG21B'),
	(102, 'K65LO4R7'),
	(103, 'ZE657QP2')
