SELECT e.EmployeeID, e.FirstName, e.ManagerID, empM.FirstName AS ManagerName
	FROM Employees e
	JOIN Employees AS empM ON e.ManagerID = empM.EmployeeID
	WHERE e.ManagerID IN (3, 7)
ORDER BY e.EmployeeID