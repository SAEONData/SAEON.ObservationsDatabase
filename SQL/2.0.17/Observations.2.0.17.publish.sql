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
--IF (SELECT is_default
--    FROM   [$(DatabaseName)].[sys].[filegroups]
--    WHERE  [name] = N'Documents') = 0
--    BEGIN
--        ALTER DATABASE [$(DatabaseName)]
--            MODIFY FILEGROUP [Documents] DEFAULT;
--    END


GO
USE [$(DatabaseName)];


GO
/*
The column [dbo].[Sensor].[StationID] is being dropped, data loss could occur.
*/

--IF EXISTS (select top 1 1 from [dbo].[Sensor])
--    RAISERROR (N'Rows were detected. The schema update is terminating because data loss might occur.', 16, 127) WITH NOWAIT

GO
PRINT N'Dropping [dbo].[Sensor].[IX_Sensor_StationID]...';


GO
DROP INDEX [IX_Sensor_StationID]
    ON [dbo].[Sensor];


GO
PRINT N'Dropping [dbo].[FK_Sensor_Station]...';


GO
ALTER TABLE [dbo].[Sensor] DROP CONSTRAINT [FK_Sensor_Station];


GO
PRINT N'Altering [dbo].[Sensor]...';


GO
ALTER TABLE [dbo].[Sensor] DROP COLUMN [StationID];


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
  inner join Sensor 
    on (d.SensorID = Sensor.ID)
  inner join Instrument_Sensor
    on (Instrument_Sensor.SensorID = Sensor.ID)
  inner join Instrument
    on (Instrument_Sensor.InstrumentID = Instrument.ID)
  inner join Station_Instrument
    on (Station_Instrument.InstrumentID = Instrument.ID)
  inner join Station 
    on (Station_Instrument.StationID = Station.ID)
  inner join Site
    on (Station.SiteID = Site.ID)
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
PRINT N'Altering [dbo].[vDataQuery]...';


GO
--> Changed 2.0.3 20160503 TimPN
--Renamed SensorProcedure to Sensor
--< Changed 2.0.3 20160503 TimPN
ALTER VIEW [dbo].[vDataQuery]
AS
--> Removed 2.0.17 20161128 TimPN
--SELECT     TOP (100) PERCENT NEWID()ID, Organisation.IDOrganisationID, Organisation.NameOrganisation, 
--                      Organisation.DescriptionOrganisationDesc, ProjectSite.IDProjectSiteID, ProjectSite.NameProjectSite, 
--                      ProjectSite.DescriptionProjectSiteDesc, Station.IDStationID, Station.NameStation, Station.DescriptionStationDesc, 
--                      Sensor.IDSensorID, Sensor.NameSensor, Sensor.DescriptionSensorDesc, 
--                      Phenomenon.IDPhenomenonID, Phenomenon.NamePhenomenon, Phenomenon.DescriptionPhenomenonDesc, Offering.IDOfferingID, 
--                      Offering.NameOffering, Offering.DescriptionOfferingDesc
--FROM         Station INNER JOIN
--                      Sensor ON Sensor.StationID = Station.ID INNER JOIN
--                      Phenomenon ON Phenomenon.ID = Sensor.PhenomenonID INNER JOIN
--                      PhenomenonOffering ON PhenomenonOffering.PhenomenonID = Phenomenon.ID INNER JOIN
--                      Offering ON Offering.ID = PhenomenonOffering.OfferingID INNER JOIN
--                      ProjectSite ON ProjectSite.ID = Station.ProjectSiteID INNER JOIN
--                      Organisation ON Organisation.ID = ProjectSite.OrganisationID
--ORDER BY Organisation, ProjectSite, Station, Sensor, Phenomenon, Offering
--< Removed 2.0.17 20161128 TimPN
--> Added 2.0.17 20161128 TimPN
SELECT Top (100) Percent    
  Site.ID SiteID, Site.Name SiteName, Site.Description SiteDesc,
  Station.ID StationID, Station.Name StationName, Station.Description StationDesc,
  Instrument.ID InstrumentID, Instrument.Name InstrumentName, Instrument.Description InstrumentDesc,
  Sensor.ID SensorID, Sensor.Name Sensor, Sensor.Description SensorDesc, 
  Phenomenon.ID PhenomenonID, Phenomenon.Name Phenomenon, Phenomenon.Description PhenomenonDesc, 
  Offering.ID OfferingID, Offering.Name Offering, Offering.Description OfferingDesc
FROM
	Sensor 
	inner join Instrument_Sensor
	  on (Instrument_Sensor.SensorID = Sensor.ID)
	inner join Instrument
	  on (Instrument_Sensor.InstrumentID = Instrument.ID)
	inner join Station_Instrument
	  on (Station_Instrument.InstrumentID = Instrument.ID)
	inner join Station 
	  on (Station_Instrument.StationID = Station.ID)
	inner join Site
	  on (Station.SiteID = Site.ID)
	INNER JOIN Phenomenon ON Phenomenon.ID = Sensor.PhenomenonID 
	INNER JOIN PhenomenonOffering ON PhenomenonOffering.PhenomenonID = Phenomenon.ID 
	INNER JOIN Offering ON Offering.ID = PhenomenonOffering.OfferingID 
ORDER BY 
  Site.Name, Station.Name, Instrument.Name, Sensor, Phenomenon, Offering
--< Added 2.0.17 20161128 TimPN
GO
PRINT N'Refreshing [dbo].[vInstrumentSensor]...';


GO
SET ANSI_NULLS, QUOTED_IDENTIFIER OFF;


GO
EXECUTE sp_refreshsqlmodule N'[dbo].[vInstrumentSensor]';


GO
SET ANSI_NULLS, QUOTED_IDENTIFIER ON;


GO
PRINT N'Altering [dbo].[vInventory]...';


GO
--> Changed 2.0.3 20160503 TimPN
--Renamed SensorProcedure to Sensor
--< Changed 2.0.3 20160503 TimPN
--> Removed 2.0.17 20161128 TimPN
--CREATE VIEW [dbo].[vInventory]
--AS
--Select 
-- ps.Name Site,
-- s.Name Station,
-- sp.Name Sensor,
-- p.Name Phenomenon,
-- d.StartDate,
-- d.EndDate
--FROM Station s with (nolock)
-- INNER Join ProjectSite ps with (nolock)
-- on  ps.ID=  s.ProjectSiteID
--INNER Join Sensor sp with (nolock)
-- on s.ID = sp.StationID
--INNER Join Phenomenon p with (nolock)
-- on  sp.PhenomenonID = p.ID 

--INNER JOIN 
--(
-- SELECT SensorID,MIN(ValueDate) StartDate,MAX(ValueDate) EndDate
--  FROM Observation with (nolock)
-- Group By SensorID
--)d
--ON sp.ID = d.SensorID
--< Removed 2.0.17 20161128 TimPN
--> Added 2.0.17 20161128 TimPN
ALTER VIEW [dbo].[vInventory]
AS
Select 
  Site.Name Site,
  Station.Name Station,
  Instrument.Name Instrument,
  Sensor.Name Sensor,
  p.Name Phenomenon,
  d.StartDate,
  d.EndDate
from
  Sensor 
  inner join Instrument_Sensor
	on (Instrument_Sensor.SensorID = Sensor.ID)
  inner join Instrument
	on (Instrument_Sensor.InstrumentID = Instrument.ID)
  inner join Station_Instrument
    on (Station_Instrument.InstrumentID = Instrument.ID)
  inner join Station 
    on (Station_Instrument.StationID = Station.ID)
  inner join Site
    on (Station.SiteID = Site.ID)
  inner join Phenomenon p 
   on (Sensor.PhenomenonID = p.ID )

INNER JOIN 
(
 SELECT SensorID,MIN(ValueDate) StartDate,MAX(ValueDate) EndDate
  FROM Observation with (nolock)
 Group By SensorID
)d
ON (Sensor.ID = d.SensorID)
--< Added 2.0.17 20161128 TimPN
GO
PRINT N'Altering [dbo].[vObservation]...';


GO
--> Changed 2.0.3 20160503 TimPN
--Renamed SensorProcedure to Sensor
--< Changed 2.0.3 20160503 TimPN
ALTER VIEW [dbo].[vObservation]
AS
--> Changed 2.0.16 20161107 TimPN
--> Changed 2.0.3 20160421 TimPN
--SELECT     o.ID, o.SensorID, o.PhenonmenonOfferingID, o.PhenonmenonUOMID, o.UserId, o.RawValue, o.DataValue, o.ImportBatchID, o.ValueDate, 
--SELECT     o.ID, o.SensorID, o.PhenomenonOfferingID, o.PhenomenonUOMID, o.UserId, o.RawValue, o.DataValue, o.ImportBatchID, o.ValueDate, 
--< Changed 2.0.3 20160421 TimPN
--                      sp.Code AS spCode, sp.Description AS spDesc, sp.Name AS spName, sp.Url AS spURL, sp.DataSchemaID, sp.DataSourceID, sp.PhenomenonID, sp.StationID, 
--                      ph.Name AS phName, st.Name AS stName, ds.Name AS dsName, ISNULL(dschema.Name,dschema1.Name) AS dschemaName, offer.Name AS offName, offer.ID AS offID, ps.Name AS psName, 
--                      ps.ID AS psID, org.Name AS orgName, org.ID AS orgID, uom.Unit AS uomUnit, uom.UnitSymbol AS uomSymbol, users.UserName,
--                      o.Comment
--FROM         dbo.Observation AS o INNER JOIN
--                      dbo.Sensor AS sp ON sp.ID = o.SensorID INNER JOIN
--                      dbo.Phenomenon AS ph ON ph.ID = sp.PhenomenonID INNER JOIN
--> Changed 2.0.3 20160421 TimPN
--                      dbo.PhenomenonOffering AS phOff ON phOff.ID = o.PhenonmenonOfferingID INNER JOIN  
--                      dbo.PhenomenonOffering AS phOff ON phOff.ID = o.PhenomenonOfferingID INNER JOIN  
--< Changed 2.0.3 20160421 TimPN
--                      dbo.Offering AS offer ON offer.ID = phOff.OfferingID INNER JOIN
--> Changed 2.0.3 20160421 TimPN
--                      dbo.PhenomenonUOM AS puom ON puom.ID = o.PhenonmenonUOMID INNER JOIN
--                      dbo.PhenomenonUOM AS puom ON puom.ID = o.PhenomenonUOMID INNER JOIN
--< Changed 2.0.3 20160421 TimPN
--                      dbo.Station AS st ON st.ID = sp.StationID INNER JOIN
--                      dbo.DataSource AS ds ON ds.ID = sp.DataSourceID LEFT JOIN
--                      dbo.DataSchema AS dschema1 ON dschema1.ID = ds.DataSchemaID LEFT JOIN
--                      dbo.DataSchema AS dschema ON dschema.ID = sp.DataSchemaID INNER JOIN                   
--                      dbo.ProjectSite AS ps ON ps.ID = st.ProjectSiteID INNER JOIN
--                      dbo.Organisation AS org ON org.ID = ps.OrganisationID INNER JOIN
--                      dbo.UnitOfMeasure AS uom ON uom.ID = puom.UnitOfMeasureID INNER JOIN
--                      dbo.aspnet_Users AS users ON users.UserId = o.UserId 
SELECT 
  o.ID, o.SensorID, o.PhenomenonOfferingID, o.PhenomenonUOMID, o.RawValue, o.DataValue, o.ImportBatchID, o.ValueDate, o.Comment, 
  o.UserId, aspnet_Users.UserName,
  Status.Name StatusName,
  StatusReason.Name StatusReasonName,
  Offering.ID OfferingID,
  Offering.Name OfferingName,
  UnitOfMeasure.ID UnitOfMeasureID,
  UnitOfMeasure.Unit UnitOfMeasureUnit,
  UnitOfMeasure.UnitSymbol UnitOfMeasureSymbol,
  Sensor.Name SensorName,
  Phenomenon.ID PhenomenonID,
  Phenomenon.Name PhenomenonName,
  DataSource.ID DataSourceID,
  DataSource.Name DataSourceName,
  IsNull(SensorSchema.Name, DataSourceSchema.Name) DataSchemaName,
  Instrument.ID InstrumentID,
  Instrument.Name InstrumentName,
  Station.ID StationID,
  Station.Name StationName,
  Site.ID SiteID,
  Site.Name SiteName,
  Organisation.ID OrganisationID,
  Organisation.Name OrganisationName
FROM
  Observation o
  left join Status
    on (o.StatusID = Status.ID)
  left join StatusReason
    on (o.StatusReasonID = StatusReason.ID)
  inner join PhenomenonOffering
    on (o.PhenomenonOfferingID = PhenomenonOffering.ID)
  inner join Offering
    on (PhenomenonOffering.OfferingID = Offering.ID)
  inner join PhenomenonUOM
    on (o.PhenomenonUOMID = PhenomenonUOM.ID)
  inner join UnitOfMeasure
    on (PhenomenonUOM.UnitOfMeasureID = UnitOfMeasure.ID)
  inner join Sensor 
    on (o.SensorID = Sensor.ID)
  inner join Phenomenon
    on (Sensor.PhenomenonID = Phenomenon.ID)
  left join DataSchema SensorSchema
    on (Sensor.DataSchemaID = SensorSchema.ID)
  inner join DataSource
    on (Sensor.DataSourceID = DataSource.ID)
  left join DataSchema DataSourceSchema
    on (DataSource.DataSchemaID = DataSourceSchema.ID)
  inner join Instrument_Sensor
    on (Instrument_Sensor.SensorID = Sensor.ID)
  inner join Instrument
    on (Instrument_Sensor.InstrumentID = Instrument.ID)
  inner join Station_Instrument
    on (Station_Instrument.InstrumentID = Instrument.ID)
  inner join Station
    on (Station_Instrument.StationID = Station.ID)
  inner join Site
    on (Station.SiteID = Site.ID)
  inner join Organisation_Site
    on (Organisation_Site.SiteID = Site.ID)
  inner join Organisation
    on (Organisation_Site.OrganisationID = Organisation.ID)
  inner join aspnet_Users
    on (o.UserId = aspnet_Users.UserId)
--< Changed 2.0.16 20161107 TimPN
GO
PRINT N'Refreshing [dbo].[vObservationsList]...';


GO
SET ANSI_NULLS, QUOTED_IDENTIFIER OFF;


GO
EXECUTE sp_refreshsqlmodule N'[dbo].[vObservationsList]';


GO
SET ANSI_NULLS, QUOTED_IDENTIFIER ON;


GO
PRINT N'Altering [dbo].[vSensor]...';


GO
--> Changed 2.0.3 20160503 TimPN
--Renamed SensorProcedure to Sensor
--< Changed 2.0.3 20160503 TimPN
--> Removed 2.0.17 20161128 TimPN
--CREATE VIEW [dbo].[vSensor]
--AS
--SELECT 
--s.ID,
--s.Code,
--s.Name,
--s.[Description],
--s.Url,
--s.StationID,
--s.DataSourceID,
--s.PhenomenonID,
----> Added 2.0.7 20160609 TimPN
--  [Phenomenon].Name PhenomenonName,
----< Added 2.0.7 20160609 TimPN
--s.UserId,
--st.Name AS StationName,
--d.Name AS DataSourceName,
----> Added 20161110 TimPN
--s.DataSchemaID,
----< Added 20161110 TimPN
----> Changed 20161110 TimPN
----ds.[Description] DataSchemaName
--ds.[Name] DataSchemaName
----< Changed 20161110 TimPN
--FROM Sensor s
--INNER JOIN DataSource d
--    on s.DataSourceID = d.ID
--INNER JOIN Station st
--    on s.StationID = st.ID
--LEFT JOIN DataSchema ds
--    on s.DataSchemaID = ds.ID
----> Added 2.0.7 20160609 TimPN
--  inner join [Phenomenon]
--    on (s.PhenomenonID = [Phenomenon].ID)
----< Added 2.0.7 20160609 TimPN
--< Removed 2.0.17 20161128 TimPN
--> Added 2.0.17 20161128 TimPN
ALTER VIEW [dbo].[vSensor]
AS
SELECT 
  Sensor.ID,
  Sensor.Code,
  Sensor.Name,
  Sensor.[Description],
  Sensor.Url,
  Sensor.DataSourceID,
  Sensor.PhenomenonID,
  [Phenomenon].Name PhenomenonName,
  Sensor.UserId,
  Site.Name Site,
  Station.Name Station,
  Instrument.Name Instrument,
  d.Name AS DataSourceName,
  Sensor.DataSchemaID,
  ds.[Name] DataSchemaName
FROM 
  Sensor 
  inner join Instrument_Sensor
	on (Instrument_Sensor.SensorID = Sensor.ID)
  inner join Instrument
	on (Instrument_Sensor.InstrumentID = Instrument.ID)
  inner join Station_Instrument
    on (Station_Instrument.InstrumentID = Instrument.ID)
  inner join Station 
    on (Station_Instrument.StationID = Station.ID)
  inner join Site
    on (Station.SiteID = Site.ID)
INNER JOIN DataSource d
    on Sensor.DataSourceID = d.ID
LEFT JOIN DataSchema ds
    on Sensor.DataSchemaID = ds.ID
  inner join [Phenomenon]
    on (Sensor.PhenomenonID = [Phenomenon].ID)
--< Added 2.0.17 20161128 TimPN
GO
PRINT N'Refreshing [dbo].[vObservationRoles]...';


GO
EXECUTE sp_refreshsqlmodule N'[dbo].[vObservationRoles]';


GO
PRINT N'Update complete.';


GO
