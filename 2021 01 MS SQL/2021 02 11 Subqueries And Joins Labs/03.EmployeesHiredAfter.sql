SELECT e.FirstName, e.LastName, e.HireDate, d.[Name] AS [DeptName]
	FROM Employees AS e
	JOIN Departments AS d ON e.DepartmentID = d.DepartmentID
	WHERE d.[Name] IN ('Sales',  'Finance')
		AND e.HireDate > '1999-01-01'
	ORDER BY e.HireDate