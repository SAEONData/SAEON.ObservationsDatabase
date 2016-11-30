﻿<%@ Page Title="Data Sources" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="DataSources.aspx.cs" Inherits="Admin_DataSources" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript" src="../JS/DataSources.js"></script>
    <script type="text/javascript" src="../JS/generic.js"></script>
    <script type="text/javascript">
        var submitValue = function (format) {
            GridData.setValue(Ext.encode(ContentPlaceHolder1_GridFilters1.buildQuery(ContentPlaceHolder1_GridFilters1.getFilterData())));
            //VisCols.setValue(Ext.encode(DataSourcesGrid.getRowsValues({ visibleOnly: true, excludeId: true })[0]));
            var viscolsNew = makenewJsonForExport(DataSourcesGrid.getColumnModel().getColumnsBy(function (column, colIndex) { return !this.isHidden(colIndex); }))
            VisCols.setValue(viscolsNew);
            FormatType.setValue(format);
            SortInfo.setValue(ContentPlaceHolder1_GridFilters1.store.sortInfo.field + "|" + ContentPlaceHolder1_GridFilters1.store.sortInfo.direction);
            DataSourcesGrid.submitData(false);
        };
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <ext:Store ID="DataSchemaStore" runat="server">
        <Reader>
            <ext:JsonReader IDProperty="Id">
                <Fields>
                    <ext:RecordField Name="Id" Type="String" />
                    <ext:RecordField Name="Name" Type="String" />
                </Fields>
            </ext:JsonReader>
        </Reader>
    </ext:Store>
    <ext:Store ID="InstrumentStore" runat="server">
        <Reader>
            <ext:JsonReader IDProperty="Id">
                <Fields>
                    <ext:RecordField Name="Id" Type="Auto" />
                    <ext:RecordField Name="Name" Type="String" />
                </Fields>
            </ext:JsonReader>
        </Reader>
    </ext:Store>
    <ext:Store ID="TransformationTypeStore" runat="server">
        <Reader>
            <ext:JsonReader IDProperty="Id">
                <Fields>
                    <ext:RecordField Name="Id" Type="String" />
                    <ext:RecordField Name="Name" Type="String" />
                </Fields>
            </ext:JsonReader>
        </Reader>
    </ext:Store>
    <ext:Store ID="PhenomenonStore" runat="server">
        <Reader>
            <ext:JsonReader IDProperty="Id">
                <Fields>
                    <ext:RecordField Name="Id" Type="String" />
                    <ext:RecordField Name="Name" Type="String" />
                </Fields>
            </ext:JsonReader>
        </Reader>
    </ext:Store>
    <ext:Hidden ID="GridData" runat="server" ClientIDMode="Static" />
    <ext:Hidden ID="VisCols" runat="server" ClientIDMode="Static" />
    <ext:Hidden ID="FormatType" runat="server" ClientIDMode="Static" />
    <ext:Hidden ID="SortInfo" runat="server" ClientIDMode="Static" />
    <ext:Viewport ID="ViewPort1" runat="server">
        <Items>
            <ext:BorderLayout ID="BorderLayout1" runat="server">
                <Center MarginsSummary="5 0 0 5">
                    <ext:Panel ID="Panel1" runat="server" Title="Data Sources" Layout="FitLayout" Hidden="false">
                        <TopBar>
                            <ext:Toolbar ID="Toolbar1" runat="server">
                                <Items>
                                    <ext:Button ID="Button1" runat="server" Icon="Add" Text="Add Data Source">
                                        <ToolTips>
                                            <ext:ToolTip ID="ToolTip1" runat="server" Html="Add" />
                                        </ToolTips>
                                        <Listeners>
                                            <Click Fn="New" />
                                        </Listeners>
                                    </ext:Button>
                                    <ext:ToolbarFill ID="ToolbarFill1" runat="server" />
                                    <ext:Button ID="Button2" runat="server" Text="To Excel" Icon="PageExcel">
                                        <Listeners>
                                            <Click Handler="submitValue('exc');" />
                                        </Listeners>
                                    </ext:Button>
                                    <ext:Button ID="Button3" runat="server" Text="To CSV" Icon="PageAttach">
                                        <Listeners>
                                            <Click Handler="submitValue('csv');" />
                                        </Listeners>
                                    </ext:Button>
                                </Items>
                            </ext:Toolbar>
                        </TopBar>
                        <Items>
                            <ext:GridPanel ID="DataSourcesGrid" runat="server" Border="false" ClientIDMode="Static">
                                <Store>
                                    <ext:Store ID="DataSourcesGridStore" runat="server" RemoteSort="true" OnRefreshData="DataSourcesGridStore_RefreshData"
                                        OnSubmitData="DataSourcesGridStore_Submit">
                                        <Proxy>
                                            <ext:PageProxy />
                                        </Proxy>
                                        <Reader>
                                            <ext:JsonReader IDProperty="Id">
                                                <Fields>
                                                    <ext:RecordField Name="Id" Type="Auto" />
                                                    <ext:RecordField Name="Code" Type="String" />
                                                    <ext:RecordField Name="Name" Type="String" />
                                                    <ext:RecordField Name="Description" Type="String" />
                                                    <ext:RecordField Name="Url" Type="String" />
                                                    <ext:RecordField Name="DefaultNullValue" Type="Float" />
                                                    <ext:RecordField Name="UpdateFreq" Type="Float" />
                                                    <ext:RecordField Name="StartDate" Type="Date" />
                                                    <ext:RecordField Name="EndDate" Type="Date" />
                                                    <ext:RecordField Name="LastUpdate" Type="Date" />
                                                    <ext:RecordField Name="DataSchemaID" Type="Auto" />
                                                    <ext:RecordField Name="DataSchemaName" Type="String" />
                                                </Fields>
                                            </ext:JsonReader>
                                        </Reader>
                                        <BaseParams>
                                            <ext:Parameter Name="start" Value="0" Mode="Raw" />
                                            <ext:Parameter Name="limit" Value="25" Mode="Raw" />
                                            <ext:Parameter Name="sort" Value="" />
                                            <ext:Parameter Name="dir" Value="" />
                                        </BaseParams>
                                        <SortInfo Field="Name" Direction="ASC" />
                                        <DirectEventConfig IsUpload="true" />
                                    </ext:Store>
                                </Store>
                                <ColumnModel ID="ColumnModel1" runat="server">
                                    <Columns>
                                        <ext:Column Header="Code" DataIndex="Code" Width="200" />
                                        <ext:Column Header="Name" DataIndex="Name" Width="300" />
                                        <ext:Column Header="Url" DataIndex="Url" Width="150" />
                                        <ext:Column Header="Description" DataIndex="Description" Width="300" />
                                        <ext:Column Header="Data Schema" DataIndex="DataSchemaName" Width="200" />
                                        <ext:CommandColumn Width="75">
                                            <Commands>
                                                <ext:GridCommand Icon="NoteEdit" CommandName="Edit" Text="Edit" ToolTip-Text="Edit" />
                                            </Commands>
                                        </ext:CommandColumn>
                                    </Columns>
                                </ColumnModel>
                                <SelectionModel>
                                    <ext:RowSelectionModel ID="RowSelectionModel1" runat="server" SingleSelect="true">
                                        <Listeners>
                                            <RowSelect Fn="DataSourceRowSelect" Buffer="250" />
                                        </Listeners>
                                    </ext:RowSelectionModel>
                                </SelectionModel>
                                <LoadMask ShowMask="true" />
                                <Plugins>
                                    <ext:GridFilters runat="server" ID="GridFilters1">
                                        <Filters>
                                            <ext:StringFilter DataIndex="ID" />
                                            <ext:StringFilter DataIndex="Code" />
                                            <ext:StringFilter DataIndex="Name" />
                                            <ext:StringFilter DataIndex="Url" />
                                            <ext:StringFilter DataIndex="Description" />
                                            <ext:DateFilter DataIndex="StartDate" />
                                            <ext:DateFilter DataIndex="EndDate" />
                                            <ext:DateFilter DataIndex="LastUpdate" />
                                            <ext:StringFilter DataIndex="DataSchemaName" />
                                        </Filters>
                                    </ext:GridFilters>
                                </Plugins>
                                <BottomBar>
                                    <ext:PagingToolbar ID="PagingToolbar1" runat="server" PageSize="25" EmptyMsg="No data found" />
                                </BottomBar>
                                <Listeners>
                                    <Command Fn="onCommand" />
                                </Listeners>
                            </ext:GridPanel>
                        </Items>
                    </ext:Panel>
                </Center>
                <South Collapsible="true" Split="true" MinHeight="250">
                    <ext:TabPanel ID="pnlSouth" runat="server" Height="250" TabPosition="Top" Border="false" ClientIDMode="Static">
                        <Items>
                            <ext:Panel ID="pnlInstruments" runat="server" Title="Instruments" Layout="FitLayout"
                                Height="200" ClientIDMode="Static">
                                <TopBar>
                                    <ext:Toolbar ID="Toolbar4" runat="server">
                                        <Items>
                                            <ext:Button ID="btnInstrumentLinkAdd" runat="server" Icon="LinkAdd" Text="Link Instrument" ClientIDMode="Static">
                                                <ToolTips>
                                                    <ext:ToolTip ID="ToolTip4" runat="server" Html="Link" />
                                                </ToolTips>
                                                <Listeners>
                                                    <Click Handler="if(Ext.getCmp('#{DataSourcesGrid}') && #{DataSourcesGrid}.getSelectionModel().hasSelection()){#{InstrumentLinkWindow}.show()}else{Ext.Msg.alert('Invalid Selection','Select a DataSource.')}" />
                                                </Listeners>
                                            </ext:Button>
                                            <%-- 
                                            <ext:Button ID="btnAddInstrument" runat="server" Icon="Add" Text="Add Instrument">
                                                <ToolTips>
                                                    <ext:ToolTip ID="ToolTip5" runat="server" Html="Add" />
                                                </ToolTips>
                                                <DirectEvents>
                                                    <Click OnEvent="AddInstrumentClick" />
                                                </DirectEvents>
                                            </ext:Button>
                                            --%>
                                        </Items>
                                    </ext:Toolbar>
                                </TopBar>
                                <Items>
                                    <ext:GridPanel ID="InstrumentLinksGrid" runat="server" Border="false" ClientIDMode="Static">
                                        <Store>
                                            <ext:Store ID="InstrumentLinksGridStore" runat="server" OnRefreshData="InstrumentLinksGridStore_RefreshData">
                                                <Proxy>
                                                    <ext:PageProxy />
                                                </Proxy>
                                                <Reader>
                                                    <ext:JsonReader IDProperty="Id">
                                                        <Fields>
                                                            <ext:RecordField Name="Id" Type="Auto" />
                                                            <ext:RecordField Name="InstrumentID" Type="Auto" />
                                                            <ext:RecordField Name="InstrumentCode" Type="Auto" />
                                                            <ext:RecordField Name="InstrumentName" Type="Auto" />
                                                            <ext:RecordField Name="StartDate" Type="Date" />
                                                            <ext:RecordField Name="EndDate" Type="Date" />
                                                        </Fields>
                                                    </ext:JsonReader>
                                                </Reader>
                                                <BaseParams>
                                                    <ext:Parameter Name="DataSourceID" Value="Ext.getCmp('#{DataSourcesGrid}') && #{DataSourcesGrid}.getSelectionModel().hasSelection() ? #{DataSourcesGrid}.getSelectionModel().getSelected().id : -1"
                                                        Mode="Raw" />
                                                </BaseParams>
                                            </ext:Store>
                                        </Store>
                                        <ColumnModel ID="ColumnModel3" runat="server">
                                            <Columns>
                                                <ext:Column Header="Code" DataIndex="InstrumentCode" Width="200" />
                                                <ext:Column Header="Name" DataIndex="InstrumentName" Width="200" />
                                                <ext:DateColumn Header="Start Date" DataIndex="StartDate" Width="100" Format="dd MMM yyyy" />
                                                <ext:DateColumn Header="End Date" DataIndex="EndDate" Width="100" Format="dd MMM yyyy" />
                                                <ext:CommandColumn Width="150">
                                                    <Commands>
                                                        <ext:GridCommand Icon="NoteEdit" CommandName="Edit" Text="Edit" />
                                                        <ext:GridCommand Icon="LinkDelete" CommandName="Delete" Text="Unlink" />
                                                    </Commands>
                                                </ext:CommandColumn>
                                            </Columns>
                                        </ColumnModel>
                                        <SelectionModel>
                                            <ext:RowSelectionModel ID="RowSelectionModel4" runat="server" SingleSelect="true">
                                            </ext:RowSelectionModel>
                                        </SelectionModel>
                                        <LoadMask ShowMask="true" />
                                        <Listeners>
                                            <Command Fn="OnInstrumentLinkCommand" />
                                        </Listeners>
                                    </ext:GridPanel>
                                </Items>
                            </ext:Panel>
                            <ext:Panel ID="pnlTransformations" runat="server" Title="Transformations" Layout="FitLayout"
                                Height="200" ClientIDMode="Static">
                                <TopBar>
                                    <ext:Toolbar ID="Toolbar2" runat="server">
                                        <Items>
                                            <ext:Button ID="btnAddTransformation" runat="server" Icon="Add" Text="Add Transformation">
                                                <ToolTips>
                                                    <ext:ToolTip ID="ToolTip2" runat="server" Html="Add" />
                                                </ToolTips>
                                                <Listeners>
                                                    <Click Fn="NewTransform" />
                                                </Listeners>
                                            </ext:Button>
                                        </Items>
                                    </ext:Toolbar>
                                </TopBar>
                                <Items>
                                    <ext:GridPanel ID="TransformationsGrid" runat="server" Border="false" ClientIDMode="Static">
                                        <Store>
                                            <ext:Store ID="TransformationsGridStore" runat="server" OnRefreshData="TransformationsGridStore_RefreshData">
                                                <Proxy>
                                                    <ext:PageProxy />
                                                </Proxy>
                                                <Reader>
                                                    <ext:JsonReader IDProperty="Id">
                                                        <Fields>
                                                            <ext:RecordField Name="Id" Type="Auto" />
                                                            <ext:RecordField Name="TransformationTypeID" Type="Auto" />
                                                            <ext:RecordField Name="PhenomenonID" Type="Auto" />
                                                            <ext:RecordField Name="PhenomenonOfferingID" Type="Auto" />
                                                            <ext:RecordField Name="StartDate" Type="Date" />
                                                            <ext:RecordField Name="EndDate" Type="Date" />
                                                            <ext:RecordField Name="DataSourceID" Type="Auto" />
                                                            <ext:RecordField Name="Definition" Type="String" />
                                                            <ext:RecordField Name="PhenomenonName" Type="String" />
                                                            <ext:RecordField Name="TransformationName" Type="String" />
                                                            <ext:RecordField Name="PhenomenonOfferingId" Type="Auto" />
                                                            <ext:RecordField Name="UnitOfMeasureId" Type="Auto" />
                                                            <ext:RecordField Name="OfferingName" Type="String" />
                                                            <ext:RecordField Name="UnitofMeasure" Type="String" />
                                                            <ext:RecordField Name="NewPhenomenonOfferingID" Type="Auto" />
                                                            <ext:RecordField Name="NewPhenomenonUOMID" Type="Auto" />
                                                            <ext:RecordField Name="Rank" Type="Int" UseNull="true" />
                                                        </Fields>
                                                    </ext:JsonReader>
                                                </Reader>
                                                <BaseParams>
                                                    <ext:Parameter Name="DataSourceID" Value="Ext.getCmp('#{DataSourcesGrid}') && #{DataSourcesGrid}.getSelectionModel().hasSelection() ? #{DataSourcesGrid}.getSelectionModel().getSelected().id : -1"
                                                        Mode="Raw" />
                                                </BaseParams>
                                            </ext:Store>
                                        </Store>
                                        <ColumnModel ID="ColumnModel2" runat="server">
                                            <Columns>
                                                <ext:Column Header="Phenomenon" DataIndex="PhenomenonName" Width="150" />
                                                <ext:Column Header="Transformation" DataIndex="TransformationName" Width="150" />
                                                <ext:Column Header="Offering" DataIndex="OfferingName" Width="150" />
                                                <ext:Column Header="Unit of Measure" DataIndex="UnitofMeasure" Width="150" />
                                                <ext:DateColumn Header="Start Date" DataIndex="StartDate" Width="150" Format="dd MMM yyyy" />
                                                <ext:DateColumn Header="End Date" DataIndex="EndDate" Width="150" Format="dd MMM yyyy" />
                                                <ext:CommandColumn Width="75">
                                                    <Commands>
                                                        <ext:GridCommand Icon="NoteEdit" CommandName="Edit" Text="Edit" ToolTip-Text="Edit" />
                                                        <ext:GridCommand Icon="NoteDelete" CommandName="Delete" Text="" ToolTip-Text="Delete" />
                                                    </Commands>
                                                </ext:CommandColumn>
                                            </Columns>
                                        </ColumnModel>
                                        <SelectionModel>
                                            <ext:RowSelectionModel ID="RowSelectionModel2" runat="server" SingleSelect="true">
                                            </ext:RowSelectionModel>
                                        </SelectionModel>
                                        <LoadMask ShowMask="true" />
                                        <Listeners>
                                            <Command Fn="onTransformCommand" />
                                        </Listeners>
                                    </ext:GridPanel>
                                </Items>
                            </ext:Panel>
                            <ext:Panel ID="pnlRoles" runat="server" Title="Roles" Layout="Fit" Width="425" ClientIDMode="Static">
                                <TopBar>
                                    <ext:Toolbar ID="Toolbar3" runat="server">
                                        <Items>
                                            <ext:Button ID="btnRoleLinksAdd" runat="server" Icon="LinkAdd" Text="Link Roles">
                                                <ToolTips>
                                                    <ext:ToolTip ID="ToolTip3" runat="server" Html="Link" />
                                                </ToolTips>
                                                <Listeners>
                                                    <Click Handler="if(Ext.getCmp('#{DataSourcesGrid}') && #{DataSourcesGrid}.getSelectionModel().hasSelection()){#{AvailableRolesGridStore}.reload();#{AvailableRolesWindow}.show()}else{Ext.Msg.alert('Invalid Selection','Select a Data Source.')}" />
                                                </Listeners>
                                            </ext:Button>
                                        </Items>
                                    </ext:Toolbar>
                                </TopBar>
                                <Items>
                                    <ext:GridPanel ID="RolesGrid" runat="server" Border="false" Layout="FitLayout"
                                        ClientIDMode="Static">
                                        <Store>
                                            <ext:Store ID="RolesGridStore" runat="server" OnRefreshData="RolesGridStore_RefreshData">
                                                <Proxy>
                                                    <ext:PageProxy />
                                                </Proxy>
                                                <Reader>
                                                    <ext:JsonReader IDProperty="Id">
                                                        <Fields>
                                                            <ext:RecordField Name="Id" Type="Auto" />
                                                            <ext:RecordField Name="ActualRoleName" Type="String" />
                                                            <ext:RecordField Name="RoleDescription" Type="String" />
                                                            <ext:RecordField Name="DateStart" Type="Date" />
                                                            <ext:RecordField Name="DateEnd" Type="Date" />
                                                            <ext:RecordField Name="IsRoleReadOnly" Type="Boolean" />
                                                        </Fields>
                                                    </ext:JsonReader>
                                                </Reader>
                                                <BaseParams>
                                                    <ext:Parameter Name="DataSourceID" Value="Ext.getCmp('#{DataSourcesGrid}') && #{DataSourcesGrid}.getSelectionModel().hasSelection() ? #{DataSourcesGrid}.getSelectionModel().getSelected().id : -1"
                                                        Mode="Raw" />
                                                </BaseParams>
                                            </ext:Store>
                                        </Store>
                                        <ColumnModel ID="ColumnModel5" runat="server">
                                            <Columns>
                                                <ext:Column Header="Name" DataIndex="ActualRoleName" Width="100" />
                                                <ext:Column Header="Description" DataIndex="RoleDescription" Width="150" />
                                                <ext:DateColumn Header="Date Start" DataIndex="DateStart" Width="75" Format="dd MMM yyyy" />
                                                <ext:DateColumn Header="Date End" DataIndex="DateEnd" Width="75" Format="dd MMM yyyy" />
                                                <ext:CheckColumn Header="Read Only" DataIndex="IsRoleReadOnly" Width="100" Tooltip="Read Only" />
                                                <ext:CommandColumn Width="150">
                                                    <Commands>
                                                        <ext:GridCommand Icon="NoteEdit" CommandName="Edit" Text="Edit" ToolTip-Text="Edit">
                                                        </ext:GridCommand>
                                                        <ext:GridCommand Icon="LinkDelete" CommandName="Delete" Text="Unlink" ToolTip-Text="Unlink">
                                                        </ext:GridCommand>
                                                    </Commands>
                                                </ext:CommandColumn>
                                            </Columns>
                                        </ColumnModel>
                                        <SelectionModel>
                                            <ext:RowSelectionModel ID="RowSelectionModel3" runat="server" SingleSelect="true">
                                            </ext:RowSelectionModel>
                                        </SelectionModel>
                                        <LoadMask ShowMask="true" />
                                        <Listeners>
                                            <Command Fn="onRoleCommand" />
                                        </Listeners>
                                    </ext:GridPanel>
                                </Items>
                            </ext:Panel>
                        </Items>
                    </ext:TabPanel>
                </South>
                <East Collapsible="true" Split="true" MarginsSummary="5 5 0 0">
                </East>
                <South Collapsible="true" Split="true" MarginsSummary="0 5 5 5">
                </South>
            </ext:BorderLayout>
        </Items>
    </ext:Viewport>
    <ext:Window ID="DetailWindow" runat="server" Width="700" Height="400" Closable="true"
        Hidden="true" Collapsible="false" Title="Data Source Detail" Maximizable="false"
        Layout="Fit" ClientIDMode="Static">
        <Content>
            <ext:FormPanel ID="DetailsFormPanel" runat="server" Title="" MonitorPoll="500" MonitorValid="true"
                MonitorResize="true" Padding="10" ButtonAlign="Right" Layout="RowLayout" ClientIDMode="Static">
                <LoadMask ShowMask="true" />
                <Items>
                    <ext:Hidden ID="tfID" DataIndex="Id" runat="server" ClientIDMode="Static">
                    </ext:Hidden>
                    <ext:Container ID="Container1" runat="server" Layout="Column" Height="100">
                        <Items>
                            <ext:Container ID="Container2" runat="server" LabelAlign="Top" Layout="Form" ColumnWidth=".5">
                                <Items>
                                    <ext:TextField ID="tfCode" DataIndex="Code" IsRemoteValidation="true" MaxLength="50"
                                        runat="server" FieldLabel="Code" AnchorHorizontal="93%" AllowBlank="false" BlankText="Code is a required"
                                        MsgTarget="Side" ClientIDMode="Static">
                                        <RemoteValidation OnValidation="ValidateField" />
                                    </ext:TextField>
                                    <ext:ComboBox ID="cbDataSchema" runat="server" StoreID="DataSchemaStore" Editable="true"
                                        DisplayField="Name" ValueField="Id" TypeAhead="true" Mode="Local" ForceSelection="true"
                                        TriggerAction="All" AllowBlank="true" DataIndex="DataSchemaID" EmptyText="Select Data Schema"
                                        SelectOnFocus="true" FieldLabel="Data Schema" AnchorHorizontal="93%" BlankText="Data Schema is required"
                                        MsgTarget="Side">
                                        <Triggers>
                                            <ext:FieldTrigger Icon="Clear" />
                                        </Triggers>
                                        <Listeners>
                                            <TriggerClick Handler="this.clearValue();" />
                                        </Listeners>
                                    </ext:ComboBox>
                                </Items>
                            </ext:Container>
                            <ext:Container ID="Container3" runat="server" LabelAlign="Top" Layout="Form" ColumnWidth=".5">
                                <Items>
                                    <ext:TextField ID="tfName" DataIndex="Name" MaxLength="150" IsRemoteValidation="true"
                                        AllowBlank="false" BlankText="Name is a required" MsgTarget="Side" runat="server"
                                        FieldLabel="Name" AnchorHorizontal="93%" ClientIDMode="Static">
                                        <RemoteValidation OnValidation="ValidateField" />
                                    </ext:TextField>
                                    <ext:TextField ID="tfUrl" DataIndex="Url" MaxLength="150" Vtype="url" runat="server"
                                        MsgTarget="Side" FieldLabel="Url" ClientIDMode="Static" BlankText="URL is required."
                                        AnchorHorizontal="95%">
                                    </ext:TextField>
                                </Items>
                            </ext:Container>
                        </Items>
                    </ext:Container>
                    <ext:Container ID="Container5" runat="server" Layout="Column" Height="50">
                        <Items>
                            <ext:Container ID="Container6" runat="server" LabelAlign="Top" Layout="Form" ColumnWidth=".5">
                                <Items>
                                    <ext:ComboBox ID="cbUpdateFrequency" runat="server" Editable="false" MsgTarget="Side"
                                        ForceSelection="true" TriggerAction="All" AllowBlank="false" DataIndex="UpdateFreq"
                                        SelectOnFocus="true" BlankText="Frequency is required." EmptyText="Select Update Frequency"
                                        FieldLabel="Update Frequency" AnchorHorizontal="93%" ClientIDMode="Static">
                                        <Listeners>
                                            <Select Fn="FrequencyUpdate" />
                                        </Listeners>
                                    </ext:ComboBox>
                                </Items>
                            </ext:Container>
                            <ext:Container ID="Container7" runat="server" LabelAlign="Top" Layout="Form" ColumnWidth=".5">
                                <Items>
                                    <ext:DateField ID="StartDate" DataIndex="StartDate" runat="server" FieldLabel="Start Date"
                                        BlankText="Start Date is required." AnchorHorizontal="93%" Format="dd MMM yyyy"
                                        ClientIDMode="Static">
                                    </ext:DateField>
                                </Items>
                            </ext:Container>
                            <ext:Container ID="Container13" runat="server" LabelAlign="Top" Layout="Form" ColumnWidth=".5">
                                <Items>
                                    <ext:DateField ID="EndDate" DataIndex="EndDate" runat="server" FieldLabel="End Date"
                                        BlankText="End Date is required." AnchorHorizontal="93%" Format="dd MMM yyyy"
                                        ClientIDMode="Static">
                                    </ext:DateField>
                                </Items>
                            </ext:Container>
                        </Items>
                    </ext:Container>
                    <ext:Container ID="Container4" runat="server" Layout="Form"
                        LabelAlign="Top">
                        <Defaults>
                            <ext:Parameter Name="AllowBlank" Value="false" Mode="Raw" />
                            <ext:Parameter Name="blankText" Value="Description is required" Mode="Value" />
                            <ext:Parameter Name="MsgTarget" Value="side" />
                        </Defaults>
                        <Items>
                            <ext:TextArea ID="tfDescription" DataIndex="Description" runat="server" AllowBlank="false"
                                BlankText="Description is required" MsgTarget="Side" FieldLabel="Description"
                                AnchorHorizontal="95%">
                            </ext:TextArea>
                        </Items>
                    </ext:Container>
                </Items>
                <Buttons>
                    <ext:Button ID="btnSave" runat="server" Text="Save" FormBind="true">
                        <DirectEvents>
                            <Click OnEvent="Save" Method="POST">
                                <EventMask ShowMask="true" />
                            </Click>
                        </DirectEvents>
                    </ext:Button>
                </Buttons>
                <BottomBar>
                    <ext:StatusBar ID="StatusBar1" runat="server" Height="25" />
                </BottomBar>
                <Listeners>
                    <ClientValidation Handler="this.getBottomToolbar().setStatus({text : valid ? 'Form is valid' : 'Form is invalid', iconCls: valid ? 'icon-accept1' : 'icon-exclamation'});" />
                </Listeners>
            </ext:FormPanel>
        </Content>
    </ext:Window>
    <ext:Window ID="InstrumentLinkWindow" runat="server" Width="450" Height="300" Closable="true"
        Hidden="true" Collapsible="false" Title="Link Instrument"
        Maximizable="false" Layout="Fit" ClientIDMode="Static">
        <Listeners>
            <Hide Fn="ClearInstrumentLinkForm" />
        </Listeners>
        <Content>
            <ext:FormPanel ID="InstrumentLinkFormPanel" runat="server" Title="" MonitorPoll="500" MonitorValid="true"
                MonitorResize="true" Padding="10" Width="440" Height="370" ButtonAlign="Right"
                Layout="RowLayout" ClientIDMode="Static">
                <LoadMask ShowMask="true" />
                <Items>
                    <ext:Hidden ID="InstrumentLinkID" DataIndex="Id" runat="server" ClientIDMode="Static">
                    </ext:Hidden>
                    <ext:Panel ID="Panel6" runat="server" Border="false" Header="false" Layout="FormLayout"
                        LabelAlign="Top">
                        <Defaults>
                            <ext:Parameter Name="AllowBlank" Value="false" Mode="Value" />
                            <ext:Parameter Name="blankText" Value="Instrument is a required" Mode="Value" />
                            <ext:Parameter Name="MsgTarget" Value="side" />
                        </Defaults>
                        <Items>
                            <ext:ComboBox ID="cbInstrument" runat="server" StoreID="InstrumentStore" Editable="true" DisplayField="Name"
                                ValueField="Id" TypeAhead="true" Mode="Local" ForceSelection="true" TriggerAction="All"
                                AllowBlank="false" DataIndex="InstrumentID" EmptyText="Select Instrument"
                                SelectOnFocus="true" AnchorHorizontal="95%" ClientIDMode="Static">
                                <Triggers>
                                    <ext:FieldTrigger Icon="Clear" />
                                </Triggers>
                                <Listeners>
                                    <TriggerClick Handler="this.clearValue();this.focus();" />
                                </Listeners>
                            </ext:ComboBox>
                        </Items>
                    </ext:Panel>
                    <ext:Panel ID="Panel7" runat="server" Border="false" Header="false" Layout="FormLayout" LabelAlign="Top">
                        <Defaults>
                            <ext:Parameter Name="AllowBlank" Value="true" Mode="Raw" />
                            <ext:Parameter Name="blankText" Value="Start Date is required" Mode="Value" />
                            <ext:Parameter Name="MsgTarget" Value="side" />
                        </Defaults>
                        <Items>
                            <ext:DateField ID="dfInstrumentStartDate" DataIndex="StartDate" MaxLength="100" runat="server" ClientIDMode="Static"
                                FieldLabel="Start Date" AnchorHorizontal="95%" Format="dd MMM yyyy">
                            </ext:DateField>
                        </Items>
                    </ext:Panel>
                    <ext:Panel ID="Panel8" runat="server" Border="false" Header="false" Layout="FormLayout" LabelAlign="Top">
                        <Defaults>
                            <ext:Parameter Name="AllowBlank" Value="true" Mode="Raw" />
                            <ext:Parameter Name="blankText" Value="End Date is required" Mode="Value" />
                            <ext:Parameter Name="MsgTarget" Value="side" />
                        </Defaults>
                        <Items>
                            <ext:DateField ID="dfInstrumentEndDate" DataIndex="EndDate" MaxLength="100" runat="server" ClientIDMode="Static"
                                FieldLabel="End Date" AnchorHorizontal="95%" Format="dd MMM yyyy">
                            </ext:DateField>
                        </Items>
                    </ext:Panel>
                </Items>
                <Buttons>
                    <ext:Button ID="btnInstrumentLinkSave" runat="server" Text="Save" FormBind="true" Icon="Accept" ClientIDMode="Static">
                        <DirectEvents>
                            <Click OnEvent="InstrumentLinkSave">
                                <EventMask ShowMask="true" />
                            </Click>
                        </DirectEvents>
                    </ext:Button>
                </Buttons>
                <BottomBar>
                    <ext:StatusBar ID="StatusBar4" runat="server" Height="25" />
                </BottomBar>
                <Listeners>
                    <ClientValidation Handler="this.getBottomToolbar().setStatus({text : valid ? 'Form is valid' : 'Form is invalid', iconCls: valid ? 'icon-accept1' : 'icon-exclamation'});" />
                </Listeners>
            </ext:FormPanel>
        </Content>
    </ext:Window>
    <ext:Window ID="TransformationDetailWindow" runat="server" Width="450" Height="600"
        Closable="true" Hidden="true" Collapsible="false" Title="Transformation Detail"
        Maximizable="false" Layout="Fit" ClientIDMode="Static">
        <Content>
            <ext:FormPanel ID="TransformationDetailPanel" runat="server" Title="" MonitorPoll="500"
                MonitorValid="true" MonitorResize="true" Padding="10" Width="440" Height="520"
                ButtonAlign="Right" Layout="RowLayout" ClientIDMode="Static">
                <Items>
                    <ext:Hidden ID="tfTransID" DataIndex="Id" runat="server">
                    </ext:Hidden>
                    <ext:Panel ID="Panel3" runat="server" Border="false" Header="false" Layout="Form"
                        LabelAlign="Top">
                        <Items>
                            <ext:ComboBox ID="cbTransformType" runat="server" StoreID="TransformationTypeStore"
                                Editable="true" BlankText="Transform Type is required" MsgTarget="Side" DisplayField="Name"
                                ValueField="Id" TypeAhead="true" Mode="Local" ForceSelection="true" TriggerAction="All"
                                AllowBlank="false" DataIndex="TransformationTypeID" EmptyText="Select Transform Type"
                                SelectOnFocus="true" FieldLabel="Transformation Type" AnchorHorizontal="95%">
                                <Listeners>
                                    <Select Fn="handlechange" />
                                </Listeners>
                            </ext:ComboBox>
                        </Items>
                    </ext:Panel>
                    <ext:Panel ID="Panel4" runat="server" Border="false" Header="false" Layout="Form"
                        LabelAlign="Top">
                        <Items>
                            <ext:SelectBox ID="cbPhenomenon" runat="server" StoreID="PhenomenonStore" Editable="true"
                                BlankText="Phenomenon is required" MsgTarget="Side" DisplayField="Name" ValueField="Id"
                                TypeAhead="true" Mode="Local" ForceSelection="true" TriggerAction="All" AllowBlank="false"
                                DataIndex="PhenomenonID" EmptyText="Select Phenomenon" SelectOnFocus="true" FieldLabel="Phenomenon"
                                AnchorHorizontal="95%" ClientIDMode="Static">
                                <Listeners>
                                    <Select Handler="#{cbOffering}.clearValue();#{cbOffering}.getStore().reload();#{cbUnitofMeasure}.clearValue();#{cbUnitofMeasure}.getStore().reload()
                                                    ;#{sbNewOffering}.clearValue();#{sbNewOffering}.getStore().reload();#{sbNewUoM}.clearValue();#{sbNewUoM}.getStore().reload()" />
                                </Listeners>
                            </ext:SelectBox>
                        </Items>
                    </ext:Panel>
                    <ext:Panel ID="Panel9" runat="server" Border="false" Header="false" Layout="Form"
                        LabelAlign="Top">
                        <Items>
                            <ext:SelectBox ID="cbOffering" runat="server" DataIndex="PhenomenonOfferingId" DisplayField="Name"
                                AllowBlank="true" BlankText="Offering is required" MsgTarget="Side" ForceSelection="true"
                                ValueField="ID" FieldLabel="Offering" EmptyText="Please select" ValueNotFoundText="Please select"
                                AnchorHorizontal="95%" ClientIDMode="Static">
                                <Store>
                                    <ext:Store ID="store3" runat="server" AutoLoad="false" OnRefreshData="cbOffering_RefreshData">
                                        <Reader>
                                            <ext:JsonReader IDProperty="ID">
                                                <Fields>
                                                    <ext:RecordField Name="ID" />
                                                    <ext:RecordField Name="Name" />
                                                </Fields>
                                            </ext:JsonReader>
                                        </Reader>
                                    </ext:Store>
                                </Store>
                                <Triggers>
                                    <ext:FieldTrigger Icon="Clear" />
                                </Triggers>
                                <Listeners>
                                    <TriggerClick Handler="this.clearValue();" />
                                </Listeners>
                            </ext:SelectBox>
                        </Items>
                    </ext:Panel>
                    <ext:Panel ID="Panel11" runat="server" Border="false" Header="false" Layout="Form"
                        LabelAlign="Top">
                        <Items>
                            <ext:SelectBox ID="cbUnitofMeasure" runat="server" DataIndex="UnitOfMeasureId" DisplayField="Unit"
                                AllowBlank="true" BlankText="Offering is required" MsgTarget="Side" ForceSelection="true"
                                ValueField="ID" FieldLabel="Unit of Measure" EmptyText="Please select" ValueNotFoundText="Please select"
                                AnchorHorizontal="95%" ClientIDMode="Static">
                                <Store>
                                    <ext:Store ID="store5" runat="server" AutoLoad="false" OnRefreshData="cbUnitofMeasure_RefreshData">
                                        <Reader>
                                            <ext:JsonReader IDProperty="ID">
                                                <Fields>
                                                    <ext:RecordField Name="ID" />
                                                    <ext:RecordField Name="Unit" />
                                                </Fields>
                                            </ext:JsonReader>
                                        </Reader>
                                    </ext:Store>
                                </Store>
                                <Triggers>
                                    <ext:FieldTrigger Icon="Clear" />
                                </Triggers>
                                <Listeners>
                                    <TriggerClick Handler="this.clearValue();" />
                                </Listeners>
                            </ext:SelectBox>
                        </Items>
                    </ext:Panel>
                    <ext:Container ID="Container9" runat="server" LabelAlign="Top" Layout="Form" ColumnWidth=".5">
                        <Items>
                            <ext:DateField ID="dfTransStart" DataIndex="StartDate" runat="server" FieldLabel="Start Date"
                                AnchorHorizontal="95%" AllowBlank="false" BlankText="Start Date is required">
                            </ext:DateField>
                        </Items>
                    </ext:Container>
                    <ext:Container ID="Container14" runat="server" LabelAlign="Top" Layout="Form" ColumnWidth=".5">
                        <Items>
                            <ext:DateField ID="dfTransEnd" DataIndex="EndDate" runat="server" FieldLabel="Start Date"
                                AnchorHorizontal="95%" AllowBlank="true" BlankText="Start Date is required">
                            </ext:DateField>
                        </Items>
                    </ext:Container>
                    <%--Format="dd/MM/yyyy"--%>
                    <ext:Container ID="Container10" runat="server" Layout="Form"
                        LabelAlign="Top">
                        <Items>
                            <ext:TextArea ID="tfDefinition" DataIndex="Definition" runat="server" AllowBlank="false"
                                BlankText="Transformation Definition is required" MsgTarget="Side" IsRemoteValidation="true"
                                FieldLabel="Transformation Definition" AnchorHorizontal="95%" ClientIDMode="Static">
                                <RemoteValidation OnValidation="OnDefinitionValidation">
                                </RemoteValidation>
                            </ext:TextArea>
                        </Items>
                    </ext:Container>
                    <%--=============--%>
                    <ext:Panel ID="Panel2" runat="server" Layout="Form"
                        LabelAlign="Top">
                        <Items>
                            <ext:SelectBox ID="sbNewOffering" runat="server" DataIndex="NewPhenomenonOfferingID" DisplayField="Name"
                                AllowBlank="true" BlankText="Offering is required" MsgTarget="Side" ForceSelection="false"
                                ValueField="ID" FieldLabel="New Offering" EmptyText="Please select" ValueNotFoundText="Please select"
                                AnchorHorizontal="95%" ClientIDMode="Static">
                                <Store>
                                    <ext:Store ID="store6" runat="server" AutoLoad="false" OnRefreshData="cbNewOffering_RefreshData">
                                        <Reader>
                                            <ext:JsonReader IDProperty="ID">
                                                <Fields>
                                                    <ext:RecordField Name="ID" />
                                                    <ext:RecordField Name="Name" />
                                                </Fields>
                                            </ext:JsonReader>
                                        </Reader>
                                    </ext:Store>
                                </Store>
                                <Triggers>
                                    <ext:FieldTrigger Icon="Clear" />
                                </Triggers>
                                <Listeners>
                                    <TriggerClick Handler="this.clearValue();" />
                                </Listeners>
                            </ext:SelectBox>
                        </Items>
                    </ext:Panel>
                    <ext:Panel ID="Panel5" runat="server" Border="false" Header="false" Layout="Form"
                        LabelAlign="Top">
                        <Items>
                            <ext:SelectBox ID="sbNewUoM" runat="server" DataIndex="NewPhenomenonUOMID" DisplayField="Unit"
                                AllowBlank="true" BlankText="Offering is required" MsgTarget="Side" ForceSelection="false"
                                ValueField="ID" FieldLabel="New Unit of Measure" EmptyText="Please select" ValueNotFoundText="Please select"
                                AnchorHorizontal="95%" ClientIDMode="Static">
                                <Store>
                                    <ext:Store ID="store7" runat="server" AutoLoad="false" OnRefreshData="cbNewUnitofMeasure_RefreshData">
                                        <Reader>
                                            <ext:JsonReader IDProperty="ID">
                                                <Fields>
                                                    <ext:RecordField Name="ID" />
                                                    <ext:RecordField Name="Unit" />
                                                </Fields>
                                            </ext:JsonReader>
                                        </Reader>
                                    </ext:Store>
                                </Store>
                                <Triggers>
                                    <ext:FieldTrigger Icon="Clear" />
                                </Triggers>
                                <Listeners>
                                    <TriggerClick Handler="this.clearValue();" />
                                </Listeners>
                            </ext:SelectBox>
                        </Items>
                    </ext:Panel>
                    <ext:Panel ID="Panel10" runat="server" Border="false" Header="false" Layout="Form"
                        LabelAlign="Top">
                        <Items>
                            <ext:NumberField AllowDecimals="false" ID="tfRank" DataIndex="Rank" MaxLength="10"
                                runat="server" FieldLabel="Transformation Rank" AnchorHorizontal="95%"
                                AllowBlank="false" BlankText="Rank is required">
                            </ext:NumberField>
                        </Items>
                    </ext:Panel>
                    <%--=============--%>
                </Items>
                <Buttons>
                    <ext:Button ID="SaveTransform" runat="server" Text="Save" FormBind="true">
                        <DirectEvents>
                            <Click OnEvent="SaveTransformation" Method="POST">
                                <EventMask ShowMask="true" />
                            </Click>
                        </DirectEvents>
                    </ext:Button>
                </Buttons>
                <BottomBar>
                    <ext:StatusBar ID="StatusBar2" runat="server" Height="25" />
                </BottomBar>
                <Listeners>
                    <ClientValidation Handler="this.getBottomToolbar().setStatus({text : valid ? 'Form is valid' : 'Form is invalid', iconCls: valid ? 'icon-accept1' : 'icon-exclamation'});" />
                </Listeners>
            </ext:FormPanel>
        </Content>
    </ext:Window>
    <ext:Window ID="AvailableRolesWindow" runat="server" Collapsible="false" Maximizable="false"
        Title="Available Roles" Width="750" Height="300" X="50" Y="50"
        Layout="Fit" Hidden="true" ClientIDMode="Static">
        <Items>
            <ext:GridPanel ID="AvailableRolesGrid" runat="server" Header="false" Border="false" ClientIDMode="Static">
                <Store>
                    <ext:Store ID="AvailableRolesGridStore" runat="server" OnRefreshData="AvailableRolesGridStore_RefreshData">
                        <Proxy>
                            <ext:PageProxy />
                        </Proxy>
                        <Reader>
                            <ext:JsonReader IDProperty="RoleId">
                                <Fields>
                                    <ext:RecordField Name="RoleId" Type="Auto" />
                                    <ext:RecordField Name="RoleName" Type="String" />
                                    <ext:RecordField Name="Description" Type="String" />
                                </Fields>
                            </ext:JsonReader>
                        </Reader>
                        <BaseParams>
                            <ext:Parameter Name="DataSourceID" Value="Ext.getCmp('#{DataSourcesGrid}') && #{DataSourcesGrid}.getSelectionModel().hasSelection() ? #{DataSourcesGrid}.getSelectionModel().getSelected().id : -1"
                                Mode="Raw" />
                        </BaseParams>
                    </ext:Store>
                </Store>
                <ColumnModel ID="ColumnModel4" runat="server">
                    <Columns>
                        <ext:Column Header="Role Name" DataIndex="RoleName" Width="150" />
                        <ext:Column Header="Description" DataIndex="Description" Width="150" />
                    </Columns>
                </ColumnModel>
                <LoadMask ShowMask="true" />
                <SelectionModel>
                    <ext:CheckboxSelectionModel ID="CheckboxSelectionModel2" runat="server" />
                </SelectionModel>
                <Buttons>
                    <ext:Button ID="AcceptRoleButton" runat="server" Text="Save" Icon="Accept">
                        <DirectEvents>
                            <Click OnEvent="RoleLinksSave">
                                <EventMask ShowMask="true" />
                            </Click>
                        </DirectEvents>
                    </ext:Button>
                </Buttons>
            </ext:GridPanel>
        </Items>
        <Listeners>
            <Hide Fn="CloseAvailableRoles" />
        </Listeners>
    </ext:Window>
    <ext:Window ID="RoleDetailWindow" runat="server" Width="450" Height="400" Closable="true"
        Hidden="true" Collapsible="false" Title="Role Detail" Maximizable="false" Layout="Fit"
        ClientIDMode="Static">
        <Content>
            <ext:FormPanel ID="RoleDetailFormPanel" runat="server" Title="" MonitorPoll="500"
                MonitorValid="true" MonitorResize="true" Padding="10" Width="440" Height="370"
                ButtonAlign="Right" Layout="RowLayout" ClientIDMode="Static">
                <Items>
                    <ext:Hidden ID="hiddenRoleDetail" DataIndex="Id" runat="server">
                    </ext:Hidden>
                    <ext:Container ID="Container8" runat="server" LabelAlign="Top" Layout="Form" ColumnWidth=".5">
                        <Items>
                            <ext:DateField ID="dfRoleDetailStart" DataIndex="DateStart" runat="server" FieldLabel="Start Date"
                                AnchorHorizontal="95%" Format="dd MMM yyyy" AllowBlank="true" BlankText="Start Date is required">
                            </ext:DateField>
                        </Items>
                    </ext:Container>
                    <ext:Container ID="Container11" runat="server" LabelAlign="Top" Layout="Form" ColumnWidth=".5">
                        <Items>
                            <ext:DateField ID="dfRoleDetailEnd" DataIndex="DateEnd" runat="server" FieldLabel="End Date"
                                AnchorHorizontal="95%" Format="dd MMM yyyy" AllowBlank="true" BlankText="End Date is required">
                            </ext:DateField>
                        </Items>
                    </ext:Container>
                    <ext:Container ID="Container12" runat="server" LabelAlign="Top" Layout="Form" ColumnWidth=".5">
                        <Items>
                            <ext:Checkbox ID="cbIsRoleReadOnly" DataIndex="IsRoleReadOnly" runat="server" FieldLabel="Read Only"
                                AnchorHorizontal="95%">
                            </ext:Checkbox>
                        </Items>
                    </ext:Container>
                </Items>
                <Buttons>
                    <ext:Button ID="Button4" runat="server" Text="Save" FormBind="true">
                        <DirectEvents>
                            <Click OnEvent="SaveRoleDetail" Method="POST">
                                <EventMask ShowMask="true" />
                            </Click>
                        </DirectEvents>
                    </ext:Button>
                </Buttons>
                <BottomBar>
                    <ext:StatusBar ID="StatusBar3" runat="server" Height="25" />
                </BottomBar>
                <Listeners>
                    <ClientValidation Handler="this.getBottomToolbar().setStatus({text : valid ? 'Form is valid' : 'Form is invalid', iconCls: valid ? 'icon-accept1' : 'icon-exclamation'});" />
                </Listeners>
            </ext:FormPanel>
        </Content>
    </ext:Window>
</asp:Content>

