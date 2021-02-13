SELECT i.Id, (Username +' '+ ':' + ' ' + Title) AS IssueAssignee
	FROM Issues as i
	LEFT JOIN Users AS u ON i.AssigneeId = u.Id
ORDER BY i.Id DESC, i.AssigneeId


