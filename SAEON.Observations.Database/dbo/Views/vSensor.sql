﻿--> Changed 2.0.3 20160503 TimPN
--Renamed SensorProcedure to Sensor
--< Changed 2.0.3 20160503 TimPN
CREATE VIEW [dbo].[vSensor]
AS
SELECT 
s.ID,
s.Code,
s.Name,
s.[Description],
s.Url,
s.StationID,
s.DataSourceID,
s.PhenomenonID,
--> Added 2.0.7 20160609 TimPN
  [Phenomenon].Name PhenomenonName,
--< Added 2.0.7 20160609 TimPN
s.UserId,
st.Name AS StationName,
d.Name AS DataSourceName,
--> Added 20161110 TimPN
s.DataSchemaID,
--< Added 20161110 TimPN
--> Changed 20161110 TimPN
--ds.[Description] DataSchemaName
ds.[Name] DataSchemaName
--< Changed 20161110 TimPN
FROM Sensor s
INNER JOIN DataSource d
    on s.DataSourceID = d.ID
INNER JOIN Station st
    on s.StationID = st.ID
LEFT JOIN DataSchema ds
    on s.DataSchemaID = ds.ID
--> Added 2.0.7 20160609 TimPN
  inner join [Phenomenon]
    on (s.PhenomenonID = [Phenomenon].ID)
--< Added 2.0.7 20160609 TimPN



