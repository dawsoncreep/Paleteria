USE [Paleteria]
GO

DECLARE	@return_value int
declare @fecha datetime 
set @fecha = getdate()

EXEC	@return_value = [dbo].[SP_tabla_venta]
		@Operacion = N'I',
		@idVenta = 0,
		@idUsuario = 1,
		@fechaHora = @fecha
GO
declare @idVenta int
set @idVenta = (select max(idVenta) from venta)
INSERT INTO [dbo].[ventaDetalle]
           ([idProducto]
           ,[cantidad]
           ,[precioMayoreo]
           ,[idVenta])
select idProducto, 1, 0, @idVenta
from producto
    

GO



Select * from venta v
left join ventadetalle vd on v.idVenta = vd.idVenta

select * from corteX

select * from corteXDetalle

delete from corteX
delete from corteXDetalle
