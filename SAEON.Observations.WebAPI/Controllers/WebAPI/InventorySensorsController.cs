﻿using SAEON.Observations.Core;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SAEON.Observations.WebAPI.Controllers.WebAPI
{
    public class InventorySensorsController : ApiReadController<InventorySensor>
    {
        /// <summary>
        /// All Sensors
        /// </summary>
        /// <returns></returns>
        public override Task<IEnumerable<InventorySensor>> GetAll()
        {
            return base.GetAll();
        }
    }
}
