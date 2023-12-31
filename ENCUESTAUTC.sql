
CREATE DATABASE ENCUESTAUTC
GO

USE encuestautc
GO

CREATE TABLE PARTIDOSP
(
	PartidoID INT PRIMARY KEY IDENTITY(1,1),
	Nombre VARCHAR(15)
)
GO

CREATE TABLE FORM
(
	NumEncuesta INT PRIMARY KEY IDENTITY(1,1),
	NombreParticipante VARCHAR(50),
	Edad INT,
	CorreoElectronico VARCHAR(50),
	PartidoP INT,
	CONSTRAINT fk_partido FOREIGN KEY (PartidoP) REFERENCES PARTIDOSP(PartidoID)
)
GO

INSERT INTO PARTIDOSP(Nombre)
VALUES 
('PLN'), ('PUSC'), ('PAC')
GO

CREATE PROCEDURE AGREGAR_FORM
@NOMBRE VARCHAR(50),
@EDAD INT,
@CORREOELEC VARCHAR(50),
@PARTIDOP INT
AS
	BEGIN
		INSERT INTO FORM(NombreParticipante, Edad, CorreoElectronico, PartidoP)
		VALUES(@NOMBRE, @EDAD, @CORREOELEC, @PARTIDOP)
	END
GO

CREATE PROCEDURE CONSULTAR_TODOS_FORM
AS
	BEGIN
		SELECT FORM.NumEncuesta, FORM.NombreParticipante as Nombre, FORM.Edad as Edad, FORM.CorreoElectronico as Correo, PARTIDOSP.Nombre as Partido
		FROM FORM
		INNER JOIN PARTIDOSP ON FORM.PartidoP = PARTIDOSP.PartidoID
	END
GO

CREATE PROCEDURE CONSULTAR_PARTIDOS
AS
	BEGIN
		SELECT CONVERT (VARCHAR (15),PartidoID) + Nombre AS NombrePartido, PartidoID
		FROM PARTIDOSP
	END


INSERT INTO FORM VALUES 
('Dayana', '20', 'daya@utc.com', '1'),
('Genesis', '18', 'genesis@utc.com','2' ),
('Reichel', '21', '@utc.com','3' )


