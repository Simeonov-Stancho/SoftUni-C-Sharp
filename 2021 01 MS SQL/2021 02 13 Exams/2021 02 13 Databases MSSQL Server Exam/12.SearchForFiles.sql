CREATE PROCEDURE usp_SearchForFiles(@fileExtension VARCHAR(100))
AS
	BEGIN
		SELECT Id, [Name], (CONVERT(NVARCHAR(30), f.Size)+'KB') AS Size
		FROM Files AS f
		WHERE SUBSTRING(f.Name, CHARINDEX('.', f.Name)+1, LEN(f.Name)) = @fileExtension
		ORDER BY f.Id, f.Name, f.Size DESC
	END


EXEC usp_SearchForFiles 'txt'

SELECT Id, [Name], (CONVERT(NVARCHAR(30), f.Size)+'KB') AS Size 
	FROM Files AS f
	WHERE  SUBSTRING(f.Name, CHARINDEX('.', f.Name)+1, LEN(f.Name)) = 'txt'
