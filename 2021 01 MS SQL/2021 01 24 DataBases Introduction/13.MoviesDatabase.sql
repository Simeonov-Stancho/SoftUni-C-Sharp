CREATE DATABASE Movies

CREATE TABLE Directors
(
	Id INT PRIMARY KEY IDENTITY,
	DirectorName NVARCHAR(20) NOT NULL,
	Notes NVARCHAR(MAX)
)

CREATE TABLE Genres
(
	Id INT PRIMARY KEY IDENTITY,
	GenreName NVARCHAR(20) NOT NULL,
	Notes NVARCHAR(MAX) 
)

CREATE TABLE Categories
(
	Id INT PRIMARY KEY IDENTITY,
	CategoryName NVARCHAR(30),
	Notes NVARCHAR(MAX)
)

CREATE TABLE Movies
(
	Id INT PRIMARY KEY IDENTITY,
	Title NVARCHAR(50) NOT NULL,
	DirectorId INT FOREIGN KEY REFERENCES Directors(Id),
	CopyrightYear DATETIME2 NOT NULL,
	[Length] TIME NOT NULL,
	GenreId INT FOREIGN KEY REFERENCES Genres(Id),
	CategoryId INT FOREIGN KEY REFERENCES Categories(Id),
	Rating DECIMAL(2,1),
	Notes NVARCHAR(MAX)
)

DROP TABLE Movies

INSERT INTO Directors(DirectorName,Notes)
	VALUES
		('Димитричко' , NULL),
		('Dimi', NULL),
		('Pesho', NULL),
		('Gosho', NULL),
		('Tosho', NULL)

INSERT INTO Genres(GenreName, Notes)
	VALUES
		('Horror', NULL),
		('Action', NULL),
		('Actient', NULL),
		('Comedy', NULL),
		('Drama', NULL)

INSERT INTO Categories(CategoryName,Notes)
	VALUES
		('Man role', NULL),
		('Women role', NULL),
		('Music', NULL),
		('History', NULL),
		('Film of the year', NULL)

INSERT INTO Movies(Title, DirectorId, CopyrightYear, [Length], GenreId, CategoryId, Rating, Notes)
	VALUES
		('Harry Poter', 1, '2001', '02:11', 2, 3, 9.20, NULL),
		('Harry Poter 2', 2, '1972', '02:55', 3, 4, 9.80, NULL),
		('Scary Movie 1',3,'1993','03:15', 4, 5, 7.90, NULL),
		('Scary Movie 2',4,'1993','03:15', 5, 1, 8.90, NULL),
		('Scary Movie 3',5,'1993','03:15', 1, 2, 9.90, NULL)
		