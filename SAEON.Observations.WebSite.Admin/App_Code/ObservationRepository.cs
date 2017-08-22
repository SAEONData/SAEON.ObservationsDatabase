﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ext.Net;
using SubSonic;
using SAEON.Observations.Data;
using System.Web.Security;

/// <summary>
/// Summary description for ObservationRepository
/// </summary>
public class ObservationRepository : BaseRepository
{
    public ObservationRepository()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public static List<object> GetPagedList(StoreRefreshDataEventArgs e, string paramPrefix)
    {
        SqlQuery q = new Select().From(VObservation.Schema);

        GetPagedQuery(ref q, e, paramPrefix);

        VObservationCollection col = q.ExecuteAsCollection<VObservationCollection>();

        return col.ToList<object>();
    }

    public static List<VObservationsList> GetPagedListByBatch(StoreRefreshDataEventArgs e, string paramPrefix, Guid BatchID)
    {
        SqlQuery q = new Select().From(VObservationsList.Schema)
            .Where(VObservationsList.Columns.ImportBatchID).IsEqualTo(BatchID)
            .OrderDesc(VObservationsList.Columns.ValueDate)
            .OrderAsc(VObservationsList.Columns.SensorName)
            .OrderAsc(VObservationsList.Columns.OfferingName);
        GetPagedQuery(ref q, e, paramPrefix);
        VObservationsListCollection col = q.ExecuteAsCollection<VObservationsListCollection>();
        return q.ExecuteAsCollection<VObservationsListCollection>().ToList<VObservationsList>();
    }
}