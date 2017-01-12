﻿CREATE TABLE [dbo].[PhenomenonOffering] (
    [ID]           UNIQUEIDENTIFIER CONSTRAINT [DF_PhenomenonOffering_ID] DEFAULT (newid()) NOT NULL,
    [PhenomenonID] UNIQUEIDENTIFIER NOT NULL,
    [OfferingID]   UNIQUEIDENTIFIER NOT NULL,
    [UserId] UNIQUEIDENTIFIER NULL, 
--> Added 2.0.8 20160718 TimPN
    [AddedAt] DATETIME NULL CONSTRAINT [DF_PhenomenonOffering_AddedAt] DEFAULT GetDate(), 
    [UpdatedAt] DATETIME NULL CONSTRAINT [DF_PhenomenonOffering_UpdatedAt] DEFAULT GetDate(), 
--< Added 2.0.8 20160718 TimPN
--> Changed 2.0.8 20160718 TimPN
--    CONSTRAINT [PK_PhenomenonOffering] PRIMARY KEY CLUSTERED ([ID]),
    CONSTRAINT [PK_PhenomenonOffering] PRIMARY KEY NONCLUSTERED ([ID]),
--< Changed 2.0.8 20160718 TimPN
    CONSTRAINT [FK_PhenomenonOffering_Offering] FOREIGN KEY ([OfferingID]) REFERENCES [dbo].[Offering] ([ID]),
    CONSTRAINT [FK_PhenomenonOffering_Phenomenon] FOREIGN KEY ([PhenomenonID]) REFERENCES [dbo].[Phenomenon] ([ID]),
--> Added 2.0.0 20160406 TimPN
    CONSTRAINT [UX_PhenomenonOffering] UNIQUE ([PhenomenonID],[OfferingID]),
    CONSTRAINT [FK_PhenomenonOffering_aspnet_Users] FOREIGN KEY ([UserId]) REFERENCES [dbo].[aspnet_Users] ([UserId])
--< Added 2.0.0 20160406 TimPN
);
--> Added 2.0.8 20160718 TimPN
GO
--> Changed 2.0.23 20170112 TimPN
--CREATE CLUSTERED INDEX [CX_PhenomenonOffering] ON [dbo].[PhenomenonOffering] ([AddedAt])
CREATE UNIQUE CLUSTERED INDEX [CX_PhenomenonOffering] ON [dbo].[PhenomenonOffering] ([AddedAt])
--< Changed 2.0.23 20170112 TimPN
--< Added 2.0.8 20160718 TimPN
--> Added 2.0.0 20160406 TimPN
GO
CREATE INDEX [IX_PhenomenonOffering_PhenomenonID] ON [dbo].[PhenomenonOffering] ([PhenomenonID])
GO
CREATE INDEX [IX_PhenomenonOffering_OfferingID] ON [dbo].[PhenomenonOffering] ([OfferingID])
GO
CREATE INDEX [IX_PhenomenonOffering_UserId] ON [dbo].[PhenomenonOffering] ([UserId])
--< Added 2.0.0 20160406 TimPN
--> Added 2.0.8 20160718 TimPN
--> Changed 2.0.15 20161102 TimPN
GO
CREATE TRIGGER [dbo].[TR_PhenomenonOffering_Insert] ON [dbo].[PhenomenonOffering]
FOR INSERT
AS
BEGIN
    SET NoCount ON
    Update
        src
    set
        AddedAt = GETDATE(),
        UpdatedAt = NULL
    from
        PhenomenonOffering src
        inner join inserted ins
            on (ins.ID = src.ID)
END
GO
CREATE TRIGGER [dbo].[TR_PhenomenonOffering_Update] ON [dbo].[PhenomenonOffering]
FOR UPDATE
AS
BEGIN
    SET NoCount ON
    Update
        src
    set
--> Changed 2.0.19 20161205 TimPN
--		AddedAt = del.AddedAt,
        AddedAt = Coalesce(del.AddedAt, ins.AddedAt, GetDate ()),
--< Changed 2.0.19 20161205 TimPN
        UpdatedAt = GETDATE()
    from
        PhenomenonOffering src
        inner join inserted ins
            on (ins.ID = src.ID)
		inner join deleted del
			on (del.ID = src.ID)
END
--< Changed 2.0.15 20161102 TimPN
--< Added 2.0.8 20160718 TimPN

