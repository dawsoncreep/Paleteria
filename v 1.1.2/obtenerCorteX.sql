USE [Paleteria]
GO
/****** Object:  StoredProcedure [dbo].[obtenerCorteX]    Script Date: 28/05/2018 04:18:54 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Jaime Castorena
-- Create date: 03/05/2018
-- Description:	Obtiene los datos para el corte
-- =============================================
ALTER PROCEDURE [dbo].[obtenerCorteX]
	 @idUsuario int = null,
	 @idCorteX int = null
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	if (@idCorteX is null)
	begin
		declare @fechaUltimoCorte datetime 
		declare @cuenta int
		set @cuenta = (select count(*) from corteX)
		if @cuenta > 0
		begin
		set @fechaUltimoCorte = (select top 1 fecha from corteX order by 1 desc)
		end else if @cuenta = 0
		begin 
		set @fechaUltimoCorte = (SELECT CONVERT(VARCHAR(10), GETDATE(), 110))
		end
		print @fechaUltimoCorte


 DECLARE @regs int
   SET @regs=(SELECT MAX(idCorteX)+1 FROM corteX)
   IF @regs IS NULL  SET @regs=1;
   print @regs

INSERT INTO [dbo].[corteX]
           ([idCorteX]
           ,[fecha]
           ,[idUsuario]
           ,[totalVenta]
           ,[totalRetiros]
           ,[GranTotal]
           ,[fechaInicio]
           ,[fechaFin]
           ,[inicialCaja])
    select distinct
	@regs
	, getdate()
	, @idUsuario
	, sum(p.precio * vd.cantidad)
	, isnull(dbo.retirosporCorte(getdate()),0)
	, isnull(dbo.obtenerInicialCajon (getdate()),0) + sum(p.precio * vd.cantidad) - isnull(dbo.retirosporCorte(getdate()),0)
	, min(v.fechaHora) 
	, max(v.fechaHora) 
	, isnull(dbo.obtenerInicialCajon (getdate())   ,0)      
	from venta v 
	inner join ventaDetalle vd on v.idVenta = vd.idVenta
	inner join producto p on p.idProducto = vd.idProducto
	--inner join usuario u on v.idUsuario = isnull(@idUsuario, v.idUsuario)
	where (SELECT CONVERT(VARCHAR(10), fechaHora, 110)) > @fechaUltimoCorte
	group by  v.idUsuario


select * from CorteX where idCorteX = @regs

END
else

begin

select * from CorteX where idCorteX = @idCorteX

end

END
