CREATE PROCEDURE usp_GetHoldersWithBalanceHigherThan(@number MONEY)
AS
	SELECT accH.FirstName AS [First Name], accH.LastName AS [Last Name]
		FROM Accounts AS acc
		JOIN AccountHolders accH ON acc.AccountHolderId = accH.Id
		GROUP BY FirstName, LastName
		HAVING SUM(acc.Balance) > @number
		ORDER BY accH.FirstName, accH.LastName
GO

EXECUTE usp_GetHoldersWithBalanceHigherThan 20000