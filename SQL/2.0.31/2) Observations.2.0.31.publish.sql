﻿/*
Deployment script for Observations

This code was generated by a tool.
Changes to this file may cause incorrect behavior and will be lost if
the code is regenerated.
*/

GO
SET ANSI_NULLS, ANSI_PADDING, ANSI_WARNINGS, ARITHABORT, CONCAT_NULL_YIELDS_NULL, QUOTED_IDENTIFIER ON;

SET NUMERIC_ROUNDABORT OFF;


GO
:setvar DatabaseName "Observations"
:setvar DefaultFilePrefix "Observations"
:setvar DefaultDataPath "C:\Program Files\Microsoft SQL Server\MSSQL13.SAEON\MSSQL\DATA\"
:setvar DefaultLogPath "C:\Program Files\Microsoft SQL Server\MSSQL13.SAEON\MSSQL\DATA\"

GO
:on error exit
GO
/*
Detect SQLCMD mode and disable script execution if SQLCMD mode is not supported.
To re-enable the script after enabling SQLCMD mode, execute the following:
SET NOEXEC OFF; 
*/
:setvar __IsSqlCmdEnabled "True"
GO
IF N'$(__IsSqlCmdEnabled)' NOT LIKE N'True'
    BEGIN
        PRINT N'SQLCMD mode must be enabled to successfully execute this script.';
        SET NOEXEC ON;
    END


GO
IF (SELECT is_default
    FROM   [$(DatabaseName)].[sys].[filegroups]
    WHERE  [name] = N'Documents') = 0
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            MODIFY FILEGROUP [Documents] DEFAULT;
    END


GO
USE [$(DatabaseName)];


GO
PRINT N'The following operation was generated from a refactoring log file 918c74d0-40e9-42c0-93fd-69523ed88a2b';

PRINT N'Rename [dbo].[UserQueries].[QueryURI] to QueryInput';


GO
EXECUTE sp_rename @objname = N'[dbo].[UserQueries].[QueryURI]', @newname = N'QueryInput', @objtype = N'COLUMN';


GO
PRINT N'Dropping [dbo].[DF_DataLog_AddedAt]...';


GO
ALTER TABLE [dbo].[DataLog] DROP CONSTRAINT [DF_DataLog_AddedAt];


GO
PRINT N'Dropping [dbo].[DF_DataLog_ImportDate]...';


GO
ALTER TABLE [dbo].[DataLog] DROP CONSTRAINT [DF_DataLog_ImportDate];


GO
PRINT N'Dropping [dbo].[DF_DataLog_ID]...';


GO
ALTER TABLE [dbo].[DataLog] DROP CONSTRAINT [DF_DataLog_ID];


GO
PRINT N'Dropping [dbo].[DF_DataLog_UpdatedAt]...';


GO
ALTER TABLE [dbo].[DataLog] DROP CONSTRAINT [DF_DataLog_UpdatedAt];


GO
PRINT N'Dropping [dbo].[DF_Observation_AddedDate]...';


GO
ALTER TABLE [dbo].[Observation] DROP CONSTRAINT [DF_Observation_AddedDate];


GO
PRINT N'Dropping [dbo].[DF_Observation_UpdatedAt]...';


GO
ALTER TABLE [dbo].[Observation] DROP CONSTRAINT [DF_Observation_UpdatedAt];


GO
PRINT N'Dropping [dbo].[DF_Observation_AddedAt]...';


GO
ALTER TABLE [dbo].[Observation] DROP CONSTRAINT [DF_Observation_AddedAt];


GO
PRINT N'Dropping [dbo].[DF_UserDownloads_ID]...';


GO
ALTER TABLE [dbo].[UserDownloads] DROP CONSTRAINT [DF_UserDownloads_ID];


GO
PRINT N'Dropping [dbo].[DF_UserDownloads_AddedAt]...';


GO
ALTER TABLE [dbo].[UserDownloads] DROP CONSTRAINT [DF_UserDownloads_AddedAt];


GO
PRINT N'Dropping [dbo].[DF_UserDownloads_UpdatedAt]...';


GO
ALTER TABLE [dbo].[UserDownloads] DROP CONSTRAINT [DF_UserDownloads_UpdatedAt];


GO
PRINT N'Dropping [dbo].[FK_DataLog_DataSourceTransformation]...';


GO
ALTER TABLE [dbo].[DataLog] DROP CONSTRAINT [FK_DataLog_DataSourceTransformation];


GO
PRINT N'Dropping [dbo].[FK_DataLog_ImportBatch]...';


GO
ALTER TABLE [dbo].[DataLog] DROP CONSTRAINT [FK_DataLog_ImportBatch];


GO
PRINT N'Dropping [dbo].[FK_DataLog_PhenomenonOffering]...';


GO
ALTER TABLE [dbo].[DataLog] DROP CONSTRAINT [FK_DataLog_PhenomenonOffering];


GO
PRINT N'Dropping [dbo].[FK_DataLog_PhenomenonUOM]...';


GO
ALTER TABLE [dbo].[DataLog] DROP CONSTRAINT [FK_DataLog_PhenomenonUOM];


GO
PRINT N'Dropping [dbo].[FK_DataLog_Sensor]...';


GO
ALTER TABLE [dbo].[DataLog] DROP CONSTRAINT [FK_DataLog_Sensor];


GO
PRINT N'Dropping [dbo].[FK_DataLog_Status]...';


GO
ALTER TABLE [dbo].[DataLog] DROP CONSTRAINT [FK_DataLog_Status];


GO
PRINT N'Dropping [dbo].[FK_DataLog_StatusReason]...';


GO
ALTER TABLE [dbo].[DataLog] DROP CONSTRAINT [FK_DataLog_StatusReason];


GO
PRINT N'Dropping [dbo].[FK_DataLog_aspnet_Users]...';


GO
ALTER TABLE [dbo].[DataLog] DROP CONSTRAINT [FK_DataLog_aspnet_Users];


GO
PRINT N'Dropping [dbo].[FK_Observation_ImportBatch]...';


GO
ALTER TABLE [dbo].[Observation] DROP CONSTRAINT [FK_Observation_ImportBatch];


GO
PRINT N'Dropping [dbo].[FK_Observation_PhenomenonOffering]...';


GO
ALTER TABLE [dbo].[Observation] DROP CONSTRAINT [FK_Observation_PhenomenonOffering];


GO
PRINT N'Dropping [dbo].[FK_Observation_PhenomenonUOM]...';


GO
ALTER TABLE [dbo].[Observation] DROP CONSTRAINT [FK_Observation_PhenomenonUOM];


GO
PRINT N'Dropping [dbo].[FK_Observation_Sensor]...';


GO
ALTER TABLE [dbo].[Observation] DROP CONSTRAINT [FK_Observation_Sensor];


GO
PRINT N'Dropping [dbo].[FK_Observation_Status]...';


GO
ALTER TABLE [dbo].[Observation] DROP CONSTRAINT [FK_Observation_Status];


GO
PRINT N'Dropping [dbo].[FK_Observation_StatusReason]...';


GO
ALTER TABLE [dbo].[Observation] DROP CONSTRAINT [FK_Observation_StatusReason];


GO
PRINT N'Dropping [dbo].[FK_Observation_aspnet_Users]...';


GO
ALTER TABLE [dbo].[Observation] DROP CONSTRAINT [FK_Observation_aspnet_Users];


GO
PRINT N'Starting rebuilding table [dbo].[DataLog]...';


GO
BEGIN TRANSACTION;

SET TRANSACTION ISOLATION LEVEL SERIALIZABLE;

SET XACT_ABORT ON;

CREATE TABLE [dbo].[tmp_ms_xx_DataLog] (
    [ID]                         UNIQUEIDENTIFIER CONSTRAINT [DF_DataLog_ID] DEFAULT newid() NOT NULL,
    [SensorID]                   UNIQUEIDENTIFIER NULL,
    [ImportDate]                 DATETIME         CONSTRAINT [DF_DataLog_ImportDate] DEFAULT (getdate()) NOT NULL,
    [ValueDate]                  DATETIME         NULL,
    [ValueTime]                  DATETIME         NULL,
    [ValueDay]                   AS               CAST (ValueDate AS DATE),
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
    [StatusReasonID]             UNIQUEIDENTIFIER NULL,
    [ImportStatus]               VARCHAR (500)    NOT NULL,
    [UserId]                     UNIQUEIDENTIFIER NULL,
    [PhenomenonOfferingID]       UNIQUEIDENTIFIER NULL,
    [PhenomenonUOMID]            UNIQUEIDENTIFIER NULL,
    [ImportBatchID]              UNIQUEIDENTIFIER NOT NULL,
    [RawRecordData]              VARCHAR (500)    NULL,
    [RawFieldValue]              VARCHAR (50)     NOT NULL,
    [CorrelationID]              UNIQUEIDENTIFIER NULL,
    [AddedAt]                    DATETIME         CONSTRAINT [DF_DataLog_AddedAt] DEFAULT GetDate() NULL,
    [UpdatedAt]                  DATETIME         CONSTRAINT [DF_DataLog_UpdatedAt] DEFAULT GetDate() NULL,
    CONSTRAINT [tmp_ms_xx_constraint_PK_DataLog1] PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [tmp_ms_xx_constraint_UX_DataLog1] UNIQUE NONCLUSTERED ([ImportBatchID] ASC, [SensorID] ASC, [ImportDate] ASC, [ValueDate] ASC, [ValueTime] ASC, [PhenomenonOfferingID] ASC, [PhenomenonUOMID] ASC)
);

IF EXISTS (SELECT TOP 1 1 
           FROM   [dbo].[DataLog])
    BEGIN
        INSERT INTO [dbo].[tmp_ms_xx_DataLog] ([ID], [SensorID], [ImportDate], [ValueDate], [ValueTime], [ValueText], [TransformValueText], [RawValue], [DataValue], [Comment], [InvalidDateValue], [InvalidTimeValue], [InvalidOffering], [InvalidUOM], [DataSourceTransformationID], [StatusID], [StatusReasonID], [ImportStatus], [UserId], [PhenomenonOfferingID], [PhenomenonUOMID], [ImportBatchID], [RawRecordData], [RawFieldValue], [CorrelationID], [AddedAt], [UpdatedAt])
        SELECT   [ID],
                 [SensorID],
                 [ImportDate],
                 [ValueDate],
                 [ValueTime],
                 [ValueText],
                 [TransformValueText],
                 [RawValue],
                 [DataValue],
                 [Comment],
                 [InvalidDateValue],
                 [InvalidTimeValue],
                 [InvalidOffering],
                 [InvalidUOM],
                 [DataSourceTransformationID],
                 [StatusID],
                 [StatusReasonID],
                 [ImportStatus],
                 [UserId],
                 [PhenomenonOfferingID],
                 [PhenomenonUOMID],
                 [ImportBatchID],
                 [RawRecordData],
                 [RawFieldValue],
                 [CorrelationID],
                 [AddedAt],
                 [UpdatedAt]
        FROM     [dbo].[DataLog]
        ORDER BY [ID] ASC;
    END

DROP TABLE [dbo].[DataLog];

EXECUTE sp_rename N'[dbo].[tmp_ms_xx_DataLog]', N'DataLog';

EXECUTE sp_rename N'[dbo].[tmp_ms_xx_constraint_PK_DataLog1]', N'PK_DataLog', N'OBJECT';

EXECUTE sp_rename N'[dbo].[tmp_ms_xx_constraint_UX_DataLog1]', N'UX_DataLog', N'OBJECT';

COMMIT TRANSACTION;

SET TRANSACTION ISOLATION LEVEL READ COMMITTED;


GO
PRINT N'Creating [dbo].[DataLog].[IX_DataLog_ImportBatchID]...';


GO
CREATE NONCLUSTERED INDEX [IX_DataLog_ImportBatchID]
    ON [dbo].[DataLog]([ImportBatchID] ASC);


GO
PRINT N'Creating [dbo].[DataLog].[IX_DataLog_SensorID]...';


GO
CREATE NONCLUSTERED INDEX [IX_DataLog_SensorID]
    ON [dbo].[DataLog]([SensorID] ASC);


GO
PRINT N'Creating [dbo].[DataLog].[IX_DataLog_ValueDay]...';


GO
CREATE NONCLUSTERED INDEX [IX_DataLog_ValueDay]
    ON [dbo].[DataLog]([ValueDay] ASC);


GO
PRINT N'Creating [dbo].[DataLog].[IX_DataLog_DataSourceTransformationID]...';


GO
CREATE NONCLUSTERED INDEX [IX_DataLog_DataSourceTransformationID]
    ON [dbo].[DataLog]([DataSourceTransformationID] ASC);


GO
PRINT N'Creating [dbo].[DataLog].[IX_DataLog_PhenomenonOfferingID]...';


GO
CREATE NONCLUSTERED INDEX [IX_DataLog_PhenomenonOfferingID]
    ON [dbo].[DataLog]([PhenomenonOfferingID] ASC);


GO
PRINT N'Creating [dbo].[DataLog].[IX_DataLog_PhenomenonUOMID]...';


GO
CREATE NONCLUSTERED INDEX [IX_DataLog_PhenomenonUOMID]
    ON [dbo].[DataLog]([PhenomenonUOMID] ASC);


GO
PRINT N'Creating [dbo].[DataLog].[IX_DataLog_StatusID]...';


GO
CREATE NONCLUSTERED INDEX [IX_DataLog_StatusID]
    ON [dbo].[DataLog]([StatusID] ASC);


GO
PRINT N'Creating [dbo].[DataLog].[IX_DataLog_UserId]...';


GO
CREATE NONCLUSTERED INDEX [IX_DataLog_UserId]
    ON [dbo].[DataLog]([UserId] ASC);


GO
PRINT N'Creating [dbo].[DataLog].[IX_DataLog_StatusReasonID]...';


GO
CREATE NONCLUSTERED INDEX [IX_DataLog_StatusReasonID]
    ON [dbo].[DataLog]([StatusReasonID] ASC);


GO
PRINT N'Starting rebuilding table [dbo].[Observation]...';

GO
PRINT N'Creating [dbo].[Observation].[IX_Observation_ImportBatchID]...';


GO
CREATE NONCLUSTERED INDEX [IX_Observation_ImportBatchID]
    ON [dbo].[Observation]([ImportBatchID] ASC)
    INCLUDE([ValueDate], [RawValue], [DataValue], [Comment], [CorrelationID])
    ON [Observations];


--GO
--PRINT N'Creating [dbo].[Observation].[IX_Observation_SensorID]...';


--GO
--CREATE NONCLUSTERED INDEX [IX_Observation_SensorID]
--    ON [dbo].[Observation]([SensorID] ASC)
--    ON [Observations];


--GO
--PRINT N'Creating [dbo].[Observation].[IX_Observation_PhenomenonOfferingID]...';


--GO
--CREATE NONCLUSTERED INDEX [IX_Observation_PhenomenonOfferingID]
--    ON [dbo].[Observation]([PhenomenonOfferingID] ASC)
--    ON [Observations];


--GO
--PRINT N'Creating [dbo].[Observation].[IX_Observation_PhenomenonUOMID]...';


--GO
--CREATE NONCLUSTERED INDEX [IX_Observation_PhenomenonUOMID]
--    ON [dbo].[Observation]([PhenomenonUOMID] ASC)
--    ON [Observations];


--GO
--PRINT N'Creating [dbo].[Observation].[IX_Observation_UserId]...';


--GO
--CREATE NONCLUSTERED INDEX [IX_Observation_UserId]
--    ON [dbo].[Observation]([UserId] ASC)
--    ON [Observations];


GO
PRINT N'Creating [dbo].[Observation].[IX_Observation_AddedDate]...';


GO
CREATE NONCLUSTERED INDEX [IX_Observation_AddedDate]
    ON [dbo].[Observation]([AddedDate] ASC)
    ON [Observations];


GO
PRINT N'Creating [dbo].[Observation].[IX_Observation_ValueDate]...';


GO
CREATE NONCLUSTERED INDEX [IX_Observation_ValueDate]
    ON [dbo].[Observation]([ValueDate] ASC)
    ON [Observations];


GO
PRINT N'Creating [dbo].[Observation].[IX_Observation_ValueDateDesc]...';


GO
CREATE NONCLUSTERED INDEX [IX_Observation_ValueDateDesc]
    ON [dbo].[Observation]([ValueDate] DESC)
    ON [Observations];


GO
PRINT N'Creating [dbo].[Observation].[IX_Observation_ValueDay]...';


GO
CREATE NONCLUSTERED INDEX [IX_Observation_ValueDay]
    ON [dbo].[Observation]([ValueDay] ASC);


--GO
--PRINT N'Creating [dbo].[Observation].[IX_Observation_StatusID]...';


--GO
--CREATE NONCLUSTERED INDEX [IX_Observation_StatusID]
--    ON [dbo].[Observation]([StatusID] ASC)
--    ON [Observations];


--GO
--PRINT N'Creating [dbo].[Observation].[IX_Observation_StatusReasonID]...';


--GO
--CREATE NONCLUSTERED INDEX [IX_Observation_StatusReasonID]
--    ON [dbo].[Observation]([StatusReasonID] ASC)
--    ON [Observations];


--GO
--PRINT N'Creating [dbo].[Observation].[IX_Observation_CorrelationID]...';


--GO
--CREATE NONCLUSTERED INDEX [IX_Observation_CorrelationID]
--    ON [dbo].[Observation]([CorrelationID] ASC)
--    ON [Observations];


GO
PRINT N'Starting rebuilding table [dbo].[UserDownloads]...';


GO
SET ANSI_NULLS, QUOTED_IDENTIFIER OFF;


GO
SET ANSI_NULLS, QUOTED_IDENTIFIER OFF;


GO
BEGIN TRANSACTION;

SET TRANSACTION ISOLATION LEVEL SERIALIZABLE;

SET XACT_ABORT ON;

CREATE TABLE [dbo].[tmp_ms_xx_UserDownloads] (
    [ID]          UNIQUEIDENTIFIER CONSTRAINT [DF_UserDownloads_ID] DEFAULT NewId() NOT NULL,
    [UserId]      NVARCHAR (128)   NOT NULL,
    [Name]        VARCHAR (150)    NOT NULL,
    [Description] VARCHAR (5000)   NULL,
    [QueryInput]  VARCHAR (5000)   NOT NULL,
    [DownloadURI] VARCHAR (500)    NOT NULL,
    [AddedAt]     DATETIME         CONSTRAINT [DF_UserDownloads_AddedAt] DEFAULT GetDate() NULL,
    [AddedBy]     NVARCHAR (128)   NOT NULL,
    [UpdatedAt]   DATETIME         CONSTRAINT [DF_UserDownloads_UpdatedAt] DEFAULT GetDate() NULL,
    [UpdatedBy]   NVARCHAR (128)   NOT NULL,
    CONSTRAINT [tmp_ms_xx_constraint_PK_UserDownloads1] PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [tmp_ms_xx_constraint_UX_UserDownloads_UserId_Name1] UNIQUE NONCLUSTERED ([UserId] ASC, [Name] ASC)
);

IF EXISTS (SELECT TOP 1 1 
           FROM   [dbo].[UserDownloads])
    BEGIN
        INSERT INTO [dbo].[tmp_ms_xx_UserDownloads] ([ID], [UserId], [Name], [Description], [DownloadURI], [AddedAt], [AddedBy], [UpdatedAt], [UpdatedBy])
        SELECT   [ID],
                 [UserId],
                 [Name],
                 [Description],
                 [DownloadURI],
                 [AddedAt],
                 [AddedBy],
                 [UpdatedAt],
                 [UpdatedBy]
        FROM     [dbo].[UserDownloads]
        ORDER BY [ID] ASC;
    END

DROP TABLE [dbo].[UserDownloads];

EXECUTE sp_rename N'[dbo].[tmp_ms_xx_UserDownloads]', N'UserDownloads';

EXECUTE sp_rename N'[dbo].[tmp_ms_xx_constraint_PK_UserDownloads1]', N'PK_UserDownloads', N'OBJECT';

EXECUTE sp_rename N'[dbo].[tmp_ms_xx_constraint_UX_UserDownloads_UserId_Name1]', N'UX_UserDownloads_UserId_Name', N'OBJECT';

COMMIT TRANSACTION;

SET TRANSACTION ISOLATION LEVEL READ COMMITTED;


GO
SET ANSI_NULLS, QUOTED_IDENTIFIER ON;


GO
SET ANSI_NULLS, QUOTED_IDENTIFIER ON;


GO
PRINT N'Altering [dbo].[UserQueries]...';


GO
SET ANSI_NULLS, QUOTED_IDENTIFIER OFF;


GO
ALTER TABLE [dbo].[UserQueries] ALTER COLUMN [QueryInput] VARCHAR (5000) NOT NULL;


GO
SET ANSI_NULLS, QUOTED_IDENTIFIER ON;


GO
PRINT N'Creating [dbo].[FK_DataLog_DataSourceTransformation]...';


GO
ALTER TABLE [dbo].[DataLog] WITH NOCHECK
    ADD CONSTRAINT [FK_DataLog_DataSourceTransformation] FOREIGN KEY ([DataSourceTransformationID]) REFERENCES [dbo].[DataSourceTransformation] ([ID]);


GO
PRINT N'Creating [dbo].[FK_DataLog_ImportBatch]...';


GO
ALTER TABLE [dbo].[DataLog] WITH NOCHECK
    ADD CONSTRAINT [FK_DataLog_ImportBatch] FOREIGN KEY ([ImportBatchID]) REFERENCES [dbo].[ImportBatch] ([ID]);


GO
PRINT N'Creating [dbo].[FK_DataLog_PhenomenonOffering]...';


GO
ALTER TABLE [dbo].[DataLog] WITH NOCHECK
    ADD CONSTRAINT [FK_DataLog_PhenomenonOffering] FOREIGN KEY ([PhenomenonOfferingID]) REFERENCES [dbo].[PhenomenonOffering] ([ID]);


GO
PRINT N'Creating [dbo].[FK_DataLog_PhenomenonUOM]...';


GO
ALTER TABLE [dbo].[DataLog] WITH NOCHECK
    ADD CONSTRAINT [FK_DataLog_PhenomenonUOM] FOREIGN KEY ([PhenomenonUOMID]) REFERENCES [dbo].[PhenomenonUOM] ([ID]);


GO
PRINT N'Creating [dbo].[FK_DataLog_Sensor]...';


GO
ALTER TABLE [dbo].[DataLog] WITH NOCHECK
    ADD CONSTRAINT [FK_DataLog_Sensor] FOREIGN KEY ([SensorID]) REFERENCES [dbo].[Sensor] ([ID]);


GO
PRINT N'Creating [dbo].[FK_DataLog_Status]...';


GO
ALTER TABLE [dbo].[DataLog] WITH NOCHECK
    ADD CONSTRAINT [FK_DataLog_Status] FOREIGN KEY ([StatusID]) REFERENCES [dbo].[Status] ([ID]);


GO
PRINT N'Creating [dbo].[FK_DataLog_StatusReason]...';


GO
ALTER TABLE [dbo].[DataLog] WITH NOCHECK
    ADD CONSTRAINT [FK_DataLog_StatusReason] FOREIGN KEY ([StatusReasonID]) REFERENCES [dbo].[StatusReason] ([ID]);


GO
PRINT N'Creating [dbo].[FK_DataLog_aspnet_Users]...';


GO
ALTER TABLE [dbo].[DataLog] WITH NOCHECK
    ADD CONSTRAINT [FK_DataLog_aspnet_Users] FOREIGN KEY ([UserId]) REFERENCES [dbo].[aspnet_Users] ([UserId]);


GO
PRINT N'Creating [dbo].[FK_Observation_ImportBatch]...';


GO
ALTER TABLE [dbo].[Observation] WITH NOCHECK
    ADD CONSTRAINT [FK_Observation_ImportBatch] FOREIGN KEY ([ImportBatchID]) REFERENCES [dbo].[ImportBatch] ([ID]);


GO
PRINT N'Creating [dbo].[FK_Observation_PhenomenonOffering]...';


GO
ALTER TABLE [dbo].[Observation] WITH NOCHECK
    ADD CONSTRAINT [FK_Observation_PhenomenonOffering] FOREIGN KEY ([PhenomenonOfferingID]) REFERENCES [dbo].[PhenomenonOffering] ([ID]);


GO
PRINT N'Creating [dbo].[FK_Observation_PhenomenonUOM]...';


GO
ALTER TABLE [dbo].[Observation] WITH NOCHECK
    ADD CONSTRAINT [FK_Observation_PhenomenonUOM] FOREIGN KEY ([PhenomenonUOMID]) REFERENCES [dbo].[PhenomenonUOM] ([ID]);


GO
PRINT N'Creating [dbo].[FK_Observation_Sensor]...';


GO
ALTER TABLE [dbo].[Observation] WITH NOCHECK
    ADD CONSTRAINT [FK_Observation_Sensor] FOREIGN KEY ([SensorID]) REFERENCES [dbo].[Sensor] ([ID]);


GO
PRINT N'Creating [dbo].[FK_Observation_Status]...';


GO
ALTER TABLE [dbo].[Observation] WITH NOCHECK
    ADD CONSTRAINT [FK_Observation_Status] FOREIGN KEY ([StatusID]) REFERENCES [dbo].[Status] ([ID]);


GO
PRINT N'Creating [dbo].[FK_Observation_StatusReason]...';


GO
ALTER TABLE [dbo].[Observation] WITH NOCHECK
    ADD CONSTRAINT [FK_Observation_StatusReason] FOREIGN KEY ([StatusReasonID]) REFERENCES [dbo].[StatusReason] ([ID]);


GO
PRINT N'Creating [dbo].[FK_Observation_aspnet_Users]...';


GO
ALTER TABLE [dbo].[Observation] WITH NOCHECK
    ADD CONSTRAINT [FK_Observation_aspnet_Users] FOREIGN KEY ([UserId]) REFERENCES [dbo].[aspnet_Users] ([UserId]);


GO
PRINT N'Creating [dbo].[TR_DataLog_Insert]...';


GO
CREATE TRIGGER [dbo].[TR_DataLog_Insert] ON [dbo].[DataLog]
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
        DataLog src
        inner join inserted ins 
            on (ins.ID = src.ID)
END
GO
PRINT N'Creating [dbo].[TR_DataLog_Update]...';


GO
CREATE TRIGGER [dbo].[TR_DataLog_Update] ON [dbo].[DataLog]
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
        DataLog src
        inner join inserted ins 
            on (ins.ID = src.ID)
        inner join deleted del
            on (del.ID = src.ID)
END
--< Changed 2.0.15 20161102 TimPN
--< Added 2.0.8 20160708 TimPN
--GO
--PRINT N'Creating [dbo].[TR_Observation_Insert]...';


--GO
--CREATE TRIGGER [dbo].[TR_Observation_Insert] ON [dbo].[Observation]
--FOR INSERT
--AS
--BEGIN
--    SET NoCount ON
--    Update
--        src
--    set
--        AddedAt = GETDATE(),
--        UpdatedAt = NULL
--    from
--        Observation src
--        inner join inserted ins
--            on (ins.ID = src.ID)
--END
--GO
--PRINT N'Creating [dbo].[TR_Observation_Update]...';


--GO
--CREATE TRIGGER [dbo].[TR_Observation_Update] ON [dbo].[Observation]
--FOR UPDATE
--AS
--BEGIN
--    SET NoCount ON
--    Update
--        src
--    set
----> Changed 2.0.19 20161205 TimPN
----		AddedAt = del.AddedAt,
--        AddedAt = Coalesce(del.AddedAt, ins.AddedAt, GetDate ()),
----< Changed 2.0.19 20161205 TimPN
--        UpdatedAt = GETDATE()
--    from
--        Observation src
--        inner join inserted ins
--            on (ins.ID = src.ID)
--        inner join deleted del
--            on (del.ID = src.ID)
--END
----< Changed 2.0.15 20161102 TimPN
----< Added 2.0.8 20160718 TimPN
GO
PRINT N'Creating [dbo].[TR_UserDownloads_Insert]...';


GO
SET ANSI_NULLS, QUOTED_IDENTIFIER OFF;


GO
CREATE TRIGGER [dbo].[TR_UserDownloads_Insert] ON [dbo].[UserDownloads]
FOR INSERT
AS
BEGIN
  SET NoCount ON
  Update
      src
  set
      AddedAt = GetDate(),
      UpdatedAt = NULL
  from
    UserDownloads src
    inner join inserted ins
      on (ins.ID = src.ID)
END
GO
SET ANSI_NULLS, QUOTED_IDENTIFIER ON;


GO
PRINT N'Creating [dbo].[TR_UserDownloads_Update]...';


GO
SET ANSI_NULLS, QUOTED_IDENTIFIER OFF;


GO
CREATE TRIGGER [dbo].[TR_UserDownloads_Update] ON [dbo].[UserDownloads]
FOR UPDATE
AS
BEGIN
  SET NoCount ON
  Update
      src
  set
    AddedAt = Coalesce(del.AddedAt, ins.AddedAt, GetDate ()),
    UpdatedAt = GetDate ()
  from
    UserDownloads src
    inner join inserted ins
      on (ins.ID = src.ID)
    inner join deleted del
      on (del.ID = src.ID)
END
--< Added 2.0.26 20170127 TimPN
GO
SET ANSI_NULLS, QUOTED_IDENTIFIER ON;


GO
PRINT N'Altering [dbo].[vDataLog]...';


GO
--> Changed 2.0.3 20160503 TimPN
--Renamed SensorProcedure to Sensor
--< Changed 2.0.3 20160503 TimPN
ALTER VIEW [dbo].[vDataLog]
AS

SELECT 
d.ID, 
d.ImportDate,

--> Added 2.0.17 20161128 TimPN
Site.Name SiteName,
Station.Name StationName,
Instrument.Name InstrumentName,
--< Added 2.0.17 20161128 TimPN
--> Removed 2.0.17 20161128 TimPN
--org.Name Organisation,
--ps.[Description] ProjectSite,
--st.Name StationName,
--< Removed 2.0.17 20161128 TimPN
d.SensorID,
Sensor.Name SensorName,
CASE 
    WHEN d.SensorID is null then 1
    ELSE 0
END SensorInvalid,

d.ValueDate,
d.InvalidDateValue, 
CASE 
    WHEN ValueDate is null then 1
    ELSE 0
END DateValueInvalid,

d.InvalidTimeValue, 
CASE 
    WHEN InvalidTimeValue is not null then 1
    ELSE 0
END TimeValueInvalid,

CASE 
    WHEN InvalidDateValue is null AND InvalidTimeValue IS NULL Then ValueDate
    WHEN ValueTime is not null then ValueTime 
END ValueTime,


d.RawValue,
d.ValueText,
CASE
    WHEN d.RawValue is null then 1
    ELSE 0
END RawValueInvalid,	

d.DataValue,
d.TransformValueText, 
CASE
    WHEN d.DataValue is null then 1
    ELSE 0
END DataValueInvalid,

d.PhenomenonOfferingID, 
CASE
    WHEN d.PhenomenonOfferingID is null then 1
    ELSE 0
END OfferingInvalid,

--> Changed 2.0.3 20160421 TimPN
--d.PhenonmenonUOMID, 
d.PhenomenonUOMID, 
--< Changed 2.0.3 20160421 TimPN
CASE
--> Changed 2.0.3 20160421 TimPN
--    WHEN d.PhenonmenonUOMID is null then 1
    WHEN d.PhenomenonUOMID is null then 1
--< Changed 2.0.3 20160421 TimPN
    ELSE 0
END UOMInvalid,

p.Name PhenomenonName,
o.Name OfferingName,
uom.Unit,

d.DataSourceTransformationID,
tt.Name Transformation,
d.StatusID,
s.Name [Status],
d.ImportBatchID,
d.RawFieldValue,
d.Comment

FROM DataLog d
--> Removed 2.0.17 20161128 TimPN
--LEFT JOIN Sensor sp
--    on d.SensorID = sp.ID
--LEFT JOIN Station st
--    on sp.StationID = st.ID
--LEFT JOIN ProjectSite ps
--    on st.ProjectSiteID = ps.ID
--LEFT JOIN Organisation org
--    on ps.OrganisationID = org.ID
--< Removed 2.0.17 20161128 TimPN
--> Added 2.0.17 20161128 TimPN
--> Changed 2.0.28 20170317 TimPN
--  inner join Sensor 
  left join Sensor 
--< Changed 2.0.28 20170317 TimPN
    on (d.SensorID = Sensor.ID) 
--> Changed 2.0.28 20170317 TimPN
--  inner join Instrument_Sensor
  left join Instrument_Sensor
--< Changed 2.0.28 20170317 TimPN
    on (Instrument_Sensor.SensorID = Sensor.ID) and
--> Changed 2.0.22 20170111 TimPN
--	   ((Instrument_Sensor.StartDate is null) or (d.ValueDate >= Instrument_Sensor.StartDate)) and
--	   ((Instrument_Sensor.EndDate is null) or (d.ValueDate <= Instrument_Sensor.EndDate))
--> Changed 2.0.31 20170423 TimPN
       --((Instrument_Sensor.StartDate is null) or (Cast(d.ValueDate as Date) >= Instrument_Sensor.StartDate)) and
       --((Instrument_Sensor.EndDate is null) or (Cast(d.ValueDate as Date) <= Instrument_Sensor.EndDate))
       ((Instrument_Sensor.StartDate is null) or (d.ValueDay >= Instrument_Sensor.StartDate)) and
       ((Instrument_Sensor.EndDate is null) or (d.ValueDay <= Instrument_Sensor.EndDate))
--< Changed 2.0.31 20170423 TimPN
--< Changed 2.0.22 20170111 TimPN
--> Changed 2.0.28 20170317 TimPN
--  inner join Instrument
  left join Instrument
--< Changed 2.0.28 20170317 TimPN
    on (Instrument_Sensor.InstrumentID = Instrument.ID) and
--> Changed 2.0.22 20170111 TimPN
--	   ((Instrument.StartDate is null) or (d.ValueDate >= Instrument.StartDate )) and
--	   ((Instrument.EndDate is null) or (d.ValueDate <= Instrument.EndDate))
--> Changed 2.0.31 20170423 TimPN
       --((Instrument.StartDate is null) or (Cast(d.ValueDate as Date) >= Instrument.StartDate )) and
       --((Instrument.EndDate is null) or (Cast(d.ValueDate as Date) <= Instrument.EndDate))
       ((Instrument.StartDate is null) or (d.ValueDay >= Instrument.StartDate )) and
       ((Instrument.EndDate is null) or (d.ValueDay <= Instrument.EndDate))
--< Changed 2.0.31 20170423 TimPN
--< Changed 2.0.22 20170111 TimPN
--> Changed 2.0.28 20170317 TimPN
--  inner join Station_Instrument
  left join Station_Instrument
--< Changed 2.0.28 20170317 TimPN
    on (Station_Instrument.InstrumentID = Instrument.ID) and
--> Changed 2.0.22 20170111 TimPN
--	   ((Station_Instrument.StartDate is null) or (d.ValueDate >= Station_Instrument.StartDate)) and
--	   ((Station_Instrument.EndDate is null) or (d.ValueDate <= Station_Instrument.EndDate))
--> Changed 2.0.31 20170423 TimPN
       --((Station_Instrument.StartDate is null) or (Cast(d.ValueDate as Date) >= Station_Instrument.StartDate)) and
       --((Station_Instrument.EndDate is null) or (Cast(d.ValueDate as Date) <= Station_Instrument.EndDate))
       ((Station_Instrument.StartDate is null) or (d.ValueDay >= Station_Instrument.StartDate)) and
       ((Station_Instrument.EndDate is null) or (d.ValueDay <= Station_Instrument.EndDate))
--< Changed 2.0.31 20170423 TimPN
--< Changed 2.0.22 20170111 TimPN
--> Changed 2.0.28 20170317 TimPN
--  inner join Station 
  left join Station 
--< Changed 2.0.28 20170317 TimPN
    on (Station_Instrument.StationID = Station.ID) and
--> Changed 2.0.22 20170111 TimPN
--	   ((Station.StartDate is null) or (Cast(d.ValueDate as Date) >= Cast(Station.StartDate as Date))) and
--	   ((Station.EndDate is null) or (Cast(d.ValueDate as Date) <= Cast(Station.EndDate as Date)))
--> Changed 2.0.31 20170423 TimPN
       --((Station.StartDate is null) or (Cast(d.ValueDate as Date) >= Station.StartDate)) and
       --((Station.EndDate is null) or (Cast(d.ValueDate as Date) <= Station.EndDate))
       ((Station.StartDate is null) or (d.ValueDay >= Station.StartDate)) and
       ((Station.EndDate is null) or (d.ValueDay <= Station.EndDate))
--< Changed 2.0.31 20170423 TimPN
--< Changed 2.0.22 20170111 TimPN
--> Changed 2.0.28 20170317 TimPN
--  inner join Site
  left join Site
--< Changed 2.0.28 20170317 TimPN
    on (Station.SiteID = Site.ID) and
--> Changed 2.0.22 20170111 TimPN
--	   ((Site.StartDate is null) or  (Cast(d.ValueDate as Date) >= Cast(Site.StartDate as Date))) and
--	   ((Site.EndDate is null) or  (Cast(d.ValueDate as Date) <= Cast(Site.EndDate as Date)))
--> Changed 2.0.31 20170423 TimPN
       --((Site.StartDate is null) or  (Cast(d.ValueDate as Date) >= Site.StartDate)) and
       --((Site.EndDate is null) or  (Cast(d.ValueDate as Date) <= Site.EndDate))
       ((Site.StartDate is null) or  (d.ValueDay >= Site.StartDate)) and
       ((Site.EndDate is null) or  (d.ValueDay <= Site.EndDate))
--< Changed 2.0.31 20170423 TimPN
--< Changed 2.0.22 20170111 TimPN
--< Added 2.0.17 20161128 TimPN
LEFT JOIN PhenomenonOffering po
 ON d.PhenomenonOfferingID = po.ID
LEFT JOIN Phenomenon p
    on po.PhenomenonID = p.ID
LEFT JOIN Offering o
    on po.OfferingID = o.ID
LEFT JOIN PhenomenonUOM pu
--> Changed 2.0.3 20160421 TimPN
--    on d.PhenonmenonUOMID = pu.ID
    on d.PhenomenonUOMID = pu.ID
--< Changed 2.0.3 20160421 TimPN
LEFT JOIN UnitOfMeasure uom
    on pu.UnitOfMeasureID = uom.ID
LEFT JOIN DataSourceTransformation ds
    on d.DataSourceTransformationID = ds.ID
LEFT JOIN TransformationType tt
    on ds.TransformationTypeID = tt.ID
INNER JOIN [Status] s
    on d.StatusID = s.ID
GO
PRINT N'Altering [dbo].[vDownloads]...';


GO
SET ANSI_NULLS, QUOTED_IDENTIFIER OFF;


GO
--> Added 2.0.26 20170130 TimPN
ALTER VIEW [dbo].[vDownloads]
AS
Select
  Observation.ID,
  Site.ID SiteID,
  Site.Code SiteCode,
  Site.Name SiteName,
  Site.Description SiteDescription,
  Site.Url SiteUrl,
  Station.ID StationID,
  Station.Code StationCode,
  Station.Name StationName,
  Station.Description StationDescription,
  Station.Url StationUrl,
  Station.Latitude StationLatitude,
  Station.Longitude StationLongitude,
  Station.Elevation StationElevation,
  Instrument.ID InstrumentID,
  Instrument.Code InstrumentCode,
  Instrument.Name InstrumentName,
  Instrument.Description InstrumentDescription,
  Instrument.Url InstrumentUrl,
  Sensor.ID SensorID,
  Sensor.Code SensorCode,
  Sensor.Name SensorName,
  Sensor.Description SensorDescription,
  Sensor.Url SensorUrl,
  Phenomenon.ID PhenomenonID,
  Phenomenon.Code PhenomenonCode,
  Phenomenon.Name PhenomenonName,
  Phenomenon.Description PhenomenonDescription,
  Phenomenon.Url PhenomenonUrl,
  PhenomenonOffering.ID PhenomenonOfferingID,
  Offering.ID OfferingID,
  Offering.Code OfferingCode,
  Offering.Name OfferingName,
  Offering.Description OfferingDescription,
  PhenomenonUOM.ID PhenomenonUnitOfMeasureID,
  UnitOfMeasure.ID UnitOfMeasureID,
  UnitOfMeasure.Code UnitOfMeasureCode,
  UnitOfMeasure.Unit UnitOfMeasureUnit,
  UnitOfMeasure.UnitSymbol UnitOfMeasureSymbol,
  Phenomenon.Name + ', ' + Offering.Name + ', ' + UnitOfMeasure.UnitSymbol Feature,
  Observation.ValueDate,
  Observation.ValueDay,
  Observation.RawValue,
  Observation.DataValue,
  Observation.Comment,
  Observation.CorrelationID
from
  Observation
  inner join Status
    on (Observation.StatusID = Status.ID)
  inner join Sensor
    on (Observation.SensorID = Sensor.ID)
  inner join PhenomenonOffering
    on (Observation.PhenomenonOfferingID = PhenomenonOffering.ID)
  inner join Phenomenon
    on (PhenomenonOffering.PhenomenonID = Phenomenon.ID)
  inner join Offering
    on (PhenomenonOffering.OfferingID = Offering.ID)
  inner join PhenomenonUOM
    on (Observation.PhenomenonUOMID = PhenomenonUOM.ID)
  inner join UnitOfMeasure
    on (PhenomenonUOM.UnitOfMeasureID = UnitOfMeasure.ID)
  inner join Instrument_Sensor
    on (Instrument_Sensor.SensorID = Sensor.ID) and
--> Changed 2.0.31 20170423 TimPN
       --((Instrument_Sensor.StartDate is null) or (Cast(Observation.ValueDate as Date) >= Instrument_Sensor.StartDate)) and
       --((Instrument_Sensor.EndDate is null) or (Cast(Observation.ValueDate as Date) <= Instrument_Sensor.EndDate))
       ((Instrument_Sensor.StartDate is null) or (Observation.ValueDay >= Instrument_Sensor.StartDate)) and
       ((Instrument_Sensor.EndDate is null) or (Observation.ValueDay <= Instrument_Sensor.EndDate))
--< Changed 2.0.31 20170423 TimPN
  inner join Instrument
    on (Instrument_Sensor.InstrumentID = Instrument.ID) and
--> Changed 2.0.31 20170423 TimPN
       --((Instrument.StartDate is null) or (Cast(Observation.ValueDate as Date) >= Instrument.StartDate )) and
       --((Instrument.EndDate is null) or (Cast(Observation.ValueDate as Date) <= Instrument.EndDate))
       ((Instrument.StartDate is null) or (Observation.ValueDay >= Instrument.StartDate )) and
       ((Instrument.EndDate is null) or (Observation.ValueDay <= Instrument.EndDate))
--< Changed 2.0.31 20170423 TimPN
  inner join Station_Instrument
    on (Station_Instrument.InstrumentID = Instrument.ID) and
--> Changed 2.0.31 20170423 TimPN
       --((Station_Instrument.StartDate is null) or (Cast(Observation.ValueDate as Date) >= Station_Instrument.StartDate)) and
       --((Station_Instrument.EndDate is null) or (Cast(Observation.ValueDate as Date) <= Station_Instrument.EndDate))
       ((Station_Instrument.StartDate is null) or (Observation.ValueDay >= Station_Instrument.StartDate)) and
       ((Station_Instrument.EndDate is null) or (Observation.ValueDay <= Station_Instrument.EndDate))
--< Changed 2.0.31 20170423 TimPN
  inner join Station
    on (Station_Instrument.StationID = Station.ID) and
--> Changed 2.0.31 20170423 TimPN
       --((Station.StartDate is null) or (Cast(Observation.ValueDate as Date) >= Cast(Station.StartDate as Date))) and
       --((Station.EndDate is null) or (Cast(Observation.ValueDate as Date) <= Cast(Station.EndDate as Date)))
       ((Station.StartDate is null) or (Observation.ValueDay = Station.StartDate)) and
       ((Station.EndDate is null) or (Observation.ValueDay <= Station.EndDate))
--< Changed 2.0.31 20170423 TimPN
  inner join Site
    on (Station.SiteID = Site.ID) and
--> Changed 2.0.31 20170423 TimPN
       --((Site.StartDate is null) or (Cast(Observation.ValueDate as Date) >= Cast(Site.StartDate as Date))) and
       --((Site.EndDate is null) or (Cast(Observation.ValueDate as Date) <= Cast(Site.EndDate as Date)))
       ((Site.StartDate is null) or (Observation.ValueDay >= Site.StartDate)) and
       ((Site.EndDate is null) or (Observation.ValueDay <= Site.EndDate))
--< Changed 2.0.31 20170423 TimPN
where
  (Status.Name = 'Verified')
--< Added 2.0.26 20170130 TimPN
GO
SET ANSI_NULLS, QUOTED_IDENTIFIER ON;


GO
PRINT N'Refreshing [dbo].[vInventory]...';


GO
EXECUTE sp_refreshsqlmodule N'[dbo].[vInventory]';


GO
PRINT N'Refreshing [dbo].[vObservation]...';


GO
EXECUTE sp_refreshsqlmodule N'[dbo].[vObservation]';


GO
PRINT N'Altering [dbo].[vObservationsList]...';


GO
SET ANSI_NULLS, QUOTED_IDENTIFIER OFF;


GO
--> Added 2.0.15 20161024 TimPN
ALTER VIEW [dbo].[vObservationsList]
AS 
SELECT 
--> Changed 2.0.31 20170502 TimPN
  --Observation.*,
  Observation.ID,
  Observation.ImportBatchID,
  Observation.ValueDate,
  Observation.RawValue,
  Observation.DataValue,
  Observation.Comment,
  Observation.CorrelationID,
--< Changed 2.0.31 20170502 TimPN
  Sensor.Code SensorCode,
  Sensor.Name SensorName,
  Phenomenon.Code PhenomenonCode,
  Phenomenon.Name PhenomenonName,
  Offering.Code OfferingCode,
  Offering.Name OfferingName,
  UnitOfMeasure.Code UnitOfMeasureCode,
  UnitOfMeasure.Unit UnitOfMeasureUnit,
  Status.Code StatusCode,
  Status.Name StatusName,
  StatusReason.Code StatusReasonCode,
  StatusReason.Name StatusReasonName
FROM
  Observation
  inner join Sensor
    on (Observation.SensorID = Sensor.ID)
  inner join PhenomenonOffering
    on (Observation.PhenomenonOfferingID = PhenomenonOffering.ID)
  inner join Phenomenon
    on (PhenomenonOffering.PhenomenonID = Phenomenon.ID)
  inner join Offering
    on (PhenomenonOffering.OfferingID = Offering.ID)
  inner join PhenomenonUOM
    on (Observation.PhenomenonUOMID = PhenomenonUOM.ID)
  inner join UnitOfMeasure
    on (PhenomenonUOM.UnitOfMeasureID = UnitOfMeasure.ID)
  left join Status
    on (Observation.StatusID = Status.ID)
  left join StatusReason
    on (Observation.StatusReasonID = StatusReason.ID)
--> Added 2.0.15 20161024 TimPN
GO
SET ANSI_NULLS, QUOTED_IDENTIFIER ON;


GO
PRINT N'Refreshing [dbo].[vObservationRoles]...';


GO
EXECUTE sp_refreshsqlmodule N'[dbo].[vObservationRoles]';


GO
PRINT N'Refreshing [dbo].[progress_Status_Raw]...';


GO
EXECUTE sp_refreshsqlmodule N'[dbo].[progress_Status_Raw]';


GO
-- Refactoring step to update target server with deployed transaction logs
IF NOT EXISTS (SELECT OperationKey FROM [dbo].[__RefactorLog] WHERE OperationKey = '918c74d0-40e9-42c0-93fd-69523ed88a2b')
INSERT INTO [dbo].[__RefactorLog] (OperationKey) values ('918c74d0-40e9-42c0-93fd-69523ed88a2b')

GO

GO
PRINT N'Checking existing data against newly created constraints';


GO
USE [$(DatabaseName)];


GO
ALTER TABLE [dbo].[DataLog] WITH CHECK CHECK CONSTRAINT [FK_DataLog_DataSourceTransformation];

ALTER TABLE [dbo].[DataLog] WITH CHECK CHECK CONSTRAINT [FK_DataLog_ImportBatch];

ALTER TABLE [dbo].[DataLog] WITH CHECK CHECK CONSTRAINT [FK_DataLog_PhenomenonOffering];

ALTER TABLE [dbo].[DataLog] WITH CHECK CHECK CONSTRAINT [FK_DataLog_PhenomenonUOM];

ALTER TABLE [dbo].[DataLog] WITH CHECK CHECK CONSTRAINT [FK_DataLog_Sensor];

ALTER TABLE [dbo].[DataLog] WITH CHECK CHECK CONSTRAINT [FK_DataLog_Status];

ALTER TABLE [dbo].[DataLog] WITH CHECK CHECK CONSTRAINT [FK_DataLog_StatusReason];

ALTER TABLE [dbo].[DataLog] WITH CHECK CHECK CONSTRAINT [FK_DataLog_aspnet_Users];

ALTER TABLE [dbo].[Observation] WITH CHECK CHECK CONSTRAINT [FK_Observation_ImportBatch];

ALTER TABLE [dbo].[Observation] WITH CHECK CHECK CONSTRAINT [FK_Observation_PhenomenonOffering];

ALTER TABLE [dbo].[Observation] WITH CHECK CHECK CONSTRAINT [FK_Observation_PhenomenonUOM];

ALTER TABLE [dbo].[Observation] WITH CHECK CHECK CONSTRAINT [FK_Observation_Sensor];

ALTER TABLE [dbo].[Observation] WITH CHECK CHECK CONSTRAINT [FK_Observation_Status];

ALTER TABLE [dbo].[Observation] WITH CHECK CHECK CONSTRAINT [FK_Observation_StatusReason];

ALTER TABLE [dbo].[Observation] WITH CHECK CHECK CONSTRAINT [FK_Observation_aspnet_Users];


GO
PRINT N'Update complete.';


GO