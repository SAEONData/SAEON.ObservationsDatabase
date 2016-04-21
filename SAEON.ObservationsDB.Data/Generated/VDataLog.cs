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
namespace SAEON.ObservationsDB.Data{
    /// <summary>
    /// Strongly-typed collection for the VDataLog class.
    /// </summary>
    [Serializable]
    public partial class VDataLogCollection : ReadOnlyList<VDataLog, VDataLogCollection>
    {        
        public VDataLogCollection() {}
    }
    /// <summary>
    /// This is  Read-only wrapper class for the vDataLog view.
    /// </summary>
    [Serializable]
    public partial class VDataLog : ReadOnlyRecord<VDataLog>, IReadOnlyRecord
    {
    
	    #region Default Settings
	    protected static void SetSQLProps() 
	    {
		    GetTableSchema();
	    }
	    #endregion
        #region Schema Accessor
	    public static TableSchema.Table Schema
        {
            get
            {
                if (BaseSchema == null)
                {
                    SetSQLProps();
                }
                return BaseSchema;
            }
        }
    	
        private static void GetTableSchema() 
        {
            if(!IsSchemaInitialized)
            {
                //Schema declaration
                TableSchema.Table schema = new TableSchema.Table("vDataLog", TableType.View, DataService.GetInstance("ObservationsDB"));
                schema.Columns = new TableSchema.TableColumnCollection();
                schema.SchemaName = @"dbo";
                //columns
                
                TableSchema.TableColumn colvarId = new TableSchema.TableColumn(schema);
                colvarId.ColumnName = "ID";
                colvarId.DataType = DbType.Int32;
                colvarId.MaxLength = 0;
                colvarId.AutoIncrement = false;
                colvarId.IsNullable = false;
                colvarId.IsPrimaryKey = false;
                colvarId.IsForeignKey = false;
                colvarId.IsReadOnly = false;
                
                schema.Columns.Add(colvarId);
                
                TableSchema.TableColumn colvarImportDate = new TableSchema.TableColumn(schema);
                colvarImportDate.ColumnName = "ImportDate";
                colvarImportDate.DataType = DbType.DateTime;
                colvarImportDate.MaxLength = 0;
                colvarImportDate.AutoIncrement = false;
                colvarImportDate.IsNullable = false;
                colvarImportDate.IsPrimaryKey = false;
                colvarImportDate.IsForeignKey = false;
                colvarImportDate.IsReadOnly = false;
                
                schema.Columns.Add(colvarImportDate);
                
                TableSchema.TableColumn colvarOrganisation = new TableSchema.TableColumn(schema);
                colvarOrganisation.ColumnName = "Organisation";
                colvarOrganisation.DataType = DbType.AnsiString;
                colvarOrganisation.MaxLength = 150;
                colvarOrganisation.AutoIncrement = false;
                colvarOrganisation.IsNullable = true;
                colvarOrganisation.IsPrimaryKey = false;
                colvarOrganisation.IsForeignKey = false;
                colvarOrganisation.IsReadOnly = false;
                
                schema.Columns.Add(colvarOrganisation);
                
                TableSchema.TableColumn colvarProjectSite = new TableSchema.TableColumn(schema);
                colvarProjectSite.ColumnName = "ProjectSite";
                colvarProjectSite.DataType = DbType.AnsiString;
                colvarProjectSite.MaxLength = 5000;
                colvarProjectSite.AutoIncrement = false;
                colvarProjectSite.IsNullable = true;
                colvarProjectSite.IsPrimaryKey = false;
                colvarProjectSite.IsForeignKey = false;
                colvarProjectSite.IsReadOnly = false;
                
                schema.Columns.Add(colvarProjectSite);
                
                TableSchema.TableColumn colvarStationName = new TableSchema.TableColumn(schema);
                colvarStationName.ColumnName = "StationName";
                colvarStationName.DataType = DbType.AnsiString;
                colvarStationName.MaxLength = 150;
                colvarStationName.AutoIncrement = false;
                colvarStationName.IsNullable = true;
                colvarStationName.IsPrimaryKey = false;
                colvarStationName.IsForeignKey = false;
                colvarStationName.IsReadOnly = false;
                
                schema.Columns.Add(colvarStationName);
                
                TableSchema.TableColumn colvarSensorProcedureID = new TableSchema.TableColumn(schema);
                colvarSensorProcedureID.ColumnName = "SensorProcedureID";
                colvarSensorProcedureID.DataType = DbType.Guid;
                colvarSensorProcedureID.MaxLength = 0;
                colvarSensorProcedureID.AutoIncrement = false;
                colvarSensorProcedureID.IsNullable = true;
                colvarSensorProcedureID.IsPrimaryKey = false;
                colvarSensorProcedureID.IsForeignKey = false;
                colvarSensorProcedureID.IsReadOnly = false;
                
                schema.Columns.Add(colvarSensorProcedureID);
                
                TableSchema.TableColumn colvarSensorName = new TableSchema.TableColumn(schema);
                colvarSensorName.ColumnName = "SensorName";
                colvarSensorName.DataType = DbType.AnsiString;
                colvarSensorName.MaxLength = 150;
                colvarSensorName.AutoIncrement = false;
                colvarSensorName.IsNullable = true;
                colvarSensorName.IsPrimaryKey = false;
                colvarSensorName.IsForeignKey = false;
                colvarSensorName.IsReadOnly = false;
                
                schema.Columns.Add(colvarSensorName);
                
                TableSchema.TableColumn colvarSensorInvalid = new TableSchema.TableColumn(schema);
                colvarSensorInvalid.ColumnName = "SensorInvalid";
                colvarSensorInvalid.DataType = DbType.Int32;
                colvarSensorInvalid.MaxLength = 0;
                colvarSensorInvalid.AutoIncrement = false;
                colvarSensorInvalid.IsNullable = false;
                colvarSensorInvalid.IsPrimaryKey = false;
                colvarSensorInvalid.IsForeignKey = false;
                colvarSensorInvalid.IsReadOnly = false;
                
                schema.Columns.Add(colvarSensorInvalid);
                
                TableSchema.TableColumn colvarValueDate = new TableSchema.TableColumn(schema);
                colvarValueDate.ColumnName = "ValueDate";
                colvarValueDate.DataType = DbType.DateTime;
                colvarValueDate.MaxLength = 0;
                colvarValueDate.AutoIncrement = false;
                colvarValueDate.IsNullable = true;
                colvarValueDate.IsPrimaryKey = false;
                colvarValueDate.IsForeignKey = false;
                colvarValueDate.IsReadOnly = false;
                
                schema.Columns.Add(colvarValueDate);
                
                TableSchema.TableColumn colvarInvalidDateValue = new TableSchema.TableColumn(schema);
                colvarInvalidDateValue.ColumnName = "InvalidDateValue";
                colvarInvalidDateValue.DataType = DbType.AnsiString;
                colvarInvalidDateValue.MaxLength = 50;
                colvarInvalidDateValue.AutoIncrement = false;
                colvarInvalidDateValue.IsNullable = true;
                colvarInvalidDateValue.IsPrimaryKey = false;
                colvarInvalidDateValue.IsForeignKey = false;
                colvarInvalidDateValue.IsReadOnly = false;
                
                schema.Columns.Add(colvarInvalidDateValue);
                
                TableSchema.TableColumn colvarDateValueInvalid = new TableSchema.TableColumn(schema);
                colvarDateValueInvalid.ColumnName = "DateValueInvalid";
                colvarDateValueInvalid.DataType = DbType.Int32;
                colvarDateValueInvalid.MaxLength = 0;
                colvarDateValueInvalid.AutoIncrement = false;
                colvarDateValueInvalid.IsNullable = false;
                colvarDateValueInvalid.IsPrimaryKey = false;
                colvarDateValueInvalid.IsForeignKey = false;
                colvarDateValueInvalid.IsReadOnly = false;
                
                schema.Columns.Add(colvarDateValueInvalid);
                
                TableSchema.TableColumn colvarInvalidTimeValue = new TableSchema.TableColumn(schema);
                colvarInvalidTimeValue.ColumnName = "InvalidTimeValue";
                colvarInvalidTimeValue.DataType = DbType.AnsiString;
                colvarInvalidTimeValue.MaxLength = 50;
                colvarInvalidTimeValue.AutoIncrement = false;
                colvarInvalidTimeValue.IsNullable = true;
                colvarInvalidTimeValue.IsPrimaryKey = false;
                colvarInvalidTimeValue.IsForeignKey = false;
                colvarInvalidTimeValue.IsReadOnly = false;
                
                schema.Columns.Add(colvarInvalidTimeValue);
                
                TableSchema.TableColumn colvarTimeValueInvalid = new TableSchema.TableColumn(schema);
                colvarTimeValueInvalid.ColumnName = "TimeValueInvalid";
                colvarTimeValueInvalid.DataType = DbType.Int32;
                colvarTimeValueInvalid.MaxLength = 0;
                colvarTimeValueInvalid.AutoIncrement = false;
                colvarTimeValueInvalid.IsNullable = false;
                colvarTimeValueInvalid.IsPrimaryKey = false;
                colvarTimeValueInvalid.IsForeignKey = false;
                colvarTimeValueInvalid.IsReadOnly = false;
                
                schema.Columns.Add(colvarTimeValueInvalid);
                
                TableSchema.TableColumn colvarValueTime = new TableSchema.TableColumn(schema);
                colvarValueTime.ColumnName = "ValueTime";
                colvarValueTime.DataType = DbType.DateTime;
                colvarValueTime.MaxLength = 0;
                colvarValueTime.AutoIncrement = false;
                colvarValueTime.IsNullable = true;
                colvarValueTime.IsPrimaryKey = false;
                colvarValueTime.IsForeignKey = false;
                colvarValueTime.IsReadOnly = false;
                
                schema.Columns.Add(colvarValueTime);
                
                TableSchema.TableColumn colvarRawValue = new TableSchema.TableColumn(schema);
                colvarRawValue.ColumnName = "RawValue";
                colvarRawValue.DataType = DbType.Double;
                colvarRawValue.MaxLength = 0;
                colvarRawValue.AutoIncrement = false;
                colvarRawValue.IsNullable = true;
                colvarRawValue.IsPrimaryKey = false;
                colvarRawValue.IsForeignKey = false;
                colvarRawValue.IsReadOnly = false;
                
                schema.Columns.Add(colvarRawValue);
                
                TableSchema.TableColumn colvarValueText = new TableSchema.TableColumn(schema);
                colvarValueText.ColumnName = "ValueText";
                colvarValueText.DataType = DbType.AnsiString;
                colvarValueText.MaxLength = 50;
                colvarValueText.AutoIncrement = false;
                colvarValueText.IsNullable = false;
                colvarValueText.IsPrimaryKey = false;
                colvarValueText.IsForeignKey = false;
                colvarValueText.IsReadOnly = false;
                
                schema.Columns.Add(colvarValueText);
                
                TableSchema.TableColumn colvarRawValueInvalid = new TableSchema.TableColumn(schema);
                colvarRawValueInvalid.ColumnName = "RawValueInvalid";
                colvarRawValueInvalid.DataType = DbType.Int32;
                colvarRawValueInvalid.MaxLength = 0;
                colvarRawValueInvalid.AutoIncrement = false;
                colvarRawValueInvalid.IsNullable = false;
                colvarRawValueInvalid.IsPrimaryKey = false;
                colvarRawValueInvalid.IsForeignKey = false;
                colvarRawValueInvalid.IsReadOnly = false;
                
                schema.Columns.Add(colvarRawValueInvalid);
                
                TableSchema.TableColumn colvarDataValue = new TableSchema.TableColumn(schema);
                colvarDataValue.ColumnName = "DataValue";
                colvarDataValue.DataType = DbType.Double;
                colvarDataValue.MaxLength = 0;
                colvarDataValue.AutoIncrement = false;
                colvarDataValue.IsNullable = true;
                colvarDataValue.IsPrimaryKey = false;
                colvarDataValue.IsForeignKey = false;
                colvarDataValue.IsReadOnly = false;
                
                schema.Columns.Add(colvarDataValue);
                
                TableSchema.TableColumn colvarTransformValueText = new TableSchema.TableColumn(schema);
                colvarTransformValueText.ColumnName = "TransformValueText";
                colvarTransformValueText.DataType = DbType.AnsiString;
                colvarTransformValueText.MaxLength = 50;
                colvarTransformValueText.AutoIncrement = false;
                colvarTransformValueText.IsNullable = true;
                colvarTransformValueText.IsPrimaryKey = false;
                colvarTransformValueText.IsForeignKey = false;
                colvarTransformValueText.IsReadOnly = false;
                
                schema.Columns.Add(colvarTransformValueText);
                
                TableSchema.TableColumn colvarDataValueInvalid = new TableSchema.TableColumn(schema);
                colvarDataValueInvalid.ColumnName = "DataValueInvalid";
                colvarDataValueInvalid.DataType = DbType.Int32;
                colvarDataValueInvalid.MaxLength = 0;
                colvarDataValueInvalid.AutoIncrement = false;
                colvarDataValueInvalid.IsNullable = false;
                colvarDataValueInvalid.IsPrimaryKey = false;
                colvarDataValueInvalid.IsForeignKey = false;
                colvarDataValueInvalid.IsReadOnly = false;
                
                schema.Columns.Add(colvarDataValueInvalid);
                
                TableSchema.TableColumn colvarPhenomenonOfferingID = new TableSchema.TableColumn(schema);
                colvarPhenomenonOfferingID.ColumnName = "PhenomenonOfferingID";
                colvarPhenomenonOfferingID.DataType = DbType.Guid;
                colvarPhenomenonOfferingID.MaxLength = 0;
                colvarPhenomenonOfferingID.AutoIncrement = false;
                colvarPhenomenonOfferingID.IsNullable = true;
                colvarPhenomenonOfferingID.IsPrimaryKey = false;
                colvarPhenomenonOfferingID.IsForeignKey = false;
                colvarPhenomenonOfferingID.IsReadOnly = false;
                
                schema.Columns.Add(colvarPhenomenonOfferingID);
                
                TableSchema.TableColumn colvarOfferingInvalid = new TableSchema.TableColumn(schema);
                colvarOfferingInvalid.ColumnName = "OfferingInvalid";
                colvarOfferingInvalid.DataType = DbType.Int32;
                colvarOfferingInvalid.MaxLength = 0;
                colvarOfferingInvalid.AutoIncrement = false;
                colvarOfferingInvalid.IsNullable = false;
                colvarOfferingInvalid.IsPrimaryKey = false;
                colvarOfferingInvalid.IsForeignKey = false;
                colvarOfferingInvalid.IsReadOnly = false;
                
                schema.Columns.Add(colvarOfferingInvalid);
                
                TableSchema.TableColumn colvarPhenomenonUOMID = new TableSchema.TableColumn(schema);
                colvarPhenomenonUOMID.ColumnName = "PhenomenonUOMID";
                colvarPhenomenonUOMID.DataType = DbType.Guid;
                colvarPhenomenonUOMID.MaxLength = 0;
                colvarPhenomenonUOMID.AutoIncrement = false;
                colvarPhenomenonUOMID.IsNullable = true;
                colvarPhenomenonUOMID.IsPrimaryKey = false;
                colvarPhenomenonUOMID.IsForeignKey = false;
                colvarPhenomenonUOMID.IsReadOnly = false;
                
                schema.Columns.Add(colvarPhenomenonUOMID);
                
                TableSchema.TableColumn colvarUOMInvalid = new TableSchema.TableColumn(schema);
                colvarUOMInvalid.ColumnName = "UOMInvalid";
                colvarUOMInvalid.DataType = DbType.Int32;
                colvarUOMInvalid.MaxLength = 0;
                colvarUOMInvalid.AutoIncrement = false;
                colvarUOMInvalid.IsNullable = false;
                colvarUOMInvalid.IsPrimaryKey = false;
                colvarUOMInvalid.IsForeignKey = false;
                colvarUOMInvalid.IsReadOnly = false;
                
                schema.Columns.Add(colvarUOMInvalid);
                
                TableSchema.TableColumn colvarPhenomenonName = new TableSchema.TableColumn(schema);
                colvarPhenomenonName.ColumnName = "PhenomenonName";
                colvarPhenomenonName.DataType = DbType.AnsiString;
                colvarPhenomenonName.MaxLength = 150;
                colvarPhenomenonName.AutoIncrement = false;
                colvarPhenomenonName.IsNullable = true;
                colvarPhenomenonName.IsPrimaryKey = false;
                colvarPhenomenonName.IsForeignKey = false;
                colvarPhenomenonName.IsReadOnly = false;
                
                schema.Columns.Add(colvarPhenomenonName);
                
                TableSchema.TableColumn colvarOfferingName = new TableSchema.TableColumn(schema);
                colvarOfferingName.ColumnName = "OfferingName";
                colvarOfferingName.DataType = DbType.AnsiString;
                colvarOfferingName.MaxLength = 150;
                colvarOfferingName.AutoIncrement = false;
                colvarOfferingName.IsNullable = true;
                colvarOfferingName.IsPrimaryKey = false;
                colvarOfferingName.IsForeignKey = false;
                colvarOfferingName.IsReadOnly = false;
                
                schema.Columns.Add(colvarOfferingName);
                
                TableSchema.TableColumn colvarUnit = new TableSchema.TableColumn(schema);
                colvarUnit.ColumnName = "Unit";
                colvarUnit.DataType = DbType.AnsiString;
                colvarUnit.MaxLength = 100;
                colvarUnit.AutoIncrement = false;
                colvarUnit.IsNullable = true;
                colvarUnit.IsPrimaryKey = false;
                colvarUnit.IsForeignKey = false;
                colvarUnit.IsReadOnly = false;
                
                schema.Columns.Add(colvarUnit);
                
                TableSchema.TableColumn colvarDataSourceTransformationID = new TableSchema.TableColumn(schema);
                colvarDataSourceTransformationID.ColumnName = "DataSourceTransformationID";
                colvarDataSourceTransformationID.DataType = DbType.Guid;
                colvarDataSourceTransformationID.MaxLength = 0;
                colvarDataSourceTransformationID.AutoIncrement = false;
                colvarDataSourceTransformationID.IsNullable = true;
                colvarDataSourceTransformationID.IsPrimaryKey = false;
                colvarDataSourceTransformationID.IsForeignKey = false;
                colvarDataSourceTransformationID.IsReadOnly = false;
                
                schema.Columns.Add(colvarDataSourceTransformationID);
                
                TableSchema.TableColumn colvarTransformation = new TableSchema.TableColumn(schema);
                colvarTransformation.ColumnName = "Transformation";
                colvarTransformation.DataType = DbType.AnsiString;
                colvarTransformation.MaxLength = 150;
                colvarTransformation.AutoIncrement = false;
                colvarTransformation.IsNullable = true;
                colvarTransformation.IsPrimaryKey = false;
                colvarTransformation.IsForeignKey = false;
                colvarTransformation.IsReadOnly = false;
                
                schema.Columns.Add(colvarTransformation);
                
                TableSchema.TableColumn colvarStatusID = new TableSchema.TableColumn(schema);
                colvarStatusID.ColumnName = "StatusID";
                colvarStatusID.DataType = DbType.Guid;
                colvarStatusID.MaxLength = 0;
                colvarStatusID.AutoIncrement = false;
                colvarStatusID.IsNullable = false;
                colvarStatusID.IsPrimaryKey = false;
                colvarStatusID.IsForeignKey = false;
                colvarStatusID.IsReadOnly = false;
                
                schema.Columns.Add(colvarStatusID);
                
                TableSchema.TableColumn colvarStatus = new TableSchema.TableColumn(schema);
                colvarStatus.ColumnName = "Status";
                colvarStatus.DataType = DbType.AnsiString;
                colvarStatus.MaxLength = 150;
                colvarStatus.AutoIncrement = false;
                colvarStatus.IsNullable = false;
                colvarStatus.IsPrimaryKey = false;
                colvarStatus.IsForeignKey = false;
                colvarStatus.IsReadOnly = false;
                
                schema.Columns.Add(colvarStatus);
                
                TableSchema.TableColumn colvarImportBatchID = new TableSchema.TableColumn(schema);
                colvarImportBatchID.ColumnName = "ImportBatchID";
                colvarImportBatchID.DataType = DbType.Int32;
                colvarImportBatchID.MaxLength = 0;
                colvarImportBatchID.AutoIncrement = false;
                colvarImportBatchID.IsNullable = false;
                colvarImportBatchID.IsPrimaryKey = false;
                colvarImportBatchID.IsForeignKey = false;
                colvarImportBatchID.IsReadOnly = false;
                
                schema.Columns.Add(colvarImportBatchID);
                
                TableSchema.TableColumn colvarRawFieldValue = new TableSchema.TableColumn(schema);
                colvarRawFieldValue.ColumnName = "RawFieldValue";
                colvarRawFieldValue.DataType = DbType.AnsiString;
                colvarRawFieldValue.MaxLength = 50;
                colvarRawFieldValue.AutoIncrement = false;
                colvarRawFieldValue.IsNullable = false;
                colvarRawFieldValue.IsPrimaryKey = false;
                colvarRawFieldValue.IsForeignKey = false;
                colvarRawFieldValue.IsReadOnly = false;
                
                schema.Columns.Add(colvarRawFieldValue);
                
                TableSchema.TableColumn colvarComment = new TableSchema.TableColumn(schema);
                colvarComment.ColumnName = "Comment";
                colvarComment.DataType = DbType.AnsiString;
                colvarComment.MaxLength = 250;
                colvarComment.AutoIncrement = false;
                colvarComment.IsNullable = true;
                colvarComment.IsPrimaryKey = false;
                colvarComment.IsForeignKey = false;
                colvarComment.IsReadOnly = false;
                
                schema.Columns.Add(colvarComment);
                
                
                BaseSchema = schema;
                //add this schema to the provider
                //so we can query it later
                DataService.Providers["ObservationsDB"].AddSchema("vDataLog",schema);
            }
        }
        #endregion
        
        #region Query Accessor
	    public static Query CreateQuery()
	    {
		    return new Query(Schema);
	    }
	    #endregion
	    
	    #region .ctors
	    public VDataLog()
	    {
            SetSQLProps();
            SetDefaults();
            MarkNew();
        }
        public VDataLog(bool useDatabaseDefaults)
	    {
		    SetSQLProps();
		    if(useDatabaseDefaults)
		    {
				ForceDefaults();
			}
			MarkNew();
	    }
	    
	    public VDataLog(object keyID)
	    {
		    SetSQLProps();
		    LoadByKey(keyID);
	    }
    	 
	    public VDataLog(string columnName, object columnValue)
        {
            SetSQLProps();
            LoadByParam(columnName,columnValue);
        }
        
	    #endregion
	    
	    #region Props
	    
          
        [XmlAttribute("Id")]
        [Bindable(true)]
        public int Id 
	    {
		    get
		    {
			    return GetColumnValue<int>("ID");
		    }
            set 
		    {
			    SetColumnValue("ID", value);
            }
        }
	      
        [XmlAttribute("ImportDate")]
        [Bindable(true)]
        public DateTime ImportDate 
	    {
		    get
		    {
			    return GetColumnValue<DateTime>("ImportDate");
		    }
            set 
		    {
			    SetColumnValue("ImportDate", value);
            }
        }
	      
        [XmlAttribute("Organisation")]
        [Bindable(true)]
        public string Organisation 
	    {
		    get
		    {
			    return GetColumnValue<string>("Organisation");
		    }
            set 
		    {
			    SetColumnValue("Organisation", value);
            }
        }
	      
        [XmlAttribute("ProjectSite")]
        [Bindable(true)]
        public string ProjectSite 
	    {
		    get
		    {
			    return GetColumnValue<string>("ProjectSite");
		    }
            set 
		    {
			    SetColumnValue("ProjectSite", value);
            }
        }
	      
        [XmlAttribute("StationName")]
        [Bindable(true)]
        public string StationName 
	    {
		    get
		    {
			    return GetColumnValue<string>("StationName");
		    }
            set 
		    {
			    SetColumnValue("StationName", value);
            }
        }
	      
        [XmlAttribute("SensorProcedureID")]
        [Bindable(true)]
        public Guid? SensorProcedureID 
	    {
		    get
		    {
			    return GetColumnValue<Guid?>("SensorProcedureID");
		    }
            set 
		    {
			    SetColumnValue("SensorProcedureID", value);
            }
        }
	      
        [XmlAttribute("SensorName")]
        [Bindable(true)]
        public string SensorName 
	    {
		    get
		    {
			    return GetColumnValue<string>("SensorName");
		    }
            set 
		    {
			    SetColumnValue("SensorName", value);
            }
        }
	      
        [XmlAttribute("SensorInvalid")]
        [Bindable(true)]
        public int SensorInvalid 
	    {
		    get
		    {
			    return GetColumnValue<int>("SensorInvalid");
		    }
            set 
		    {
			    SetColumnValue("SensorInvalid", value);
            }
        }
	      
        [XmlAttribute("ValueDate")]
        [Bindable(true)]
        public DateTime? ValueDate 
	    {
		    get
		    {
			    return GetColumnValue<DateTime?>("ValueDate");
		    }
            set 
		    {
			    SetColumnValue("ValueDate", value);
            }
        }
	      
        [XmlAttribute("InvalidDateValue")]
        [Bindable(true)]
        public string InvalidDateValue 
	    {
		    get
		    {
			    return GetColumnValue<string>("InvalidDateValue");
		    }
            set 
		    {
			    SetColumnValue("InvalidDateValue", value);
            }
        }
	      
        [XmlAttribute("DateValueInvalid")]
        [Bindable(true)]
        public int DateValueInvalid 
	    {
		    get
		    {
			    return GetColumnValue<int>("DateValueInvalid");
		    }
            set 
		    {
			    SetColumnValue("DateValueInvalid", value);
            }
        }
	      
        [XmlAttribute("InvalidTimeValue")]
        [Bindable(true)]
        public string InvalidTimeValue 
	    {
		    get
		    {
			    return GetColumnValue<string>("InvalidTimeValue");
		    }
            set 
		    {
			    SetColumnValue("InvalidTimeValue", value);
            }
        }
	      
        [XmlAttribute("TimeValueInvalid")]
        [Bindable(true)]
        public int TimeValueInvalid 
	    {
		    get
		    {
			    return GetColumnValue<int>("TimeValueInvalid");
		    }
            set 
		    {
			    SetColumnValue("TimeValueInvalid", value);
            }
        }
	      
        [XmlAttribute("ValueTime")]
        [Bindable(true)]
        public DateTime? ValueTime 
	    {
		    get
		    {
			    return GetColumnValue<DateTime?>("ValueTime");
		    }
            set 
		    {
			    SetColumnValue("ValueTime", value);
            }
        }
	      
        [XmlAttribute("RawValue")]
        [Bindable(true)]
        public double? RawValue 
	    {
		    get
		    {
			    return GetColumnValue<double?>("RawValue");
		    }
            set 
		    {
			    SetColumnValue("RawValue", value);
            }
        }
	      
        [XmlAttribute("ValueText")]
        [Bindable(true)]
        public string ValueText 
	    {
		    get
		    {
			    return GetColumnValue<string>("ValueText");
		    }
            set 
		    {
			    SetColumnValue("ValueText", value);
            }
        }
	      
        [XmlAttribute("RawValueInvalid")]
        [Bindable(true)]
        public int RawValueInvalid 
	    {
		    get
		    {
			    return GetColumnValue<int>("RawValueInvalid");
		    }
            set 
		    {
			    SetColumnValue("RawValueInvalid", value);
            }
        }
	      
        [XmlAttribute("DataValue")]
        [Bindable(true)]
        public double? DataValue 
	    {
		    get
		    {
			    return GetColumnValue<double?>("DataValue");
		    }
            set 
		    {
			    SetColumnValue("DataValue", value);
            }
        }
	      
        [XmlAttribute("TransformValueText")]
        [Bindable(true)]
        public string TransformValueText 
	    {
		    get
		    {
			    return GetColumnValue<string>("TransformValueText");
		    }
            set 
		    {
			    SetColumnValue("TransformValueText", value);
            }
        }
	      
        [XmlAttribute("DataValueInvalid")]
        [Bindable(true)]
        public int DataValueInvalid 
	    {
		    get
		    {
			    return GetColumnValue<int>("DataValueInvalid");
		    }
            set 
		    {
			    SetColumnValue("DataValueInvalid", value);
            }
        }
	      
        [XmlAttribute("PhenomenonOfferingID")]
        [Bindable(true)]
        public Guid? PhenomenonOfferingID 
	    {
		    get
		    {
			    return GetColumnValue<Guid?>("PhenomenonOfferingID");
		    }
            set 
		    {
			    SetColumnValue("PhenomenonOfferingID", value);
            }
        }
	      
        [XmlAttribute("OfferingInvalid")]
        [Bindable(true)]
        public int OfferingInvalid 
	    {
		    get
		    {
			    return GetColumnValue<int>("OfferingInvalid");
		    }
            set 
		    {
			    SetColumnValue("OfferingInvalid", value);
            }
        }
	      
        [XmlAttribute("PhenomenonUOMID")]
        [Bindable(true)]
        public Guid? PhenomenonUOMID 
	    {
		    get
		    {
			    return GetColumnValue<Guid?>("PhenomenonUOMID");
		    }
            set 
		    {
			    SetColumnValue("PhenomenonUOMID", value);
            }
        }
	      
        [XmlAttribute("UOMInvalid")]
        [Bindable(true)]
        public int UOMInvalid 
	    {
		    get
		    {
			    return GetColumnValue<int>("UOMInvalid");
		    }
            set 
		    {
			    SetColumnValue("UOMInvalid", value);
            }
        }
	      
        [XmlAttribute("PhenomenonName")]
        [Bindable(true)]
        public string PhenomenonName 
	    {
		    get
		    {
			    return GetColumnValue<string>("PhenomenonName");
		    }
            set 
		    {
			    SetColumnValue("PhenomenonName", value);
            }
        }
	      
        [XmlAttribute("OfferingName")]
        [Bindable(true)]
        public string OfferingName 
	    {
		    get
		    {
			    return GetColumnValue<string>("OfferingName");
		    }
            set 
		    {
			    SetColumnValue("OfferingName", value);
            }
        }
	      
        [XmlAttribute("Unit")]
        [Bindable(true)]
        public string Unit 
	    {
		    get
		    {
			    return GetColumnValue<string>("Unit");
		    }
            set 
		    {
			    SetColumnValue("Unit", value);
            }
        }
	      
        [XmlAttribute("DataSourceTransformationID")]
        [Bindable(true)]
        public Guid? DataSourceTransformationID 
	    {
		    get
		    {
			    return GetColumnValue<Guid?>("DataSourceTransformationID");
		    }
            set 
		    {
			    SetColumnValue("DataSourceTransformationID", value);
            }
        }
	      
        [XmlAttribute("Transformation")]
        [Bindable(true)]
        public string Transformation 
	    {
		    get
		    {
			    return GetColumnValue<string>("Transformation");
		    }
            set 
		    {
			    SetColumnValue("Transformation", value);
            }
        }
	      
        [XmlAttribute("StatusID")]
        [Bindable(true)]
        public Guid StatusID 
	    {
		    get
		    {
			    return GetColumnValue<Guid>("StatusID");
		    }
            set 
		    {
			    SetColumnValue("StatusID", value);
            }
        }
	      
        [XmlAttribute("Status")]
        [Bindable(true)]
        public string Status 
	    {
		    get
		    {
			    return GetColumnValue<string>("Status");
		    }
            set 
		    {
			    SetColumnValue("Status", value);
            }
        }
	      
        [XmlAttribute("ImportBatchID")]
        [Bindable(true)]
        public int ImportBatchID 
	    {
		    get
		    {
			    return GetColumnValue<int>("ImportBatchID");
		    }
            set 
		    {
			    SetColumnValue("ImportBatchID", value);
            }
        }
	      
        [XmlAttribute("RawFieldValue")]
        [Bindable(true)]
        public string RawFieldValue 
	    {
		    get
		    {
			    return GetColumnValue<string>("RawFieldValue");
		    }
            set 
		    {
			    SetColumnValue("RawFieldValue", value);
            }
        }
	      
        [XmlAttribute("Comment")]
        [Bindable(true)]
        public string Comment 
	    {
		    get
		    {
			    return GetColumnValue<string>("Comment");
		    }
            set 
		    {
			    SetColumnValue("Comment", value);
            }
        }
	    
	    #endregion
    
	    #region Columns Struct
	    public struct Columns
	    {
		    
		    
            public static string Id = @"ID";
            
            public static string ImportDate = @"ImportDate";
            
            public static string Organisation = @"Organisation";
            
            public static string ProjectSite = @"ProjectSite";
            
            public static string StationName = @"StationName";
            
            public static string SensorProcedureID = @"SensorProcedureID";
            
            public static string SensorName = @"SensorName";
            
            public static string SensorInvalid = @"SensorInvalid";
            
            public static string ValueDate = @"ValueDate";
            
            public static string InvalidDateValue = @"InvalidDateValue";
            
            public static string DateValueInvalid = @"DateValueInvalid";
            
            public static string InvalidTimeValue = @"InvalidTimeValue";
            
            public static string TimeValueInvalid = @"TimeValueInvalid";
            
            public static string ValueTime = @"ValueTime";
            
            public static string RawValue = @"RawValue";
            
            public static string ValueText = @"ValueText";
            
            public static string RawValueInvalid = @"RawValueInvalid";
            
            public static string DataValue = @"DataValue";
            
            public static string TransformValueText = @"TransformValueText";
            
            public static string DataValueInvalid = @"DataValueInvalid";
            
            public static string PhenomenonOfferingID = @"PhenomenonOfferingID";
            
            public static string OfferingInvalid = @"OfferingInvalid";
            
            public static string PhenomenonUOMID = @"PhenomenonUOMID";
            
            public static string UOMInvalid = @"UOMInvalid";
            
            public static string PhenomenonName = @"PhenomenonName";
            
            public static string OfferingName = @"OfferingName";
            
            public static string Unit = @"Unit";
            
            public static string DataSourceTransformationID = @"DataSourceTransformationID";
            
            public static string Transformation = @"Transformation";
            
            public static string StatusID = @"StatusID";
            
            public static string Status = @"Status";
            
            public static string ImportBatchID = @"ImportBatchID";
            
            public static string RawFieldValue = @"RawFieldValue";
            
            public static string Comment = @"Comment";
            
	    }
	    #endregion
	    
	    
	    #region IAbstractRecord Members
        public new CT GetColumnValue<CT>(string columnName) {
            return base.GetColumnValue<CT>(columnName);
        }
        public object GetColumnValue(string columnName) {
            return base.GetColumnValue<object>(columnName);
        }
        #endregion
	    
    }
}
