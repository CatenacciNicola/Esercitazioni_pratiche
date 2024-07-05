﻿INSERT INTO [dbo].[Anagrafica] ([Cognome], [Nome], [Indirizzo], [Citta], [Cap], [CodFiscale])
VALUES 
('Rossi', 'Mario', 'Via Roma 1', 'Roma', '00100', 'RSSMRA80A01H501U'),
('Bianchi', 'Luca', 'Via Milano 2', 'Milano', '20100', 'BNCMLU85B02F205X'),
('Verdi', 'Giulia', 'Via Napoli 3', 'Napoli', '80100', 'VRDGLI90C03L720Z'),
('Neri', 'Francesca', 'Via Firenze 4', 'Firenze', '50100', 'NRFNSC95D04D612U'),
('Gialli', 'Paolo', 'Via Torino 5', 'Torino', '10100', 'GLLPLA99E05M860T'),
('Azzurri', 'Anna', 'Via Bologna 6', 'Bologna', '40100', 'AZZANN01F06F206B'),
('Rosa', 'Giuseppe', 'Via Genova 7', 'Genova', '16100', 'RSAGPP02G07Z404C'),
('Marroni', 'Simone', 'Via Venezia 8', 'Venezia', '30100', 'MRNSMN03H08E279Q'),
('Viola', 'Marco', 'Via Verona 9', 'Verona', '37100', 'VLMARC04I09F403K'),
('Blu', 'Elena', 'Via Pisa 10', 'Pisa', '56100', 'BLULNE05L10C629W');


INSERT INTO [dbo].[Violazione] ([Descrizione])
VALUES 
('Eccesso di velocità'),
('Parcheggio vietato'),
('Mancato rispetto del semaforo'),
('Guida in stato di ebbrezza'),
('Uso del telefono cellulare alla guida'),
('Assenza di cinture di sicurezza'),
('Mancato rispetto della precedenza'),
('Sosta su marciapiede'),
('Sosta in doppia fila'),
('Guida senza patente');


INSERT INTO [dbo].[Verbale] ([DataViolazione], [IndirizzoViolazione], [NominativoAgente], [DataTrascrizioneVerbale], [Importo], [DecurtamentoPunti], [IdAnagraficaFK])
VALUES 
('2023-06-01 15:00:00', 'Via Roma 1', 'Agente Rossi', '2023-06-02 09:00:00', 150.00, 2, 1),
('2023-06-05 10:00:00', 'Via Milano 2', 'Agente Bianchi', '2023-06-06 11:00:00', 100.00, 1, 2),
('2023-06-10 16:45:00', 'Via Napoli 3', 'Agente Verdi', '2023-06-11 12:30:00', 200.00, 3, 3),
('2023-06-15 08:15:00', 'Via Firenze 4', 'Agente Neri', '2023-06-16 10:00:00', 300.00, 5, 4),
('2023-06-20 12:00:00', 'Via Torino 5', 'Agente Gialli', '2023-06-21 13:00:00', 250.00, 4, 5),
('2023-06-25 09:30:00', 'Via Bologna 6', 'Agente Azzurri', '2023-06-26 15:00:00', 50.00, 0, 6),
('2023-06-30 18:00:00', 'Via Genova 7', 'Agente Rosa', '2023-07-01 09:30:00', 75.00, 1, 7),
('2023-07-05 07:45:00', 'Via Venezia 8', 'Agente Marroni', '2023-07-06 11:30:00', 125.00, 2, 8),
('2023-07-10 20:00:00', 'Via Verona 9', 'Agente Viola', '2023-07-11 12:45:00', 175.00, 3, 9),
('2023-07-15 14:00:00', 'Via Pisa 10', 'Agente Blu', '2023-07-16 14:30:00', 225.00, 4, 10);


INSERT INTO [dbo].[ViolazioniAVerbale] ([IdVerbaleFK], [IdViolazioneFK])
VALUES 
(1, 1),
(2, 2),
(3, 3),
(4, 4),
(5, 5),
(6, 6),
(7, 7),
(8, 8),
(9, 9),
(10, 10),
(1, 2),
(2, 3),
(3, 4),
(4, 5),
(5, 6),
(6, 7),
(7, 8),
(8, 9),
(9, 10),
(10, 1);
