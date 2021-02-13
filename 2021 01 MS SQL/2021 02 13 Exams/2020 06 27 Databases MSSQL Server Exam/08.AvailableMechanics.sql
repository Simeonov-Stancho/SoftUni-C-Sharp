SELECT m.FirstName + ' ' + m.LastName
	FROM Mechanics AS m
	LEFT JOIN Jobs AS j ON j.MechanicId = m.MechanicId
	WHERE j.JobId IS NULL OR
	(SELECT COUNT(JobId)
		FROM Jobs
		WHERE Status != 'Finished' AND MechanicId = m.MechanicId
		GROUP BY MechanicId, Status) IS NULL
	GROUP BY m.MechanicId, m.FirstName + ' ' + m.LastName


SELECT m.FirstName + ' ' + m.LastName AS Available
	FROM Mechanics AS m
	LEFT JOIN Jobs AS j ON j.MechanicId = m.MechanicId
	WHERE j.Status = 'Finished' or j.Status IS NULL
	GROUP BY m.MechanicId, m.FirstName + ' ' + m.LastName
ORDER BY m.MechanicId
