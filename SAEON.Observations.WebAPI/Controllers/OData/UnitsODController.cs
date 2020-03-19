﻿using Microsoft.AspNet.OData;
using Microsoft.AspNet.OData.Routing;
using SAEON.Observations.Core.Entities;
using System;
using System.Linq;
using System.Web.Http;

namespace SAEON.Observations.WebAPI.Controllers.OData
{
    /// <summary>
    /// Units
    /// </summary>
    [ODataRoutePrefix("Units")]
    public class UnitsODController : NamedController<Unit>
    {

        // GET: odata/Units
        /// <summary>
        /// All Units
        /// </summary>
        /// <returns>ListOf(Unit)</returns>
        [ODataRoute]
        public override IQueryable<Unit> GetAll()
        {
            return base.GetAll();
        }

        // GET: odata/Units(5)
        /// <summary>
        /// Unit by Id
        /// </summary>
        /// <param name="id">Id of Unit</param>
        /// <returns>Unit</returns>
        [ODataRoute("({id})")]
        public override SingleResult<Unit> GetById([FromODataUri] Guid id)
        {
            return base.GetById(id);
        }

        // GET: odata/Units(5)/Phenomena
        /// <summary>
        /// Phenomena for the Unit
        /// </summary>
        /// <param name="id">Id of the Unit</param>
        /// <returns>ListOf(Phenomenon)</returns>
        [ODataRoute("({id})/Phenomena")]
        [EnableQuery(PageSize = PageSize, MaxTop = MaxTop)]
        public IQueryable<Phenomenon> GetPhenomena([FromODataUri] Guid id)
        {
            return GetManyWithGuidId(id, s => s.PhenomenonUnits).Select(i => i.Phenomenon);
        }
    }
}
