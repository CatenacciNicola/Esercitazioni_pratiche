-- Creazione tabelle

CREATE TABLE [dbo].[Camere] (
    [Numero]      INT             NOT NULL,
    [Descrizione] NVARCHAR (100)  NOT NULL,
    [Tipologia]   NVARCHAR (20)   NOT NULL,
    [TariffaBase] DECIMAL (18, 2) NOT NULL,
    PRIMARY KEY CLUSTERED ([Numero] ASC)
);

CREATE TABLE [dbo].[Clienti] (
    [CodiceFiscale] NVARCHAR (16) NOT NULL,
    [Cognome]       NVARCHAR (50) NOT NULL,
    [Nome]          NVARCHAR (50) NOT NULL,
    [Citta]         NVARCHAR (50) NOT NULL,
    [Provincia]     NVARCHAR (50) NOT NULL,
    [Email]         NVARCHAR (50) NOT NULL,
    [Telefono]      NVARCHAR (15) NOT NULL,
    [Cellulare]     NVARCHAR (15) NOT NULL,
    PRIMARY KEY CLUSTERED ([CodiceFiscale] ASC)
);

CREATE TABLE [dbo].[Prenotazioni] (
    [Id]                    INT             IDENTITY (1, 1) NOT NULL,
    [CodiceFiscaleCliente]  NVARCHAR (16)   NOT NULL,
    [NumeroCamera]          INT             NOT NULL,
    [DataPrenotazione]      DATETIME        NOT NULL,
    [NumeroProgressivoAnno] INT             NOT NULL,
    [Anno]                  INT             NOT NULL,
    [Dal]                   DATETIME        NOT NULL,
    [Al]                    DATETIME        NOT NULL,
    [CaparraConfirmatoria]  DECIMAL (18, 2) NOT NULL,
    [TariffaApplicata]      DECIMAL (18, 2) NOT NULL,
    [TrattamentoId]         INT             NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    FOREIGN KEY ([CodiceFiscaleCliente]) REFERENCES [dbo].[Clienti] ([CodiceFiscale]),
    FOREIGN KEY ([NumeroCamera]) REFERENCES [dbo].[Camere] ([Numero]),
    FOREIGN KEY ([TrattamentoId]) REFERENCES [dbo].[Trattamenti] ([Id])
);

CREATE TABLE [dbo].[Servizi] (
    [Id] INT IDENTITY(1,1) PRIMARY KEY,
    [Descrizione] VARCHAR(100) NOT NULL,
    [Prezzo] DECIMAL(10, 2) NOT NULL
);

CREATE TABLE [dbo].[Trattamenti] (
    [Id]                   INT             IDENTITY (1, 1) NOT NULL,
    [Descrizione]          NVARCHAR (50)   NOT NULL,
    [TariffaSupplementare] DECIMAL (18, 2) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

CREATE TABLE [dbo].[Prenotazioni_Servizi] (
    [Id]             INT IDENTITY (1, 1) NOT NULL,
    [IdPrenotazione] INT NOT NULL,
    [IdServizio]     INT NOT NULL,
    [Data] DATETIME NOT NULL, 
    [Quantita] INT NOT NULL, 
    [Prezzo] NCHAR(10) NOT NULL, 
    PRIMARY KEY CLUSTERED ([Id] ASC),
    FOREIGN KEY ([IdPrenotazione]) REFERENCES [dbo].[Prenotazioni] ([Id]),
    FOREIGN KEY ([IdServizio]) REFERENCES [dbo].[Servizi] ([id])
);


CREATE TABLE Users (
    Id INT PRIMARY KEY IDENTITY,
    Username NVARCHAR(50) NOT NULL,
    Password NVARCHAR(50) NOT NULL
);


-- Popolamento della tabella Camere
INSERT INTO [dbo].[Camere] (Numero, Descrizione, Tipologia, TariffaBase) VALUES
(101, 'Camera singola con vista mare', 'Singola', 50.00),
(102, 'Camera doppia con balcone', 'Doppia', 75.00),
(103, 'Suite con jacuzzi', 'Doppia', 150.00),
(104, 'Camera singola con vista giardino', 'Singola', 45.00),
(105, 'Camera singola con terrazza', 'singola', 60.00);

-- Popolamento della tabella Clienti
INSERT INTO [dbo].[Clienti] (CodiceFiscale, Cognome, Nome, Citta, Provincia, Email, Telefono, Cellulare) VALUES
('RSSMRA80A01H501Z', 'Rossi', 'Mario', 'Roma', 'RM', 'mario.rossi@example.com', '0612345678', '3281234567'),
('BNCFNC85B01C352T', 'Bianchi', 'Francesca', 'Milano', 'MI', 'francesca.bianchi@example.com', '0256789123', '3398765432'),
('VRDGPP90C01F205X', 'Verdi', 'Giuseppe', 'Napoli', 'NA', 'giuseppe.verdi@example.com', '0812345678', '3312345678'),
('BLUSLT95D01H501Y', 'Blu', 'Silvia', 'Torino', 'TO', 'silvia.blu@example.com', '0112345678', '3401234567'),
('NERLRA00E01M132W', 'Neri', 'Luca', 'Firenze', 'FI', 'luca.neri@example.com', '0556789123', '3387654321');

-- Popolamento della tabella Trattamenti
INSERT INTO [dbo].[Trattamenti] (Descrizione, TariffaSupplementare) VALUES
('Colazione inclusa', 10.00),
('Mezza pensione', 25.00),
('Pensione completa', 40.00);

--Popolamento della tabella Servizi
INSERT INTO [dbo].[Servizi] (Descrizione, Prezzo) VALUES
('Colazione in camera', 15.00),
('Bevande e cibo nel mini bar', 20.00),
('Internet', 5.00),
('Letto aggiuntivo', 25.00),
('Culla', 10.00);

-- Popolamento della tabella Users
INSERT INTO Users (Username, Password) VALUES
('user1', 'password1'),
('user2', 'password2'),
('user3', 'password3');


