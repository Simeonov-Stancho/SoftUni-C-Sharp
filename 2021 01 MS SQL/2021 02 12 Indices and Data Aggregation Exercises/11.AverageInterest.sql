SELECT DepositGroup, IsDepositExpired, AVG(DepositInterest) AS AverageInterest
	FROM WizzardDeposits AS wd
	WHERE wd.DepositStartDate > '1985-01-01'
	GROUP BY DepositGroup, IsDepositExpired
ORDER BY DepositGroup DESC, IsDepositExpired