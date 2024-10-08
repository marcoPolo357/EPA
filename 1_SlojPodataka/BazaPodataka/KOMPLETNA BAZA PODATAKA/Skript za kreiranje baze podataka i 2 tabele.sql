USE [master]
GO

CREATE DATABASE [EvidencijaPopravkiAviona] 
GO

USE [EvidencijaPopravkiAviona]
GO

CREATE TABLE [dbo].[OPERATER](
	[JMBG] [Char] (13) NOT NULL,
	[Prezime] [nvarchar](40) NOT NULL,
	[Ime] [nvarchar](40) NOT NULL,
	[IDLetelice] [char](10) NOT NULL
)
GO

ALTER TABLE [dbo].[OPERATER]
ADD CONSTRAINT [PK_OPERATER] PRIMARY KEY CLUSTERED 
(
	[JMBG] ASC
)

GO

CREATE TABLE [dbo].[LETELICA](
	[RegBr] [Char] (10) NOT NULL,
	[Naziv] [nvarchar](40) NOT NULL,
)
GO

ALTER TABLE [dbo].[LETELICA]
ADD CONSTRAINT [PK_LETELICA] PRIMARY KEY CLUSTERED
(
	[RegBr] ASC
)
GO

ALTER TABLE [dbo].[OPERATER] ADD CONSTRAINT
[FK_OPERATER_LETELICA] FOREIGN KEY([IDLetelice])
REFERENCES [dbo].[LETELICA] ([RegBr])
ON UPDATE CASCADE
GO


CREATE TABLE [dbo].[Korisnik](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Prezime] [nvarchar](40) NOT NULL,
	[Ime] [nvarchar](30) NOT NULL,
	[KorisnickoIme] [nvarchar](20) NOT NULL,
	[Sifra] [nvarchar](30) NOT NULL,
	[Status] [nvarchar](10) NOT NULL
)

GO 

INSERT INTO [dbo].[Korisnik] (Prezime, Ime, KorisnickoIme, Sifra, Status)
VALUES ('Smiljanić', 'Marko', 'msmiljanic', 'ms', 'admin');

INSERT INTO LETELICA (RegBr, Naziv)
VALUES ('N123AB', 'H - C130 Globemaster');

INSERT INTO LETELICA (RegBr, Naziv)
VALUES ('G-BHXY', 'M - Airbus A320');

INSERT INTO LETELICA (RegBr, Naziv)
VALUES ('D-AFTR', 'L - Cessna 172');

INSERT INTO OPERATER (JMBG, Prezime, Ime, IDLetelice)
VALUES 
('0101985850001', 'Petrović', 'Milan', 'N123AB'),
('1507955850023', 'Jovanović', 'Nikola', 'N123AB'),
('2312935850045', 'Đorđević', 'Marko', 'N123AB'),
('0804935850002', 'Lazić', 'Ana', 'G-BHXY'),
('0912885850015', 'Nikolić', 'Jovana', 'G-BHXY'),
('2511955850034', 'Stanković', 'Ivana', 'D-AFTR');
