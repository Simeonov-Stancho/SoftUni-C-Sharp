CREATE PROC usp_GetEmployeesFromTown(@TownName VARCHAR(50))
AS
BEGIN
	SELECT FirstName AS [First Name], LastName AS [Last Name]
		FROM Employees AS e
		JOIN Addresses AS a ON e.AddressID = a.AddressID
		JOIN Towns as t ON a.TownID = t.TownID
		WHERE t.Name = @TownName
END

EXEC usp_GetEmployeesFromTown 'Sofia'
