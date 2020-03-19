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
namespace SAEON.Observations.Data{
    /// <summary>
    /// Strongly-typed collection for the VObservationODatum class.
    /// </summary>
    [Serializable]
    public partial class VObservationODatumCollection : ReadOnlyList<VObservationODatum, VObservationODatumCollection>
    {        
        public VObservationODatumCollection() {}
    }
    /// <summary>
    /// This is  Read-only wrapper class for the vObservationOData view.
    /// </summary>
    [Serializable]
    public partial class VObservationODatum : ReadOnlyRecord<VObservationODatum>, IReadOnlyRecord
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
                TableSchema.Table schema = new TableSchema.Table("vObservationOData", TableType.View, DataService.GetInstance("ObservationsDB"));
                schema.Columns = new TableSchema.TableColumnCollection();
                schema.SchemaName = @"dbo";
                //columns
                
                TableSchema.TableColumn colvarSensorID = new TableSchema.TableColumn(schema);
                colvarSensorID.ColumnName = "SensorID";
                colvarSensorID.DataType = DbType.Guid;
                colvarSensorID.MaxLength = 0;
                colvarSensorID.AutoIncrement = false;
                colvarSensorID.IsNullable = false;
                colvarSensorID.IsPrimaryKey = false;
                colvarSensorID.IsForeignKey = false;
                colvarSensorID.IsReadOnly = false;
                
                schema.Columns.Add(colvarSensorID);
                
                TableSchema.TableColumn colvarValueDate = new TableSchema.TableColumn(schema);
                colvarValueDate.ColumnName = "ValueDate";
                colvarValueDate.DataType = DbType.DateTime;
                colvarValueDate.MaxLength = 0;
                colvarValueDate.AutoIncrement = false;
                colvarValueDate.IsNullable = false;
                colvarValueDate.IsPrimaryKey = false;
                colvarValueDate.IsForeignKey = false;
                colvarValueDate.IsReadOnly = false;
                
                schema.Columns.Add(colvarValueDate);
                
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
                
                TableSchema.TableColumn colvarTextValue = new TableSchema.TableColumn(schema);
                colvarTextValue.ColumnName = "TextValue";
                colvarTextValue.DataType = DbType.AnsiString;
                colvarTextValue.MaxLength = 10;
                colvarTextValue.AutoIncrement = false;
                colvarTextValue.IsNullable = true;
                colvarTextValue.IsPrimaryKey = false;
                colvarTextValue.IsForeignKey = false;
                colvarTextValue.IsReadOnly = false;
                
                schema.Columns.Add(colvarTextValue);
                
                TableSchema.TableColumn colvarLatitude = new TableSchema.TableColumn(schema);
                colvarLatitude.ColumnName = "Latitude";
                colvarLatitude.DataType = DbType.Double;
                colvarLatitude.MaxLength = 0;
                colvarLatitude.AutoIncrement = false;
                colvarLatitude.IsNullable = true;
                colvarLatitude.IsPrimaryKey = false;
                colvarLatitude.IsForeignKey = false;
                colvarLatitude.IsReadOnly = false;
                
                schema.Columns.Add(colvarLatitude);
                
                TableSchema.TableColumn colvarLongitude = new TableSchema.TableColumn(schema);
                colvarLongitude.ColumnName = "Longitude";
                colvarLongitude.DataType = DbType.Double;
                colvarLongitude.MaxLength = 0;
                colvarLongitude.AutoIncrement = false;
                colvarLongitude.IsNullable = true;
                colvarLongitude.IsPrimaryKey = false;
                colvarLongitude.IsForeignKey = false;
                colvarLongitude.IsReadOnly = false;
                
                schema.Columns.Add(colvarLongitude);
                
                TableSchema.TableColumn colvarElevation = new TableSchema.TableColumn(schema);
                colvarElevation.ColumnName = "Elevation";
                colvarElevation.DataType = DbType.Double;
                colvarElevation.MaxLength = 0;
                colvarElevation.AutoIncrement = false;
                colvarElevation.IsNullable = true;
                colvarElevation.IsPrimaryKey = false;
                colvarElevation.IsForeignKey = false;
                colvarElevation.IsReadOnly = false;
                
                schema.Columns.Add(colvarElevation);
                
                TableSchema.TableColumn colvarPhenomenonID = new TableSchema.TableColumn(schema);
                colvarPhenomenonID.ColumnName = "PhenomenonID";
                colvarPhenomenonID.DataType = DbType.Guid;
                colvarPhenomenonID.MaxLength = 0;
                colvarPhenomenonID.AutoIncrement = false;
                colvarPhenomenonID.IsNullable = false;
                colvarPhenomenonID.IsPrimaryKey = false;
                colvarPhenomenonID.IsForeignKey = false;
                colvarPhenomenonID.IsReadOnly = false;
                
                schema.Columns.Add(colvarPhenomenonID);
                
                TableSchema.TableColumn colvarPhenomenonCode = new TableSchema.TableColumn(schema);
                colvarPhenomenonCode.ColumnName = "PhenomenonCode";
                colvarPhenomenonCode.DataType = DbType.AnsiString;
                colvarPhenomenonCode.MaxLength = 50;
                colvarPhenomenonCode.AutoIncrement = false;
                colvarPhenomenonCode.IsNullable = false;
                colvarPhenomenonCode.IsPrimaryKey = false;
                colvarPhenomenonCode.IsForeignKey = false;
                colvarPhenomenonCode.IsReadOnly = false;
                
                schema.Columns.Add(colvarPhenomenonCode);
                
                TableSchema.TableColumn colvarPhenomenonName = new TableSchema.TableColumn(schema);
                colvarPhenomenonName.ColumnName = "PhenomenonName";
                colvarPhenomenonName.DataType = DbType.AnsiString;
                colvarPhenomenonName.MaxLength = 150;
                colvarPhenomenonName.AutoIncrement = false;
                colvarPhenomenonName.IsNullable = false;
                colvarPhenomenonName.IsPrimaryKey = false;
                colvarPhenomenonName.IsForeignKey = false;
                colvarPhenomenonName.IsReadOnly = false;
                
                schema.Columns.Add(colvarPhenomenonName);
                
                TableSchema.TableColumn colvarPhenomenonDescription = new TableSchema.TableColumn(schema);
                colvarPhenomenonDescription.ColumnName = "PhenomenonDescription";
                colvarPhenomenonDescription.DataType = DbType.AnsiString;
                colvarPhenomenonDescription.MaxLength = 5000;
                colvarPhenomenonDescription.AutoIncrement = false;
                colvarPhenomenonDescription.IsNullable = true;
                colvarPhenomenonDescription.IsPrimaryKey = false;
                colvarPhenomenonDescription.IsForeignKey = false;
                colvarPhenomenonDescription.IsReadOnly = false;
                
                schema.Columns.Add(colvarPhenomenonDescription);
                
                TableSchema.TableColumn colvarOfferingID = new TableSchema.TableColumn(schema);
                colvarOfferingID.ColumnName = "OfferingID";
                colvarOfferingID.DataType = DbType.Guid;
                colvarOfferingID.MaxLength = 0;
                colvarOfferingID.AutoIncrement = false;
                colvarOfferingID.IsNullable = false;
                colvarOfferingID.IsPrimaryKey = false;
                colvarOfferingID.IsForeignKey = false;
                colvarOfferingID.IsReadOnly = false;
                
                schema.Columns.Add(colvarOfferingID);
                
                TableSchema.TableColumn colvarOfferingCode = new TableSchema.TableColumn(schema);
                colvarOfferingCode.ColumnName = "OfferingCode";
                colvarOfferingCode.DataType = DbType.AnsiString;
                colvarOfferingCode.MaxLength = 50;
                colvarOfferingCode.AutoIncrement = false;
                colvarOfferingCode.IsNullable = false;
                colvarOfferingCode.IsPrimaryKey = false;
                colvarOfferingCode.IsForeignKey = false;
                colvarOfferingCode.IsReadOnly = false;
                
                schema.Columns.Add(colvarOfferingCode);
                
                TableSchema.TableColumn colvarOfferingName = new TableSchema.TableColumn(schema);
                colvarOfferingName.ColumnName = "OfferingName";
                colvarOfferingName.DataType = DbType.AnsiString;
                colvarOfferingName.MaxLength = 150;
                colvarOfferingName.AutoIncrement = false;
                colvarOfferingName.IsNullable = false;
                colvarOfferingName.IsPrimaryKey = false;
                colvarOfferingName.IsForeignKey = false;
                colvarOfferingName.IsReadOnly = false;
                
                schema.Columns.Add(colvarOfferingName);
                
                TableSchema.TableColumn colvarOfferingDescription = new TableSchema.TableColumn(schema);
                colvarOfferingDescription.ColumnName = "OfferingDescription";
                colvarOfferingDescription.DataType = DbType.AnsiString;
                colvarOfferingDescription.MaxLength = 5000;
                colvarOfferingDescription.AutoIncrement = false;
                colvarOfferingDescription.IsNullable = true;
                colvarOfferingDescription.IsPrimaryKey = false;
                colvarOfferingDescription.IsForeignKey = false;
                colvarOfferingDescription.IsReadOnly = false;
                
                schema.Columns.Add(colvarOfferingDescription);
                
                TableSchema.TableColumn colvarUnitOfMeasureID = new TableSchema.TableColumn(schema);
                colvarUnitOfMeasureID.ColumnName = "UnitOfMeasureID";
                colvarUnitOfMeasureID.DataType = DbType.Guid;
                colvarUnitOfMeasureID.MaxLength = 0;
                colvarUnitOfMeasureID.AutoIncrement = false;
                colvarUnitOfMeasureID.IsNullable = false;
                colvarUnitOfMeasureID.IsPrimaryKey = false;
                colvarUnitOfMeasureID.IsForeignKey = false;
                colvarUnitOfMeasureID.IsReadOnly = false;
                
                schema.Columns.Add(colvarUnitOfMeasureID);
                
                TableSchema.TableColumn colvarUnitOfMeasureCode = new TableSchema.TableColumn(schema);
                colvarUnitOfMeasureCode.ColumnName = "UnitOfMeasureCode";
                colvarUnitOfMeasureCode.DataType = DbType.AnsiString;
                colvarUnitOfMeasureCode.MaxLength = 50;
                colvarUnitOfMeasureCode.AutoIncrement = false;
                colvarUnitOfMeasureCode.IsNullable = false;
                colvarUnitOfMeasureCode.IsPrimaryKey = false;
                colvarUnitOfMeasureCode.IsForeignKey = false;
                colvarUnitOfMeasureCode.IsReadOnly = false;
                
                schema.Columns.Add(colvarUnitOfMeasureCode);
                
                TableSchema.TableColumn colvarUnitOfMeasureUnit = new TableSchema.TableColumn(schema);
                colvarUnitOfMeasureUnit.ColumnName = "UnitOfMeasureUnit";
                colvarUnitOfMeasureUnit.DataType = DbType.AnsiString;
                colvarUnitOfMeasureUnit.MaxLength = 100;
                colvarUnitOfMeasureUnit.AutoIncrement = false;
                colvarUnitOfMeasureUnit.IsNullable = false;
                colvarUnitOfMeasureUnit.IsPrimaryKey = false;
                colvarUnitOfMeasureUnit.IsForeignKey = false;
                colvarUnitOfMeasureUnit.IsReadOnly = false;
                
                schema.Columns.Add(colvarUnitOfMeasureUnit);
                
                TableSchema.TableColumn colvarUnitOfMeasureSymbol = new TableSchema.TableColumn(schema);
                colvarUnitOfMeasureSymbol.ColumnName = "UnitOfMeasureSymbol";
                colvarUnitOfMeasureSymbol.DataType = DbType.AnsiString;
                colvarUnitOfMeasureSymbol.MaxLength = 20;
                colvarUnitOfMeasureSymbol.AutoIncrement = false;
                colvarUnitOfMeasureSymbol.IsNullable = false;
                colvarUnitOfMeasureSymbol.IsPrimaryKey = false;
                colvarUnitOfMeasureSymbol.IsForeignKey = false;
                colvarUnitOfMeasureSymbol.IsReadOnly = false;
                
                schema.Columns.Add(colvarUnitOfMeasureSymbol);
                
                TableSchema.TableColumn colvarCorrelationID = new TableSchema.TableColumn(schema);
                colvarCorrelationID.ColumnName = "CorrelationID";
                colvarCorrelationID.DataType = DbType.Guid;
                colvarCorrelationID.MaxLength = 0;
                colvarCorrelationID.AutoIncrement = false;
                colvarCorrelationID.IsNullable = true;
                colvarCorrelationID.IsPrimaryKey = false;
                colvarCorrelationID.IsForeignKey = false;
                colvarCorrelationID.IsReadOnly = false;
                
                schema.Columns.Add(colvarCorrelationID);
                
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
                
                TableSchema.TableColumn colvarStatusCode = new TableSchema.TableColumn(schema);
                colvarStatusCode.ColumnName = "StatusCode";
                colvarStatusCode.DataType = DbType.AnsiString;
                colvarStatusCode.MaxLength = 50;
                colvarStatusCode.AutoIncrement = false;
                colvarStatusCode.IsNullable = true;
                colvarStatusCode.IsPrimaryKey = false;
                colvarStatusCode.IsForeignKey = false;
                colvarStatusCode.IsReadOnly = false;
                
                schema.Columns.Add(colvarStatusCode);
                
                TableSchema.TableColumn colvarStatusName = new TableSchema.TableColumn(schema);
                colvarStatusName.ColumnName = "StatusName";
                colvarStatusName.DataType = DbType.AnsiString;
                colvarStatusName.MaxLength = 150;
                colvarStatusName.AutoIncrement = false;
                colvarStatusName.IsNullable = true;
                colvarStatusName.IsPrimaryKey = false;
                colvarStatusName.IsForeignKey = false;
                colvarStatusName.IsReadOnly = false;
                
                schema.Columns.Add(colvarStatusName);
                
                TableSchema.TableColumn colvarStatusDescription = new TableSchema.TableColumn(schema);
                colvarStatusDescription.ColumnName = "StatusDescription";
                colvarStatusDescription.DataType = DbType.AnsiString;
                colvarStatusDescription.MaxLength = 500;
                colvarStatusDescription.AutoIncrement = false;
                colvarStatusDescription.IsNullable = true;
                colvarStatusDescription.IsPrimaryKey = false;
                colvarStatusDescription.IsForeignKey = false;
                colvarStatusDescription.IsReadOnly = false;
                
                schema.Columns.Add(colvarStatusDescription);
                
                TableSchema.TableColumn colvarStatusReasonCode = new TableSchema.TableColumn(schema);
                colvarStatusReasonCode.ColumnName = "StatusReasonCode";
                colvarStatusReasonCode.DataType = DbType.AnsiString;
                colvarStatusReasonCode.MaxLength = 50;
                colvarStatusReasonCode.AutoIncrement = false;
                colvarStatusReasonCode.IsNullable = true;
                colvarStatusReasonCode.IsPrimaryKey = false;
                colvarStatusReasonCode.IsForeignKey = false;
                colvarStatusReasonCode.IsReadOnly = false;
                
                schema.Columns.Add(colvarStatusReasonCode);
                
                TableSchema.TableColumn colvarStatusReasonName = new TableSchema.TableColumn(schema);
                colvarStatusReasonName.ColumnName = "StatusReasonName";
                colvarStatusReasonName.DataType = DbType.AnsiString;
                colvarStatusReasonName.MaxLength = 150;
                colvarStatusReasonName.AutoIncrement = false;
                colvarStatusReasonName.IsNullable = true;
                colvarStatusReasonName.IsPrimaryKey = false;
                colvarStatusReasonName.IsForeignKey = false;
                colvarStatusReasonName.IsReadOnly = false;
                
                schema.Columns.Add(colvarStatusReasonName);
                
                TableSchema.TableColumn colvarStatusReasonDescription = new TableSchema.TableColumn(schema);
                colvarStatusReasonDescription.ColumnName = "StatusReasonDescription";
                colvarStatusReasonDescription.DataType = DbType.AnsiString;
                colvarStatusReasonDescription.MaxLength = 500;
                colvarStatusReasonDescription.AutoIncrement = false;
                colvarStatusReasonDescription.IsNullable = true;
                colvarStatusReasonDescription.IsPrimaryKey = false;
                colvarStatusReasonDescription.IsForeignKey = false;
                colvarStatusReasonDescription.IsReadOnly = false;
                
                schema.Columns.Add(colvarStatusReasonDescription);
                
                
                BaseSchema = schema;
                //add this schema to the provider
                //so we can query it later
                DataService.Providers["ObservationsDB"].AddSchema("vObservationOData",schema);
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
	    public VObservationODatum()
	    {
            SetSQLProps();
            SetDefaults();
            MarkNew();
        }
        public VObservationODatum(bool useDatabaseDefaults)
	    {
		    SetSQLProps();
		    if(useDatabaseDefaults)
		    {
				ForceDefaults();
			}
			MarkNew();
	    }
	    
	    public VObservationODatum(object keyID)
	    {
		    SetSQLProps();
		    LoadByKey(keyID);
	    }
    	 
	    public VObservationODatum(string columnName, object columnValue)
        {
            SetSQLProps();
            LoadByParam(columnName,columnValue);
        }
        
	    #endregion
	    
	    #region Props
	    
          
        [XmlAttribute("SensorID")]
        [Bindable(true)]
        public Guid SensorID 
	    {
		    get
		    {
			    return GetColumnValue<Guid>("SensorID");
		    }
            set 
		    {
			    SetColumnValue("SensorID", value);
            }
        }
	      
        [XmlAttribute("ValueDate")]
        [Bindable(true)]
        public DateTime ValueDate 
	    {
		    get
		    {
			    return GetColumnValue<DateTime>("ValueDate");
		    }
            set 
		    {
			    SetColumnValue("ValueDate", value);
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
	      
        [XmlAttribute("TextValue")]
        [Bindable(true)]
        public string TextValue 
	    {
		    get
		    {
			    return GetColumnValue<string>("TextValue");
		    }
            set 
		    {
			    SetColumnValue("TextValue", value);
            }
        }
	      
        [XmlAttribute("Latitude")]
        [Bindable(true)]
        public double? Latitude 
	    {
		    get
		    {
			    return GetColumnValue<double?>("Latitude");
		    }
            set 
		    {
			    SetColumnValue("Latitude", value);
            }
        }
	      
        [XmlAttribute("Longitude")]
        [Bindable(true)]
        public double? Longitude 
	    {
		    get
		    {
			    return GetColumnValue<double?>("Longitude");
		    }
            set 
		    {
			    SetColumnValue("Longitude", value);
            }
        }
	      
        [XmlAttribute("Elevation")]
        [Bindable(true)]
        public double? Elevation 
	    {
		    get
		    {
			    return GetColumnValue<double?>("Elevation");
		    }
            set 
		    {
			    SetColumnValue("Elevation", value);
            }
        }
	      
        [XmlAttribute("PhenomenonID")]
        [Bindable(true)]
        public Guid PhenomenonID 
	    {
		    get
		    {
			    return GetColumnValue<Guid>("PhenomenonID");
		    }
            set 
		    {
			    SetColumnValue("PhenomenonID", value);
            }
        }
	      
        [XmlAttribute("PhenomenonCode")]
        [Bindable(true)]
        public string PhenomenonCode 
	    {
		    get
		    {
			    return GetColumnValue<string>("PhenomenonCode");
		    }
            set 
		    {
			    SetColumnValue("PhenomenonCode", value);
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
	      
        [XmlAttribute("PhenomenonDescription")]
        [Bindable(true)]
        public string PhenomenonDescription 
	    {
		    get
		    {
			    return GetColumnValue<string>("PhenomenonDescription");
		    }
            set 
		    {
			    SetColumnValue("PhenomenonDescription", value);
            }
        }
	      
        [XmlAttribute("OfferingID")]
        [Bindable(true)]
        public Guid OfferingID 
	    {
		    get
		    {
			    return GetColumnValue<Guid>("OfferingID");
		    }
            set 
		    {
			    SetColumnValue("OfferingID", value);
            }
        }
	      
        [XmlAttribute("OfferingCode")]
        [Bindable(true)]
        public string OfferingCode 
	    {
		    get
		    {
			    return GetColumnValue<string>("OfferingCode");
		    }
            set 
		    {
			    SetColumnValue("OfferingCode", value);
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
	      
        [XmlAttribute("OfferingDescription")]
        [Bindable(true)]
        public string OfferingDescription 
	    {
		    get
		    {
			    return GetColumnValue<string>("OfferingDescription");
		    }
            set 
		    {
			    SetColumnValue("OfferingDescription", value);
            }
        }
	      
        [XmlAttribute("UnitOfMeasureID")]
        [Bindable(true)]
        public Guid UnitOfMeasureID 
	    {
		    get
		    {
			    return GetColumnValue<Guid>("UnitOfMeasureID");
		    }
            set 
		    {
			    SetColumnValue("UnitOfMeasureID", value);
            }
        }
	      
        [XmlAttribute("UnitOfMeasureCode")]
        [Bindable(true)]
        public string UnitOfMeasureCode 
	    {
		    get
		    {
			    return GetColumnValue<string>("UnitOfMeasureCode");
		    }
            set 
		    {
			    SetColumnValue("UnitOfMeasureCode", value);
            }
        }
	      
        [XmlAttribute("UnitOfMeasureUnit")]
        [Bindable(true)]
        public string UnitOfMeasureUnit 
	    {
		    get
		    {
			    return GetColumnValue<string>("UnitOfMeasureUnit");
		    }
            set 
		    {
			    SetColumnValue("UnitOfMeasureUnit", value);
            }
        }
	      
        [XmlAttribute("UnitOfMeasureSymbol")]
        [Bindable(true)]
        public string UnitOfMeasureSymbol 
	    {
		    get
		    {
			    return GetColumnValue<string>("UnitOfMeasureSymbol");
		    }
            set 
		    {
			    SetColumnValue("UnitOfMeasureSymbol", value);
            }
        }
	      
        [XmlAttribute("CorrelationID")]
        [Bindable(true)]
        public Guid? CorrelationID 
	    {
		    get
		    {
			    return GetColumnValue<Guid?>("CorrelationID");
		    }
            set 
		    {
			    SetColumnValue("CorrelationID", value);
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
	      
        [XmlAttribute("StatusCode")]
        [Bindable(true)]
        public string StatusCode 
	    {
		    get
		    {
			    return GetColumnValue<string>("StatusCode");
		    }
            set 
		    {
			    SetColumnValue("StatusCode", value);
            }
        }
	      
        [XmlAttribute("StatusName")]
        [Bindable(true)]
        public string StatusName 
	    {
		    get
		    {
			    return GetColumnValue<string>("StatusName");
		    }
            set 
		    {
			    SetColumnValue("StatusName", value);
            }
        }
	      
        [XmlAttribute("StatusDescription")]
        [Bindable(true)]
        public string StatusDescription 
	    {
		    get
		    {
			    return GetColumnValue<string>("StatusDescription");
		    }
            set 
		    {
			    SetColumnValue("StatusDescription", value);
            }
        }
	      
        [XmlAttribute("StatusReasonCode")]
        [Bindable(true)]
        public string StatusReasonCode 
	    {
		    get
		    {
			    return GetColumnValue<string>("StatusReasonCode");
		    }
            set 
		    {
			    SetColumnValue("StatusReasonCode", value);
            }
        }
	      
        [XmlAttribute("StatusReasonName")]
        [Bindable(true)]
        public string StatusReasonName 
	    {
		    get
		    {
			    return GetColumnValue<string>("StatusReasonName");
		    }
            set 
		    {
			    SetColumnValue("StatusReasonName", value);
            }
        }
	      
        [XmlAttribute("StatusReasonDescription")]
        [Bindable(true)]
        public string StatusReasonDescription 
	    {
		    get
		    {
			    return GetColumnValue<string>("StatusReasonDescription");
		    }
            set 
		    {
			    SetColumnValue("StatusReasonDescription", value);
            }
        }
	    
	    #endregion
    
	    #region Columns Struct
	    public struct Columns
	    {
		    
		    
            public static string SensorID = @"SensorID";
            
            public static string ValueDate = @"ValueDate";
            
            public static string DataValue = @"DataValue";
            
            public static string TextValue = @"TextValue";
            
            public static string Latitude = @"Latitude";
            
            public static string Longitude = @"Longitude";
            
            public static string Elevation = @"Elevation";
            
            public static string PhenomenonID = @"PhenomenonID";
            
            public static string PhenomenonCode = @"PhenomenonCode";
            
            public static string PhenomenonName = @"PhenomenonName";
            
            public static string PhenomenonDescription = @"PhenomenonDescription";
            
            public static string OfferingID = @"OfferingID";
            
            public static string OfferingCode = @"OfferingCode";
            
            public static string OfferingName = @"OfferingName";
            
            public static string OfferingDescription = @"OfferingDescription";
            
            public static string UnitOfMeasureID = @"UnitOfMeasureID";
            
            public static string UnitOfMeasureCode = @"UnitOfMeasureCode";
            
            public static string UnitOfMeasureUnit = @"UnitOfMeasureUnit";
            
            public static string UnitOfMeasureSymbol = @"UnitOfMeasureSymbol";
            
            public static string CorrelationID = @"CorrelationID";
            
            public static string Comment = @"Comment";
            
            public static string StatusCode = @"StatusCode";
            
            public static string StatusName = @"StatusName";
            
            public static string StatusDescription = @"StatusDescription";
            
            public static string StatusReasonCode = @"StatusReasonCode";
            
            public static string StatusReasonName = @"StatusReasonName";
            
            public static string StatusReasonDescription = @"StatusReasonDescription";
            
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
