CREATE TABLE [dbo].[SHIPMENT] (
    [shipment_id]          INT             NOT NULL,
    [shipper_id]           INT             NOT NULL,
    [shipment_description] VARCHAR (100)   NOT NULL,
    [shipment_weight]      NUMERIC (18, 2) NOT NULL,
    [shipment_rate_id]     INT             NOT NULL,
    [carrier_id]           INT             NOT NULL,
    CONSTRAINT [PK_SHIPMENT] PRIMARY KEY CLUSTERED ([shipment_id] ASC),
    CONSTRAINT [FK_SHIPMENT_CARRIER] FOREIGN KEY ([carrier_id]) REFERENCES [dbo].[CARRIER] ([carrier_id]),
    CONSTRAINT [FK_SHIPMENT_SHIPMENT_RATE] FOREIGN KEY ([shipment_rate_id]) REFERENCES [dbo].[SHIPMENT_RATE] ([shipment_rate_id]),
    CONSTRAINT [FK_SHIPMENT_SHIPPER] FOREIGN KEY ([shipper_id]) REFERENCES [dbo].[SHIPPER] ([shipper_id])
);

