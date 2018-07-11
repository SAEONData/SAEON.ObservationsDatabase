﻿using Newtonsoft.Json.Linq;
using e = SAEON.Observations.Core.Entities;
using SAEON.SensorThings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace SAEON.Observations.WebAPI.Controllers.SensorThingsAPI
{
    [RoutePrefix("SensorThings/Things")]
    public class ThingsSTController : BaseController<Thing>
    {
        protected override Thing GetEntity(int id)
        {
            var station = db.Stations.Where(i => i.Latitude.HasValue && i.Longitude.HasValue).ToList().FirstOrDefault(i => i.Id.GetHashCode() == id);
            if (station != null) return SensorThingsFactory.ThingFromStation(station, Request.RequestUri);
            var instrument = db.Instruments.Where(i => i.Latitude.HasValue && i.Longitude.HasValue).ToList().FirstOrDefault(i => i.Id.GetHashCode() == id);
            if (instrument != null) return SensorThingsFactory.ThingFromInstrument(instrument, Request.RequestUri);
            var sensor = db.Sensors.Where(i => i.Latitude.HasValue && i.Longitude.HasValue).ToList().FirstOrDefault(i => i.Id.GetHashCode() == id);
            if (sensor != null) return SensorThingsFactory.ThingFromSensor(sensor, Request.RequestUri);
            return null;
        }

        protected override List<Thing> GetEntities()
        {
            var result = base.GetEntities();
            foreach (var station in db.Stations.Where(i => i.Latitude.HasValue && i.Longitude.HasValue))
            {
                result.Add(SensorThingsFactory.ThingFromStation(station, Request.RequestUri));
            }
            foreach (var instrument in db.Instruments.Where(i => i.Latitude.HasValue && i.Longitude.HasValue))
            {
                result.Add(SensorThingsFactory.ThingFromInstrument(instrument, Request.RequestUri));
            }
            foreach (var sensor in db.Sensors.Where(i => i.Latitude.HasValue && i.Longitude.HasValue))
            {
                result.Add(SensorThingsFactory.ThingFromSensor(sensor, Request.RequestUri));
            }
            return result.OrderBy(i => i.Name).ToList();
        }

        private List<Location> GetLocationsList(int id)
        {
            var result = new List<Location>();
            var thing = GetEntity(id);
            if (thing != null)
            {
                result.Add(thing.Location);
            }
            return result.OrderBy(i => i.Name).ToList();
        }

        private List<HistoricalLocation> GetHistoricalLocationsList(int id)
        {
            var result = new List<HistoricalLocation>();
            var thing = GetEntity(id);
            if (thing != null)
            {
                result.AddRange(thing.HistoricalLocations);
            }
            return result.ToList();
        }

        public override JToken GetAll()
        {
            return base.GetAll();
        }

        [Route("~/SensorThings/Things({id:int})")]
        public override JToken GetById([FromUri] int id)
        {
            return base.GetById(id);
        }

        [HttpGet]
        [Route("~/SensorThings/Things({id:int})/Locations")]
        public JToken GetLocations([FromUri] int id)
        {
            return GetMany<Location>(id, GetLocationsList);
        }

        [HttpGet]
        [Route("~/SensorThings/Things({id:int})/HistoricalLocations")]
        public JToken GetHistoricalLocations([FromUri] int id)
        {
            return GetMany<HistoricalLocation>(id, GetHistoricalLocationsList);
        }

    }
}