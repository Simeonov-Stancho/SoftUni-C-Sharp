SELECT j.JobId, 
	CASE 
	WHEN SUM(p.Price * op.Quantity) IS NULL THEN 0
	ELSE SUM(p.Price * op.Quantity)
	END AS Total
		FROM Jobs AS j
		LEFT JOIN Orders AS o ON j.JobId = o.JobId
		LEFT JOIN OrderParts AS op ON op.OrderId = o.OrderId
		LEFT JOIN Parts AS p ON op.PartId = p.PartId
		WHERE j.Status = 'Finished'
		GROUP BY j.JobId
ORDER BY Total DESC, j.JobId