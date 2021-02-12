SELECT DepositGroup, SUM(DepositAmount) AS TotalSum
	FROM WizzardDeposits wd
	WHERE wd.MagicWandCreator = 'Ollivander family'
	GROUP BY DepositGroup