CREATE PROCEDURE usp_EmployeesBySalaryLevel(@LevelOfSalary VARCHAR(20))
AS
	BEGIN
	SELECT FirstName AS [First Name], LastName AS [Last Name]
		FROM Employees
		WHERE @LevelOfSalary = dbo.ufn_GetSalaryLevel(Salary)
	END
GO

EXEC usp_EmployeesBySalaryLevel 'High'