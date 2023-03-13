CREATE TABLE [dbo].[CARRIER] (
    [carrier_id]   INT           NOT NULL,
    [carrier_name] VARCHAR (100) NOT NULL,
    [carrier_mode] VARCHAR (25)  NOT NULL,
    CONSTRAINT [PK_CARRIER] PRIMARY KEY CLUSTERED ([carrier_id] ASC)
);

