﻿using Microsoft.AspNetCore.Cors;
using SAEON.Observations.Auth;
using SAEON.Observations.Core;

namespace SAEON.Observations.WebAPI.Controllers.OData
{
    [EnableCors(SAEONAuthenticationDefaults.CorsAllowAllPolicy)]
    public abstract class ODataController<TEntity> : BaseODataController<TEntity> where TEntity : BaseEntity
    {
    }
}
