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
 ordenFechaIngreso DATETIME NULL,
 ordenUsuarioNombre VARCHAR(100),
 ordenFechaInicioCoordinacion DATE NULL,
 ordenFechaFinCoordinacion DATE NULL,
 ordenFechaFinalizacion DATE NULL,
 ordenMovil VARCHAR(50) NULL,
 ordenLugar VARCHAR(50) NULL,
 ordenEstado VARCHAR(50) NULL,
 ordenComentario VARCHAR(1000) NULL,
 ordenEmpresaId INT FOREIGN KEY REFERENCES Empresa(empresaId) NULL,
 ordenEmpresaNombre VARCHAR (50) NULL,
 ordenFuncionarioId INT FOREIGN KEY REFERENCES Funcionario(funcionarioId) NULL,
 ordenFuncionarioNombre VARCHAR(50) NULL,
 ordenFuncionarioApellido VARCHAR(50) NULL
)

INSERT INTO Usuario VALUES('49260752','Nicolás','Barreto','nbarreto@acu.com.uy','1234',0)
INSERT INTO Empresa VALUES('ACU',5,800,1800)
INSERT INTO Empresa VALUES('ACUTEST',8,1000,1800)
select * from Empresa