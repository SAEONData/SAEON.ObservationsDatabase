﻿using Ext.Net;
using SAEON.Logs;
using SAEON.Observations.Data;
using SubSonic;
using System;
using System.Data;
using System.Linq;

public partial class Admin_Sensors : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!X.IsAjaxRequest)
        {
            InstrumentStore.DataSource = new InstrumentCollection().OrderByAsc(Instrument.Columns.Name).Load();
            InstrumentStore.DataBind();

            //var store = cbStation.GetStore();
            //SubSonic.SqlQuery q = new Select(Station.Columns.Id, Station.Columns.Name)
            //                        .From(Station.Schema)
            //                        .Where(Station.Columns.Id).IsNotNull()
            //                        .OrderAsc(DataSchema.Columns.Name);
            //DataSet ds = q.ExecuteDataSet();
            //store.DataSource = ds.Tables[0];
            //store.DataBind();

            var store = cbPhenomenon.GetStore();
            SqlQuery q = new Select(Phenomenon.Columns.Id, Phenomenon.Columns.Name)
                       .From(Phenomenon.Schema)
                       .Where(Phenomenon.Columns.Id).IsNotNull()
                       .OrderAsc(Phenomenon.Columns.Name);
            DataSet ds = q.ExecuteDataSet();
            store.DataSource = ds.Tables[0];
            store.DataBind();

            store = cbDataSource.GetStore();
            q = new Select(DataSource.Columns.Id, DataSource.Columns.Name, DataSource.Columns.DataSchemaID)
                    .From(DataSource.Schema)
                    .Where(DataSource.Columns.Id).IsNotNull()
                    .OrderAsc(DataSource.Columns.Name);
            ds = q.ExecuteDataSet();
            store.DataSource = ds.Tables[0];
            store.DataBind();


            cbDataSchema.GetStore().DataSource = new DataSchemaCollection().OrderByAsc(DataSchema.Columns.Name).Load();
            cbDataSchema.GetStore().DataBind();
        }
    }

    #region Sensors
    protected void SensorsGridStore_RefreshData(object sender, StoreRefreshDataEventArgs e)
    {
        this.SensorsGrid.GetStore().DataSource = SensorRepository.GetPagedList(e, e.Parameters[this.GridFilters1.ParamPrefix]);
    }

    protected void ValidateField(object sender, RemoteValidationEventArgs e)
    {
        SensorCollection col = new SensorCollection();
        string checkColumn = String.Empty;
        string errorMessage = String.Empty;
        e.Success = true;

        if (e.ID == "tfCode" || e.ID == "tfName")
        {
            if (e.ID == "tfCode")
            {
                checkColumn = Sensor.Columns.Code;
                errorMessage = "The specified Sensor Code already exists";
                col = new SensorCollection().Where(Sensor.Columns.Code, e.Value.ToString().Trim()).Where(Offering.Columns.Id, SubSonic.Comparison.NotEquals, tfID.Text.Trim()).Load();
            }
            else if (e.ID == "tfName")
            {
                checkColumn = Sensor.Columns.Name;
                errorMessage = "The specified Sensor Name already exists";

            }

            if (tfID.IsEmpty)
                col = new SensorCollection().Where(checkColumn, e.Value.ToString().Trim()).Load();
            else
                col = new SensorCollection().Where(checkColumn, e.Value.ToString().Trim()).Where(Offering.Columns.Id, SubSonic.Comparison.NotEquals, tfID.Text.Trim()).Load();

            if (col.Count > 0)
            {
                e.Success = false;
                e.ErrorMessage = errorMessage;
            }
        }
    }

    protected void Save(object sender, DirectEventArgs e)
    {
        using (Logging.MethodCall(GetType()))
        {
            try
            {

                Sensor sens = new Sensor();

                if (String.IsNullOrEmpty(tfID.Text))
                    sens.Id = Guid.NewGuid();
                else
                    sens = new Sensor(tfID.Text.Trim());

                sens.Code = tfCode.Text.Trim();
                sens.Name = tfName.Text.Trim();
                sens.Description = tfDescription.Text.Trim();
                sens.UserId = AuthHelper.GetLoggedInUserId;
                sens.Url = tfUrl.Text.Trim();
                //sens.StationID = Guid.Parse(cbStation.SelectedItem.Value);
                sens.PhenomenonID = Guid.Parse(cbPhenomenon.SelectedItem.Value);
                sens.DataSourceID = Guid.Parse(cbDataSource.SelectedItem.Value);

                if (cbDataSchema.SelectedItem.Value != null)
                {
                    //test if dataschema is valid (linked to test in datasource files)
                    bool isValid = true;
                    string dataSourceName = "";

                    if (sens.DataSource.DataSchemaID != null)
                    {
                        isValid = false;
                        dataSourceName = sens.DataSource.Name;
                    }

                    //
                    if (isValid)
                    {
                        sens.DataSchemaID = Guid.Parse(cbDataSchema.SelectedItem.Value);
                    }
                    else
                    {
                        X.Msg.Show(new MessageBoxConfig
                        {
                            Title = "Invalid Data Source",
                            //Message = "The selected data schema is already linked to a sensor that is linked to this data source.",
                            Message = "This sensor cant have a data schema because its data source (" + dataSourceName + ") is already linked to a data schema",
                            Buttons = MessageBox.Button.OK,
                            Icon = MessageBox.Icon.ERROR
                        });

                        return;
                    }
                }
                else
                    sens.DataSchemaID = null;

                sens.Save();
                Auditing.Log(GetType(), new ParameterList {
                { "ID", sens.Id }, { "Code", sens.Code }, { "Name", sens.Name } });


                SensorsGrid.DataBind();

                DetailWindow.Hide();
            }
            catch (Exception ex)
            {
                Logging.Exception(ex);
                MessageBoxes.Error(ex, "Error", "Unable to save sensor");
            }
        }
    }

    protected void SensorsGridStore_Submit(object sender, StoreSubmitDataEventArgs e)
    {
        string type = FormatType.Text;
        string visCols = VisCols.Value.ToString();
        string gridData = GridData.Text;
        string sortCol = SortInfo.Text.Substring(0, SortInfo.Text.IndexOf("|"));
        string sortDir = SortInfo.Text.Substring(SortInfo.Text.IndexOf("|") + 1);

        //string js = BaseRepository.BuildExportQ("VSensor", gridData, visCols, sortCol, sortDir);
        //BaseRepository.doExport(type, js);
        BaseRepository.Export("vSensor", gridData, visCols, sortCol, sortDir, type, "Sensors");
    }
    #endregion

    #region Instruments
    protected void InstrumentLinksGridStore_RefreshData(object sender, StoreRefreshDataEventArgs e)
    {
        using (Logging.MethodCall(GetType()))
        {
            if (e.Parameters["SensorID"] != null && e.Parameters["SensorID"].ToString() != "-1")
            {
                Guid Id = Guid.Parse(e.Parameters["SensorID"].ToString());
                try
                {
                    VInstrumentSensorCollection col = new VInstrumentSensorCollection()
                        .Where(VInstrumentSensor.Columns.SensorID, Id)
                        .OrderByAsc(VInstrumentSensor.Columns.StartDate)
                        .OrderByAsc(VInstrumentSensor.Columns.EndDate)
                        .OrderByAsc(VInstrumentSensor.Columns.InstrumentName)
                        .Load();
                    InstrumentLinksGrid.GetStore().DataSource = col;
                    InstrumentLinksGrid.GetStore().DataBind();
                }
                catch (Exception ex)
                {
                    Logging.Exception(ex);
                    MessageBoxes.Error(ex, "Error", "Unable to refresh instruments grid");
                }
            }
        }
    }

    private bool InstrumentLinkOk()
    {
        RowSelectionModel masterRow = SensorsGrid.SelectionModel.Primary as RowSelectionModel;
        var masterID = new Guid(masterRow.SelectedRecordID);
        InstrumentSensorCollection col = new InstrumentSensorCollection()
            .Where(InstrumentSensor.Columns.SensorID, masterID)
            .Where(InstrumentSensor.Columns.InstrumentID, cbInstrument.SelectedItem.Value);
        if (!String.IsNullOrEmpty(dfInstrumentStartDate.Text) && (dfInstrumentStartDate.SelectedDate.Year >= 1900))
            col.Where(InstrumentSensor.Columns.StartDate, dfInstrumentStartDate.SelectedDate);
        if (!String.IsNullOrEmpty(dfInstrumentEndDate.Text) && (dfInstrumentEndDate.SelectedDate.Year >= 1900))
            col.Where(InstrumentSensor.Columns.EndDate, dfInstrumentEndDate.SelectedDate);
        col.Load();
        var id = Utilities.MakeGuid(InstrumentLinkID.Value);
        return !col.Any(i => i.Id != id);
    }

    protected void InstrumentLinkSave(object sender, DirectEventArgs e)
    {
        using (Logging.MethodCall(GetType()))
        {
            try
            {
                if (!InstrumentLinkOk())
                {
                    MessageBoxes.Error("Error", "Instrument is already linked");
                    return;
                }
                RowSelectionModel masterRow = SensorsGrid.SelectionModel.Primary as RowSelectionModel;
                var masterID = new Guid(masterRow.SelectedRecordID);
                InstrumentSensor instrumentSensor = new InstrumentSensor(Utilities.MakeGuid(InstrumentLinkID.Value));
                instrumentSensor.SensorID = masterID;
                instrumentSensor.InstrumentID = new Guid(cbInstrument.SelectedItem.Value.Trim());
                if (!String.IsNullOrEmpty(dfInstrumentStartDate.Text) && (dfInstrumentStartDate.SelectedDate.Year >= 1900))
                    instrumentSensor.StartDate = dfInstrumentStartDate.SelectedDate;
                else
                    instrumentSensor.StartDate = null;
                if (!String.IsNullOrEmpty(dfInstrumentEndDate.Text) && (dfInstrumentEndDate.SelectedDate.Year >= 1900))
                    instrumentSensor.EndDate = dfInstrumentEndDate.SelectedDate;
                else
                    instrumentSensor.EndDate = null;
                instrumentSensor.UserId = AuthHelper.GetLoggedInUserId;
                instrumentSensor.Save();
                Auditing.Log(GetType(), new ParameterList {
                { "SensorID", instrumentSensor.SensorID },
                { "SensorCode", instrumentSensor.Sensor.Code },
                { "InstrumentID", instrumentSensor.InstrumentID},
                { "InstrumentCode", instrumentSensor.Instrument.Code},
                { "StartDate", instrumentSensor?.StartDate },
                { "EndDate", instrumentSensor?.EndDate}
            });
                InstrumentLinksGrid.DataBind();
                InstrumentLinkWindow.Hide();
            }
            catch (Exception ex)
            {
                Logging.Exception(ex);
                MessageBoxes.Error(ex, "Error", "Unable to link sensor");
            }
        }
    }

    [DirectMethod]
    public void ConfirmDeleteInstrumentLink(Guid aID)
    {
        MessageBoxes.Confirm(
            "Confirm Delete",
            String.Format("DirectCall.DeleteInstrumentLink(\"{0}\",{{ eventMask: {{ showMask: true}}}});", aID.ToString()),
            "Are you sure you want to delete this instrument link?");
    }

    [DirectMethod]
    public void DeleteInstrumentLink(Guid aID)
    {
        using (Logging.MethodCall(GetType(), new ParameterList { { "ID", aID } }))
        {
            try
            {
                InstrumentSensor.Delete(aID);
                Auditing.Log(GetType(), new ParameterList { { "ID", aID } });
                InstrumentLinksGrid.DataBind();
            }
            catch (Exception ex)
            {
                Logging.Exception(ex);
                MessageBoxes.Error(ex, "Error", "Unable to delete instrument link");
            }
        }
    }

    [DirectMethod]
    public void AddInstrumentClick(object sender, DirectEventArgs e)
    {
        //X.Redirect(X.ResourceManager.ResolveUrl("Admin/Sites"));
    }
    #endregion
}