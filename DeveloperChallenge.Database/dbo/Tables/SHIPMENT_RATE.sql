CREATE TABLE [dbo].[SHIPMENT_RATE] (
    [shipment_rate_id]          INT          NOT NULL,
    [shipment_rate_class]       VARCHAR (10) NOT NULL,
    [shipment_rate_description] VARCHAR (25) NOT NULL,
    CONSTRAINT [PK_SHIPMENT_RATE] PRIMARY KEY CLUSTERED ([shipment_rate_id] ASC)
);

