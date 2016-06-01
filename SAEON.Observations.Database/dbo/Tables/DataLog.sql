﻿CREATE TABLE [dbo].[DataLog] (
    [ID]                         INT              IDENTITY (1, 1) NOT NULL,
--> Changed 2.0.3 20160503 TimPN
--    [SensorProcedureID]          UNIQUEIDENTIFIER NULL,
    [SensorID]          UNIQUEIDENTIFIER NULL,
--< Changed 2.0.3 20160503 TimPN
    [ImportDate]                 DATETIME         CONSTRAINT [DF_DataLog_ImportDate] DEFAULT (getdate()) NOT NULL,
    [ValueDate]                  DATETIME         NULL,
    [ValueTime]                  DATETIME         NULL,
    [ValueText]                  VARCHAR (50)     NOT NULL,
    [TransformValueText]         VARCHAR (50)     NULL,
    [RawValue]                   FLOAT (53)       NULL,
    [DataValue]                  FLOAT (53)       NULL,
    [Comment]                    VARCHAR (250)    NULL,
    [InvalidDateValue]           VARCHAR (50)     NULL,
    [InvalidTimeValue]           VARCHAR (50)     NULL,
    [InvalidOffering]            VARCHAR (50)     NULL,
    [InvalidUOM]                 VARCHAR (50)     NULL,
    [DataSourceTransformationID] UNIQUEIDENTIFIER NULL,
    [StatusID]                   UNIQUEIDENTIFIER NOT NULL,
    [ImportStatus]               VARCHAR (500)    NOT NULL,
    [UserId]                     UNIQUEIDENTIFIER NULL,
    [PhenomenonOfferingID]       UNIQUEIDENTIFIER NULL,
--> Changed 2.0.3 20160421 TimPN
--    [PhenonmenonUOMID]           UNIQUEIDENTIFIER NULL,
    [PhenomenonUOMID]           UNIQUEIDENTIFIER NULL,
--< Changed 2.0.3 20160421 TimPN
    [ImportBatchID]              INT              NOT NULL,
    [RawRecordData]              VARCHAR (500)    NULL,
    [RawFieldValue]              VARCHAR (50)     NOT NULL,
    CONSTRAINT [PK_DataLog] PRIMARY KEY CLUSTERED ([ID]),
    CONSTRAINT [FK_DataLog_aspnet_Users] FOREIGN KEY ([UserId]) REFERENCES [dbo].[aspnet_Users] ([UserId]),
    CONSTRAINT [FK_DataLog_DataSourceTransformation] FOREIGN KEY ([DataSourceTransformationID]) REFERENCES [dbo].[DataSourceTransformation] ([ID]),
    CONSTRAINT [FK_DataLog_ImportBatch] FOREIGN KEY ([ImportBatchID]) REFERENCES [dbo].[ImportBatch] ([ID]),
    CONSTRAINT [FK_DataLog_PhenomenonOffering] FOREIGN KEY ([PhenomenonOfferingID]) REFERENCES [dbo].[PhenomenonOffering] ([ID]),
    CONSTRAINT [FK_DataLog_PhenomenonUOM] FOREIGN KEY ([PhenomenonUOMID]) REFERENCES [dbo].[PhenomenonUOM] ([ID]),
--> Changed 2.0.3 20160503 TimPN
--    CONSTRAINT [FK_DataLog_SensorProcedure] FOREIGN KEY ([SensorProcedureID]) REFERENCES [dbo].[SensorProcedure] ([ID]),
    CONSTRAINT [FK_DataLog_Sensor] FOREIGN KEY ([SensorID]) REFERENCES [dbo].[Sensor] ([ID]),
--< Changed 2.0.3 20160503 TimPN
    CONSTRAINT [FK_DataLog_Status] FOREIGN KEY ([StatusID]) REFERENCES [dbo].[Status] ([ID])
);
GO
CREATE INDEX [IX_DataLog] ON [dbo].[DataLog]([ImportBatchID]);
--> Added 2.0.0 20160406 TimPN
GO
--> Changed 2.0.3 20160503 TimPN
--CREATE INDEX [IX_DataLog_SensorProcedureID] ON [dbo].[DataLog] ([SensorProcedureID]);
CREATE INDEX [IX_DataLog_SensorID] ON [dbo].[DataLog] ([SensorID]);
--< Changed 2.0.3 20160503 TimPN
GO
CREATE INDEX [IX_DataLog_DataSourceTransformationID] ON [dbo].[DataLog] ([DataSourceTransformationID])
GO
CREATE INDEX [IX_DataLog_PhenomenonOfferingID] ON [dbo].[DataLog] ([PhenomenonOfferingID])
GO
CREATE INDEX [IX_DataLog_PhenomenonUOMID] ON [dbo].[DataLog] ([PhenomenonUOMID])
GO
CREATE INDEX [IX_DataLog_StatusID] ON [dbo].[DataLog] ([StatusID])
GO
CREATE INDEX [IX_DataLog_UserId] ON [dbo].[DataLog] ([UserId])
--< Added 2.0.0 20160406 TimPN
