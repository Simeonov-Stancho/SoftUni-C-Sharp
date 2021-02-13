CREATE PROC usp_GetTownsStartingWith(@Letter NVARCHAR(10))
AS
BEGIN
	SELECT [Name] AS Town
		FROM Towns
		WHERE SUBSTRING([Name], 1, 1) = @Letter
END

EXEC usp_GetTownsStartingWith 'c'