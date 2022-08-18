CREATE DATABASE BD_Zoologico;
USE BD_Zoologico;

GO 
CREATE TABLE Especies(
Id TINYINT IDENTITY(1,1),
Nombre VARCHAR(30) NOT NULL,
CONSTRAINT pk_especia PRIMARY KEY (Id)
);

INSERT Especies
VALUES ('Mamiferos'),
		('Reptiles'),
		('Aves'),
		('Peces'),
		('Insectos'),
		('Anfibios');

INSERT Especies
VALUES ('Moluscos'),
('Cetaceos');

INSERT Especies
VALUES
('Corales');
GO
---CREAR PROCEDIMIENTO ALMACENADO
--METER EN UN ESQUEMA
--user stored procedure
CREATE PROC usp_AgregarEspecies
--@Variable o parametro
--@Parametro en un Proceso almacenado
@nombre VARCHAR(30) --VALOR DE ENTRADA:PARAMETROS
AS--CUERPO: LO QUE PUEDE HACER
INSERT Especies 
VALUES(@nombre);
GO

--probar PROC
--Ejecución:
--Posición o referencia
EXEC usp_AgregarEspecies
@nombre='Calamares'

EXEC usp_AgregarEspecies 'Aracnidos';

SELECT * FROM Especies

GO
CREATE PROC usp_Eliminar
@ide TINYINT
AS
DELETE FROM Especies
WHERE Id=@ide
GO

CREATE PROC usp_Buscar
@ide TINYINT
AS
SELECT * FROM Especies
WHERE Id=@ide
--select @@SERVERNAME;
GO
CREATE PROC usp_Consultar
AS
SELECT * FROM Especies
GO

CREATE PROC usp_Actualizar
@ide TINYINT,
@nombre VARCHAR(30)
AS
UPDATE Especies
SET Nombre=@nombre
WHERE Id=@ide;
GO

