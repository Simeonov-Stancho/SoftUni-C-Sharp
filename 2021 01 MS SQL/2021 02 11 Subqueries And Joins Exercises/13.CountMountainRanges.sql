SELECT c.CountryCode, COUNT(m.MountainRange) AS MountainRanges
	FROM Countries c
	JOIN MountainsCountries mc ON c.CountryCode = mc.CountryCode
	JOIN Mountains m ON mc.MountainId = m.Id
	WHERE c.CountryCode IN ('US', 'RU', 'BG')
GROUP BY c.CountryCode