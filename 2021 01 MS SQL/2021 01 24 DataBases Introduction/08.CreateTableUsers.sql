CREATE TABLE Users
(
	Id BIGINT PRIMARY KEY IDENTITY,
	Username VARCHAR(30) UNIQUE NOT NUll,
	[Password] VARCHAR(26) NOT NULL,
	ProfilePicture VARBINARY(900),
	LasrLoginTime DATETIME NOT NULL,
	IsDeleted BIT NOT NULL
)

INSERT INTO Users(Username, [Password], ProfilePicture, LasrLoginTime, IsDeleted )
VALUES
('Dimitrichko', 'Dimi!a29::)', NULL, '2021-01-01', 0),
('Dimitrichka', 'Dima@c34]:)', NULL, '2021-01-10', 1),
('Pesho', '1234', NULL, '2020-12-12', 0),
('Gosho', 'admin', NULL, '2020-08-31', 1),
('LastOne', 'password', NULL, '2020-10-01', 1)