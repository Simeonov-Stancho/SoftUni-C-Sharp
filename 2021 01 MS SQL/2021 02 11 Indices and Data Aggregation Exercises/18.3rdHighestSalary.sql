SELECT DISTINCT DepartmentID, Salary AS ThirdHighestSalary
FROM(
SELECT DepartmentID, Salary,
	DENSE_RANK() OVER (PARTITION BY DepartmentId ORDER BY Salary DESC) AS SalaryRank
	FROM Employees) AS RankingTable
WHERE SalaryRank = 3
	