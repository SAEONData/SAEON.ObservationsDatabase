﻿using Microsoft.AspNet.OData;
using Microsoft.AspNet.OData.Routing;
using SAEON.Observations.SensorThings;
using System;
using System.Linq;
using System.Web.Http;
using db = SAEON.Observations.Core.Entities;

namespace SAEON.Observations.WebAPI.Controllers.SensorThings
{

    [ODataRoutePrefix("Sensors")]
    public class SensorsSTController : BaseController<Sensor, db.SensorThingsSensor>
    {
        [EnableQuery(PageSize = Config.PageSize), ODataRoute]
        public override IQueryable<Sensor> GetAll()
        {
            return base.GetAll();
        }

        [EnableQuery(PageSize = Config.PageSize), ODataRoute("({id})")]
        public override SingleResult<Sensor> GetById([FromODataUri] Guid id)
        {
            return base.GetById(id);
        }

        [EnableQuery(PageSize = Config.PageSize), ODataRoute("({id})/Datastreams")]
        public IQueryable<Datastream> GetDatastreams([FromUri] Guid id)
        {
            return GetRelatedMany(id, i => i.Datastreams);
        }

    }
}
