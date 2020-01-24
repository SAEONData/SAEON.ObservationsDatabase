﻿/*
Deployment script for ObservationsSACTN

This code was generated by a tool.
Changes to this file may cause incorrect behavior and will be lost if
the code is regenerated.
*/

GO
SET ANSI_NULLS, ANSI_PADDING, ANSI_WARNINGS, ARITHABORT, CONCAT_NULL_YIELDS_NULL, QUOTED_IDENTIFIER ON;

SET NUMERIC_ROUNDABORT OFF;


GO
:setvar DatabaseName "ObservationsSACTN"
:setvar DefaultFilePrefix "ObservationsSACTN"
:setvar DefaultDataPath "D:\Program Files\Microsoft SQL Server\MSSQL14.SAEON\MSSQL\DATA\"
:setvar DefaultLogPath "D:\Program Files\Microsoft SQL Server\MSSQL14.SAEON\MSSQL\DATA\"

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
USE [$(DatabaseName)];


--GO
--IF EXISTS (SELECT 1
--           FROM   [master].[dbo].[sysdatabases]
--           WHERE  [name] = N'$(DatabaseName)')
--    BEGIN
--        ALTER DATABASE [$(DatabaseName)]
--            SET TEMPORAL_HISTORY_RETENTION ON 
--            WITH ROLLBACK IMMEDIATE;
--    END


GO
/*
The type for column AddedBy in table [dbo].[DigitalObjectIdentifiers] is currently  NVARCHAR (128) NOT NULL but is being changed to  VARCHAR (128) NOT NULL. Data loss could occur.

The type for column Name in table [dbo].[DigitalObjectIdentifiers] is currently  NVARCHAR (500) NULL but is being changed to  VARCHAR (1000) NULL. Data loss could occur.

The type for column UpdatedBy in table [dbo].[DigitalObjectIdentifiers] is currently  NVARCHAR (128) NOT NULL but is being changed to  VARCHAR (128) NOT NULL. Data loss could occur.
*/

--IF EXISTS (select top 1 1 from [dbo].[DigitalObjectIdentifiers])
--    RAISERROR (N'Rows were detected. The schema update is terminating because data loss might occur.', 16, 127) WITH NOWAIT

GO
/*
The column [dbo].[UserDownloads].[OpenDataPlatformID] on table [dbo].[UserDownloads] must be added, but the column has no default value and does not allow NULL values. If the table contains data, the ALTER script will not work. To avoid this issue you must either: add a default value to the column, mark it as allowing NULL values, or enable the generation of smart-defaults as a deployment option.

The column [dbo].[UserDownloads].[ZipURL] on table [dbo].[UserDownloads] must be added, but the column has no default value and does not allow NULL values. If the table contains data, the ALTER script will not work. To avoid this issue you must either: add a default value to the column, mark it as allowing NULL values, or enable the generation of smart-defaults as a deployment option.

The type for column AddedBy in table [dbo].[UserDownloads] is currently  NVARCHAR (128) NOT NULL but is being changed to  VARCHAR (128) NOT NULL. Data loss could occur.

The type for column UpdatedBy in table [dbo].[UserDownloads] is currently  NVARCHAR (128) NOT NULL but is being changed to  VARCHAR (128) NOT NULL. Data loss could occur.

The type for column UserId in table [dbo].[UserDownloads] is currently  NVARCHAR (128) NOT NULL but is being changed to  VARCHAR (128) NOT NULL. Data loss could occur.
*/

--IF EXISTS (select top 1 1 from [dbo].[UserDownloads])
--    RAISERROR (N'Rows were detected. The schema update is terminating because data loss might occur.', 16, 127) WITH NOWAIT

GO
/*
The type for column AddedBy in table [dbo].[UserQueries] is currently  NVARCHAR (128) NOT NULL but is being changed to  VARCHAR (128) NOT NULL. Data loss could occur.

The type for column UpdatedBy in table [dbo].[UserQueries] is currently  NVARCHAR (128) NOT NULL but is being changed to  VARCHAR (128) NOT NULL. Data loss could occur.

The type for column UserId in table [dbo].[UserQueries] is currently  NVARCHAR (128) NOT NULL but is being changed to  VARCHAR (128) NOT NULL. Data loss could occur.
*/

--IF EXISTS (select top 1 1 from [dbo].[UserQueries])
--    RAISERROR (N'Rows were detected. The schema update is terminating because data loss might occur.', 16, 127) WITH NOWAIT

GO
PRINT N'Dropping [dbo].[Observation].[IX_Observation_ValueDecade]...';


GO
DROP INDEX [IX_Observation_ValueDecade]
    ON [dbo].[Observation];


GO
PRINT N'Dropping [dbo].[Observation].[IX_Observation_ValueYear]...';


GO
DROP INDEX [IX_Observation_ValueYear]
    ON [dbo].[Observation];


GO
PRINT N'Dropping [dbo].[DF_DigitalObjectIdentifiers_UpdatedAt]...';


GO
ALTER TABLE [dbo].[DigitalObjectIdentifiers] DROP CONSTRAINT [DF_DigitalObjectIdentifiers_UpdatedAt];


GO
PRINT N'Dropping [dbo].[DF_DigitalObjectIdentifiers_AddedAt]...';


GO
ALTER TABLE [dbo].[DigitalObjectIdentifiers] DROP CONSTRAINT [DF_DigitalObjectIdentifiers_AddedAt];


GO
PRINT N'Dropping [dbo].[FK_UserDownloads_DigitalObjectIdentifiers]...';


GO
ALTER TABLE [dbo].[UserDownloads] DROP CONSTRAINT [FK_UserDownloads_DigitalObjectIdentifiers];


GO
PRINT N'Dropping [dbo].[UX_UserDownloads_UserId_Name]...';


GO
ALTER TABLE [dbo].[UserDownloads] DROP CONSTRAINT [UX_UserDownloads_UserId_Name];


GO
PRINT N'Dropping [dbo].[UX_UserQueries_UserId_Name]...';


GO
ALTER TABLE [dbo].[UserQueries] DROP CONSTRAINT [UX_UserQueries_UserId_Name];


GO
PRINT N'Starting rebuilding table [dbo].[DigitalObjectIdentifiers]...';


GO
SET ANSI_NULLS, QUOTED_IDENTIFIER OFF;


GO
SET ANSI_NULLS, QUOTED_IDENTIFIER OFF;


GO
BEGIN TRANSACTION;

SET TRANSACTION ISOLATION LEVEL SERIALIZABLE;

SET XACT_ABORT ON;

CREATE TABLE [dbo].[tmp_ms_xx_DigitalObjectIdentifiers] (
    [ID]         INT            IDENTITY (1, 1) NOT NULL,
    [DOI]        AS             '10.15493/obsdb.' + Stuff(CONVERT (VARCHAR (20), CONVERT (VARBINARY (4), ID), 2), 5, 0, '.'),
    [DOIUrl]     AS             'https://doi.org/10.15493/obsdb.' + Stuff(CONVERT (VARCHAR (20), CONVERT (VARBINARY (4), ID), 2), 5, 0, '.'),
    [Name]       VARCHAR (1000) NULL,
    [AddedAt]    DATETIME       CONSTRAINT [DF_DigitalObjectIdentifiers_AddedAt] DEFAULT (getdate()) NULL,
    [AddedBy]    VARCHAR (128)  NOT NULL,
    [UpdatedAt]  DATETIME       CONSTRAINT [DF_DigitalObjectIdentifiers_UpdatedAt] DEFAULT (getdate()) NULL,
    [UpdatedBy]  VARCHAR (128)  NOT NULL,
    [RowVersion] ROWVERSION     NOT NULL,
    CONSTRAINT [tmp_ms_xx_constraint_PK_DigitalObjectIdentifiers1] PRIMARY KEY CLUSTERED ([ID] ASC)
);

IF EXISTS (SELECT TOP 1 1 
           FROM   [dbo].[DigitalObjectIdentifiers])
    BEGIN
        SET IDENTITY_INSERT [dbo].[tmp_ms_xx_DigitalObjectIdentifiers] ON;
        INSERT INTO [dbo].[tmp_ms_xx_DigitalObjectIdentifiers] ([ID], [Name], [AddedAt], [AddedBy], [UpdatedAt], [UpdatedBy])
        SELECT   [ID],
                 [Name],
                 [AddedAt],
                 [AddedBy],
                 [UpdatedAt],
                 [UpdatedBy]
        FROM     [dbo].[DigitalObjectIdentifiers]
        ORDER BY [ID] ASC;
        SET IDENTITY_INSERT [dbo].[tmp_ms_xx_DigitalObjectIdentifiers] OFF;
    END

DROP TABLE [dbo].[DigitalObjectIdentifiers];

EXECUTE sp_rename N'[dbo].[tmp_ms_xx_DigitalObjectIdentifiers]', N'DigitalObjectIdentifiers';

EXECUTE sp_rename N'[dbo].[tmp_ms_xx_constraint_PK_DigitalObjectIdentifiers1]', N'PK_DigitalObjectIdentifiers', N'OBJECT';

COMMIT TRANSACTION;

SET TRANSACTION ISOLATION LEVEL READ COMMITTED;


GO
SET ANSI_NULLS, QUOTED_IDENTIFIER ON;


GO
SET ANSI_NULLS, QUOTED_IDENTIFIER ON;


GO
PRINT N'Creating [dbo].[DigitalObjectIdentifiers].[IX_DigitalObjectIdentifiers_Name]...';


GO
CREATE NONCLUSTERED INDEX [IX_DigitalObjectIdentifiers_Name]
    ON [dbo].[DigitalObjectIdentifiers]([Name] ASC);


GO
PRINT N'Altering [dbo].[Observation]...';


GO
ALTER TABLE [dbo].[Observation] DROP COLUMN [ValueYear], COLUMN [ValueDecade];


GO
ALTER TABLE [dbo].[Observation]
    ADD [ValueYear]   AS (Year([ValueDate])),
        [ValueDecade] AS (Year([ValueDate]) / 10 * 10);


GO
PRINT N'Creating [dbo].[Observation].[IX_Observation_ValueDecade]...';


GO
CREATE NONCLUSTERED INDEX [IX_Observation_ValueDecade]
    ON [dbo].[Observation]([ValueDecade] ASC)
    ON [Observations];


GO
PRINT N'Creating [dbo].[Observation].[IX_Observation_ValueYear]...';


GO
CREATE NONCLUSTERED INDEX [IX_Observation_ValueYear]
    ON [dbo].[Observation]([ValueYear] ASC)
    ON [Observations];


GO
PRINT N'Altering [dbo].[UserDownloads]...';


GO
SET ANSI_NULLS, QUOTED_IDENTIFIER OFF;


GO
ALTER TABLE [dbo].[UserDownloads] ALTER COLUMN [AddedBy] VARCHAR (128) NOT NULL;

ALTER TABLE [dbo].[UserDownloads] ALTER COLUMN [UpdatedBy] VARCHAR (128) NOT NULL;

ALTER TABLE [dbo].[UserDownloads] ALTER COLUMN [UserId] VARCHAR (128) NOT NULL;


GO
ALTER TABLE [dbo].[UserDownloads]
    ADD [OpenDataPlatformID] UNIQUEIDENTIFIER NOT NULL,
        [ZipURL]             VARCHAR (2000)   NOT NULL;


GO
SET ANSI_NULLS, QUOTED_IDENTIFIER ON;


GO
PRINT N'Creating [dbo].[UX_UserDownloads_UserId_Name]...';


GO
ALTER TABLE [dbo].[UserDownloads]
    ADD CONSTRAINT [UX_UserDownloads_UserId_Name] UNIQUE NONCLUSTERED ([UserId] ASC, [Name] ASC);


GO
PRINT N'Altering [dbo].[UserQueries]...';


GO
SET ANSI_NULLS, QUOTED_IDENTIFIER OFF;


GO
ALTER TABLE [dbo].[UserQueries] ALTER COLUMN [AddedBy] VARCHAR (128) NOT NULL;

ALTER TABLE [dbo].[UserQueries] ALTER COLUMN [UpdatedBy] VARCHAR (128) NOT NULL;

ALTER TABLE [dbo].[UserQueries] ALTER COLUMN [UserId] VARCHAR (128) NOT NULL;


GO
SET ANSI_NULLS, QUOTED_IDENTIFIER ON;


GO
PRINT N'Creating [dbo].[UX_UserQueries_UserId_Name]...';


GO
ALTER TABLE [dbo].[UserQueries]
    ADD CONSTRAINT [UX_UserQueries_UserId_Name] UNIQUE NONCLUSTERED ([UserId] ASC, [Name] ASC);


GO
PRINT N'Creating [dbo].[FK_UserDownloads_DigitalObjectIdentifiers]...';


GO
ALTER TABLE [dbo].[UserDownloads] WITH NOCHECK
    ADD CONSTRAINT [FK_UserDownloads_DigitalObjectIdentifiers] FOREIGN KEY ([DigitalObjectIdentifierID]) REFERENCES [dbo].[DigitalObjectIdentifiers] ([ID]);


GO
PRINT N'Creating [dbo].[TR_DigitalObjectIdentifiers_Insert]...';


GO
SET ANSI_NULLS, QUOTED_IDENTIFIER OFF;


GO
CREATE TRIGGER [dbo].[TR_DigitalObjectIdentifiers_Insert] ON [dbo].[DigitalObjectIdentifiers]
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
    DigitalObjectIdentifiers src
    inner join inserted ins
      on (ins.ID = src.ID)
END
GO
SET ANSI_NULLS, QUOTED_IDENTIFIER ON;


GO
PRINT N'Creating [dbo].[TR_DigitalObjectIdentifiers_Update]...';


GO
SET ANSI_NULLS, QUOTED_IDENTIFIER OFF;


GO
CREATE TRIGGER [dbo].[TR_DigitalObjectIdentifiers_Update] ON [dbo].[DigitalObjectIdentifiers]
FOR UPDATE
AS
BEGIN
  SET NoCount ON
  Update
      src
  set
    AddedAt = Coalesce(del.AddedAt, ins.AddedAt, GetDate()),
    UpdatedAt = GetDate()
  from
    DigitalObjectIdentifiers src
    inner join inserted ins
      on (ins.ID = src.ID)
    inner join deleted del
      on (del.ID = src.ID)
END
GO
SET ANSI_NULLS, QUOTED_IDENTIFIER ON;


GO
PRINT N'Refreshing [dbo].[vUserDownloads]...';


GO
SET ANSI_NULLS, QUOTED_IDENTIFIER OFF;


GO
EXECUTE sp_refreshsqlmodule N'[dbo].[vUserDownloads]';


GO
SET ANSI_NULLS, QUOTED_IDENTIFIER ON;


GO
PRINT N'Refreshing [dbo].[vObservationExpansion]...';


GO
SET ANSI_NULLS, QUOTED_IDENTIFIER OFF;


GO
EXECUTE sp_refreshsqlmodule N'[dbo].[vObservationExpansion]';


GO
SET ANSI_NULLS, QUOTED_IDENTIFIER ON;


GO
PRINT N'Refreshing [dbo].[vObservation]...';


GO
SET ANSI_NULLS, QUOTED_IDENTIFIER OFF;


GO
EXECUTE sp_refreshsqlmodule N'[dbo].[vObservation]';


GO
SET ANSI_NULLS, QUOTED_IDENTIFIER ON;


GO
PRINT N'Refreshing [dbo].[vObservationJSON]...';


GO
SET ANSI_NULLS, QUOTED_IDENTIFIER OFF;


GO
EXECUTE sp_refreshsqlmodule N'[dbo].[vObservationJSON]';


GO
SET ANSI_NULLS, QUOTED_IDENTIFIER ON;


GO
PRINT N'Altering [dbo].[vImportBatchSummary]...';


GO
SET ANSI_NULLS, QUOTED_IDENTIFIER OFF;


GO
ALTER VIEW [dbo].[vImportBatchSummary]
AS 
Select
  ImportBatchSummary.*, 
  Phenomenon.Code PhenomenonCode, Phenomenon.Name PhenomenonName, Phenomenon.Description PhenomenonDescription,
  Offering.Code OfferingCode, Offering.Name OfferingName, Offering.Description OfferingDescription,
  UnitOfMeasure.Code UnitOfMeasureCode, UnitOfMeasure.Unit UnitOfMeasureUnit, UnitOfMeasure.UnitSymbol UnitOfMeasureSymbol,
  Sensor.Code SensorCode, Sensor.Name SensorName, Sensor.Description SensorDescription,
  Instrument.Code InstrumentCode, Instrument.Name InstrumentName, Instrument.Description InstrumentDescription,
  Station.Code StationCode, Station.Name StationName, Station.Description StationDescription,
  Site.Code SiteCode, Site.Name SiteName, Site.Description SiteDescription
From
  ImportBatchSummary
  inner join Sensor
    on (ImportBatchSummary.SensorID = Sensor.ID)
  inner join Instrument
    on (ImportBatchSummary.InstrumentID = Instrument.ID)
  inner join Station
    on (ImportBatchSummary.StationID = Station.ID)
  inner join Site
    on (ImportBatchSummary.SiteID = Site.ID)
  inner join PhenomenonOffering
    on (ImportBatchSummary.PhenomenonOfferingID = PhenomenonOffering.ID)
  inner join Phenomenon
    on (PhenomenonOffering.PhenomenonID = Phenomenon.ID)
  inner join Offering
    on (PhenomenonOffering.OfferingID = Offering.ID)
  inner join PhenomenonUOM
    on (ImportBatchSummary.PhenomenonUOMID = PhenomenonUOM.ID)
  inner join UnitOfMeasure
    on (PhenomenonUOM.UnitOfMeasureID = UnitOfMeasure.ID)
GO
SET ANSI_NULLS, QUOTED_IDENTIFIER ON;


GO
PRINT N'Refreshing [dbo].[vInventory]...';


GO
EXECUTE sp_refreshsqlmodule N'[dbo].[vInventory]';


GO
PRINT N'Altering [dbo].[vSensorDates]...';


GO
SET ANSI_NULLS, QUOTED_IDENTIFIER OFF;


GO
ALTER VIEW [dbo].[vSensorDates]
AS
Select
  Sensor.ID SensorID,
  Sensor.Name SensorName,
  Instrument_Sensor.StartDate InstrumenSensorStartDate, Instrument_Sensor.EndDate InstrumenSensorEndDate,
  Instrument.Name InstrumentName, Instrument.StartDate InstrumentStartDate, Instrument.EndDate InstrumentEndDate,
  Station_Instrument.StartDate StationInstrumentStartDate, Station_Instrument.EndDate StationInstrumentEndDate,
  Station.Name StationName, Station.StartDate StationStartDate, Station.EndDate StationEndDate,
  Site.Name SiteName, Site.StartDate SiteStartDate, Site.EndDate SiteEndDate,
  (
  Select
    Min(v)
  from
    (Values (Instrument_Sensor.StartDate),(Instrument.StartDate),(Station_Instrument.StartDate),(Station.StartDate),(Site.StartDate)) as Value(v)
  ) StartDate,
  (
  Select
    Max(v)
  from
    (Values (Instrument_Sensor.EndDate),(Instrument.EndDate),(Station_Instrument.EndDate),(Station.EndDate),(Site.EndDate)) as Value(v)
  ) EndDate
from
  Sensor
  left join Instrument_Sensor
    on (Instrument_Sensor.SensorID = Sensor.ID)
  left join Instrument
    on (Instrument_Sensor.InstrumentID = Instrument.ID)
  left join Station_Instrument
    on (Station_Instrument.InstrumentID = Instrument.ID)
  left join Station
    on (Station_Instrument.StationID = Station.ID)
  inner join Site
    on (Station.SiteID = Site.ID)
GO
SET ANSI_NULLS, QUOTED_IDENTIFIER ON;


GO
PRINT N'Creating [dbo].[vSensorThingsAPIDatastreams]...';


GO
SET ANSI_NULLS, QUOTED_IDENTIFIER OFF;


GO
CREATE VIEW [dbo].[vSensorThingsAPIDatastreams]
AS
Select Distinct
  Sensor.ID, Sensor.Code, Sensor.Name, Sensor.Description,
  PhenomenonCode, PhenomenonName, Phenomenon.Description PhenomenonDescription, Phenomenon.Url PhenomenonUrl,
  OfferingCode, OfferingName, Offering.Description OfferingDescription,
  UnitOfMeasureCode, UnitOfMeasureUnit, UnitOfMeasure.UnitSymbol UnitOfMeasureSymbol,
  StartDate, EndDate, LatitudeNorth, LatitudeSouth, LongitudeWest, LongitudeEast
from
  vInventory
  inner join Sensor
    on (vInventory.SensorID = Sensor.ID)
  inner join Phenomenon
    on (vInventory.PhenomenonCode = Phenomenon.Code)
  inner join Offering
    on (vInventory.OfferingCode = Offering.Code)
  inner join UnitOfMeasure
    on (vInventory.UnitOfMeasureCode = UnitOfMeasure.Code)
GO
SET ANSI_NULLS, QUOTED_IDENTIFIER ON;


GO
PRINT N'Creating [dbo].[vSensorThingsAPIInstrumentDates]...';


GO
SET ANSI_NULLS, QUOTED_IDENTIFIER OFF;


GO
CREATE VIEW [dbo].[vSensorThingsAPIInstrumentDates]
AS
with Dates
as
(
Select
  ID, Name,
  -- StartDate
  -- Instrument
  StartDate InstrumentStartDate,
  -- Instrument_Sensor
  (Select Min(Instrument_Sensor.StartDate) from Instrument_Sensor where Instrument_Sensor.InstrumentID = Instrument.ID) InstrumentSensorStartDate,
  -- EndDate
  -- Instrument
  EndDate InstrumentEndDate,
  -- Instrument_Sensor
  (Select Max(Instrument_Sensor.EndDate) from Instrument_Sensor where Instrument_Sensor.InstrumentID = Instrument.ID) InstrumentSensorEndDate
from
  Instrument
)
Select
  --*,
  ID, Name,
  (Select Min(Value) from (Values (InstrumentStartDate), (InstrumentSensorStartDate)) as x(Value)) StartDate,
  (Select Max(Value) from (Values (InstrumentEndDate), (InstrumentSensorEndDate)) as x(Value)) EndDate
from
  Dates
GO
SET ANSI_NULLS, QUOTED_IDENTIFIER ON;


GO
PRINT N'Creating [dbo].[vSensorThingsAPILocations]...';


GO
SET ANSI_NULLS, QUOTED_IDENTIFIER OFF;


GO
CREATE VIEW [dbo].[vSensorThingsAPILocations]
AS
-- Stations
Select
  Station.ID, Station.Code, Station.Name, Station.Description, Station.Latitude, Station.Longitude, Station.Elevation, Station.StartDate, Station.EndDate
from
  vInventory
  inner join Station
    on (vInventory.StationID = Station.ID)
  where
    (Station.Latitude is not null) and (Station.Longitude is not null)
union
-- Instruments
Select
  Instrument.ID, Instrument.Code, Instrument.Name, Instrument.Description, Instrument.Latitude, Instrument.Longitude, Instrument.Elevation, Instrument.StartDate, Instrument.EndDate
from
  vInventory
  inner join Instrument
    on (vInventory.InstrumentID = Instrument.ID)
  where
    (Instrument.Latitude is not null) and (Instrument.Longitude is not null)
GO
SET ANSI_NULLS, QUOTED_IDENTIFIER ON;


GO
PRINT N'Creating [dbo].[vSensorThingsAPIObservedProperties]...';


GO
SET ANSI_NULLS, QUOTED_IDENTIFIER OFF;


GO
CREATE VIEW [dbo].[vSensorThingsAPIObservedProperties]
AS
Select Distinct
  Phenomenon.ID, Phenomenon.Code, Phenomenon.Name, Phenomenon.Description, Phenomenon.Url
from
  vInventory
  inner join Phenomenon
    on (vInventory.PhenomenonCode = Phenomenon.Code)
GO
SET ANSI_NULLS, QUOTED_IDENTIFIER ON;


GO
PRINT N'Creating [dbo].[vSensorThingsAPISensors]...';


GO
SET ANSI_NULLS, QUOTED_IDENTIFIER OFF;


GO
CREATE VIEW [dbo].[vSensorThingsAPISensors]
AS
Select Distinct
  Sensor.ID, Sensor.Code, Sensor.Name, Sensor.Description, Sensor.Url
from
  vInventory
  inner join Sensor
    on (vInventory.SensorID = Sensor.ID)
GO
SET ANSI_NULLS, QUOTED_IDENTIFIER ON;


GO
PRINT N'Creating [dbo].[vSensorThingsAPIStationDates]...';


GO
SET ANSI_NULLS, QUOTED_IDENTIFIER OFF;


GO
CREATE VIEW [dbo].[vSensorThingsAPIStationDates]
AS
with Dates
as
(
Select
  ID, Name,
  -- StartDate
  -- Station
  StartDate StationStartDate,
  -- Station_Instrument
  (Select Min(Station_Instrument.StartDate) from Station_Instrument where Station_Instrument.StationID = Station.ID) StationInstrumentStartDate,
  -- Instrument
  (
  Select
    Min(Instrument.StartDate)
  from
    Station_Instrument
    inner join Instrument
      on (Station_Instrument.InstrumentID = Instrument.ID)
    where
      (Station_Instrument.StationID = Station.ID)
  ) InstrumentStartDate,
  -- Instrument_Sensor
  (
  Select
    Min(Instrument_Sensor.StartDate)
  from
    Station_Instrument
    inner join Instrument
      on (Station_Instrument.InstrumentID = Instrument.ID)
    inner join Instrument_Sensor
      on (Instrument_Sensor.InstrumentID = Instrument.ID)
    where
      (Station_Instrument.StationID = Station.ID)
  ) InstrumentSensorStartDate,
  -- EndDate
  -- Station
  EndDate StationEndDate,
  -- Station_Instrument
  (Select Max(Station_Instrument.EndDate) from Station_Instrument where Station_Instrument.StationID = Station.ID) StationInstrumentEndDate,
  -- Instrument
  (
  Select
    Max(Instrument.EndDate)
  from
    Station_Instrument
    inner join Instrument
      on (Station_Instrument.InstrumentID = Instrument.ID)
    where
      (Station_Instrument.StationID = Station.ID)
  ) InstrumentEndDate,
  -- Instrument_Sensor
  (
  Select
    Max(Instrument_Sensor.EndDate)
  from
    Station_Instrument
    inner join Instrument
      on (Station_Instrument.InstrumentID = Instrument.ID)
    inner join Instrument_Sensor
      on (Instrument_Sensor.InstrumentID = Instrument.ID)
    where
      (Station_Instrument.StationID = Station.ID)
  ) InstrumentSensorEndDate
from
  Station
)
Select
  --*,
  ID, Name,
  (Select Min(Value) from (Values (StationStartDate), (StationInstrumentStartDate), (InstrumentStartDate), (InstrumentSensorStartDate)) as x(Value)) StartDate,
  (Select Max(Value) from (Values (StationEndDate), (StationInstrumentEndDate), (InstrumentEndDate), (InstrumentSensorEndDate)) as x(Value)) EndDate
from
  Dates
GO
SET ANSI_NULLS, QUOTED_IDENTIFIER ON;


GO
PRINT N'Creating [dbo].[vSensorThingsAPIThings]...';


GO
SET ANSI_NULLS, QUOTED_IDENTIFIER OFF;


GO
CREATE VIEW [dbo].[vSensorThingsAPIThings]
AS
-- Sites
Select
  Site.ID, Site.Code, Site.Name, Site.Description, 'Site' Kind, Site.Url, Site.StartDate, Site.EndDate
from
  vInventory
  inner join Site
    on (vInventory.SiteID = Site.ID)
union
-- Stations
Select
  Station.ID, Station.Code, Station.Name, Station.Description, 'Station' Kind, Station.Url, Station.StartDate, Station.EndDate
from
  vInventory
  inner join Station
    on (vInventory.StationID = Station.ID)
union
-- Instruments
Select
  Instrument.ID, Instrument.Code, Instrument.Name, Instrument.Description, 'Instrument' Kind, Instrument.Url, Instrument.StartDate, Instrument.EndDate
from
  vInventory
  inner join Instrument
    on (vInventory.InstrumentID = Instrument.ID)
GO
SET ANSI_NULLS, QUOTED_IDENTIFIER ON;


GO
PRINT N'Checking existing data against newly created constraints';


GO
USE [$(DatabaseName)];


GO
ALTER TABLE [dbo].[UserDownloads] WITH CHECK CHECK CONSTRAINT [FK_UserDownloads_DigitalObjectIdentifiers];


GO
PRINT N'Update complete.';


GO
