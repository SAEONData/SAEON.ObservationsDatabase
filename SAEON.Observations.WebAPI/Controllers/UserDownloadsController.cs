﻿using AutoMapper;
using Microsoft.AspNet.Identity;
using Microsoft.Web.Http;
using SAEON.Observations.Core;
using Serilog;
using Serilog.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SAEON.Observations.WebAPI.Controllers
{
    /// <summary>
    /// Users have to be logged in to download data in the QuerySite. Any downloads are saved for later re-downloads.
    /// </summary>
    [ApiVersion("1.0")]
    [RoutePrefix("UserDownloads")]
    [Authorize(Roles = "Administrators,DataReaders")]
    public class UserDownloadsController : ApiController
    {
        ObservationsDbContext db = null;

        public UserDownloadsController()
        {
            db = new ObservationsDbContext();
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
        /// Return all UserDownloads for the logged in user
        /// </summary>
        /// <returns></returns>
        [Route]
        public IEnumerable<UserDownloadDTO> Get()
        {
            return db.UserDownloads.Where(d => d.UserId == User.Identity.GetUserId());
        }

        /// <summary>
        /// Return a UserDownload for for the logged in user
        /// </summary>
        /// <param name="id">The id of the UserDownload</param>
        /// <returns></returns>
        [Route("{id:guid}")]
        public UserDownloadDTO Get(Guid id)
        {
            var item = db.UserDownloads.FirstOrDefault(d => (d.UserId == User.Identity.GetUserId()) && (d.Id == id));
            if (item == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return item;
        }

        /// <summary>
        /// Return a UserDownload for for the logged in user
        /// </summary>
        /// <param name="name">The name of the UserDownload</param>
        /// <returns></returns>
        [Route("{name}")]
        public UserDownloadDTO GetByName(string name)
        {
            var item = db.UserDownloads.FirstOrDefault(d => (d.UserId == User.Identity.GetUserId()) && (d.Name == name));
            if (item == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return item;
        }

        /// <summary>
        /// Create a UserDownload
        /// </summary>
        /// <param name="itemDTO">The UserDownload to be created</param>
        [Route]
        [Authorize(Roles = "QuerySite")]
        public UserDownloadDTO Post([FromBody]UserDownloadDTO itemDTO)
        {
            using (LogContext.PushProperty("Method", "Post"))
            {
                try
                {
                    Log.Verbose("Adding {itemDTO.Name} {@itemDTO}", itemDTO);
                    if (!ModelState.IsValid)
                    {
                        throw new HttpResponseException(HttpStatusCode.BadRequest);
                    }
                    try
                    {
                        db.UserDownloads.Add(Mapper.Map<UserDownloadDTO, UserDownload>(itemDTO));
                        db.SaveChanges();
                    }
                    catch (DbUpdateException)
                    {
                        if (!db.UserDownloads.Any(i => i.Id == itemDTO.Id))
                        {
                            throw new HttpResponseException(HttpStatusCode.Conflict);
                        }
                        else
                        {
                            throw;
                        }
                    }
                    return itemDTO;
                }
                catch (Exception ex)
                {
                    Log.Error(ex, "Unable to add {itemDTO.Name}", itemDTO);
                    throw;
                }
            }
        }

        /// <summary>
        /// Update a UserDownload for the logged in user
        /// </summary>
        /// <param name="id">The id of the UserDownload</param>
        /// <param name="itemDTO">The UserDownload to be updated</param>
        [Route("{id:guid}")]
        [Authorize(Roles = "QuerySite")]
        public void PutById(Guid id, [FromBody]UserDownloadDTO itemDTO)
        {
            using (LogContext.PushProperty("Method", "PutById"))
            {
                try
                {
                    Log.Verbose("Updating {id} {@itemDTO}", id, itemDTO);
                    if (!ModelState.IsValid || (id != itemDTO.Id))
                    {
                        throw new HttpResponseException(HttpStatusCode.BadRequest);
                    }
                    var item = db.UserDownloads.FirstOrDefault(i => i.Id == id);
                    if (item == null)
                    {
                        throw new HttpResponseException(HttpStatusCode.NotFound);
                    }
                    Mapper.Map<UserDownloadDTO, UserDownload>(itemDTO, item);
                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    Log.Error(ex, "Unable to update {id}", id);
                    throw;
                }
            }
        }

        /// <summary>
        /// Update a UserDownload for the logged in user
        /// </summary>
        /// <param name="name">The name of the UserDownload</param>
        /// <param name="itemDTO">The UserDownload to be updated</param>
        [Route("{name}")]
        [Authorize(Roles = "QuerySite")]
        public void PutByName(string name, [FromBody]UserDownloadDTO itemDTO)
        {
            using (LogContext.PushProperty("Method", "PutByName"))
            {
                try
                {
                    Log.Verbose("Updating {name} {@itemDTO}", name, itemDTO);
                    if (!ModelState.IsValid || (name != itemDTO.Name))
                    {
                        throw new HttpResponseException(HttpStatusCode.BadRequest);
                    }
                    var item = db.UserDownloads.FirstOrDefault(i => i.Name == name);
                    if (item == null)
                    {
                        throw new HttpResponseException(HttpStatusCode.NotFound);
                    }
                    Mapper.Map<UserDownloadDTO, UserDownload>(itemDTO, item);
                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    Log.Error(ex, "Unable to update {name}", name);
                    throw;
                }
            }
        }

        /// <summary>
        /// Delete a UserDownload for the logged in user
        /// </summary>
        /// <param name="id">The id of the UserDownload</param>
        [Route("{id:guid}")]
        [Authorize(Roles = "QuerySite")]
        public void DeleteById(Guid id)
        {
            using (LogContext.PushProperty("Method", "DeleteById"))
            {
                try
                {
                    Log.Verbose("Deleting {id}", id);
                    var item = db.UserDownloads.FirstOrDefault(d => (d.UserId == User.Identity.GetUserId()) && (d.Id == id));
                    if (item == null)
                    {
                        throw new HttpResponseException(HttpStatusCode.NotFound);
                    }
                    db.UserDownloads.Remove(item);
                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    Log.Error(ex, "Unable to delete {id}", id);
                    throw;
                }
            }
        }

        /// <summary>
        /// Delete a UserDownload for the logged in user
        /// </summary>
        /// <param name="name">The name of the UserDownload</param>
        [Route("{name}")]
        [Authorize(Roles = "QuerySite")]
        public void DeleteByName(string name)
        {
            using (LogContext.PushProperty("Method", "DeleteByName"))
            {
                try
                {
                    Log.Verbose("Deleting {name}", name);
                    var item = db.UserDownloads.FirstOrDefault(d => (d.UserId == User.Identity.GetUserId()) && (d.Name == name));
                    if (item == null)
                    {
                        throw new HttpResponseException(HttpStatusCode.NotFound);
                    }
                    db.UserDownloads.Remove(item);
                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    Log.Error(ex, "Unable to delete {name}", name);
                    throw;
                }
            }
        }
    }
}