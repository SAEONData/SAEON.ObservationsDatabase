﻿using SAEON.Logs;
using SAEON.Observations.Core.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.OData;

namespace SAEON.Observations.WebAPI.Controllers.OData
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ODataRouteName("OData")]
    public abstract class BaseODataController<TEntity> : ODataController where TEntity : BaseEntity
    {
        protected readonly ObservationsDbContext db = null;

        public BaseODataController()
        {
            db = new ObservationsDbContext();
            db.Configuration.AutoDetectChangesEnabled = false;
            db.Database.CommandTimeout = 30 * 60;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        /// <summary>
        /// Overwrite to filter entities
        /// </summary>
        /// <returns>ListOf(PredicateOf(TEntity))</returns>
        protected virtual List<Expression<Func<TEntity, bool>>> GetWheres()
        {
            return new List<Expression<Func<TEntity, bool>>>();
        }

        /// <summary>
        /// Overwrite to order of entities
        /// </summary>
        /// <returns>ListOf(PredicateOf(TEntity))</returns>
        protected virtual List<Expression<Func<TEntity, object>>> GetOrderBys()
        {
            return new List<Expression<Func<TEntity, object>>>();
        }

        /// <summary>
        /// Overwrite for entity includes
        /// </summary>
        /// <returns>ListOf(PredicateOf(TEntity))</returns>
        protected virtual List<Expression<Func<TEntity, bool>>> GetIncludes()
        {
            return new List<Expression<Func<TEntity, bool>>>();
        }

        /// <summary>
        /// query for items
        /// </summary>
        /// <returns></returns>
        protected IQueryable<TEntity> GetQuery(Expression<Func<TEntity, bool>> extraWhere = null)
        {
            var query = db.Set<TEntity>().AsQueryable().AsNoTracking();
            foreach (var include in GetIncludes())
            {
                query = query.Include(include);
            }
            foreach (var where in GetWheres())
            {
                query = query.Where(where);
            }
            if (extraWhere != null)
            {
                query = query.Where(extraWhere);
            }
            foreach (var orderBy in GetOrderBys())
            {
                query = query.OrderBy(orderBy);
            }
            return query;
        }

        /// <summary>
        /// Get all entities
        /// </summary>
        /// <returns>ListOf(TEntity)</returns>
        // GET: odata/TEntity
        //[EnableQuery, ODataRoute] Required in derived class
        public virtual IQueryable<TEntity> GetAll()
        {
            using (Logging.MethodCall<TEntity>(GetType()))
            {
                try
                {
                    return GetQuery();
                }
                catch (Exception ex)
                {
                    Logging.Exception(ex, "Unable to get all");
                    throw;
                }
            }
        }

        /// <summary>
        /// Get TEntity by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>TEntity</returns>
        // GET: odata/TEntity(5)
        //[EnableQuery, ODataRoute("({id})")] Required in derived class
        public virtual SingleResult<TEntity> GetById([FromODataUri] Guid id)
        {
            using (Logging.MethodCall<SingleResult<TEntity>>(GetType(), new ParameterList { { "Id", id } }))
            {
                try
                {
                    return SingleResult.Create(GetQuery(i => (i.Id == id)));
                }
                catch (Exception ex)
                {
                    Logging.Exception(ex, "Unable to get {id}", id);
                    throw;
                }
            }
        }

        /// <summary>
        /// Related Entity TEntity.TRelated
        /// </summary>
        /// <typeparam name="TRelated"></typeparam>
        /// <param name="id">Id of TEntity</param>
        /// <param name="select">Lambda to select TRelated</param>
        /// <param name="include">Lamda to include TRelated.TEntity</param>
        /// <returns>SingleResultOf(TRelated)</returns>
        // GET: odata/TEntity(5)/TRelated
        //[EnableQuery, ODataRoute("({id})/TRelated")] Required in derived class
        protected SingleResult<TRelated> GetSingle<TRelated>(Guid id, Expression<Func<TEntity, TRelated>> select, Expression<Func<TRelated, TEntity>> include) where TRelated : BaseEntity
        {
            using (Logging.MethodCall<SingleResult<TRelated>>(GetType()))
            {
                try
                {
                    return SingleResult.Create(GetQuery(i => (i.Id == id)).Select(select).Include(include));
                }
                catch (Exception ex)
                {
                    Logging.Exception(ex, "Unable to get {id}", id);
                    throw;
                }
            }
        }

        /// <summary>
        /// Related Entity TEntity.TRelated
        /// </summary>
        /// <typeparam name="TRelated"></typeparam>
        /// <param name="id">Id of TEntity</param>
        /// <param name="select">Lambda to select TRelated</param>
        /// <param name="include">Lamda to include TRelated.ListOf(TEntity)</param>
        /// <returns>SingleResultOf(TRelated)</returns>
        // GET: odata/TEntity(5)/TRelated
        //[EnableQuery, ODataRoute("({id})/TRelated")] Required in derived class
        protected SingleResult<TRelated> GetSingle<TRelated>(Guid id, Expression<Func<TEntity, TRelated>> select, Expression<Func<TRelated, IEnumerable<TEntity>>> include) where TRelated : BaseEntity
        {
            using (Logging.MethodCall<SingleResult<TRelated>>(GetType()))
            {
                try
                {
                    return SingleResult.Create(GetQuery(i => (i.Id == id)).Select(select).Include(include));
                }
                catch (Exception ex)
                {
                    Logging.Exception(ex, "Unable to get {id}", id);
                    throw;
                }
            }
        }

        /// <summary>
        /// Get IQueryableOf(TRelated)
        /// </summary>
        /// <typeparam name="TRelated"></typeparam>
        /// <param name="id">Id of TEntity</param>
        /// <param name="select">Lambda to select ListOf(TRelated)</param>
        /// <param name="include">Lambda to include TRelated.TEntity</param>
        /// <returns>IQueryableOf(TRelated)</returns>
        // GET: odata/TEntity(5)/TRelated
        //[EnableQuery, ODataRoute("({id})/TRelated")] Required in derived class
        protected IQueryable<TRelated> GetMany<TRelated>(Guid id, Expression<Func<TEntity, IEnumerable<TRelated>>> select, Expression<Func<TRelated, TEntity>> include) where TRelated : BaseEntity
        {
            using (Logging.MethodCall<TRelated>(GetType()))
            {
                try
                {
                    return GetQuery(i => i.Id == id).SelectMany(select).Include(include);
                }
                catch (Exception ex)
                {
                    Logging.Exception(ex, "Unable to get {id}", id);
                    throw;
                }
            }
        }

        /// <summary>
        /// Get IQueryableOf(TRelated)
        /// </summary>
        /// <typeparam name="TRelated"></typeparam>
        /// <param name="id">Id of TEntity</param>
        /// <param name="select">Lambda to select ListOf(TRelated)</param>
        /// <param name="include">Lambda to include TRelated.ListOf(TEntity)</param>
        /// <returns>IQueryableOf(TRelated)</returns>
        // GET: odata/TEntity(5)/TRelated
        //[EnableQuery, ODataRoute("({id})/TRelated")] Required in derived class
        protected IQueryable<TRelated> GetMany<TRelated>(Guid id, Expression<Func<TEntity, IEnumerable<TRelated>>> select, Expression<Func<TRelated, IEnumerable<TEntity>>> include) where TRelated : BaseEntity
        {
            using (Logging.MethodCall<TRelated>(GetType()))
            {
                try
                {
                    return GetQuery(i => i.Id == id).SelectMany(select).Include(include);
                }
                catch (Exception ex)
                {
                    Logging.Exception(ex, "Unable to get {id}", id);
                    throw;
                }
            }
        }
    }

    public abstract class NamedODataController<TEntity> : BaseODataController<TEntity> where TEntity : NamedEntity
    {
        protected override List<Expression<Func<TEntity, object>>> GetOrderBys()
        {
            var result = base.GetOrderBys();
            result.Add(i => i.Name);
            return result;
        }

        /// <summary>
        /// Get TEntity by Name
        /// </summary>
        /// <param name="name"></param>
        /// <returns>TEntity</returns>
        // GET: odata/TEntity(abc)
        //[EnableQuery, ODataRoute("({name})")] Required in derived class 
        public virtual SingleResult<TEntity> GetByName([FromODataUri] string name)
        {
            using (Logging.MethodCall<SingleResult<TEntity>>(GetType(), new ParameterList { { "Name", name } }))
            {
                try
                {
                    return SingleResult.Create(GetQuery(i => (i.Name == name)));
                }
                catch (Exception ex)
                {
                    Logging.Exception(ex, "Unable to get {name}", name);
                    throw;
                }
            }
        }
    }

    public abstract class CodedODataController<TEntity> : NamedODataController<TEntity> where TEntity : CodedEntity
    {
        protected override List<Expression<Func<TEntity, object>>> GetOrderBys()
        {
            var result = base.GetOrderBys();
            result.Insert(0, i => i.Code);
            return result;
        }

        /// <summary>
        /// Get TEntity by Code
        /// </summary>
        /// <param name="code"></param>
        /// <returns>TEntity</returns>
        // GET: odata/TEntity(abc)
        //[EnableQuery, ODataRoute("({name})")] Required in derived class 
        public virtual SingleResult<TEntity> GetByCode([FromODataUri] string code)
        {
            using (Logging.MethodCall<SingleResult<TEntity>>(GetType(), new ParameterList { { "Code", code } }))
            {
                try
                {
                    return SingleResult.Create(GetQuery(i => (i.Code == code)));
                }
                catch (Exception ex)
                {
                    Logging.Exception(ex, "Unable to get {code}", code);
                    throw;
                }
            }
        }
    }


    //// PUT: odata/Instruments(5)
    //public async Task<IHttpActionResult> Put([FromODataUri] Guid key, Delta<Instrument> patch)
    //{
    //    Validate(patch.GetEntity());

    //    if (!ModelState.IsValid)
    //    {
    //        return BadRequest(ModelState);
    //    }

    //    Instrument instrument = await db.Instruments.FindAsync(key);
    //    if (instrument == null)
    //    {
    //        return NotFound();
    //    }

    //    patch.Put(instrument);

    //    try
    //    {
    //        await db.SaveChangesAsync();
    //    }
    //    catch (DbUpdateConcurrencyException)
    //    {
    //        if (!InstrumentExists(key))
    //        {
    //            return NotFound();
    //        }
    //        else
    //        {
    //            throw;
    //        }
    //    }

    //    return Updated(instrument);
    //}

    //// POST: odata/Instruments
    //public async Task<IHttpActionResult> Post(Instrument instrument)
    //{
    //    if (!ModelState.IsValid)
    //    {
    //        return BadRequest(ModelState);
    //    }

    //    db.Instruments.Add(instrument);

    //    try
    //    {
    //        await db.SaveChangesAsync();
    //    }
    //    catch (DbUpdateException)
    //    {
    //        if (InstrumentExists(instrument.Id))
    //        {
    //            return Conflict();
    //        }
    //        else
    //        {
    //            throw;
    //        }
    //    }

    //    return Created(instrument);
    //}

    //// PATCH: odata/Instruments(5)
    //[AcceptVerbs("PATCH", "MERGE")]
    //public async Task<IHttpActionResult> Patch([FromODataUri] Guid key, Delta<Instrument> patch)
    //{
    //    Validate(patch.GetEntity());

    //    if (!ModelState.IsValid)
    //    {
    //        return BadRequest(ModelState);
    //    }

    //    Instrument instrument = await db.Instruments.FindAsync(key);
    //    if (instrument == null)
    //    {
    //        return NotFound();
    //    }

    //    patch.Patch(instrument);

    //    try
    //    {
    //        await db.SaveChangesAsync();
    //    }
    //    catch (DbUpdateConcurrencyException)
    //    {
    //        if (!InstrumentExists(key))
    //        {
    //            return NotFound();
    //        }
    //        else
    //        {
    //            throw;
    //        }
    //    }

    //    return Updated(instrument);
    //}

    //// DELETE: odata/Instruments(5)
    //public async Task<IHttpActionResult> Delete([FromODataUri] Guid key)
    //{
    //    Instrument instrument = await db.Instruments.FindAsync(key);
    //    if (instrument == null)
    //    {
    //        return NotFound();
    //    }

    //    db.Instruments.Remove(instrument);
    //    await db.SaveChangesAsync();

    //    return StatusCode(HttpStatusCode.NoContent);
    //}

}

