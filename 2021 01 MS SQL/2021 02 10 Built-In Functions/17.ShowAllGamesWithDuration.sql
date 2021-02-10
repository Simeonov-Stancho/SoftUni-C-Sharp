SELECT Name , 
  CASE
	WHEN DATEPART(hour, Start)  >= 0 AND DATEPART(hour, Start) < 12 THEN 'Morning'
    WHEN DATEPART(hour, Start)  >= 12 AND DATEPART(hour, Start) < 18 THEN 'Afternoon'
    ELSE 'Evening'
      END AS 'Part of the Day',
  CASE
    WHEN Games.Duration  <= 3 THEN 'Extra Short'
    WHEN Games.Duration  >= 4 AND Games.Duration <= 6 THEN 'Short'
    WHEN Games.Duration  > 6 THEN 'Long'
    ELSE 'Extra Long'
      END AS [Duration]
 FROM Games
ORDER BY  Name, [Duration]