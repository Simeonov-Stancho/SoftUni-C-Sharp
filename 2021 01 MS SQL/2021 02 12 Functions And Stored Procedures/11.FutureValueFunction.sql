CREATE FUNCTION ufn_CalculateFutureValue(@sum DECIMAL(18,4), @yearlyInterestRate FLOAT, @numbersOfYear INT)
RETURNS DECIMAL(18,4)
AS
BEGIN
	--FV=I?(?(1+R)?^T)
	DECLARE @result DECIMAL(18,4)
	SET @result = @sum * POWER((1+@yearlyInterestRate), @numbersOfYear)
	RETURN @result
END

SELECT dbo.ufn_CalculateFutureValue(1000, 0.1, 5)