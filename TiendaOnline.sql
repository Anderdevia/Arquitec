create database TIENDAONLINE
GO
USE TIENDAONLINE
GO

CREATE TABLE [dbo].[Proveedor](
	[id] [int] IDENTITY(1,1) PRIMARY KEY NOT NULL,
	[empresa] [varchar](50) NOT NULL,
	[nombre] [varchar](50) NOT NULL,
	[cargo] [varchar](50) NOT NULL,
	[districto] [int] NOT NULL,
	[telefono] [nchar](10) NOT NULL)

GO
CREATE TABLE [dbo].[Categoria](
	[id] [int] IDENTITY(1,1) PRIMARY KEY NOT NULL,
	[nombre] [varchar](200) NOT NULL,
	[descripcion] [varchar](500) NULL)
GO
SET IDENTITY_INSERT [dbo].[PROVEEDOR] ON 

INSERT [dbo].[PROVEEDOR] ([id], [empresa], [nombre], [cargo], [districto], [telefono]) VALUES (0, N'TECNOLOGIES', N'ELON MUSK', N'GERENTE', 1, N'999191919 ')
INSERT [dbo].[PROVEEDOR] ([id], [empresa], [nombre], [cargo], [districto], [telefono]) VALUES (1, N'KobeKe Technology Ltd', N'JORGE ASTAMBUR', N'TECNICO ASISTENTE', 2, N'976223455 ')
INSERT [dbo].[PROVEEDOR] ([id], [empresa], [nombre], [cargo], [districto], [telefono]) VALUES (2, N'GOLDOW TECNOLGY', N'ADRIAN CESPEDES', N'ASISTENTE ', 3, N'922922123 ')
INSERT [dbo].[PROVEEDOR] ([id], [empresa], [nombre], [cargo], [districto], [telefono]) VALUES (3, N'No hay devolucion', N'Vizcarra', N'Presidente', 1, N'974325134 ')
INSERT [dbo].[PROVEEDOR] ([id], [empresa], [nombre], [cargo], [districto], [telefono]) VALUES (4, N'Xiaomi Store', N'Chinito ', N'Gerente', 3, N'963838332 ')
INSERT [dbo].[PROVEEDOR] ([id], [empresa], [nombre], [cargo], [districto], [telefono]) VALUES (2006, N'Sert Post', N'Juan ', N'Cartero', 2, N'974735657 ')
SET IDENTITY_INSERT [dbo].[PROVEEDOR] OFF
GO
SET IDENTITY_INSERT [dbo].[CATEGORIA] ON 
INSERT [dbo].[CATEGORIA] ([id], [nombre], [DESCRIPCION]) VALUES (1, N'Electronica', N'TECLADOS, MEMORIAS')
INSERT [dbo].[CATEGORIA] ([id], [nombre], [DESCRIPCION]) VALUES (2, N'Informatica', N'reloj, mouse')
INSERT [dbo].[CATEGORIA] ([id], [nombre], [DESCRIPCION]) VALUES (3, N'Inteligencia', N'Bombilla Wif, Arduino')
INSERT [dbo].[CATEGORIA] ([id], [nombre], [DESCRIPCION]) VALUES (4, N'TECNOLOGIA', N'DRONES')
INSERT [dbo].[CATEGORIA] ([id], [nombre], [DESCRIPCION]) VALUES (5, N'SMARPHONE', N'XIAOMI , SAMSUNG')
SET IDENTITY_INSERT [dbo].[CATEGORIA] OFF
go
CREATE   TABLE [dbo].[Productos](
	[id] [int] IDENTITY(1,1) PRIMARY KEY  NOT NULL,
	[Nombre] [varchar](200) NULL,
	[descripcion] [varchar](500) NULL,
	[referencia] [int] NULL,
	[stock] [int] NOT NULL,
	[Categoria] [varchar](20) NULL,
	[precio] [numeric](20,2) NULL,
	[id_tipo] [int] NOT NULL,
	[id_proveedor] [int] NOT NULL,
	[ruta_imagen] [varchar](100) NULL
	)

GO
CREATE PROC [dbo].[Lista_ProductosTienda]
AS
SELECT P.id,P.Nombre,P.descripcion,P.precio,P.stock,C.nombre,prov.empresa,P.ruta_imagen
FROM dbo.Productos P 
INNER JOIN dbo.PROVEEDOR prov
ON P.id_proveedor=prov.id
INNER JOIN DBO.CATEGORIA C 
ON P.Categoria=C.id
GO
	CREATE  PROCEDURE [dbo].[Listar_Productos]
		AS 
		BEGIN
		SELECT * FROM  Productos

		END

GO
GO
	CREATE  PROCEDURE [dbo].[Listar_Proveedor]
		AS 
		BEGIN
		SELECT * FROM Proveedor

		END

GO
	CREATE  PROCEDURE [dbo].[Listar_Categoria]
		AS 
		BEGIN
		SELECT * FROM Categoria

		END

GO
	CREATE  PROCEDURE [dbo].[Insertar_Productos]
		@nombre varchar(200) null,
		@descripcion varchar (500) null,
		@referencia int        null,
		@Categoria varchar(20) null,
		@precio numeric(20,2)  null,
		@stock int  null,
		@id_tipo int  NULL,
	    @id_proveedor int  NULL,
	    @ruta_imagen varchar(100) NULL
		AS
		BEGIN
 
		 INSERT INTO Productos(Nombre,descripcion,referencia,stock,Categoria,precio,id_tipo,id_proveedor,ruta_imagen) 
		 VALUES (@nombre,@descripcion,@referencia,@stock,@Categoria,@precio,@id_tipo,@id_proveedor,@ruta_imagen)

		END  
GO

 CREATE  PROCEDURE [dbo].[Editar_Productos]
        @id int,
        @nombre varchar(200) null,
		@descripcion varchar (500) null,
		@referencia int        null,
		@Categoria varchar(20) null,
		@precio numeric(20,2)  null
		AS
		BEGIN
 
		  UPDATE Productos SET 
    
			 Nombre =@nombre,
			 descripcion =@descripcion,
			 referencia =@referencia,
			 Categoria = @Categoria,
			 precio = @precio 

			WHERE id = @id

		 END

GO
 CREATE PROCEDURE [dbo].[Eliminar_Productos]

	@id int 
	AS
	BEGIN
 
	   DELETE FROM Productos 
	   WHERE id = @id

	 END

GO
 CREATE PROCEDURE [dbo].[Seleccionar_Producto]
	@id int
	AS 
	BEGIN
	
	SELECT * FROM Productos WHERE id =@id

	END
GO