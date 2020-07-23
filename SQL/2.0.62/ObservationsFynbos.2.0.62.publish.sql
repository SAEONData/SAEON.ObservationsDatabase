﻿/*
Deployment script for ObservationsFynbos

This code was generated by a tool.
Changes to this file may cause incorrect behavior and will be lost if
the code is regenerated.
*/

GO
SET ANSI_NULLS, ANSI_PADDING, ANSI_WARNINGS, ARITHABORT, CONCAT_NULL_YIELDS_NULL, QUOTED_IDENTIFIER ON;

SET NUMERIC_ROUNDABORT OFF;


GO
:setvar DatabaseName "ObservationsFynbos"
:setvar DefaultFilePrefix "ObservationsFynbos"
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


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET QUERY_STORE (QUERY_CAPTURE_MODE = ALL) 
            WITH ROLLBACK IMMEDIATE;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET TEMPORAL_HISTORY_RETENTION ON 
            WITH ROLLBACK IMMEDIATE;
    END


GO
--/*
--The column [dbo].[aspnet_PersonalizationAllUsers].[Test] is being dropped, data loss could occur.
--*/

--IF EXISTS (select top 1 1 from [dbo].[aspnet_PersonalizationAllUsers])
--    RAISERROR (N'Rows were detected. The schema update is terminating because data loss might occur.', 16, 127) WITH NOWAIT

--GO
--/*
--The column [dbo].[aspnet_Profile].[Test] is being dropped, data loss could occur.
--*/

--IF EXISTS (select top 1 1 from [dbo].[aspnet_Profile])
--    RAISERROR (N'Rows were detected. The schema update is terminating because data loss might occur.', 16, 127) WITH NOWAIT

--GO
--/*
--The column [dbo].[aspnet_WebEvent_Events].[Test] is being dropped, data loss could occur.
--*/

--IF EXISTS (select top 1 1 from [dbo].[aspnet_WebEvent_Events])
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
PRINT N'Dropping [dbo].[DataLog].[IX_DataLog_ValueDay]...';


GO
DROP INDEX [IX_DataLog_ValueDay]
    ON [dbo].[DataLog];


GO
PRINT N'Altering [dbo].[aspnet_PersonalizationAllUsers]...';


GO
ALTER TABLE [dbo].[aspnet_PersonalizationAllUsers] DROP COLUMN [Test];


GO
PRINT N'Altering [dbo].[aspnet_Profile]...';


GO
ALTER TABLE [dbo].[aspnet_Profile] DROP COLUMN [Test];


GO
PRINT N'Altering [dbo].[aspnet_WebEvent_Events]...';


GO
ALTER TABLE [dbo].[aspnet_WebEvent_Events] DROP COLUMN [Test];


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
PRINT N'Creating [dbo].[DataSchema].[IX_DataSchema_CodeName]...';


GO
CREATE NONCLUSTERED INDEX [IX_DataSchema_CodeName]
    ON [dbo].[DataSchema]([Code] ASC, [Name] ASC);


GO
PRINT N'Creating [dbo].[DataSource].[IX_DataSource_CodeName]...';


GO
CREATE NONCLUSTERED INDEX [IX_DataSource_CodeName]
    ON [dbo].[DataSource]([Code] ASC, [Name] ASC);


GO
PRINT N'Creating [dbo].[DataSource].[IX_DataSource_StartDateEndDate]...';


GO
CREATE NONCLUSTERED INDEX [IX_DataSource_StartDateEndDate]
    ON [dbo].[DataSource]([StartDate] ASC, [EndDate] ASC);


GO
PRINT N'Creating [dbo].[DataSourceTransformation].[IX_DataSourceTransformation_StartDateEndDate]...';


GO
CREATE NONCLUSTERED INDEX [IX_DataSourceTransformation_StartDateEndDate]
    ON [dbo].[DataSourceTransformation]([StartDate] ASC, [EndDate] ASC);


GO
PRINT N'Creating [dbo].[Instrument].[IX_Instrument_CodeName]...';


GO
CREATE NONCLUSTERED INDEX [IX_Instrument_CodeName]
    ON [dbo].[Instrument]([Code] ASC, [Name] ASC);


GO
PRINT N'Creating [dbo].[Instrument].[IX_Instrument_StartDateEndDate]...';


GO
CREATE NONCLUSTERED INDEX [IX_Instrument_StartDateEndDate]
    ON [dbo].[Instrument]([StartDate] ASC, [EndDate] ASC);


GO
PRINT N'Creating [dbo].[Instrument_Sensor].[IX_Instrument_Sensor_StartDateEndDate]...';


GO
CREATE NONCLUSTERED INDEX [IX_Instrument_Sensor_StartDateEndDate]
    ON [dbo].[Instrument_Sensor]([StartDate] ASC, [EndDate] ASC);


GO
PRINT N'Creating [dbo].[Offering].[IX_Offering_CodeName]...';


GO
CREATE NONCLUSTERED INDEX [IX_Offering_CodeName]
    ON [dbo].[Offering]([Code] ASC, [Name] ASC);


GO
PRINT N'Creating [dbo].[Organisation].[IX_Organisation_CodeName]...';


GO
CREATE NONCLUSTERED INDEX [IX_Organisation_CodeName]
    ON [dbo].[Organisation]([Code] ASC, [Name] ASC);


GO
PRINT N'Creating [dbo].[Organisation_Instrument].[IX_Organisation_Instrument_StartDateEndDate]...';


GO
CREATE NONCLUSTERED INDEX [IX_Organisation_Instrument_StartDateEndDate]
    ON [dbo].[Organisation_Instrument]([StartDate] ASC, [EndDate] ASC);


GO
PRINT N'Creating [dbo].[Organisation_Site].[IX_Organisation_Site_StartDateEndDate]...';


GO
CREATE NONCLUSTERED INDEX [IX_Organisation_Site_StartDateEndDate]
    ON [dbo].[Organisation_Site]([StartDate] ASC, [EndDate] ASC);


GO
PRINT N'Creating [dbo].[Organisation_Station].[IX_Organisation_Station_StartDateEndDate]...';


GO
CREATE NONCLUSTERED INDEX [IX_Organisation_Station_StartDateEndDate]
    ON [dbo].[Organisation_Station]([StartDate] ASC, [EndDate] ASC);


GO
PRINT N'Creating [dbo].[OrganisationRole].[IX_OrganisationRole_CodeName]...';


GO
CREATE NONCLUSTERED INDEX [IX_OrganisationRole_CodeName]
    ON [dbo].[OrganisationRole]([Code] ASC, [Name] ASC);


GO
PRINT N'Creating [dbo].[Phenomenon].[IX_Phenomenon_CodeName]...';


GO
CREATE NONCLUSTERED INDEX [IX_Phenomenon_CodeName]
    ON [dbo].[Phenomenon]([Code] ASC, [Name] ASC);


GO
PRINT N'Creating [dbo].[Programme].[IX_Programme_CodeName]...';


GO
CREATE NONCLUSTERED INDEX [IX_Programme_CodeName]
    ON [dbo].[Programme]([Code] ASC, [Name] ASC);


GO
PRINT N'Creating [dbo].[Programme].[IX_Programme_StartDateEndDate]...';


GO
CREATE NONCLUSTERED INDEX [IX_Programme_StartDateEndDate]
    ON [dbo].[Programme]([StartDate] ASC, [EndDate] ASC);


GO
PRINT N'Creating [dbo].[Project].[IX_Project_CodeName]...';


GO
CREATE NONCLUSTERED INDEX [IX_Project_CodeName]
    ON [dbo].[Project]([Code] ASC, [Name] ASC);


GO
PRINT N'Creating [dbo].[Project].[IX_Project_StartDateEndDate]...';


GO
CREATE NONCLUSTERED INDEX [IX_Project_StartDateEndDate]
    ON [dbo].[Project]([StartDate] ASC, [EndDate] ASC);


GO
PRINT N'Creating [dbo].[Project_Station].[IX_Project_Station_StartDateEndDate]...';


GO
CREATE NONCLUSTERED INDEX [IX_Project_Station_StartDateEndDate]
    ON [dbo].[Project_Station]([StartDate] ASC, [EndDate] ASC);


GO
PRINT N'Creating [dbo].[Sensor].[IX_Sensor_CodeName]...';


GO
CREATE NONCLUSTERED INDEX [IX_Sensor_CodeName]
    ON [dbo].[Sensor]([Code] ASC, [Name] ASC);


GO
PRINT N'Creating [dbo].[Site].[IX_Site_CodeName]...';


GO
CREATE NONCLUSTERED INDEX [IX_Site_CodeName]
    ON [dbo].[Site]([Code] ASC, [Name] ASC);


GO
PRINT N'Creating [dbo].[Site].[IX_Site_StartDateEndDate]...';


GO
CREATE NONCLUSTERED INDEX [IX_Site_StartDateEndDate]
    ON [dbo].[Site]([StartDate] ASC, [EndDate] ASC);


GO
PRINT N'Creating [dbo].[Station].[IX_Station_CodeName]...';


GO
CREATE NONCLUSTERED INDEX [IX_Station_CodeName]
    ON [dbo].[Station]([Code] ASC, [Name] ASC);


GO
PRINT N'Creating [dbo].[Station].[IX_Station_StartDateEndDate]...';


GO
CREATE NONCLUSTERED INDEX [IX_Station_StartDateEndDate]
    ON [dbo].[Station]([StartDate] ASC, [EndDate] ASC);


GO
PRINT N'Creating [dbo].[Station_Instrument].[IX_Station_Instrument_StartDateEndDate]...';


GO
CREATE NONCLUSTERED INDEX [IX_Station_Instrument_StartDateEndDate]
    ON [dbo].[Station_Instrument]([StartDate] ASC, [EndDate] ASC);


GO
PRINT N'Creating [dbo].[Status].[IX_Status_CodeName]...';


GO
CREATE NONCLUSTERED INDEX [IX_Status_CodeName]
    ON [dbo].[Status]([Code] ASC, [Name] ASC);


GO
PRINT N'Creating [dbo].[StatusReason].[IX_StatusReason_CodeName]...';


GO
CREATE NONCLUSTERED INDEX [IX_StatusReason_CodeName]
    ON [dbo].[StatusReason]([Code] ASC, [Name] ASC);


GO
PRINT N'Creating [dbo].[TransformationType].[IX_TransformationType_CodeName]...';


GO
CREATE NONCLUSTERED INDEX [IX_TransformationType_CodeName]
    ON [dbo].[TransformationType]([Code] ASC, [Name] ASC);


GO
PRINT N'Creating [dbo].[UnitOfMeasure].[IX_UnitOfMeasure_CodeName]...';


GO
CREATE NONCLUSTERED INDEX [IX_UnitOfMeasure_CodeName]
    ON [dbo].[UnitOfMeasure]([Code] ASC, [Unit] ASC);


GO
PRINT N'Creating [dbo].[DF_Observation_AddedAt]...';


GO
ALTER TABLE [dbo].[Observation]
    ADD CONSTRAINT [DF_Observation_AddedAt] DEFAULT (getdate()) FOR [AddedAt];


GO
PRINT N'Creating [dbo].[DF_Observation_AddedDate]...';


GO
ALTER TABLE [dbo].[Observation]
    ADD CONSTRAINT [DF_Observation_AddedDate] DEFAULT (getdate()) FOR [AddedDate];


GO
PRINT N'Creating [dbo].[DF_Observation_UpdatedAt]...';


GO
ALTER TABLE [dbo].[Observation]
    ADD CONSTRAINT [DF_Observation_UpdatedAt] DEFAULT (getdate()) FOR [UpdatedAt];


GO
PRINT N'Refreshing [dbo].[vObservationExpansion]...';


GO
SET ANSI_NULLS, QUOTED_IDENTIFIER OFF;


GO
EXECUTE sp_refreshsqlmodule N'[dbo].[vObservationExpansion]';


GO
SET ANSI_NULLS, QUOTED_IDENTIFIER ON;


GO
PRINT N'Refreshing [dbo].[vSensorThingsAPIObservations]...';


GO
SET ANSI_NULLS, QUOTED_IDENTIFIER OFF;


GO
EXECUTE sp_refreshsqlmodule N'[dbo].[vSensorThingsAPIObservations]';


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
PRINT N'Refreshing [dbo].[vStationObservations]...';


GO
SET ANSI_NULLS, QUOTED_IDENTIFIER OFF;


GO
EXECUTE sp_refreshsqlmodule N'[dbo].[vStationObservations]';


GO
SET ANSI_NULLS, QUOTED_IDENTIFIER ON;


GO
PRINT N'Refreshing [dbo].[aspnet_PersonalizationAdministration_DeleteAllState]...';


GO
SET ANSI_NULLS ON;

SET QUOTED_IDENTIFIER OFF;


GO
EXECUTE sp_refreshsqlmodule N'[dbo].[aspnet_PersonalizationAdministration_DeleteAllState]';


GO
SET ANSI_NULLS, QUOTED_IDENTIFIER ON;


GO
PRINT N'Refreshing [dbo].[aspnet_PersonalizationAdministration_FindState]...';


GO
SET ANSI_NULLS ON;

SET QUOTED_IDENTIFIER OFF;


GO
EXECUTE sp_refreshsqlmodule N'[dbo].[aspnet_PersonalizationAdministration_FindState]';


GO
SET ANSI_NULLS, QUOTED_IDENTIFIER ON;


GO
PRINT N'Refreshing [dbo].[aspnet_PersonalizationAdministration_GetCountOfState]...';


GO
SET ANSI_NULLS ON;

SET QUOTED_IDENTIFIER OFF;


GO
EXECUTE sp_refreshsqlmodule N'[dbo].[aspnet_PersonalizationAdministration_GetCountOfState]';


GO
SET ANSI_NULLS, QUOTED_IDENTIFIER ON;


GO
PRINT N'Refreshing [dbo].[aspnet_PersonalizationAdministration_ResetSharedState]...';


GO
SET ANSI_NULLS ON;

SET QUOTED_IDENTIFIER OFF;


GO
EXECUTE sp_refreshsqlmodule N'[dbo].[aspnet_PersonalizationAdministration_ResetSharedState]';


GO
SET ANSI_NULLS, QUOTED_IDENTIFIER ON;


GO
PRINT N'Refreshing [dbo].[aspnet_PersonalizationAllUsers_GetPageSettings]...';


GO
SET ANSI_NULLS ON;

SET QUOTED_IDENTIFIER OFF;


GO
EXECUTE sp_refreshsqlmodule N'[dbo].[aspnet_PersonalizationAllUsers_GetPageSettings]';


GO
SET ANSI_NULLS, QUOTED_IDENTIFIER ON;


GO
PRINT N'Refreshing [dbo].[aspnet_PersonalizationAllUsers_ResetPageSettings]...';


GO
SET ANSI_NULLS ON;

SET QUOTED_IDENTIFIER OFF;


GO
EXECUTE sp_refreshsqlmodule N'[dbo].[aspnet_PersonalizationAllUsers_ResetPageSettings]';


GO
SET ANSI_NULLS, QUOTED_IDENTIFIER ON;


GO
PRINT N'Refreshing [dbo].[aspnet_PersonalizationAllUsers_SetPageSettings]...';


GO
SET ANSI_NULLS ON;

SET QUOTED_IDENTIFIER OFF;


GO
EXECUTE sp_refreshsqlmodule N'[dbo].[aspnet_PersonalizationAllUsers_SetPageSettings]';


GO
SET ANSI_NULLS, QUOTED_IDENTIFIER ON;


GO
PRINT N'Refreshing [dbo].[aspnet_AnyDataInTables]...';


GO
SET ANSI_NULLS ON;

SET QUOTED_IDENTIFIER OFF;


GO
EXECUTE sp_refreshsqlmodule N'[dbo].[aspnet_AnyDataInTables]';


GO
SET ANSI_NULLS, QUOTED_IDENTIFIER ON;


GO
PRINT N'Refreshing [dbo].[aspnet_Profile_DeleteInactiveProfiles]...';


GO
SET ANSI_NULLS ON;

SET QUOTED_IDENTIFIER OFF;


GO
EXECUTE sp_refreshsqlmodule N'[dbo].[aspnet_Profile_DeleteInactiveProfiles]';


GO
SET ANSI_NULLS, QUOTED_IDENTIFIER ON;


GO
PRINT N'Refreshing [dbo].[aspnet_Profile_GetNumberOfInactiveProfiles]...';


GO
SET ANSI_NULLS ON;

SET QUOTED_IDENTIFIER OFF;


GO
EXECUTE sp_refreshsqlmodule N'[dbo].[aspnet_Profile_GetNumberOfInactiveProfiles]';


GO
SET ANSI_NULLS, QUOTED_IDENTIFIER ON;


GO
PRINT N'Refreshing [dbo].[aspnet_Profile_GetProfiles]...';


GO
SET ANSI_NULLS ON;

SET QUOTED_IDENTIFIER OFF;


GO
EXECUTE sp_refreshsqlmodule N'[dbo].[aspnet_Profile_GetProfiles]';


GO
SET ANSI_NULLS, QUOTED_IDENTIFIER ON;


GO
PRINT N'Refreshing [dbo].[aspnet_Profile_GetProperties]...';


GO
SET ANSI_NULLS ON;

SET QUOTED_IDENTIFIER OFF;


GO
EXECUTE sp_refreshsqlmodule N'[dbo].[aspnet_Profile_GetProperties]';


GO
SET ANSI_NULLS, QUOTED_IDENTIFIER ON;


GO
PRINT N'Refreshing [dbo].[aspnet_Profile_SetProperties]...';


GO
SET ANSI_NULLS ON;

SET QUOTED_IDENTIFIER OFF;


GO
EXECUTE sp_refreshsqlmodule N'[dbo].[aspnet_Profile_SetProperties]';


GO
SET ANSI_NULLS, QUOTED_IDENTIFIER ON;


GO
PRINT N'Refreshing [dbo].[aspnet_Users_DeleteUser]...';


GO
SET ANSI_NULLS ON;

SET QUOTED_IDENTIFIER OFF;


GO
EXECUTE sp_refreshsqlmodule N'[dbo].[aspnet_Users_DeleteUser]';


GO
SET ANSI_NULLS, QUOTED_IDENTIFIER ON;


GO
PRINT N'Refreshing [dbo].[aspnet_Profile_DeleteProfiles]...';


GO
SET ANSI_NULLS ON;

SET QUOTED_IDENTIFIER OFF;


GO
EXECUTE sp_refreshsqlmodule N'[dbo].[aspnet_Profile_DeleteProfiles]';


GO
SET ANSI_NULLS, QUOTED_IDENTIFIER ON;


GO
PRINT N'Refreshing [dbo].[aspnet_WebEvent_LogEvent]...';


GO
SET ANSI_NULLS ON;

SET QUOTED_IDENTIFIER OFF;


GO
EXECUTE sp_refreshsqlmodule N'[dbo].[aspnet_WebEvent_LogEvent]';


GO
SET ANSI_NULLS, QUOTED_IDENTIFIER ON;


GO
PRINT N'Update complete.';


GO
