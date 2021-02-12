SELECT SUBSTRING(FirstName,1, 1) AS FirstLetter
	FROM WizzardDeposits wd
	WHERE wd.DepositGroup = 'Troll Chest'
GROUP BY  SUBSTRING(FirstName,1, 1)
ORDER BY SUBSTRING(FirstName,1, 1)