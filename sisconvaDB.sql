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
	filename = 'C:\Program Files\Microsoft SQL Server\MSSQL10_50.MSSQLSERVER\MSSQL\DATA\Sisconve.mdf'
	
  )
GO

USE Sisconve
GO

--
CREATE TABLE Usuario(
	usuarioCi VARCHAR (10) PRIMARY KEY,
	usuarioNombres VARCHAR(50) NULL,
	usuarioApellidos VARCHAR(50) NULL,
	usuarioEmail VARCHAR(50) CHECK ( usuarioEmail like '[a-z,0-9,_,-]%@[a-z,0-9,_,-]%.[a-z][a-z]%' ) UNIQUE NOT NULL,
	usuarioPassword VARCHAR(500) NOT NULL,
	usuarioEstado BIT DEFAULT(0) NOT NULL
)

