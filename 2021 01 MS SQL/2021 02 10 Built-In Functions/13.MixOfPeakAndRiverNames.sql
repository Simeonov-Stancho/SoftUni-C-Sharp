SELECT PeakName, Rivers.RiverName,
	LOWER(
		CONCAT(
			SUBSTRING(Peaks.PeakName, 1, LEN(Peaks.PeakName)-1), Rivers.RiverName)) AS Mix
	FROM Peaks, Rivers
	WHERE RIGHT(PeakName, 1) = LEFT(RiverName, 1)
	ORDER BY Mix