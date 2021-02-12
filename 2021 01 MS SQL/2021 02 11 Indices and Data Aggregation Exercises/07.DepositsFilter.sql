SELECT DepositGroup, SUM(DepositAmount)
	FROM WizzardDeposits AS wd
	WHERE wd.MagicWandCreator = 'Ollivander family'
	GROUP BY wd.DepositGroup
	HAVING SUM(DepositAmount) < 150000
	ORDER BY SUM(DepositAmount) DESC