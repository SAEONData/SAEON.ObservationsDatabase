﻿using System;
using System.Linq;
using System.Web.Http;
using System.Web.OData;
using System.Web.OData.Routing;
using SAEON.Observations.Core.Entities;

namespace SAEON.Observations.WebAPI.Controllers.OData
{
    /// <summary>
    /// Phenomenona
    /// </summary>
    [ODataRoutePrefix("Phenomena")]
    public class PhenomenaODController : BaseODataController<Phenomenon>
    {
        // GET: odata/Phenomena
        /// <summary>
        /// Get all Phenomena
        /// </summary>
        /// <returns>ListOf(Phenomenon)</returns>
        [EnableQuery, ODataRoute]
        public override IQueryable<Phenomenon> GetAll()
        {
            return base.GetAll();
        }

        // GET: odata/Phenomena(5)
        /// <summary>
        /// Phenomenon by Id
        /// </summary>
        /// <param name="id">Id of Phenomenon</param>
        /// <returns>Phenomenon</returns>
        [EnableQuery, ODataRoute("({id})")]
        public override SingleResult<Phenomenon> GetById([FromODataUri] Guid id)
        {
            return base.GetById(id);
        }

        // GET: odata/Phenomena(5)/Offerings
        /// <summary>
        /// Offerings for the Phenomenon
        /// </summary>
        /// <param name="id">Id of the Phenomenon</param>
        /// <returns>ListOf(Offering)</returns>
        [EnableQuery, ODataRoute("({id})/Offerings")]
        public IQueryable<Offering> GetOfferings([FromODataUri] Guid id)
        {
            return GetMany(id, s => s.Offerings, i => i.Phenomena);
        }

        // GET: odata/Phenomena(5)/Units
        /// <summary>
        /// Units for the Phenomenon
        /// </summary>
        /// <param name="id">Id of the Phenomenon</param>
        /// <returns>ListOf(Unit)</returns>
        [EnableQuery, ODataRoute("({id})/Units")]
        public IQueryable<Unit> GetUnits([FromODataUri] Guid id)
        {
            return GetMany(id, s => s.Units, i => i.Phenomena);
        }

        // GET: odata/Phenomena(5)/Sensors
        /// <summary>
        /// Sensors for the Phenomenon
        /// </summary>
        /// <param name="id">Id of the Phenomenon</param>
        /// <returns>ListOf(Sensor)</returns>
        [EnableQuery, ODataRoute("({id})/Sensors")]
        public IQueryable<Sensor> GetSensors([FromODataUri] Guid id)
        {
            return GetMany(id, s => s.Sensors, i => i.Phenomenon);
        }
    }
}