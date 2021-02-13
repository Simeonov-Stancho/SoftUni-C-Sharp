SELECT TOP(5) r.ID, r.Name, COUNT(r.Id) AS Commits
		FROM RepositoriesContributors AS rc
		JOIN Repositories AS r ON rc.RepositoryId = r.Id
		JOIN Commits AS c ON c.RepositoryId = r.Id
		GROUP BY r.Id, r.Name
		ORDER BY COUNT(r.Id) DESC