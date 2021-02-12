SELECT TOP(5) c.CountryName, MAX(p.Elevation) AS HighestPeakElevation, MAX(r.Length) AS LongestRiverLength
	FROM Countries c
	JOIN MountainsCountries mc ON c.CountryCode = mc.CountryCode
	JOIN Mountains m ON mc.MountainId = m.Id
	JOIN Peaks p ON mc.MountainId = p.MountainId
	JOIN CountriesRivers cr ON c.CountryCode = cr.CountryCode
	JOIN Rivers r ON cr.RiverId = r.Id
GROUP BY c.CountryName
ORDER BY HighestPeakElevation DESC, LongestRiverLength DESC, c.CountryName