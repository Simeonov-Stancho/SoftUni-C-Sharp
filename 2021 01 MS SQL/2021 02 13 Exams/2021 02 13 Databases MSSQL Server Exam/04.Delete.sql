DELETE FROM Files
	WHERE CommitId = 36

DELETE FROM Commits
	WHERE RepositoryId = 3

DELETE FROM Issues
	WHERE RepositoryId = 3

DELETE FROM RepositoriesContributors
	WHERE RepositoryId = 3

DELETE FROM Repositories
	WHERE Id = 3
