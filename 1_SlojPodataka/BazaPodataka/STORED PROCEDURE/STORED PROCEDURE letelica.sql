USE [EvidencijaPopravkiAviona]
GO

CREATE PROCEDURE [DajSveLetelice]
AS
select * from LETELICA
GO

CREATE PROCEDURE [DajLetelicuPoNazivu]
( @NazivLetelice nvarchar(40)
)
AS
select * from LETELICA where LETELICA.Naziv = @NazivLetelice
GO

CREATE PROCEDURE [DajNazivPoRegBr]
( @RegBr char(10)
)
AS
select Naziv from LETELICA where LETELICA.RegBr = @RegBr
GO

CREATE PROCEDURE [DajLetelicuPoRegBr]
( @RegBr char(10)
)
AS
select * from LETELICA where LETELICA.RegBr = @RegBr
GO

CREATE PROCEDURE [DodajNovuLetelicu]
( 
@RegBr char(10),
@Naziv nvarchar(40)
)
AS
BEGIN
Insert into LETELICA(RegBr, Naziv) values (@RegBr, @Naziv)
END
GO

CREATE PROCEDURE [ObrisiLetelicu](
@RegBr char(10))
AS
BEGIN
Delete from LETELICA where RegBr=@RegBr
END
GO

CREATE PROCEDURE [IzmeniLetelicu](
@StariRegBr char(10),
@RegBr char(10),
@Naziv nvarchar(40)
)
AS
BEGIN
Update LETELICA set RegBr=@RegBr, Naziv=@Naziv where RegBr=@StariRegBr
END
GO



