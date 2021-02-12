SELECT ContinentCode, CurrencyCode, CurrencyUsage
     FROM (SELECT ContinentCode, CurrencyCode, CurrencyUsage,
        DENSE_RANK() OVER (PARTITION BY ContinentCode ORDER BY CurrencyUsage DESC) AS CurrencyRank
        FROM (SELECT c.ContinentCode, cs.CurrencyCode,
                     COUNT(*) AS CurrencyUsage
	FROM Continents AS c
	JOIN Countries crs on c.ContinentCode = crs.ContinentCode
	JOIN Currencies cs on crs.CurrencyCode = cs.CurrencyCode
	GROUP BY c.ContinentCode, cs.CurrencyCode) AS GroupResult
WHERE CurrencyUsage > 1 ) AS GroupResultTOP1
WHERE GroupResultTOP1.CurrencyRank = 1
ORDER BY ContinentCode