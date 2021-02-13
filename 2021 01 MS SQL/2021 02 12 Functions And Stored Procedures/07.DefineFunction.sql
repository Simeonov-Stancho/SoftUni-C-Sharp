CREATE FUNCTION ufn_IsWordComprised(@setOfLetters NVARCHAR(MAX), @word NVARCHAR(MAX))
RETURNS BIT
AS
	BEGIN
			DECLARE @WordLength INT = LEN(@word);
			DECLARE @i INT = 1;
			DECLARE @Result BIT;
			WHILE(@WordLength >= @i)
				BEGIN
					IF(CHARINDEX(SUBSTRING(@word, @i, 1), @setOfLetters) = 0)
						RETURN 0
				SET @i +=1
				END
			RETURN 1
	END
GO

SELECT dbo.ufn_IsWordComprised('oistmiahf', 'Sofia')
SELECT dbo.ufn_IsWordComprised('oistmiahf', 'halves')
SELECT dbo.ufn_IsWordComprised('bobr', 'Rob')
SELECT dbo.ufn_IsWordComprised('pppp', 'Guy')
GO