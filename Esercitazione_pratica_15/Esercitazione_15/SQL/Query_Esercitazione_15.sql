--1 Conteggio dei verbali trascritti
SELECT COUNT(*) AS TotaleVerbali
FROM Verbale


--2 Conteggio dei verbali trascritti raggruppati per anagrafe
SELECT IdAnagrafica, COUNT(IdVerbale) AS TotaleVerbaliPerPersona
FROM Verbale AS V
INNER JOIN Anagrafica as A ON V.IdAnagraficaFK=A.IdAnagrafica
GROUP BY IdAnagrafica
--2 alternativo
SELECT IdAnagraficaFK, COUNT(IdVerbale) AS TotaleVerbaliPerPersona
FROM Verbale
GROUP BY IdAnagraficaFK


--3 Conteggio dei verbali trascritti raggruppati per tipo di violazione
SELECT Descrizione, COUNT(IdViolazioniAVerbale) AS TotaleVerbaliPerViolazione
FROM ViolazioniAVerbale
INNER JOIN Violazione on ViolazioniAVerbale.IdViolazioneFK=Violazione.IdViolazione
GROUP BY Descrizione


--4 Totale dei punti decurtati per ogni anagrafe
SELECT A.Cognome,A.Nome, SUM(V.DecurtamentoPunti) AS TotalePuntiDecurtati
FROM Verbale AS V
INNER JOIN Anagrafica AS A ON V.IdAnagraficaFK=A.IdAnagrafica
GROUP BY A.Cognome ,A.Nome 
ORDER BY A.Cognome ASC, A.Nome DESC


--5 Cognome, Nome, Data violazione, Indirizzo violazione, importo e punti decurtati per tutti gli anagrafici residenti a Palermo
SELECT A.Nome,A.Cognome,V.DataViolazione,V.IndirizzoViolazione,V.Importo,V.DecurtamentoPunti
FROM Verbale AS V
RIGHT JOIN Anagrafica AS A ON V.IdAnagraficaFK=A.IdAnagrafica
WHERE A.Citta='Palermo'


--6 Cognome, Nome, Indirizzo, Data violazione, importo e punti decurtati per le violazioni fatte tra il febbraio 2009 e luglio 2009
SELECT A.Nome,A.Cognome,A.Indirizzo,V.DataViolazione,V.Importo,V.DecurtamentoPunti
FROM Verbale AS V
INNER JOIN Anagrafica AS A ON V.IdAnagraficaFK=A.IdAnagrafica
WHERE V.DataViolazione BETWEEN '2009-02-01' AND '2009-07-31'

--7 Totale degli importi per ogni anagrafico
SELECT A.IdAnagrafica, SUM(V.Importo) AS TotaleImporti
FROM Verbale AS V
INNER JOIN Anagrafica AS A ON V.IdAnagraficaFK=A.IdAnagrafica
GROUP BY A.IdAnagrafica
--7 alternativo
SELECT IdAnagraficaFK, SUM(Importo) AS TotaleImporti
FROM Verbale
GROUP BY IdAnagraficaFK


--8 Visualizzazione di tutti gli anagrafici residenti a Palermo
SELECT *
FROM Anagrafica
WHERE Citta='Palermo'


--9 Query che visualizzi Data violazione, Importo e decurta mento punti relativi ad una certa data
SELECT DataViolazione,Importo,DecurtamentoPunti
FROM Verbale
WHERE CAST(DataViolazione AS DATE)='2023-06-01' --Dico che DataViolazione è DATE per permettere il confronto altrimenti impedito dalla presenza dell'ora 
-- WHERE DataViolazione='2023-06-01 15:00:00' --In alternativa contronto anche l'ora
-- WHERE DataViolazione BETWEEN '2023-06-01 00:00:00' AND '2023-06-01 23:59:59' --In alternativa fornisco l'intervallo tra mezzanotte e mezzanotte del giorno e cerco corrispondenza in quel range


--10 Conteggio delle violazioni contestate raggruppate per Nominativo dell’agente di Polizia
SELECT NominativoAgente, COUNT(*) AS TotaleViolazioni
FROM Verbale
GROUP BY NominativoAgente


--11 Cognome, Nome, Indirizzo, Data violazione, Importo e punti decurtati per tutte le violazioni che superino il decurtamento di 5 punti
SELECT A.Cognome,A.Nome,A.Indirizzo,V.DataViolazione,V.Importo,V.DecurtamentoPunti
FROM Verbale AS V
INNER JOIN Anagrafica AS A ON V.IdAnagraficaFK=A.IdAnagrafica
WHERE V.DecurtamentoPunti>5


--12 Cognome, Nome, Indirizzo, Data violazione, Importo e punti decurtati per tutte le violazioni che superino l’importo di 400 euro
SELECT A.Cognome,A.Nome,A.Indirizzo,V.DataViolazione,V.Importo,V.DecurtamentoPunti
FROM Verbale AS V
INNER JOIN Anagrafica AS A ON V.IdAnagraficaFK=A.IdAnagrafica
WHERE V.Importo>400
