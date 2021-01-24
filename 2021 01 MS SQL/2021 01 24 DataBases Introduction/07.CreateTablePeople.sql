CREATE TABLE People
(
	Id INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(200) NOT NULL,
	Picture VARBINARY(MAX),
	Height DECIMAL(5,2),
	[Weight] DECIMAL(5,2),
	Gender CHAR(1) NOT NULL CHECK(Gender IN('m', 'f')),
	Birthdate DATE NOT NULL,
	Biography NVARCHAR(MAX)
)

INSERT INTO People([Name], Picture, Height, [Weight], Gender, Birthdate, Biography)
	VALUES
	('Dimitichko', NULL, 1.86, 86.29, 'm', '2020-03-01', 'Iam a top'),
	('Gosho', NULL, 1.77, 90.5, 'm', '2020-03-01', NULL),
	('Pesho', NULL, 1.89, 88, 'm', '2020-03-01', 'Some man on the rock'),
	('Dimi', NULL, 1.67, 47.99, 'f', '2020-03-01', 'Dimitichka is my name'),
	('Goshka', NULL, 1.70, 50.55, 'f', '2020-03-01', 'lorem ipsum')