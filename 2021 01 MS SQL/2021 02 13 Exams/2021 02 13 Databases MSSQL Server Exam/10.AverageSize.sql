SELECT Username, AVG(Size) AS Size
	FROM Users AS u
	LEFT JOIN Commits AS c ON u.Id = c.ContributorId
	LEFT JOIN Files AS f ON f.CommitId = c.Id
	GROUP BY Username
	HAVING AVG(Size) IS NOT NULL
ORDER BY AVG(Size) DESC, Username