USE [master]
GO
/****** Object:  Database [Paleteria]    Script Date: 12/04/2018 12:32:02 p. m. ******/
CREATE DATABASE [Paleteria] ON  PRIMARY 
( NAME = N'Paleteria', FILENAME = N'c:\Program Files (x86)\Microsoft SQL Server\MSSQL.1\MSSQL\DATA\Paleteria.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'Paleteria_log', FILENAME = N'c:\Program Files (x86)\Microsoft SQL Server\MSSQL.1\MSSQL\DATA\Paleteria_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [Paleteria] SET COMPATIBILITY_LEVEL = 90
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Paleteria].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Paleteria] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Paleteria] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Paleteria] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Paleteria] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Paleteria] SET ARITHABORT OFF 
GO
ALTER DATABASE [Paleteria] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Paleteria] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [Paleteria] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Paleteria] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Paleteria] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Paleteria] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Paleteria] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Paleteria] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Paleteria] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Paleteria] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Paleteria] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Paleteria] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Paleteria] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Paleteria] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Paleteria] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Paleteria] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Paleteria] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Paleteria] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Paleteria] SET  MULTI_USER 
GO
ALTER DATABASE [Paleteria] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Paleteria] SET DB_CHAINING OFF 
GO
USE [Paleteria]
GO
/****** Object:  User [paleteria]    Script Date: 12/04/2018 12:32:02 p. m. ******/
CREATE USER [paleteria] FOR LOGIN [paleteria] WITH DEFAULT_SCHEMA=[dbo]
GO
ALTER ROLE [db_owner] ADD MEMBER [paleteria]
GO
ALTER ROLE [db_accessadmin] ADD MEMBER [paleteria]
GO
/****** Object:  StoredProcedure [dbo].[llenarGridInventario]    Script Date: 12/04/2018 12:32:02 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Jaime Castorena
-- Create date: 10-04-2018
-- Description:	Obtiene el inventario por ubicación
-- =============================================
CREATE PROCEDURE [dbo].[llenarGridInventario]
	@idUbicacion int= null
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	select p.idProducto, p.nombreProducto, u.nombreUbicacion, cantidad
	from producto p
	inner join productoUbicacion pu on pu.idProducto = p.idProducto
	inner join ubicacion u on u.idUbicacion = pu.idUbicacion
	where pu.idUbicacion = @idUbicacion
END

GO
/****** Object:  StoredProcedure [dbo].[SP_tabla_categoria]    Script Date: 12/04/2018 12:32:02 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_tabla_categoria]
   	@Operacion varchar(1),
  	@idCategoria int,
	@nombre nvarchar(50),
	@cuentaInventario bit,
	@cuentaVenta bit

AS
BEGIN
 

/* -------------------------------------------------------------------------------------
    Table:       categoria 
   ------------------------------------------------------------------------------------- */



/* -------------------------------------------------------------------------------------
    Description: Operacion de insercion de registro.
   ------------------------------------------------------------------------------------- */
IF @Operacion = 'I'  BEGIN
   DECLARE @regs int
   SET @regs=(SELECT MAX(idCategoria)+1 FROM categoria)
   IF @regs IS NULL  SET @regs=1;
 
  INSERT INTO categoria
        (
		idCategoria,
		nombre,
		cuentaInventario,
		cuentaVenta

	)
  VALUES
        (
        @regs,
		
		@nombre,
		@cuentaInventario,
		@cuentaVenta

	)
END

 
/* -------------------------------------------------------------------------------------
    Description: Operacion de actualizacion de un registro.
   ------------------------------------------------------------------------------------- */
IF @Operacion = 'U'  BEGIN
  UPDATE categoria SET
  
		
		nombre = @nombre,
		cuentaInventario = @cuentaInventario,
		cuentaVenta = @cuentaVenta

 
  WHERE idCategoria=@idCategoria
END
 

/* -------------------------------------------------------------------------------------
    Description: Operacion de eliminaci�n de un registro.
   ------------------------------------------------------------------------------------- */
IF @Operacion = 'D'  BEGIN
   DELETE FROM categoria WHERE idCategoria=@idCategoria
END
 

/* -------------------------------------------------------------------------------------
    Description: Operacion de busqueda de un registro por su ID.
   ------------------------------------------------------------------------------------- */
IF @Operacion = 'F'  BEGIN
   SELECT  * 
   FROM categoria
   WHERE  idCategoria=@idCategoria
END
 

/* -------------------------------------------------------------------------------------
    Description: Operacion de seleccion de todos los registros.
   ------------------------------------------------------------------------------------- */
IF @Operacion = 'S'  BEGIN
   SELECT  *
   FROM categoria
END
 
END

GO
/****** Object:  StoredProcedure [dbo].[SP_tabla_pantalla]    Script Date: 12/04/2018 12:32:02 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_tabla_pantalla]
   	@Operacion varchar(1),
  	@idPantalla int,
	@nombrePantalla nvarchar(50),
	@descripcionPantalla nvarchar(500)

AS
BEGIN
 

/* -------------------------------------------------------------------------------------
    Table:       pantalla 
   ------------------------------------------------------------------------------------- */



/* -------------------------------------------------------------------------------------
    Description: Operacion de insercion de registro.
   ------------------------------------------------------------------------------------- */
IF @Operacion = 'I'  BEGIN
   DECLARE @regs int
   SET @regs=(SELECT MAX(idPantalla)+1 FROM pantalla)
   IF @regs IS NULL  SET @regs=1;
 
  INSERT INTO pantalla
        (
		idPantalla,
		nombrePantalla,
		descripcionPantalla

	)
  VALUES
        (
        @regs,
		
		@nombrePantalla,
		@descripcionPantalla

	)
END

 
/* -------------------------------------------------------------------------------------
    Description: Operacion de actualizacion de un registro.
   ------------------------------------------------------------------------------------- */
IF @Operacion = 'U'  BEGIN
  UPDATE pantalla SET
  
		
		nombrePantalla = @nombrePantalla,
		descripcionPantalla = @descripcionPantalla

 
  WHERE idPantalla=@idPantalla
END
 

/* -------------------------------------------------------------------------------------
    Description: Operacion de eliminaci�n de un registro.
   ------------------------------------------------------------------------------------- */
IF @Operacion = 'D'  BEGIN
   DELETE FROM pantalla WHERE idPantalla=@idPantalla
END
 

/* -------------------------------------------------------------------------------------
    Description: Operacion de busqueda de un registro por su ID.
   ------------------------------------------------------------------------------------- */
IF @Operacion = 'F'  BEGIN
   SELECT  * 
   FROM pantalla
   WHERE  idPantalla=@idPantalla
END
 

/* -------------------------------------------------------------------------------------
    Description: Operacion de seleccion de todos los registros.
   ------------------------------------------------------------------------------------- */
IF @Operacion = 'S'  BEGIN
   SELECT  *
   FROM pantalla
END
 
END

GO
/****** Object:  StoredProcedure [dbo].[SP_tabla_pantallaRol]    Script Date: 12/04/2018 12:32:02 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_tabla_pantallaRol]
   	@Operacion varchar(1),
  	@idPantalla int,
	@idRol int

AS
BEGIN
 

/* -------------------------------------------------------------------------------------
    Table:       pantallaRol 
   ------------------------------------------------------------------------------------- */



/* -------------------------------------------------------------------------------------
    Description: Operacion de insercion de registro.
   ------------------------------------------------------------------------------------- */
IF @Operacion = 'I'  BEGIN
   DECLARE @regs int
   SET @regs=(SELECT MAX(idPantalla)+1 FROM pantallaRol)
   IF @regs IS NULL  SET @regs=1;
 
  INSERT INTO pantallaRol
        (
		idPantalla,
		idRol

	)
  VALUES
        (
        @regs,
		
		@idRol

	)
END

 
/* -------------------------------------------------------------------------------------
    Description: Operacion de actualizacion de un registro.
   ------------------------------------------------------------------------------------- */
IF @Operacion = 'U'  BEGIN
  UPDATE pantallaRol SET
  
		
		idRol = @idRol

 
  WHERE idPantalla=@idPantalla
END
 

/* -------------------------------------------------------------------------------------
    Description: Operacion de eliminaci�n de un registro.
   ------------------------------------------------------------------------------------- */
IF @Operacion = 'D'  BEGIN
   DELETE FROM pantallaRol WHERE idPantalla=@idPantalla
END
 

/* -------------------------------------------------------------------------------------
    Description: Operacion de busqueda de un registro por su ID.
   ------------------------------------------------------------------------------------- */
IF @Operacion = 'F'  BEGIN
   SELECT  * 
   FROM pantallaRol
   WHERE  idPantalla=@idPantalla
END
 

/* -------------------------------------------------------------------------------------
    Description: Operacion de seleccion de todos los registros.
   ------------------------------------------------------------------------------------- */
IF @Operacion = 'S'  BEGIN
   SELECT  *
   FROM pantallaRol
END
 
END

GO
/****** Object:  StoredProcedure [dbo].[SP_tabla_parametro]    Script Date: 12/04/2018 12:32:02 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_tabla_parametro]
   	@Operacion varchar(1),
  	@idParametro int,
	@nombreParametro nvarchar(50),
	@descripcion nvarchar(500),
	@tipoDato nvarchar(50)

AS
BEGIN
 

/* -------------------------------------------------------------------------------------
    Table:       parametro 
   ------------------------------------------------------------------------------------- */



/* -------------------------------------------------------------------------------------
    Description: Operacion de insercion de registro.
   ------------------------------------------------------------------------------------- */
IF @Operacion = 'I'  BEGIN
   DECLARE @regs int
   SET @regs=(SELECT MAX(idParametro)+1 FROM parametro)
   IF @regs IS NULL  SET @regs=1;
 
  INSERT INTO parametro
        (
		idParametro,
		nombreParametro,
		descripcion,
		tipoDato

	)
  VALUES
        (
        @regs,
		
		@nombreParametro,
		@descripcion,
		@tipoDato

	)
END

 
/* -------------------------------------------------------------------------------------
    Description: Operacion de actualizacion de un registro.
   ------------------------------------------------------------------------------------- */
IF @Operacion = 'U'  BEGIN
  UPDATE parametro SET
  
		
		nombreParametro = @nombreParametro,
		descripcion = @descripcion,
		tipoDato = @tipoDato

 
  WHERE idParametro=@idParametro
END
 

/* -------------------------------------------------------------------------------------
    Description: Operacion de eliminaci�n de un registro.
   ------------------------------------------------------------------------------------- */
IF @Operacion = 'D'  BEGIN
   DELETE FROM parametro WHERE idParametro=@idParametro
END
 

/* -------------------------------------------------------------------------------------
    Description: Operacion de busqueda de un registro por su ID.
   ------------------------------------------------------------------------------------- */
IF @Operacion = 'F'  BEGIN
   SELECT  * 
   FROM parametro
   WHERE  idParametro=@idParametro
END
 

/* -------------------------------------------------------------------------------------
    Description: Operacion de seleccion de todos los registros.
   ------------------------------------------------------------------------------------- */
IF @Operacion = 'S'  BEGIN
   SELECT  *
   FROM parametro
END
 
END

GO
/****** Object:  StoredProcedure [dbo].[SP_tabla_producto]    Script Date: 12/04/2018 12:32:02 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_tabla_producto]
   	@Operacion varchar(1),
  	@idProducto int=NULL,
	@nombreProducto nvarchar(500)=NULL,
	@costo decimal=NULL,
	@precio decimal=NULL,
	@precioMayoreo decimal=NULL,
	@idCategoria int=NULL,
	@activo bit=NULL,
	@imagen varbinary=NULL

AS
BEGIN
 

/* -------------------------------------------------------------------------------------
    Table:       producto 
   ------------------------------------------------------------------------------------- */



/* -------------------------------------------------------------------------------------
    Description: Operacion de insercion de registro.
   ------------------------------------------------------------------------------------- */
IF @Operacion = 'I'  BEGIN
   DECLARE @regs int
   SET @regs=(SELECT MAX(idProducto)+1 FROM producto)
   IF @regs IS NULL  SET @regs=1;
 
  INSERT INTO producto
        (
		idProducto,
		nombreProducto,
		costo,
		precio,
		precioMayoreo,
		idCategoria,
		activo,
		imagen

	)
  VALUES
        (
        @regs,
		
		@nombreProducto,
		@costo,
		@precio,
		@precioMayoreo,
		@idCategoria,
		1,
		@imagen

	)
END

 
/* -------------------------------------------------------------------------------------
    Description: Operacion de actualizacion de un registro.
   ------------------------------------------------------------------------------------- */
IF @Operacion = 'U'  BEGIN
  UPDATE producto SET
		nombreProducto = @nombreProducto,
		costo = @costo,
		precio = @precio,
		precioMayoreo = @precioMayoreo,
		idCategoria = @idCategoria,
		activo = @activo,
		imagen = @imagen

 
  WHERE idProducto=@idProducto
END
 

/* -------------------------------------------------------------------------------------
    Description: Operacion de eliminaci�n de un registro.
   ------------------------------------------------------------------------------------- */
IF @Operacion = 'D'  BEGIN
  UPDATE producto SET
		
		activo = 0 WHERE idProducto=@idProducto
END
 

/* -------------------------------------------------------------------------------------
    Description: Operacion de busqueda de un registro por su nombre
   ------------------------------------------------------------------------------------- */
IF @Operacion = 'F'  BEGIN
   SELECT  * 
   FROM producto
   WHERE nombreProducto like '%' + isnull(@nombreProducto,'') + '%'
   --and activo  = 1
END
 
   /* -------------------------------------------------------------------------------------
    Description: Operacion de busqueda de un registro por ID
   ------------------------------------------------------------------------------------- */
IF @Operacion = 'M'  BEGIN
   SELECT  * 
   FROM producto
   WHERE idProducto = @idProducto
  -- and activo = 1
END


 /* -------------------------------------------------------------------------------------
    Description: Operacion de busqueda de un registro por su nombre por si se repite
   ------------------------------------------------------------------------------------- */
IF @Operacion = 'R'  BEGIN
   SELECT  * 
   FROM producto
   WHERE nombreProducto like @nombreProducto
 --  and activo = 1
END
 

/* -------------------------------------------------------------------------------------
    Description: Operacion de seleccion de todos los registros.
   ------------------------------------------------------------------------------------- */
IF @Operacion = 'S'  BEGIN
   SELECT  idProducto,
		nombreProducto,
		costo,
		precio,
		precioMayoreo,
		idCategoria,
		activo, 
		imagen
   FROM producto
 --  where  activo = 1
END
 

END

GO
/****** Object:  StoredProcedure [dbo].[SP_tabla_productoUbicación]    Script Date: 12/04/2018 12:32:02 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_tabla_productoUbicación]
   	@Operacion varchar(1),
  	@idProducto int,
	@idUbicacion int,
	@cantidad int

AS
BEGIN
 

/* -------------------------------------------------------------------------------------
    Table:       productoUbicación 
   ------------------------------------------------------------------------------------- */



/* -------------------------------------------------------------------------------------
    Description: Operacion de insercion de registro.
   ------------------------------------------------------------------------------------- */
IF @Operacion = 'I'  BEGIN
   DECLARE @regs int
   SET @regs=(SELECT MAX(idProducto)+1 FROM productoUbicación)
   IF @regs IS NULL  SET @regs=1;
 
  INSERT INTO productoUbicación
        (
		idProducto,
		idUbicacion,
		cantidad

	)
  VALUES
        (
        @regs,
		
		@idUbicacion,
		@cantidad

	)
END

 
/* -------------------------------------------------------------------------------------
    Description: Operacion de actualizacion de un registro.
   ------------------------------------------------------------------------------------- */
IF @Operacion = 'U'  BEGIN
  UPDATE productoUbicación SET
  
		
		idUbicacion = @idUbicacion,
		cantidad = @cantidad

 
  WHERE idProducto=@idProducto
END
 

/* -------------------------------------------------------------------------------------
    Description: Operacion de eliminaci�n de un registro.
   ------------------------------------------------------------------------------------- */
IF @Operacion = 'D'  BEGIN
   DELETE FROM productoUbicación WHERE idProducto=@idProducto
END
 

/* -------------------------------------------------------------------------------------
    Description: Operacion de busqueda de un registro por su ID.
   ------------------------------------------------------------------------------------- */
IF @Operacion = 'F'  BEGIN
   SELECT  * 
   FROM productoUbicación
   WHERE  idProducto=@idProducto
END
 

/* -------------------------------------------------------------------------------------
    Description: Operacion de seleccion de todos los registros.
   ------------------------------------------------------------------------------------- */
IF @Operacion = 'S'  BEGIN
   SELECT  *
   FROM productoUbicación
END
 
END

GO
/****** Object:  StoredProcedure [dbo].[SP_tabla_rol]    Script Date: 12/04/2018 12:32:02 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_tabla_rol]
   	@Operacion varchar(1)=null,
  	@idRol int=null,
	@nombreRol nvarchar(50)=null,
	@descripcionRol nvarchar(500)=null

AS
BEGIN
 

/* -------------------------------------------------------------------------------------
    Table:       rol 
   ------------------------------------------------------------------------------------- */



/* -------------------------------------------------------------------------------------
    Description: Operacion de insercion de registro.
   ------------------------------------------------------------------------------------- */
IF @Operacion = 'I'  BEGIN
   DECLARE @regs int
   SET @regs=(SELECT MAX(idRol)+1 FROM rol)
   IF @regs IS NULL  SET @regs=1;
 
  INSERT INTO rol
        (
		idRol,
		nombreRol,
		descripcionRol

	)
  VALUES
        (
        @regs,
		
		@nombreRol,
		@descripcionRol

	)
END

 
/* -------------------------------------------------------------------------------------
    Description: Operacion de actualizacion de un registro.
   ------------------------------------------------------------------------------------- */
IF @Operacion = 'U'  BEGIN
  UPDATE rol SET
  
		
		nombreRol = @nombreRol,
		descripcionRol = @descripcionRol

 
  WHERE idRol=@idRol
END
 

/* -------------------------------------------------------------------------------------
    Description: Operacion de eliminaci�n de un registro.
   ------------------------------------------------------------------------------------- */
IF @Operacion = 'D'  BEGIN
   DELETE FROM rol WHERE idRol=@idRol
END
 

/* -------------------------------------------------------------------------------------
    Description: Operacion de busqueda de un registro por su ID.
   ------------------------------------------------------------------------------------- */
IF @Operacion = 'F'  BEGIN
   SELECT  * 
   FROM rol
   WHERE  idRol=@idRol
END
 

/* -------------------------------------------------------------------------------------
    Description: Operacion de seleccion de todos los registros.
   ------------------------------------------------------------------------------------- */
IF @Operacion = 'S'  BEGIN
   SELECT  *
   FROM rol
END
 
END

GO
/****** Object:  StoredProcedure [dbo].[SP_tabla_rolUsuario]    Script Date: 12/04/2018 12:32:02 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_tabla_rolUsuario]
   	@Operacion varchar(1)=null,
  	@idRol int=null,
	@idUsuario int=null

AS
BEGIN
 

/* -------------------------------------------------------------------------------------
    Table:       rolUsuario 
   ------------------------------------------------------------------------------------- */



/* -------------------------------------------------------------------------------------
    Description: Operacion de insercion de registro.
   ------------------------------------------------------------------------------------- */
IF @Operacion = 'I'  BEGIN

if (select idUsuario from rolUsuario where idUsuario = @idUsuario)>0
begin
UPDATE rolUsuario SET
  
		idRol=@idRol
		

 
  WHERE idUsuario = @idUsuario

END
else
BEGIN
   
	 --checar si ya tiene uno asignado
	  INSERT INTO rolUsuario
			(
			idRol,
			idUsuario

		)
	  VALUES
			(
		   @idRol,
		
			@idUsuario

		)
	END
END

 
/* -------------------------------------------------------------------------------------
    Description: Operacion de actualizacion de un registro.
   ------------------------------------------------------------------------------------- */
IF @Operacion = 'U'  BEGIN
  UPDATE rolUsuario SET
  
		
		idUsuario = @idUsuario

 
  WHERE idRol=@idRol
END
 

/* -------------------------------------------------------------------------------------
    Description: Operacion de eliminaci�n de un registro.
   ------------------------------------------------------------------------------------- */
IF @Operacion = 'D'  BEGIN
   DELETE FROM rolUsuario WHERE idRol=@idRol
END
 

/* -------------------------------------------------------------------------------------
    Description: Operacion de busqueda de un registro por su ID.
   ------------------------------------------------------------------------------------- */
IF @Operacion = 'F'  BEGIN
   SELECT  * 
   FROM rolUsuario
   WHERE  idUsuario = @idUsuario
END
 

/* -------------------------------------------------------------------------------------
    Description: Operacion de seleccion de todos los registros.
   ------------------------------------------------------------------------------------- */
IF @Operacion = 'S'  BEGIN
   SELECT  *
   FROM rolUsuario
END
 
END

GO
/****** Object:  StoredProcedure [dbo].[SP_tabla_ubicacion]    Script Date: 12/04/2018 12:32:02 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_tabla_ubicacion]
   	@Operacion varchar(1),
  	@idUbicacion int,
	@nombreUbicacion nvarchar(50),
	@cuentaInventario bit,
	@activo bit

AS
BEGIN
 

/* -------------------------------------------------------------------------------------
    Table:       ubicacion 
   ------------------------------------------------------------------------------------- */



/* -------------------------------------------------------------------------------------
    Description: Operacion de insercion de registro.
   ------------------------------------------------------------------------------------- */
IF @Operacion = 'I'  BEGIN
   DECLARE @regs int
   SET @regs=(SELECT MAX(idUbicacion)+1 FROM ubicacion)
   IF @regs IS NULL  SET @regs=1;
 
  INSERT INTO ubicacion
        (
		idUbicacion,
		nombreUbicacion,
		cuentaInventario,
		activo

	)
  VALUES
        (
        @regs,
		
		@nombreUbicacion,
		@cuentaInventario,
		@activo

	)
END

 
/* -------------------------------------------------------------------------------------
    Description: Operacion de actualizacion de un registro.
   ------------------------------------------------------------------------------------- */
IF @Operacion = 'U'  BEGIN
  UPDATE ubicacion SET
  
		
		nombreUbicacion = @nombreUbicacion,
		cuentaInventario = @cuentaInventario,
		activo = @activo

 
  WHERE idUbicacion=@idUbicacion
END
 

/* -------------------------------------------------------------------------------------
    Description: Operacion de eliminaci�n de un registro.
   ------------------------------------------------------------------------------------- */
IF @Operacion = 'D'  BEGIN
   DELETE FROM ubicacion WHERE idUbicacion=@idUbicacion
END
 

/* -------------------------------------------------------------------------------------
    Description: Operacion de busqueda de un registro por su ID.
   ------------------------------------------------------------------------------------- */
IF @Operacion = 'F'  BEGIN
   SELECT  * 
   FROM ubicacion
   WHERE  idUbicacion=@idUbicacion
END
 

/* -------------------------------------------------------------------------------------
    Description: Operacion de seleccion de todos los registros.
   ------------------------------------------------------------------------------------- */
IF @Operacion = 'S'  BEGIN
   SELECT  *
   FROM ubicacion
END
 
END

GO
/****** Object:  StoredProcedure [dbo].[SP_tabla_usuario]    Script Date: 12/04/2018 12:32:02 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_tabla_usuario]
   	@Operacion varchar(1),
  	@idUsuario int,
	@uid nvarchar(50),
	@pwd nvarchar(50),
	@descripcionUsuario nvarchar(500),
	@activo bit,
	@PIN nvarchar(4)

AS
BEGIN
 

/* -------------------------------------------------------------------------------------
    Table:       usuario 
   ------------------------------------------------------------------------------------- */



/* -------------------------------------------------------------------------------------
    Description: Operacion de insercion de registro.
   ------------------------------------------------------------------------------------- */
IF @Operacion = 'I'  BEGIN
   DECLARE @regs int
   SET @regs=(SELECT MAX(idUsuario)+1 FROM usuario)
   IF @regs IS NULL  SET @regs=1;
 
  INSERT INTO usuario
        (
		idUsuario,
		uid,
		pwd,
		descripcionUsuario,
		activo,
		PIN

	)
  VALUES
        (
       @regs,
		
		@uid,
		@pwd,
		@descripcionUsuario,
		@activo,
		@PIN

	)
END

 
/* -------------------------------------------------------------------------------------
    Description: Operacion de actualizacion de un registro.
   ------------------------------------------------------------------------------------- */
IF @Operacion = 'U'  BEGIN
  UPDATE usuario SET
  
		
		uid = @uid,
		pwd = @pwd,
		descripcionUsuario = @descripcionUsuario,
		activo = @activo,
		PIN = @PIN

 
  WHERE idUsuario=@idUsuario
END
 

/* -------------------------------------------------------------------------------------
    Description: Operacion de eliminaci�n de un registro.
   ------------------------------------------------------------------------------------- */
IF @Operacion = 'D'  BEGIN
   UPDATE usuario SET
  
	
		activo = 0

 
  WHERE idUsuario=@idUsuario
END
 

/* -------------------------------------------------------------------------------------
    Description: Operacion de busqueda de un registro por su ID.
   ------------------------------------------------------------------------------------- */
IF @Operacion = 'F'  BEGIN
   SELECT  * 
   FROM usuario
   WHERE  idUsuario=@idUsuario 
   and activo = 1  
END

/* -------------------------------------------------------------------------------------
    Description: Operacion de busqueda de un registro para logeo
   ------------------------------------------------------------------------------------- */
IF @Operacion = 'L'  BEGIN
   SELECT  * 
   FROM usuario
   WHERE  idUsuario=@idUsuario and PIN = @PIN
   and activo = 1  
END
 

/* -------------------------------------------------------------------------------------
    Description: Operacion de seleccion de todos los registros.
   ------------------------------------------------------------------------------------- */
IF @Operacion = 'S'  BEGIN
   SELECT  *
   FROM usuario
  where activo = 1
END


/* -------------------------------------------------------------------------------------
    Description: Operacion de seleccion de todos los registros para el catalogo
   ------------------------------------------------------------------------------------- */
IF @Operacion = 'C'  BEGIN
   SELECT  u.*, r.nombreRol as rol
   FROM usuario u
	inner join rolUsuario ru on u.idUsuario = ru.idUsuario 
	inner join rol r on r.idRol = ru.idRol
END


/* -------------------------------------------------------------------------------------
    Description: Operacion de seleccion de busqueda por nombre
   ------------------------------------------------------------------------------------- */
IF @Operacion = 'R'  BEGIN
   SELECT  *
   FROM usuario
	where uid like @uid
END
 
 
/* -------------------------------------------------------------------------------------
    Description: Operacion de seleccion de busqueda por ID
   ------------------------------------------------------------------------------------- */
IF @Operacion = 'M'  BEGIN
   SELECT  *
   FROM usuario
	where idUsuario = @idUsuario
END



END

GO
/****** Object:  StoredProcedure [dbo].[SP_tabla_venta]    Script Date: 12/04/2018 12:32:02 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_tabla_venta]
   	@Operacion varchar(1),
  	@idVenta int,
	@idUsuario int,
	@fechaHora datetime

AS
BEGIN
 

/* -------------------------------------------------------------------------------------
    Table:       venta 
   ------------------------------------------------------------------------------------- */



/* -------------------------------------------------------------------------------------
    Description: Operacion de insercion de registro.
   ------------------------------------------------------------------------------------- */
IF @Operacion = 'I'  BEGIN
   DECLARE @regs int
   SET @regs=(SELECT MAX(idVenta)+1 FROM venta)
   IF @regs IS NULL  SET @regs=1;
 
  INSERT INTO venta
        (
		idVenta,
		idUsuario,
		fechaHora

	)
  VALUES
        (
        @regs,
		
		@idUsuario,
		@fechaHora

	)
END

 
/* -------------------------------------------------------------------------------------
    Description: Operacion de actualizacion de un registro.
   ------------------------------------------------------------------------------------- */
IF @Operacion = 'U'  BEGIN
  UPDATE venta SET
  
		
		idUsuario = @idUsuario,
		fechaHora = @fechaHora

 
  WHERE idVenta=@idVenta
END
 

/* -------------------------------------------------------------------------------------
    Description: Operacion de eliminaci�n de un registro.
   ------------------------------------------------------------------------------------- */
IF @Operacion = 'D'  BEGIN
   DELETE FROM venta WHERE idVenta=@idVenta
END
 

/* -------------------------------------------------------------------------------------
    Description: Operacion de busqueda de un registro por su ID.
   ------------------------------------------------------------------------------------- */
IF @Operacion = 'F'  BEGIN
   SELECT  * 
   FROM venta
   WHERE  idVenta=@idVenta
END
 

/* -------------------------------------------------------------------------------------
    Description: Operacion de seleccion de todos los registros.
   ------------------------------------------------------------------------------------- */
IF @Operacion = 'S'  BEGIN
   SELECT  *
   FROM venta
END
 
END

GO
/****** Object:  StoredProcedure [dbo].[SP_tabla_ventaDetalle]    Script Date: 12/04/2018 12:32:02 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_tabla_ventaDetalle]
   	@Operacion varchar(1),
  	@idProducto int,
	@cantidad int,
	@precioMayoreo bit,
	@idVenta int

AS
BEGIN
 

/* -------------------------------------------------------------------------------------
    Table:       ventaDetalle 
   ------------------------------------------------------------------------------------- */



/* -------------------------------------------------------------------------------------
    Description: Operacion de insercion de registro.
   ------------------------------------------------------------------------------------- */
IF @Operacion = 'I'  BEGIN
   DECLARE @regs int
   SET @regs=(SELECT MAX(idProducto)+1 FROM ventaDetalle)
   IF @regs IS NULL  SET @regs=1;
 
  INSERT INTO ventaDetalle
        (
		idProducto,
		cantidad,
		precioMayoreo,
		idVenta

	)
  VALUES
        (
        @regs,
		
		@cantidad,
		@precioMayoreo,
		@idVenta

	)
END

 
/* -------------------------------------------------------------------------------------
    Description: Operacion de actualizacion de un registro.
   ------------------------------------------------------------------------------------- */
IF @Operacion = 'U'  BEGIN
  UPDATE ventaDetalle SET
  
		
		cantidad = @cantidad,
		precioMayoreo = @precioMayoreo,
		idVenta = @idVenta

 
  WHERE idProducto=@idProducto
END
 

/* -------------------------------------------------------------------------------------
    Description: Operacion de eliminaci�n de un registro.
   ------------------------------------------------------------------------------------- */
IF @Operacion = 'D'  BEGIN
   DELETE FROM ventaDetalle WHERE idProducto=@idProducto
END
 

/* -------------------------------------------------------------------------------------
    Description: Operacion de busqueda de un registro por su ID.
   ------------------------------------------------------------------------------------- */
IF @Operacion = 'F'  BEGIN
   SELECT  * 
   FROM ventaDetalle
   WHERE  idProducto=@idProducto
END
 

/* -------------------------------------------------------------------------------------
    Description: Operacion de seleccion de todos los registros.
   ------------------------------------------------------------------------------------- */
IF @Operacion = 'S'  BEGIN
   SELECT  *
   FROM ventaDetalle
END
 
END

GO
/****** Object:  Table [dbo].[categoria]    Script Date: 12/04/2018 12:32:02 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[categoria](
	[idCategoria] [int] NOT NULL,
	[nombre] [nvarchar](50) NOT NULL,
	[cuentaInventario] [bit] NOT NULL,
	[cuentaVenta] [bit] NOT NULL,
 CONSTRAINT [PK_categoria] PRIMARY KEY CLUSTERED 
(
	[idCategoria] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[pantalla]    Script Date: 12/04/2018 12:32:02 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[pantalla](
	[idPantalla] [int] NOT NULL,
	[nombrePantalla] [nvarchar](50) NOT NULL,
	[descripcionPantalla] [nvarchar](500) NULL,
 CONSTRAINT [PK_pantalla] PRIMARY KEY CLUSTERED 
(
	[idPantalla] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[pantallaRol]    Script Date: 12/04/2018 12:32:02 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[pantallaRol](
	[idPantalla] [int] NOT NULL,
	[idRol] [int] NOT NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[parametro]    Script Date: 12/04/2018 12:32:02 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[parametro](
	[idParametro] [int] NOT NULL,
	[nombreParametro] [nvarchar](50) NOT NULL,
	[descripcion] [nvarchar](500) NULL,
	[tipoDato] [nvarchar](50) NULL,
 CONSTRAINT [PK_parametro] PRIMARY KEY CLUSTERED 
(
	[idParametro] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[producto]    Script Date: 12/04/2018 12:32:02 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[producto](
	[idProducto] [int] NOT NULL,
	[nombreProducto] [nvarchar](500) NOT NULL,
	[costo] [decimal](13, 2) NULL,
	[precio] [decimal](13, 2) NOT NULL,
	[precioMayoreo] [decimal](13, 2) NULL,
	[idCategoria] [int] NOT NULL,
	[activo] [bit] NOT NULL,
	[imagen] [varbinary](max) NULL,
 CONSTRAINT [PK_Producto] PRIMARY KEY CLUSTERED 
(
	[idProducto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[productoUbicacion]    Script Date: 12/04/2018 12:32:02 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[productoUbicacion](
	[idProducto] [int] NOT NULL,
	[idUbicacion] [int] NOT NULL,
	[cantidad] [int] NOT NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[rol]    Script Date: 12/04/2018 12:32:02 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[rol](
	[idRol] [int] NOT NULL,
	[nombreRol] [nvarchar](50) NOT NULL,
	[descripcionRol] [nvarchar](500) NULL,
 CONSTRAINT [PK_rol] PRIMARY KEY CLUSTERED 
(
	[idRol] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[rolUsuario]    Script Date: 12/04/2018 12:32:02 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[rolUsuario](
	[idRol] [int] NOT NULL,
	[idUsuario] [int] NOT NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ubicacion]    Script Date: 12/04/2018 12:32:02 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ubicacion](
	[idUbicacion] [int] NOT NULL,
	[nombreUbicacion] [nvarchar](50) NOT NULL,
	[cuentaInventario] [bit] NULL,
	[activo] [bit] NULL,
 CONSTRAINT [PK_ubicacion] PRIMARY KEY CLUSTERED 
(
	[idUbicacion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[usuario]    Script Date: 12/04/2018 12:32:02 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[usuario](
	[idUsuario] [int] NOT NULL,
	[uid] [nvarchar](50) NULL,
	[pwd] [nvarchar](50) NULL,
	[descripcionUsuario] [nvarchar](500) NULL,
	[activo] [bit] NULL,
	[PIN] [nvarchar](4) NOT NULL,
 CONSTRAINT [PK_usuario] PRIMARY KEY CLUSTERED 
(
	[idUsuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[venta]    Script Date: 12/04/2018 12:32:02 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[venta](
	[idVenta] [int] NOT NULL,
	[idUsuario] [int] NOT NULL,
	[fechaHora] [datetime] NOT NULL,
 CONSTRAINT [PK_venta] PRIMARY KEY CLUSTERED 
(
	[idVenta] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ventaDetalle]    Script Date: 12/04/2018 12:32:02 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ventaDetalle](
	[idProducto] [int] NOT NULL,
	[cantidad] [int] NOT NULL,
	[precioMayoreo] [bit] NOT NULL,
	[idVenta] [int] NOT NULL
) ON [PRIMARY]

GO
/****** Object:  UserDefinedFunction [dbo].[permisosPorUsuario]    Script Date: 12/04/2018 12:32:02 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Jaime
-- Create date: 10-04-2016	
-- Description:	permisos por usuario
-- =============================================
CREATE FUNCTION [dbo].[permisosPorUsuario]
(	
	@idUsuario int
)
RETURNS TABLE 
AS
RETURN 
(
	select distinct pr.idPantalla
	from rolusuario ru
	inner join pantallaRol pr on pr.idRol = ru.idRol
	where ru.idRol = (select top 1 idRol from rolUsuario where idUsuario = @idUsuario)
)

GO
INSERT [dbo].[categoria] ([idCategoria], [nombre], [cuentaInventario], [cuentaVenta]) VALUES (1, N'Paletas', 1, 1)
INSERT [dbo].[pantalla] ([idPantalla], [nombrePantalla], [descripcionPantalla]) VALUES (1, N'Pral', N'Pral')
INSERT [dbo].[pantalla] ([idPantalla], [nombrePantalla], [descripcionPantalla]) VALUES (2, N'PuntoVenta', N'PuntoVenta')
INSERT [dbo].[pantalla] ([idPantalla], [nombrePantalla], [descripcionPantalla]) VALUES (3, N'Usuarios', N'Usuarios')
INSERT [dbo].[pantalla] ([idPantalla], [nombrePantalla], [descripcionPantalla]) VALUES (4, N'Productos', N'Productos')
INSERT [dbo].[pantalla] ([idPantalla], [nombrePantalla], [descripcionPantalla]) VALUES (5, N'Inventario', N'Inventario')
INSERT [dbo].[pantalla] ([idPantalla], [nombrePantalla], [descripcionPantalla]) VALUES (6, N'Reportes', N'Reportes')
INSERT [dbo].[pantalla] ([idPantalla], [nombrePantalla], [descripcionPantalla]) VALUES (7, N'Cortes', N'Cortes')
INSERT [dbo].[pantalla] ([idPantalla], [nombrePantalla], [descripcionPantalla]) VALUES (8, N'Catalogos', N'Catalogos')
INSERT [dbo].[pantallaRol] ([idPantalla], [idRol]) VALUES (1, 1)
INSERT [dbo].[pantallaRol] ([idPantalla], [idRol]) VALUES (2, 1)
INSERT [dbo].[pantallaRol] ([idPantalla], [idRol]) VALUES (1, 1)
INSERT [dbo].[pantallaRol] ([idPantalla], [idRol]) VALUES (3, 1)
INSERT [dbo].[pantallaRol] ([idPantalla], [idRol]) VALUES (4, 1)
INSERT [dbo].[pantallaRol] ([idPantalla], [idRol]) VALUES (5, 1)
INSERT [dbo].[pantallaRol] ([idPantalla], [idRol]) VALUES (6, 1)
INSERT [dbo].[pantallaRol] ([idPantalla], [idRol]) VALUES (2, 2)
INSERT [dbo].[pantallaRol] ([idPantalla], [idRol]) VALUES (8, 1)
INSERT [dbo].[parametro] ([idParametro], [nombreParametro], [descripcion], [tipoDato]) VALUES (1, N'nombreNegocio', N'Helados', N'Texto')
INSERT [dbo].[parametro] ([idParametro], [nombreParametro], [descripcion], [tipoDato]) VALUES (2, N'cantidadMayoreo', N'10', N'Numerico')
INSERT [dbo].[parametro] ([idParametro], [nombreParametro], [descripcion], [tipoDato]) VALUES (3, N'Direccion', N'Pedro de Alba San Marcos', N'Texto')
INSERT [dbo].[producto] ([idProducto], [nombreProducto], [costo], [precio], [precioMayoreo], [idCategoria], [activo], [imagen]) VALUES (1, N'PALETA CHICA', CAST(5.00 AS Decimal(13, 2)), CAST(5.00 AS Decimal(13, 2)), CAST(5.00 AS Decimal(13, 2)), 1, 0, 0xFF)
INSERT [dbo].[producto] ([idProducto], [nombreProducto], [costo], [precio], [precioMayoreo], [idCategoria], [activo], [imagen]) VALUES (2, N'PALETA CHICA', CAST(4.00 AS Decimal(13, 2)), CAST(5.00 AS Decimal(13, 2)), CAST(5.00 AS Decimal(13, 2)), 1, 1, NULL)
INSERT [dbo].[producto] ([idProducto], [nombreProducto], [costo], [precio], [precioMayoreo], [idCategoria], [activo], [imagen]) VALUES (3, N'NIEVE CHICA', CAST(12.00 AS Decimal(13, 2)), CAST(12.00 AS Decimal(13, 2)), CAST(12.00 AS Decimal(13, 2)), 1, 1, NULL)
INSERT [dbo].[producto] ([idProducto], [nombreProducto], [costo], [precio], [precioMayoreo], [idCategoria], [activo], [imagen]) VALUES (4, N'NIEVE GRANDE', CAST(22.00 AS Decimal(13, 2)), CAST(22.00 AS Decimal(13, 2)), CAST(22.00 AS Decimal(13, 2)), 1, 1, NULL)
INSERT [dbo].[rol] ([idRol], [nombreRol], [descripcionRol]) VALUES (1, N'Administrador', N'Administrador')
INSERT [dbo].[rol] ([idRol], [nombreRol], [descripcionRol]) VALUES (2, N'Cajero', N'Cajero')
INSERT [dbo].[rolUsuario] ([idRol], [idUsuario]) VALUES (1, 1)
INSERT [dbo].[rolUsuario] ([idRol], [idUsuario]) VALUES (2, 2)
INSERT [dbo].[ubicacion] ([idUbicacion], [nombreUbicacion], [cuentaInventario], [activo]) VALUES (1, N'Default', 1, 1)
INSERT [dbo].[usuario] ([idUsuario], [uid], [pwd], [descripcionUsuario], [activo], [PIN]) VALUES (1, N'ADMIN', N'ADMIN', N'ADMIN', 1, N'1234')
INSERT [dbo].[usuario] ([idUsuario], [uid], [pwd], [descripcionUsuario], [activo], [PIN]) VALUES (2, N'LK', N'LK', N'LK', 1, N'1234')
ALTER TABLE [dbo].[pantallaRol]  WITH CHECK ADD  CONSTRAINT [FK_pantallaRol_pantalla] FOREIGN KEY([idPantalla])
REFERENCES [dbo].[pantalla] ([idPantalla])
GO
ALTER TABLE [dbo].[pantallaRol] CHECK CONSTRAINT [FK_pantallaRol_pantalla]
GO
ALTER TABLE [dbo].[pantallaRol]  WITH CHECK ADD  CONSTRAINT [FK_pantallaRol_rol] FOREIGN KEY([idRol])
REFERENCES [dbo].[rol] ([idRol])
GO
ALTER TABLE [dbo].[pantallaRol] CHECK CONSTRAINT [FK_pantallaRol_rol]
GO
ALTER TABLE [dbo].[producto]  WITH CHECK ADD  CONSTRAINT [FK_Producto_categoria] FOREIGN KEY([idCategoria])
REFERENCES [dbo].[categoria] ([idCategoria])
GO
ALTER TABLE [dbo].[producto] CHECK CONSTRAINT [FK_Producto_categoria]
GO
ALTER TABLE [dbo].[productoUbicacion]  WITH CHECK ADD  CONSTRAINT [FK_productoUbicación_producto] FOREIGN KEY([idProducto])
REFERENCES [dbo].[producto] ([idProducto])
GO
ALTER TABLE [dbo].[productoUbicacion] CHECK CONSTRAINT [FK_productoUbicación_producto]
GO
ALTER TABLE [dbo].[productoUbicacion]  WITH CHECK ADD  CONSTRAINT [FK_productoUbicación_ubicacion] FOREIGN KEY([idUbicacion])
REFERENCES [dbo].[ubicacion] ([idUbicacion])
GO
ALTER TABLE [dbo].[productoUbicacion] CHECK CONSTRAINT [FK_productoUbicación_ubicacion]
GO
ALTER TABLE [dbo].[rolUsuario]  WITH CHECK ADD  CONSTRAINT [FK_rolUsuario_rol] FOREIGN KEY([idRol])
REFERENCES [dbo].[rol] ([idRol])
GO
ALTER TABLE [dbo].[rolUsuario] CHECK CONSTRAINT [FK_rolUsuario_rol]
GO
ALTER TABLE [dbo].[rolUsuario]  WITH CHECK ADD  CONSTRAINT [FK_rolUsuario_usuario] FOREIGN KEY([idUsuario])
REFERENCES [dbo].[usuario] ([idUsuario])
GO
ALTER TABLE [dbo].[rolUsuario] CHECK CONSTRAINT [FK_rolUsuario_usuario]
GO
ALTER TABLE [dbo].[venta]  WITH CHECK ADD  CONSTRAINT [FK_venta_usuario] FOREIGN KEY([idUsuario])
REFERENCES [dbo].[usuario] ([idUsuario])
GO
ALTER TABLE [dbo].[venta] CHECK CONSTRAINT [FK_venta_usuario]
GO
ALTER TABLE [dbo].[ventaDetalle]  WITH CHECK ADD  CONSTRAINT [FK_ventaDetalle_producto] FOREIGN KEY([idProducto])
REFERENCES [dbo].[producto] ([idProducto])
GO
ALTER TABLE [dbo].[ventaDetalle] CHECK CONSTRAINT [FK_ventaDetalle_producto]
GO
ALTER TABLE [dbo].[ventaDetalle]  WITH CHECK ADD  CONSTRAINT [FK_ventaDetalle_venta] FOREIGN KEY([idVenta])
REFERENCES [dbo].[venta] ([idVenta])
GO
ALTER TABLE [dbo].[ventaDetalle] CHECK CONSTRAINT [FK_ventaDetalle_venta]
GO
USE [master]
GO
ALTER DATABASE [Paleteria] SET  READ_WRITE 
GO
