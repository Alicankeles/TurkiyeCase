

----- 1- Marmara bölgesindeki toplam þehir sayýsýný veren SQL sorgusu


SELECT COUNT(*) AS 'Toplam Þehir Sayýsý' 
FROM Sehir 
WHERE BolgeId = 1



------ 2- Tüm bölgelerdeki toplam þehir sayýsýný veren SQL sorgusu

SELECT BolgeId, COUNT(*) AS 'Toplam Þehir Sayýsý' 
FROM Sehir 
GROUP BY BolgeId



------3- En çok þehiri olan bölgeyi getiren SQL sorgusu

SELECT BolgeId, COUNT(*) AS 'Toplam Þehir Sayýsý' 
FROM Sehir 
GROUP BY BolgeId 
ORDER BY COUNT(*) DESC LIMIT 1 -- Ya da TOP 1



