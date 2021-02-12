SELECT TOP(10) FirstName, LastName, DepartmentID
	FROM Employees AS e
	WHERE Salary >
		(SELECT AVG(Salary) AS AvgSalary
			FROM Employees AS avgE
			WHERE e.DepartmentID = avgE.DepartmentID
			GROUP BY DepartmentID) 
ORDER BY e.DepartmentID