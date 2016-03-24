using System; 
using System.Text; 
using System.Data;
using System.Data.SqlClient;
using System.Data.Common;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration; 
using System.Xml; 
using System.Xml.Serialization;
using SubSonic; 
using SubSonic.Utilities;
// <auto-generated />
namespace Observations.Data
{
	/// <summary>
	/// Strongly-typed collection for the DataSource class.
	/// </summary>
    [Serializable]
	public partial class DataSourceCollection : ActiveList<DataSource, DataSourceCollection>
	{	   
		public DataSourceCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>DataSourceCollection</returns>
		public DataSourceCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                DataSource o = this[i];
                foreach (SubSonic.Where w in this.wheres)
                {
                    bool remove = false;
                    System.Reflection.PropertyInfo pi = o.GetType().GetProperty(w.ColumnName);
                    if (pi.CanRead)
                    {
                        object val = pi.GetValue(o, null);
                        switch (w.Comparison)
                        {
                            case SubSonic.Comparison.Equals:
                                if (!val.Equals(w.ParameterValue))
                                {
                                    remove = true;
                                }
                                break;
                        }
                    }
                    if (remove)
                    {
                        this.Remove(o);
                        break;
                    }
                }
            }
            return this;
        }
		
		
	}
	/// <summary>
	/// This is an ActiveRecord class which wraps the DataSource table.
	/// </summary>
	[Serializable]
	public partial class DataSource : ActiveRecord<DataSource>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public DataSource()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public DataSource(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public DataSource(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public DataSource(string columnName, object columnValue)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByParam(columnName,columnValue);
		}
		
		protected static void SetSQLProps() { GetTableSchema(); }
		
		#endregion
		
		#region Schema and Query Accessor	
		public static Query CreateQuery() { return new Query(Schema); }
		public static TableSchema.Table Schema
		{
			get
			{
				if (BaseSchema == null)
					SetSQLProps();
				return BaseSchema;
			}
		}
		
		private static void GetTableSchema() 
		{
			if(!IsSchemaInitialized)
			{
				//Schema declaration
				TableSchema.Table schema = new TableSchema.Table("DataSource", TableType.Table, DataService.GetInstance("ObservationsDB"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarId = new TableSchema.TableColumn(schema);
				colvarId.ColumnName = "ID";
				colvarId.DataType = DbType.Guid;
				colvarId.MaxLength = 0;
				colvarId.AutoIncrement = false;
				colvarId.IsNullable = false;
				colvarId.IsPrimaryKey = true;
				colvarId.IsForeignKey = false;
				colvarId.IsReadOnly = false;
				
						colvarId.DefaultSetting = @"(newid())";
				colvarId.ForeignKeyTableName = "";
				schema.Columns.Add(colvarId);
				
				TableSchema.TableColumn colvarCode = new TableSchema.TableColumn(schema);
				colvarCode.ColumnName = "Code";
				colvarCode.DataType = DbType.AnsiString;
				colvarCode.MaxLength = 50;
				colvarCode.AutoIncrement = false;
				colvarCode.IsNullable = false;
				colvarCode.IsPrimaryKey = false;
				colvarCode.IsForeignKey = false;
				colvarCode.IsReadOnly = false;
				colvarCode.DefaultSetting = @"";
				colvarCode.ForeignKeyTableName = "";
				schema.Columns.Add(colvarCode);
				
				TableSchema.TableColumn colvarName = new TableSchema.TableColumn(schema);
				colvarName.ColumnName = "Name";
				colvarName.DataType = DbType.AnsiString;
				colvarName.MaxLength = 150;
				colvarName.AutoIncrement = false;
				colvarName.IsNullable = false;
				colvarName.IsPrimaryKey = false;
				colvarName.IsForeignKey = false;
				colvarName.IsReadOnly = false;
				colvarName.DefaultSetting = @"";
				colvarName.ForeignKeyTableName = "";
				schema.Columns.Add(colvarName);
				
				TableSchema.TableColumn colvarDescription = new TableSchema.TableColumn(schema);
				colvarDescription.ColumnName = "Description";
				colvarDescription.DataType = DbType.AnsiString;
				colvarDescription.MaxLength = 5000;
				colvarDescription.AutoIncrement = false;
				colvarDescription.IsNullable = true;
				colvarDescription.IsPrimaryKey = false;
				colvarDescription.IsForeignKey = false;
				colvarDescription.IsReadOnly = false;
				colvarDescription.DefaultSetting = @"";
				colvarDescription.ForeignKeyTableName = "";
				schema.Columns.Add(colvarDescription);
				
				TableSchema.TableColumn colvarUrl = new TableSchema.TableColumn(schema);
				colvarUrl.ColumnName = "Url";
				colvarUrl.DataType = DbType.AnsiString;
				colvarUrl.MaxLength = 250;
				colvarUrl.AutoIncrement = false;
				colvarUrl.IsNullable = false;
				colvarUrl.IsPrimaryKey = false;
				colvarUrl.IsForeignKey = false;
				colvarUrl.IsReadOnly = false;
				colvarUrl.DefaultSetting = @"";
				colvarUrl.ForeignKeyTableName = "";
				schema.Columns.Add(colvarUrl);
				
				TableSchema.TableColumn colvarDefaultNullValue = new TableSchema.TableColumn(schema);
				colvarDefaultNullValue.ColumnName = "DefaultNullValue";
				colvarDefaultNullValue.DataType = DbType.Double;
				colvarDefaultNullValue.MaxLength = 0;
				colvarDefaultNullValue.AutoIncrement = false;
				colvarDefaultNullValue.IsNullable = true;
				colvarDefaultNullValue.IsPrimaryKey = false;
				colvarDefaultNullValue.IsForeignKey = false;
				colvarDefaultNullValue.IsReadOnly = false;
				colvarDefaultNullValue.DefaultSetting = @"";
				colvarDefaultNullValue.ForeignKeyTableName = "";
				schema.Columns.Add(colvarDefaultNullValue);
				
				TableSchema.TableColumn colvarErrorEstimate = new TableSchema.TableColumn(schema);
				colvarErrorEstimate.ColumnName = "ErrorEstimate";
				colvarErrorEstimate.DataType = DbType.Double;
				colvarErrorEstimate.MaxLength = 0;
				colvarErrorEstimate.AutoIncrement = false;
				colvarErrorEstimate.IsNullable = true;
				colvarErrorEstimate.IsPrimaryKey = false;
				colvarErrorEstimate.IsForeignKey = false;
				colvarErrorEstimate.IsReadOnly = false;
				colvarErrorEstimate.DefaultSetting = @"";
				colvarErrorEstimate.ForeignKeyTableName = "";
				schema.Columns.Add(colvarErrorEstimate);
				
				TableSchema.TableColumn colvarUpdateFreq = new TableSchema.TableColumn(schema);
				colvarUpdateFreq.ColumnName = "UpdateFreq";
				colvarUpdateFreq.DataType = DbType.Int32;
				colvarUpdateFreq.MaxLength = 0;
				colvarUpdateFreq.AutoIncrement = false;
				colvarUpdateFreq.IsNullable = false;
				colvarUpdateFreq.IsPrimaryKey = false;
				colvarUpdateFreq.IsForeignKey = false;
				colvarUpdateFreq.IsReadOnly = false;
				colvarUpdateFreq.DefaultSetting = @"";
				colvarUpdateFreq.ForeignKeyTableName = "";
				schema.Columns.Add(colvarUpdateFreq);
				
				TableSchema.TableColumn colvarStartDate = new TableSchema.TableColumn(schema);
				colvarStartDate.ColumnName = "StartDate";
				colvarStartDate.DataType = DbType.DateTime;
				colvarStartDate.MaxLength = 0;
				colvarStartDate.AutoIncrement = false;
				colvarStartDate.IsNullable = true;
				colvarStartDate.IsPrimaryKey = false;
				colvarStartDate.IsForeignKey = false;
				colvarStartDate.IsReadOnly = false;
				colvarStartDate.DefaultSetting = @"";
				colvarStartDate.ForeignKeyTableName = "";
				schema.Columns.Add(colvarStartDate);
				
				TableSchema.TableColumn colvarLastUpdate = new TableSchema.TableColumn(schema);
				colvarLastUpdate.ColumnName = "LastUpdate";
				colvarLastUpdate.DataType = DbType.DateTime;
				colvarLastUpdate.MaxLength = 0;
				colvarLastUpdate.AutoIncrement = false;
				colvarLastUpdate.IsNullable = false;
				colvarLastUpdate.IsPrimaryKey = false;
				colvarLastUpdate.IsForeignKey = false;
				colvarLastUpdate.IsReadOnly = false;
				colvarLastUpdate.DefaultSetting = @"";
				colvarLastUpdate.ForeignKeyTableName = "";
				schema.Columns.Add(colvarLastUpdate);
				
				TableSchema.TableColumn colvarDataSchemaID = new TableSchema.TableColumn(schema);
				colvarDataSchemaID.ColumnName = "DataSchemaID";
				colvarDataSchemaID.DataType = DbType.Guid;
				colvarDataSchemaID.MaxLength = 0;
				colvarDataSchemaID.AutoIncrement = false;
				colvarDataSchemaID.IsNullable = true;
				colvarDataSchemaID.IsPrimaryKey = false;
				colvarDataSchemaID.IsForeignKey = true;
				colvarDataSchemaID.IsReadOnly = false;
				colvarDataSchemaID.DefaultSetting = @"";
				
					colvarDataSchemaID.ForeignKeyTableName = "DataSchema";
				schema.Columns.Add(colvarDataSchemaID);
				
				TableSchema.TableColumn colvarUserId = new TableSchema.TableColumn(schema);
				colvarUserId.ColumnName = "UserId";
				colvarUserId.DataType = DbType.Guid;
				colvarUserId.MaxLength = 0;
				colvarUserId.AutoIncrement = false;
				colvarUserId.IsNullable = false;
				colvarUserId.IsPrimaryKey = false;
				colvarUserId.IsForeignKey = true;
				colvarUserId.IsReadOnly = false;
				colvarUserId.DefaultSetting = @"";
				
					colvarUserId.ForeignKeyTableName = "aspnet_Users";
				schema.Columns.Add(colvarUserId);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["ObservationsDB"].AddSchema("DataSource",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("Id")]
		[Bindable(true)]
		public Guid Id 
		{
			get { return GetColumnValue<Guid>(Columns.Id); }
			set { SetColumnValue(Columns.Id, value); }
		}
		  
		[XmlAttribute("Code")]
		[Bindable(true)]
		public string Code 
		{
			get { return GetColumnValue<string>(Columns.Code); }
			set { SetColumnValue(Columns.Code, value); }
		}
		  
		[XmlAttribute("Name")]
		[Bindable(true)]
		public string Name 
		{
			get { return GetColumnValue<string>(Columns.Name); }
			set { SetColumnValue(Columns.Name, value); }
		}
		  
		[XmlAttribute("Description")]
		[Bindable(true)]
		public string Description 
		{
			get { return GetColumnValue<string>(Columns.Description); }
			set { SetColumnValue(Columns.Description, value); }
		}
		  
		[XmlAttribute("Url")]
		[Bindable(true)]
		public string Url 
		{
			get { return GetColumnValue<string>(Columns.Url); }
			set { SetColumnValue(Columns.Url, value); }
		}
		  
		[XmlAttribute("DefaultNullValue")]
		[Bindable(true)]
		public double? DefaultNullValue 
		{
			get { return GetColumnValue<double?>(Columns.DefaultNullValue); }
			set { SetColumnValue(Columns.DefaultNullValue, value); }
		}
		  
		[XmlAttribute("ErrorEstimate")]
		[Bindable(true)]
		public double? ErrorEstimate 
		{
			get { return GetColumnValue<double?>(Columns.ErrorEstimate); }
			set { SetColumnValue(Columns.ErrorEstimate, value); }
		}
		  
		[XmlAttribute("UpdateFreq")]
		[Bindable(true)]
		public int UpdateFreq 
		{
			get { return GetColumnValue<int>(Columns.UpdateFreq); }
			set { SetColumnValue(Columns.UpdateFreq, value); }
		}
		  
		[XmlAttribute("StartDate")]
		[Bindable(true)]
		public DateTime? StartDate 
		{
			get { return GetColumnValue<DateTime?>(Columns.StartDate); }
			set { SetColumnValue(Columns.StartDate, value); }
		}
		  
		[XmlAttribute("LastUpdate")]
		[Bindable(true)]
		public DateTime LastUpdate 
		{
			get { return GetColumnValue<DateTime>(Columns.LastUpdate); }
			set { SetColumnValue(Columns.LastUpdate, value); }
		}
		  
		[XmlAttribute("DataSchemaID")]
		[Bindable(true)]
		public Guid? DataSchemaID 
		{
			get { return GetColumnValue<Guid?>(Columns.DataSchemaID); }
			set { SetColumnValue(Columns.DataSchemaID, value); }
		}
		  
		[XmlAttribute("UserId")]
		[Bindable(true)]
		public Guid UserId 
		{
			get { return GetColumnValue<Guid>(Columns.UserId); }
			set { SetColumnValue(Columns.UserId, value); }
		}
		
		#endregion
		
		
		#region PrimaryKey Methods		
		
        protected override void SetPrimaryKey(object oValue)
        {
            base.SetPrimaryKey(oValue);
            
            SetPKValues();
        }
        
		
		public Observations.Data.DataSourceRoleCollection DataSourceRoleRecords()
		{
			return new Observations.Data.DataSourceRoleCollection().Where(DataSourceRole.Columns.DataSourceID, Id).Load();
		}
		public Observations.Data.ImportBatchCollection ImportBatchRecords()
		{
			return new Observations.Data.ImportBatchCollection().Where(ImportBatch.Columns.DataSourceID, Id).Load();
		}
		public Observations.Data.SensorProcedureCollection SensorProcedureRecords()
		{
			return new Observations.Data.SensorProcedureCollection().Where(SensorProcedure.Columns.DataSourceID, Id).Load();
		}
		public Observations.Data.DataSourceTransformationCollection DataSourceTransformationRecords()
		{
			return new Observations.Data.DataSourceTransformationCollection().Where(DataSourceTransformation.Columns.DataSourceID, Id).Load();
		}
		#endregion
		
			
		
		#region ForeignKey Properties
		
		/// <summary>
		/// Returns a AspnetUser ActiveRecord object related to this DataSource
		/// 
		/// </summary>
		public Observations.Data.AspnetUser AspnetUser
		{
			get { return Observations.Data.AspnetUser.FetchByID(this.UserId); }
			set { SetColumnValue("UserId", value.UserId); }
		}
		
		
		/// <summary>
		/// Returns a DataSchema ActiveRecord object related to this DataSource
		/// 
		/// </summary>
		public Observations.Data.DataSchema DataSchema
		{
			get { return Observations.Data.DataSchema.FetchByID(this.DataSchemaID); }
			set { SetColumnValue("DataSchemaID", value.Id); }
		}
		
		
		#endregion
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(Guid varId,string varCode,string varName,string varDescription,string varUrl,double? varDefaultNullValue,double? varErrorEstimate,int varUpdateFreq,DateTime? varStartDate,DateTime varLastUpdate,Guid? varDataSchemaID,Guid varUserId)
		{
			DataSource item = new DataSource();
			
			item.Id = varId;
			
			item.Code = varCode;
			
			item.Name = varName;
			
			item.Description = varDescription;
			
			item.Url = varUrl;
			
			item.DefaultNullValue = varDefaultNullValue;
			
			item.ErrorEstimate = varErrorEstimate;
			
			item.UpdateFreq = varUpdateFreq;
			
			item.StartDate = varStartDate;
			
			item.LastUpdate = varLastUpdate;
			
			item.DataSchemaID = varDataSchemaID;
			
			item.UserId = varUserId;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(Guid varId,string varCode,string varName,string varDescription,string varUrl,double? varDefaultNullValue,double? varErrorEstimate,int varUpdateFreq,DateTime? varStartDate,DateTime varLastUpdate,Guid? varDataSchemaID,Guid varUserId)
		{
			DataSource item = new DataSource();
			
				item.Id = varId;
			
				item.Code = varCode;
			
				item.Name = varName;
			
				item.Description = varDescription;
			
				item.Url = varUrl;
			
				item.DefaultNullValue = varDefaultNullValue;
			
				item.ErrorEstimate = varErrorEstimate;
			
				item.UpdateFreq = varUpdateFreq;
			
				item.StartDate = varStartDate;
			
				item.LastUpdate = varLastUpdate;
			
				item.DataSchemaID = varDataSchemaID;
			
				item.UserId = varUserId;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn IdColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn CodeColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn NameColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn DescriptionColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        public static TableSchema.TableColumn UrlColumn
        {
            get { return Schema.Columns[4]; }
        }
        
        
        
        public static TableSchema.TableColumn DefaultNullValueColumn
        {
            get { return Schema.Columns[5]; }
        }
        
        
        
        public static TableSchema.TableColumn ErrorEstimateColumn
        {
            get { return Schema.Columns[6]; }
        }
        
        
        
        public static TableSchema.TableColumn UpdateFreqColumn
        {
            get { return Schema.Columns[7]; }
        }
        
        
        
        public static TableSchema.TableColumn StartDateColumn
        {
            get { return Schema.Columns[8]; }
        }
        
        
        
        public static TableSchema.TableColumn LastUpdateColumn
        {
            get { return Schema.Columns[9]; }
        }
        
        
        
        public static TableSchema.TableColumn DataSchemaIDColumn
        {
            get { return Schema.Columns[10]; }
        }
        
        
        
        public static TableSchema.TableColumn UserIdColumn
        {
            get { return Schema.Columns[11]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string Id = @"ID";
			 public static string Code = @"Code";
			 public static string Name = @"Name";
			 public static string Description = @"Description";
			 public static string Url = @"Url";
			 public static string DefaultNullValue = @"DefaultNullValue";
			 public static string ErrorEstimate = @"ErrorEstimate";
			 public static string UpdateFreq = @"UpdateFreq";
			 public static string StartDate = @"StartDate";
			 public static string LastUpdate = @"LastUpdate";
			 public static string DataSchemaID = @"DataSchemaID";
			 public static string UserId = @"UserId";
						
		}
		#endregion
		
		#region Update PK Collections
		
        public void SetPKValues()
        {
}
        #endregion
    
        #region Deep Save
		
        public void DeepSave()
        {
            Save();
            
}
        #endregion
	}
}
