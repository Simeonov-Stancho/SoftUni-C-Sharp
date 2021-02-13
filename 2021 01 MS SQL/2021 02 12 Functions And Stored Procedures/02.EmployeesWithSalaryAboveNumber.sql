CREATE PROC usp_GetEmployeesSalaryAboveNumber (@MinSalary DECIMAL(18, 4))
AS
	SELECT FirstName, LastName
		FROM Employees
		WHERE Salary >= @MinSalary
GO

EXEC dbo.usp_GetEmployeesSalaryAboveNumber 48100
