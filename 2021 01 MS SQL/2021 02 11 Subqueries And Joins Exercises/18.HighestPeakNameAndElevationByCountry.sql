SELECT TOP(100) Country,
	CASE
		WHEN PeakName IS NULL THEN '(no highest peak)'
		ELSE PeakName
		END AS [Highest Peak Name],
	CASE
		WHEN Elevation IS NULL THEN '0'
		ELSE Elevation
		END AS [Highest Peak Elevation],
	CASE
		WHEN Mountain IS NULL THEN '(no mountain)'
		ELSE Mountain
		END AS Mountain
FROM
	( SELECT *,
		DENSE_RANK() OVER (PARTITION BY Country ORDER BY Elevation Desc) AS RankByPeak
		FROM (SELECT c.CountryName AS Country, p.PeakName, p.Elevation, m.MountainRange AS Mountain
			FROM Countries AS c	
				LEFT JOIN MountainsCountries mc ON c.CountryCode = mc.CountryCode
				LEFT JOIN Mountains m ON mc.MountainId = m.Id
				LEFT JOIN Peaks p ON m.Id = p.MountainId) AS PeaksInfo) 
		AS ALLPeaksRang
WHERE RankByPeak = 1
ORDER BY Country, [Highest Peak Name]


