﻿CREATE VIEW [dbo].[vObservationApi]
AS
Select
  ID,
  SensorID,
  ValueDate,
  DataValue,
  TextValue,
  Latitude,
  Longitude,
  Elevation,
  PhenomenonID,
  PhenomenonCode,
  PhenomenonName,
  PhenomenonDescription,
  OfferingID,
  OfferingCode,
  OfferingName,
  OfferingDescription,
  UnitOfMeasureID,
  UnitOfMeasureCode,
  UnitOfMeasureUnit,
  UnitOfMeasureSymbol,
  CorrelationID,
  Comment,
  StatusCode,
  StatusName,
  StatusDescription,
  StatusReasonCode,
  StatusReasonName,
  StatusReasonDescription
from
  vObservationExpansion
