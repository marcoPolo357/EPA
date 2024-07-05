USE [EvidencijaPopravkiAviona]
GO

CREATE PROCEDURE [DajSveOperatere]
AS
Select * from OPERATER
GO

CREATE PROCEDURE [DajSveOperatereSaJoin] 
AS
Select OPERATER.JMBG, OPERATER.Prezime, OPERATER.Ime, LETELICA.Naziv as NazivLetelice from OPERATER inner join LETELICA on OPERATER.IDLetelice = LETELICA.RegBr
GO

CREATE PROCEDURE [DajOperateraPoPrezimenu] @OperaterPrezime nvarchar(30)
AS
select OPERATER.JMBG, OPERATER.Ime, OPERATER.Prezime, LETELICA.Naziv as NazivLetelice from OPERATER inner join LETELICA on LETELICA.RegBr = OPERATER.IDLetelice where OPERATER.Prezime = @OperaterPrezime
GO

CREATE PROCEDURE [DajOperateraPoJMBG] @OperaterJMBG char(13)
AS
BEGIN
    Select * from OPERATER 
    where OPERATER.JMBG = @OperaterJMBG
END
GO

CREATE PROCEDURE [DajBrojOperateraZaLetelicu] @IDLetelice char(10)
AS
BEGIN
    SELECT COUNT(*) as BrojOperatera
    FROM OPERATER
    WHERE OPERATER.IDLetelice = @IDLetelice
END
GO

CREATE PROCEDURE [DodajNovogOperatera]( 
@JMBG [Char] (13),
@Prezime nvarchar(40),
@Ime nvarchar(40),
@IDLetelice char(10))
AS
BEGIN
Insert into OPERATER(JMBG, Prezime, Ime, IDLetelice) values (@JMBG, @Prezime, @Ime, @IDLetelice)
END
GO

CREATE PROCEDURE [ObrisiOperatera](
@JMBG [Char] (13))
AS
BEGIN
Delete from OPERATER where JMBG=@JMBG
END
GO

CREATE PROCEDURE [IzmeniOperatera](
@StariJMBG [Char] (13),
@JMBG [Char] (13),
@Prezime nvarchar(40),
@Ime nvarchar(40),
@IDLetelice char(10))
AS
BEGIN
Update OPERATER set JMBG=@JMBG, Prezime=@Prezime, Ime=@Ime, IDLetelice=@IDLetelice where JMBG=@StariJMBG
END
GO


CREATE PROCEDURE [DajSveOperatereSaJoinRegBrLetelice] 
AS
Select OPERATER.JMBG, OPERATER.Prezime, OPERATER.Ime, LETELICA.Naziv as NazivLetelice, LETELICA.RegBr as RegBrLetelice from OPERATER inner join LETELICA on OPERATER.IDLetelice = LETELICA.RegBr
GO