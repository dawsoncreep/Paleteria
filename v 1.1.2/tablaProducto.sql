USE [Paleteria]
GO
/****** Object:  StoredProcedure [dbo].[SP_tabla_producto]    Script Date: 29/05/2018 12:14:59 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[SP_tabla_producto]
   	@Operacion varchar(1),
  	@idProducto int=NULL,
	@nombreProducto nvarchar(500)=NULL,
	@costo decimal(10,2)=NULL,
	@precio decimal(10,2)=NULL,
	@precioMayoreo decimal(10,2)=NULL,
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

 IF @Operacion = 'T'  BEGIN
   SELECT  idProducto,
		nombreProducto,
		costo,
		precio,
		precioMayoreo,
		idCategoria,
		activo, 
		imagen
   FROM producto
  where  idCategoria=@idCategoria and activo = 1
END 

 

END
