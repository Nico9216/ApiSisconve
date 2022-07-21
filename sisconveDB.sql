USE master
GO

if exists (select * from sys.databases where name = 'Sisconve')
BEGIN
	DROP DATABASE Sisconve
END 
GO


-- Creo la Base de Datos
CREATE DATABASE Sisconve
ON(
	name = Nada,
	--filename = 'C:\Program Files\Microsoft SQL Server\MSSQL10_50.MSSQLSERVER\MSSQL\DATA\Sisconve.mdf'
	filename = 'C:\Sisconve.mdf'
  )
GO

USE Sisconve
GO

--
CREATE TABLE Usuario(
	usuarioId INT IDENTITY(1,1),
	usuarioCi VARCHAR (10) ,
	usuarioNombres VARCHAR(50) NULL,
	usuarioApellidos VARCHAR(50) NULL,
	usuarioEmail VARCHAR(50) CHECK ( usuarioEmail like '[a-z,0-9,_,-]%@[a-z,0-9,_,-]%.[a-z][a-z]%' ) UNIQUE NOT NULL,
	usuarioPassword VARCHAR(500) NOT NULL,
	usuarioEstado BIT DEFAULT(0) NOT NULL
)



CREATE TABLE Empresa(
	empresaId INT Identity(1,1) PRIMARY KEY,
	empresaNombre VARCHAR(50) NOT NULL,
	empresaCantEmpleados INT NULL,
	empresaHorarioInicio INT NULL,
	empresaHorarioFin INT NULL,
)

CREATE TABLE Funcionario(
	funcionarioId INT IDENTITY(1,1) PRIMARY KEY,
	funcionarioNombre VARCHAR(50) NOT NULL,
	funcionarioApellido VARCHAR(50) NOT NULL,
	funcionarioCargo VARCHAR(50) NULL,
	funcionarioEmpresaId INT FOREIGN KEY REFERENCES Empresa(empresaId),
	funcionarioEstado VARCHAR(20) NOT NULL

)

CREATE TABLE Orden(
 ordenId BIGINT IDENTITY(1,1)  PRIMARY KEY,
 ordenNumero BIGINT UNIQUE,
 ordenNombreOrganizacion VARCHAR(100),
 ordenMovil VARCHAR(10) NULL,
 ordenMatricula VARCHAR(10) NULL,
 ordenEstado VARCHAR(50) NULL,
 ordenFechaInicioCoordinacion DATE NULL,
 ordenFechaFinCoordinacion DATE NULL,
 ordenFechaFinalizacion DATE NULL,
 ordenUsuarioNombreFinalizo VARCHAR(100) NULL,
 ordenTmpoTrabajoEnMdeo VARCHAR(10) NULL,
 ordenTmpoTrabajoEnInterior VARCHAR(10) NULL,
 ordenFechaPrimeraCarga DATE NULL,
 ordenSerieDPL VARCHAR(50) NULL,
 ordenDeviceIdDPL VARCHAR(50) NULL,
 ordenSerieDataPass VARCHAR(50) NULL,
 ordenMACDataPass VARCHAR(50) NULL,
 ordenSerieTAGReader VARCHAR(50) NULL,
 ordenNroTAGReader VARCHAR(50) NULL,
 ordenChip VARCHAR(50) NULL,
 ordenDivision VARCHAR(100) NULL,
 ordenFlota VARCHAR(100) NULL,
 ordenCardId VARCHAR(50) NULL,
 ordenBobina VARCHAR(10) NULL,
 ordenComentarioInicial VARCHAR(500) NULL,
 ordenTrazaOrden VARCHAR(50) NULL,
 ordenInstalaDPL BIT NOT NULL,
 ordenInstalaDataPass BIT NOT NULL,
 ordenInstalaTAGReader BIT NOT NULL,
 ordenInstalaInmovilizador BIT NOT NULL,
 ordenLugar VARCHAR(20) NULL,
 ordenZonaGira VARCHAR(20) NULL,
 ordenNroParte VARCHAR(50) NULL,
 ordenCapacidadTanqueMIM VARCHAR(10) NULL,
 ordenCapacidadTanqueMIMTec VARCHAR(10) NULL,
 ordenInstalaCA BIT NOT NULL,
 ordenPudoInstalarCS BIT NOT NULL,
 ordenInstalaMebiclick BIT NOT NULL,
 ordenEncendidoPorMotor BIT NOT NULL,
 ordenComentarioFinales VARCHAR(1000) NULL

)

INSERT INTO Usuario VALUES('49260752','Nicolás','Barreto','nbarreto@acu.com.uy','1234',0)
INSERT INTO Empresa VALUES('ACU',5,800,1800)
INSERT INTO Empresa VALUES('ACUTEST',8,1000,1800)
select * from Empresa