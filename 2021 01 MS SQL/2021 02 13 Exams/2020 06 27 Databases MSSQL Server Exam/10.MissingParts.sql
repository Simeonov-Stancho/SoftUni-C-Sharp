SELECT p.PartId, p.Description, pn.Quantity AS [Required], p.StockQty, IIF(o.Delivered = 0, op.Quantity, 0)
		FROM Parts as p 
			LEFT JOIN PartsNeeded AS pn ON p.PartId = pn.PartId
			LEFT JOIN OrderParts AS op ON p.PartId = op.PartId
			LEFT JOIN Orders AS o ON op.OrderId = o.OrderId
			LEFT JOIN Jobs AS j ON pn.JobId = j.JobId
		WHERE j.Status != 'Finished' AND
			((pn.Quantity) > (p.StockQty + IIF(o.Delivered = 0, op.Quantity, 0)))
	ORDER BY p.PartId
		
		