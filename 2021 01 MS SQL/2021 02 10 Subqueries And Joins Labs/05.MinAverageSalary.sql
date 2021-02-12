SELECT TOP(1) d.DepartmentID,
		d.Name, 
		(SELECT AVG(Salary) FROM Employees e WHERE e.DepartmentID = d.DepartmentID ) AS MinAverageSalary
	FROM Departments d
	ORDER BY MinAverageSalary
	


SELECT TOP(1) 
		(SELECT AVG(Salary) FROM Employees e WHERE e.DepartmentID = d.DepartmentID ) AS MinAverageSalary
	FROM Departments d
	ORDER BY MinAverageSalary


SELECT TOP(1) DepartmentID, AVG(Salary) AS MinAverageSalry
	FROM Employees
	GROUP BY DepartmentID
	ORDER BY MinAverageSalry