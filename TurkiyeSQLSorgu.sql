

----- 1- Marmara b�lgesindeki toplam �ehir say�s�n� veren SQL sorgusu


SELECT COUNT(*) AS 'Toplam �ehir Say�s�' 
FROM Sehir 
WHERE BolgeId = 1



------ 2- T�m b�lgelerdeki toplam �ehir say�s�n� veren SQL sorgusu

SELECT BolgeId, COUNT(*) AS 'Toplam �ehir Say�s�' 
FROM Sehir 
GROUP BY BolgeId



------3- En �ok �ehiri olan b�lgeyi getiren SQL sorgusu

SELECT BolgeId, COUNT(*) AS 'Toplam �ehir Say�s�' 
FROM Sehir 
GROUP BY BolgeId 
ORDER BY COUNT(*) DESC LIMIT 1 -- Ya da TOP 1



