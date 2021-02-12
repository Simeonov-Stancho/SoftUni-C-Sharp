SELECT DepartmentID, 
	CASE
		WHEN DepartmentID = 1 THEN AVG(Salary)+5000
		ELSE AVG(Salary)
		END AS AverageSalary
	FROM Employees
	WHERE Salary > 30000 AND ManagerID != 42
GROUP BY DepartmentID


SELECT DepartmentID,
       AVG(IIF(DepartmentID = 1, Salary + 5000, Salary)) AS AverageSalary
FROM (
         SELECT *
         FROM Employees
         WHERE Salary > 30000
           AND ManagerID != 42
     ) AS FilteredQuery
GROUP BY DepartmentID

--working in judge
SELECT *
INTO EmployeesWithMoreThan30000
FROM Employees
WHERE Salary > 30000

DELETE FROM EmployeesWithMoreThan30000
WHERE ManagerID = 42

UPDATE EmployeesWithMoreThan30000
SET Salary += 5000
WHERE DepartmentID = 1

SELECT DepartmentID, AVG(Salary) AS AverageSalary
FROM EmployeesWithMoreThan30000
GROUP BY  DepartmentID