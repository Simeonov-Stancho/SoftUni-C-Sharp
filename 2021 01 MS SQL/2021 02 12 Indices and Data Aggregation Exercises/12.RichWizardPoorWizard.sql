SELECT SUM([Difference]) AS SumDifference
	FROM(
		SELECT FirstName AS [Host Wizard],
			DepositAmount AS [Host Wizard Deposit],
			LEAD(FirstName) OVER (ORDER BY ID) AS [Guest Wizard],
			LEAD(DepositAmount) OVER (ORDER BY ID) AS [Guest Wizard Deposit],
			(DepositAmount - LEAD(DepositAmount) OVER (ORDER BY ID)) AS [Difference]
		FROM WizzardDeposits) AS TableWithDiff
