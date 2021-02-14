SELECT rf.Id, rf.Name, (CONVERT(NVARCHAR(30), rf.Size)+'KB') AS Size 
	FROM Files AS f
	RIGHT JOIN Files as rf ON f.ParentId = rf.Id
	WHERE f.ParentId IS NULL
	ORDER BY f.Id, f.[Name], f.Size DESC

