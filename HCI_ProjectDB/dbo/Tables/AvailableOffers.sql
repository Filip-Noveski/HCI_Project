CREATE TABLE [dbo].[AvailableOffers] (
    [Id]          INT            IDENTITY (1, 1) NOT NULL,
    [Brand]       NVARCHAR (64)  NOT NULL,
    [Name]        NVARCHAR (256) NOT NULL,
    [Price]       VARCHAR (16)   NOT NULL,
    [Type]        VARCHAR (32)   NULL,
    [Age]         CHAR (4)       NULL,
    [PublishTime] DATETIME       NULL,
    [Available]   BIT            NULL,
    [Seller]      NVARCHAR (450) NULL,
    CONSTRAINT [AvailableOffersPK] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [AgeCk] CHECK ([Age]='mt2y' OR [Age]='lt2y' OR [Age]='lt1y' OR [Age]='lt6m' OR [Age]='new'),
    CONSTRAINT [TypeCk] CHECK ([Type]='speakers' OR [Type]='mouse' OR [Type]='monitor' OR [Type]='keyboard' OR [Type]='ssd' OR [Type]='hdd' OR [Type]='ram' OR [Type]='graphicsCard' OR [Type]='cpu' OR [Type]='none'),
    CONSTRAINT [SellerFK] FOREIGN KEY ([Seller]) REFERENCES [dbo].[AspNetUsers] ([Id])
);



