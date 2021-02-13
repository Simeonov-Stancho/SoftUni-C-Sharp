CREATE FUNCTION ufn_GetSalaryLevel(@Salary Money)
RETURNS NVARCHAR(20)
AS
BEGIN
	DECLARE @SalaryType NVARCHAR(30) = 'Low';
	IF(@Salary <30000)
		SET @SalaryType = 'Low'
	ELSE IF(@Salary >50000)
		SET @SalaryType = 'High'
	ELSE 
		SET @SalaryType = 'Average'
RETURN @SalaryType
END



SELECT FirstName, LastName, Salary, dbo.ufn_GetSalaryLevel(Salary) AS SalaryLevel
	FROM Employees