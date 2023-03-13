-- =============================================
-- Author:		<Author,Syed Ali Akbar>
-- Create date: <Create Date,12-03-28>
-- =============================================
CREATE PROCEDURE Sp_GetShippmentList_ById --Sp_GetShippmentList_ById 1
	-- Add the parameters for the stored procedure here
	@ShipperId int 
AS
BEGIN
	
	SET NOCOUNT ON;

	drop table if exists #tempShippments

       SELECT 
	   SHIP.[shipment_id]				
      ,SHIP.[shipper_id]				
      ,SHIP.[shipment_description]		
      ,SHIP.[shipment_weight]			
      ,SHIP.[shipment_rate_id]			
      ,SHIP.[carrier_id]				
	  INTO #tempShippments
	  FROM [ShippersDb].[dbo].[SHIPMENT] AS SHIP
	  where SHIP.shipper_id =  @ShipperId
  SELECT * FROM #tempShippments
  --[CARRIER] TABLE DATA
  select
	   CARRIER.[carrier_id]
      ,CARRIER.[carrier_name]
      ,CARRIER.[carrier_mode]
	  ,TEMPSHIP.shipment_id
  from [ShippersDb].[dbo].[CARRIER] as CARRIER
  INNER JOIN #tempShippments TEMPSHIP ON TEMPSHIP.carrier_id = CARRIER.carrier_id
 
 --SHIPER TABLE DATA
  select
	   SHIPER.shipper_id
      ,SHIPER.shipper_name 
	  	  ,TEMPSHIP.shipment_id
  from [dbo].[SHIPPER] as SHIPER
  INNER JOIN #tempShippments TEMPSHIP ON TEMPSHIP.shipper_id = SHIPER.shipper_id
	
--Rate TABLE DATA
  select
	   RATE.[shipment_rate_id]
      ,RATE.[shipment_rate_class]
      ,RATE.[shipment_rate_description]
	  ,TEMPSHIP.shipment_id
  from [dbo].[SHIPMENT_RATE] as RATE
  INNER JOIN #tempShippments TEMPSHIP ON TEMPSHIP.shipment_rate_id = RATE.shipment_rate_id
	drop table if exists #tempShippments

END