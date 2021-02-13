SELECT *
	FROM Jobs
	WHERE Status = 'Pending'


SELECT *
	FROM Mechanics


-- for judge
UPDATE Jobs
	SET MechanicId = 3,
		Status = 'In Progress'
	WHERE Status = 'Pending'