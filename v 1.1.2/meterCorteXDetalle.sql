USE [Paleteria]
GO
/****** Object:  StoredProcedure [dbo].[meterCorteXDetalle]    Script Date: 28/05/2018 04:18:42 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Jaime Castorena
-- Create date: 03/05/2018
-- Description:	Mete los datos del corteDetalle
-- =============================================
ALTER PROCEDURE [dbo].[meterCorteXDetalle]
	 @idUsuario int = null,
	 @idCorteX int 
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;


	declare @fechaUltimoCorte datetime 
	declare @cuenta int
		set @cuenta = (select count(*) from corteX)
	if @cuenta > 0
	begin
	set @fechaUltimoCorte = (select top 1 fecha from corteX order by 1 desc)
	print @fechaUltimoCorte
	end else if @cuenta = 0
	begin 
	
	set @fechaUltimoCorte = (SELECT CONVERT(VARCHAR(10), GETDATE(), 110))
	print @fechaUltimoCorte
	end

INSERT INTO [dbo].[corteXDetalle]
           ([idCorteX]
           ,[idProducto]
           ,[cantidad])
select  @idCorteX,
p.idProducto, vd.cantidad 
from venta v 
inner join ventaDetalle vd on v.idVenta = vd.idVenta
inner join producto p on p.idProducto = vd.idProducto
where (SELECT CONVERT(VARCHAR(10), fechaHora, 110)) > @fechaUltimoCorte




END
