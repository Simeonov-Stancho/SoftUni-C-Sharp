CREATE FUNCTION udf_AllUserCommits(@username NVARCHAR(100))
RETURNS INT
AS
	BEGIN
		DECLARE @count INT;
		SET @count = (SELECT COUNT(u.Id)
							FROM Users AS u
							JOIN Commits AS c ON u.Id = c.ContributorId
							WHERE u.Username = @username)
		RETURN @count
	END


SELECT dbo.udf_AllUserCommits('UnderSinduxrein')

SELECT *
		FROM Users AS u
		LEFT JOIN Commits AS c ON u.Id = c.ContributorId
		WHERE c.ContributorId IS NOT NULL
		ORDER BY u.Id
		
		