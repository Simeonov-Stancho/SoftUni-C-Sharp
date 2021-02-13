
SELECT Id, [Name], (CONVERT(NVARCHAR(30), Size)+'KB') AS Size 
	FROM
		(SELECT *
			FROM Files
			WHERE ParentId IS NOT NULL) AS Query
	WHERE Id NOT IN (ParentId)
	ORDER BY Id, [Name], Size DESC


SELECT rf.Id, rf.Name, (CONVERT(NVARCHAR(30), rf.Size)+'KB') AS Size 
	FROM Files AS f
	RIGHT JOIN Files as rf ON f.ParentId = rf.Id
	WHERE f.ParentId IS NULL
	ORDER BY f.Id, f.[Name], f.Size DESC

