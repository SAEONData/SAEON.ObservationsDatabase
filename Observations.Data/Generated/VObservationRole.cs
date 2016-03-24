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
namespace Observations.Data{
    /// <summary>
    /// Strongly-typed collection for the VObservationRole class.
    /// </summary>
    [Serializable]
    public partial class VObservationRoleCollection : ReadOnlyList<VObservationRole, VObservationRoleCollection>
    {        
        public VObservationRoleCollection() {}
    }
    /// <summary>
    /// This is  Read-only wrapper class for the vObservationRoles view.
    /// </summary>
    [Serializable]
    public partial class VObservationRole : ReadOnlyRecord<VObservationRole>, IReadOnlyRecord
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
                TableSchema.Table schema = new TableSchema.Table("vObservationRoles", TableType.View, DataService.GetInstance("ObservationsDB"));
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
                
                TableSchema.TableColumn colvarSensorProcedureID = new TableSchema.TableColumn(schema);
                colvarSensorProcedureID.ColumnName = "SensorProcedureID";
                colvarSensorProcedureID.DataType = DbType.Guid;
                colvarSensorProcedureID.MaxLength = 0;
                colvarSensorProcedureID.AutoIncrement = false;
                colvarSensorProcedureID.IsNullable = false;
                colvarSensorProcedureID.IsPrimaryKey = false;
                colvarSensorProcedureID.IsForeignKey = false;
                colvarSensorProcedureID.IsReadOnly = false;
                
                schema.Columns.Add(colvarSensorProcedureID);
                
                TableSchema.TableColumn colvarPhenonmenonOfferingID = new TableSchema.TableColumn(schema);
                colvarPhenonmenonOfferingID.ColumnName = "PhenonmenonOfferingID";
                colvarPhenonmenonOfferingID.DataType = DbType.Guid;
                colvarPhenonmenonOfferingID.MaxLength = 0;
                colvarPhenonmenonOfferingID.AutoIncrement = false;
                colvarPhenonmenonOfferingID.IsNullable = false;
                colvarPhenonmenonOfferingID.IsPrimaryKey = false;
                colvarPhenonmenonOfferingID.IsForeignKey = false;
                colvarPhenonmenonOfferingID.IsReadOnly = false;
                
                schema.Columns.Add(colvarPhenonmenonOfferingID);
                
                TableSchema.TableColumn colvarPhenonmenonUOMID = new TableSchema.TableColumn(schema);
                colvarPhenonmenonUOMID.ColumnName = "PhenonmenonUOMID";
                colvarPhenonmenonUOMID.DataType = DbType.Guid;
                colvarPhenonmenonUOMID.MaxLength = 0;
                colvarPhenonmenonUOMID.AutoIncrement = false;
                colvarPhenonmenonUOMID.IsNullable = false;
                colvarPhenonmenonUOMID.IsPrimaryKey = false;
                colvarPhenonmenonUOMID.IsForeignKey = false;
                colvarPhenonmenonUOMID.IsReadOnly = false;
                
                schema.Columns.Add(colvarPhenonmenonUOMID);
                
                TableSchema.TableColumn colvarUserId = new TableSchema.TableColumn(schema);
                colvarUserId.ColumnName = "UserId";
                colvarUserId.DataType = DbType.Guid;
                colvarUserId.MaxLength = 0;
                colvarUserId.AutoIncrement = false;
                colvarUserId.IsNullable = false;
                colvarUserId.IsPrimaryKey = false;
                colvarUserId.IsForeignKey = false;
                colvarUserId.IsReadOnly = false;
                
                schema.Columns.Add(colvarUserId);
                
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
                
                TableSchema.TableColumn colvarSpCode = new TableSchema.TableColumn(schema);
                colvarSpCode.ColumnName = "spCode";
                colvarSpCode.DataType = DbType.AnsiString;
                colvarSpCode.MaxLength = 50;
                colvarSpCode.AutoIncrement = false;
                colvarSpCode.IsNullable = false;
                colvarSpCode.IsPrimaryKey = false;
                colvarSpCode.IsForeignKey = false;
                colvarSpCode.IsReadOnly = false;
                
                schema.Columns.Add(colvarSpCode);
                
                TableSchema.TableColumn colvarSpDesc = new TableSchema.TableColumn(schema);
                colvarSpDesc.ColumnName = "spDesc";
                colvarSpDesc.DataType = DbType.AnsiString;
                colvarSpDesc.MaxLength = 5000;
                colvarSpDesc.AutoIncrement = false;
                colvarSpDesc.IsNullable = true;
                colvarSpDesc.IsPrimaryKey = false;
                colvarSpDesc.IsForeignKey = false;
                colvarSpDesc.IsReadOnly = false;
                
                schema.Columns.Add(colvarSpDesc);
                
                TableSchema.TableColumn colvarSpName = new TableSchema.TableColumn(schema);
                colvarSpName.ColumnName = "spName";
                colvarSpName.DataType = DbType.AnsiString;
                colvarSpName.MaxLength = 150;
                colvarSpName.AutoIncrement = false;
                colvarSpName.IsNullable = false;
                colvarSpName.IsPrimaryKey = false;
                colvarSpName.IsForeignKey = false;
                colvarSpName.IsReadOnly = false;
                
                schema.Columns.Add(colvarSpName);
                
                TableSchema.TableColumn colvarSpURL = new TableSchema.TableColumn(schema);
                colvarSpURL.ColumnName = "spURL";
                colvarSpURL.DataType = DbType.AnsiString;
                colvarSpURL.MaxLength = 250;
                colvarSpURL.AutoIncrement = false;
                colvarSpURL.IsNullable = true;
                colvarSpURL.IsPrimaryKey = false;
                colvarSpURL.IsForeignKey = false;
                colvarSpURL.IsReadOnly = false;
                
                schema.Columns.Add(colvarSpURL);
                
                TableSchema.TableColumn colvarDataSchemaID = new TableSchema.TableColumn(schema);
                colvarDataSchemaID.ColumnName = "DataSchemaID";
                colvarDataSchemaID.DataType = DbType.Guid;
                colvarDataSchemaID.MaxLength = 0;
                colvarDataSchemaID.AutoIncrement = false;
                colvarDataSchemaID.IsNullable = true;
                colvarDataSchemaID.IsPrimaryKey = false;
                colvarDataSchemaID.IsForeignKey = false;
                colvarDataSchemaID.IsReadOnly = false;
                
                schema.Columns.Add(colvarDataSchemaID);
                
                TableSchema.TableColumn colvarDataSourceID = new TableSchema.TableColumn(schema);
                colvarDataSourceID.ColumnName = "DataSourceID";
                colvarDataSourceID.DataType = DbType.Guid;
                colvarDataSourceID.MaxLength = 0;
                colvarDataSourceID.AutoIncrement = false;
                colvarDataSourceID.IsNullable = false;
                colvarDataSourceID.IsPrimaryKey = false;
                colvarDataSourceID.IsForeignKey = false;
                colvarDataSourceID.IsReadOnly = false;
                
                schema.Columns.Add(colvarDataSourceID);
                
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
                
                TableSchema.TableColumn colvarStationID = new TableSchema.TableColumn(schema);
                colvarStationID.ColumnName = "StationID";
                colvarStationID.DataType = DbType.Guid;
                colvarStationID.MaxLength = 0;
                colvarStationID.AutoIncrement = false;
                colvarStationID.IsNullable = false;
                colvarStationID.IsPrimaryKey = false;
                colvarStationID.IsForeignKey = false;
                colvarStationID.IsReadOnly = false;
                
                schema.Columns.Add(colvarStationID);
                
                TableSchema.TableColumn colvarPhName = new TableSchema.TableColumn(schema);
                colvarPhName.ColumnName = "phName";
                colvarPhName.DataType = DbType.AnsiString;
                colvarPhName.MaxLength = 150;
                colvarPhName.AutoIncrement = false;
                colvarPhName.IsNullable = false;
                colvarPhName.IsPrimaryKey = false;
                colvarPhName.IsForeignKey = false;
                colvarPhName.IsReadOnly = false;
                
                schema.Columns.Add(colvarPhName);
                
                TableSchema.TableColumn colvarStName = new TableSchema.TableColumn(schema);
                colvarStName.ColumnName = "stName";
                colvarStName.DataType = DbType.AnsiString;
                colvarStName.MaxLength = 150;
                colvarStName.AutoIncrement = false;
                colvarStName.IsNullable = false;
                colvarStName.IsPrimaryKey = false;
                colvarStName.IsForeignKey = false;
                colvarStName.IsReadOnly = false;
                
                schema.Columns.Add(colvarStName);
                
                TableSchema.TableColumn colvarDsName = new TableSchema.TableColumn(schema);
                colvarDsName.ColumnName = "dsName";
                colvarDsName.DataType = DbType.AnsiString;
                colvarDsName.MaxLength = 150;
                colvarDsName.AutoIncrement = false;
                colvarDsName.IsNullable = false;
                colvarDsName.IsPrimaryKey = false;
                colvarDsName.IsForeignKey = false;
                colvarDsName.IsReadOnly = false;
                
                schema.Columns.Add(colvarDsName);
                
                TableSchema.TableColumn colvarDschemaName = new TableSchema.TableColumn(schema);
                colvarDschemaName.ColumnName = "dschemaName";
                colvarDschemaName.DataType = DbType.AnsiString;
                colvarDschemaName.MaxLength = 100;
                colvarDschemaName.AutoIncrement = false;
                colvarDschemaName.IsNullable = true;
                colvarDschemaName.IsPrimaryKey = false;
                colvarDschemaName.IsForeignKey = false;
                colvarDschemaName.IsReadOnly = false;
                
                schema.Columns.Add(colvarDschemaName);
                
                TableSchema.TableColumn colvarOffName = new TableSchema.TableColumn(schema);
                colvarOffName.ColumnName = "offName";
                colvarOffName.DataType = DbType.AnsiString;
                colvarOffName.MaxLength = 150;
                colvarOffName.AutoIncrement = false;
                colvarOffName.IsNullable = false;
                colvarOffName.IsPrimaryKey = false;
                colvarOffName.IsForeignKey = false;
                colvarOffName.IsReadOnly = false;
                
                schema.Columns.Add(colvarOffName);
                
                TableSchema.TableColumn colvarOffID = new TableSchema.TableColumn(schema);
                colvarOffID.ColumnName = "offID";
                colvarOffID.DataType = DbType.Guid;
                colvarOffID.MaxLength = 0;
                colvarOffID.AutoIncrement = false;
                colvarOffID.IsNullable = false;
                colvarOffID.IsPrimaryKey = false;
                colvarOffID.IsForeignKey = false;
                colvarOffID.IsReadOnly = false;
                
                schema.Columns.Add(colvarOffID);
                
                TableSchema.TableColumn colvarPsName = new TableSchema.TableColumn(schema);
                colvarPsName.ColumnName = "psName";
                colvarPsName.DataType = DbType.AnsiString;
                colvarPsName.MaxLength = 150;
                colvarPsName.AutoIncrement = false;
                colvarPsName.IsNullable = false;
                colvarPsName.IsPrimaryKey = false;
                colvarPsName.IsForeignKey = false;
                colvarPsName.IsReadOnly = false;
                
                schema.Columns.Add(colvarPsName);
                
                TableSchema.TableColumn colvarPsID = new TableSchema.TableColumn(schema);
                colvarPsID.ColumnName = "psID";
                colvarPsID.DataType = DbType.Guid;
                colvarPsID.MaxLength = 0;
                colvarPsID.AutoIncrement = false;
                colvarPsID.IsNullable = false;
                colvarPsID.IsPrimaryKey = false;
                colvarPsID.IsForeignKey = false;
                colvarPsID.IsReadOnly = false;
                
                schema.Columns.Add(colvarPsID);
                
                TableSchema.TableColumn colvarOrgName = new TableSchema.TableColumn(schema);
                colvarOrgName.ColumnName = "orgName";
                colvarOrgName.DataType = DbType.AnsiString;
                colvarOrgName.MaxLength = 150;
                colvarOrgName.AutoIncrement = false;
                colvarOrgName.IsNullable = false;
                colvarOrgName.IsPrimaryKey = false;
                colvarOrgName.IsForeignKey = false;
                colvarOrgName.IsReadOnly = false;
                
                schema.Columns.Add(colvarOrgName);
                
                TableSchema.TableColumn colvarOrgID = new TableSchema.TableColumn(schema);
                colvarOrgID.ColumnName = "orgID";
                colvarOrgID.DataType = DbType.Guid;
                colvarOrgID.MaxLength = 0;
                colvarOrgID.AutoIncrement = false;
                colvarOrgID.IsNullable = false;
                colvarOrgID.IsPrimaryKey = false;
                colvarOrgID.IsForeignKey = false;
                colvarOrgID.IsReadOnly = false;
                
                schema.Columns.Add(colvarOrgID);
                
                TableSchema.TableColumn colvarUomUnit = new TableSchema.TableColumn(schema);
                colvarUomUnit.ColumnName = "uomUnit";
                colvarUomUnit.DataType = DbType.AnsiString;
                colvarUomUnit.MaxLength = 100;
                colvarUomUnit.AutoIncrement = false;
                colvarUomUnit.IsNullable = false;
                colvarUomUnit.IsPrimaryKey = false;
                colvarUomUnit.IsForeignKey = false;
                colvarUomUnit.IsReadOnly = false;
                
                schema.Columns.Add(colvarUomUnit);
                
                TableSchema.TableColumn colvarUomSymbol = new TableSchema.TableColumn(schema);
                colvarUomSymbol.ColumnName = "uomSymbol";
                colvarUomSymbol.DataType = DbType.AnsiString;
                colvarUomSymbol.MaxLength = 20;
                colvarUomSymbol.AutoIncrement = false;
                colvarUomSymbol.IsNullable = false;
                colvarUomSymbol.IsPrimaryKey = false;
                colvarUomSymbol.IsForeignKey = false;
                colvarUomSymbol.IsReadOnly = false;
                
                schema.Columns.Add(colvarUomSymbol);
                
                TableSchema.TableColumn colvarUserName = new TableSchema.TableColumn(schema);
                colvarUserName.ColumnName = "UserName";
                colvarUserName.DataType = DbType.String;
                colvarUserName.MaxLength = 256;
                colvarUserName.AutoIncrement = false;
                colvarUserName.IsNullable = false;
                colvarUserName.IsPrimaryKey = false;
                colvarUserName.IsForeignKey = false;
                colvarUserName.IsReadOnly = false;
                
                schema.Columns.Add(colvarUserName);
                
                TableSchema.TableColumn colvarExpr2 = new TableSchema.TableColumn(schema);
                colvarExpr2.ColumnName = "Expr2";
                colvarExpr2.DataType = DbType.Guid;
                colvarExpr2.MaxLength = 0;
                colvarExpr2.AutoIncrement = false;
                colvarExpr2.IsNullable = false;
                colvarExpr2.IsPrimaryKey = false;
                colvarExpr2.IsForeignKey = false;
                colvarExpr2.IsReadOnly = false;
                
                schema.Columns.Add(colvarExpr2);
                
                TableSchema.TableColumn colvarDateStart = new TableSchema.TableColumn(schema);
                colvarDateStart.ColumnName = "DateStart";
                colvarDateStart.DataType = DbType.DateTime;
                colvarDateStart.MaxLength = 0;
                colvarDateStart.AutoIncrement = false;
                colvarDateStart.IsNullable = true;
                colvarDateStart.IsPrimaryKey = false;
                colvarDateStart.IsForeignKey = false;
                colvarDateStart.IsReadOnly = false;
                
                schema.Columns.Add(colvarDateStart);
                
                TableSchema.TableColumn colvarDateEnd = new TableSchema.TableColumn(schema);
                colvarDateEnd.ColumnName = "DateEnd";
                colvarDateEnd.DataType = DbType.DateTime;
                colvarDateEnd.MaxLength = 0;
                colvarDateEnd.AutoIncrement = false;
                colvarDateEnd.IsNullable = true;
                colvarDateEnd.IsPrimaryKey = false;
                colvarDateEnd.IsForeignKey = false;
                colvarDateEnd.IsReadOnly = false;
                
                schema.Columns.Add(colvarDateEnd);
                
                TableSchema.TableColumn colvarExpr5 = new TableSchema.TableColumn(schema);
                colvarExpr5.ColumnName = "Expr5";
                colvarExpr5.DataType = DbType.Guid;
                colvarExpr5.MaxLength = 0;
                colvarExpr5.AutoIncrement = false;
                colvarExpr5.IsNullable = false;
                colvarExpr5.IsPrimaryKey = false;
                colvarExpr5.IsForeignKey = false;
                colvarExpr5.IsReadOnly = false;
                
                schema.Columns.Add(colvarExpr5);
                
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
                DataService.Providers["ObservationsDB"].AddSchema("vObservationRoles",schema);
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
	    public VObservationRole()
	    {
            SetSQLProps();
            SetDefaults();
            MarkNew();
        }
        public VObservationRole(bool useDatabaseDefaults)
	    {
		    SetSQLProps();
		    if(useDatabaseDefaults)
		    {
				ForceDefaults();
			}
			MarkNew();
	    }
	    
	    public VObservationRole(object keyID)
	    {
		    SetSQLProps();
		    LoadByKey(keyID);
	    }
    	 
	    public VObservationRole(string columnName, object columnValue)
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
	      
        [XmlAttribute("SensorProcedureID")]
        [Bindable(true)]
        public Guid SensorProcedureID 
	    {
		    get
		    {
			    return GetColumnValue<Guid>("SensorProcedureID");
		    }
            set 
		    {
			    SetColumnValue("SensorProcedureID", value);
            }
        }
	      
        [XmlAttribute("PhenonmenonOfferingID")]
        [Bindable(true)]
        public Guid PhenonmenonOfferingID 
	    {
		    get
		    {
			    return GetColumnValue<Guid>("PhenonmenonOfferingID");
		    }
            set 
		    {
			    SetColumnValue("PhenonmenonOfferingID", value);
            }
        }
	      
        [XmlAttribute("PhenonmenonUOMID")]
        [Bindable(true)]
        public Guid PhenonmenonUOMID 
	    {
		    get
		    {
			    return GetColumnValue<Guid>("PhenonmenonUOMID");
		    }
            set 
		    {
			    SetColumnValue("PhenonmenonUOMID", value);
            }
        }
	      
        [XmlAttribute("UserId")]
        [Bindable(true)]
        public Guid UserId 
	    {
		    get
		    {
			    return GetColumnValue<Guid>("UserId");
		    }
            set 
		    {
			    SetColumnValue("UserId", value);
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
	      
        [XmlAttribute("SpCode")]
        [Bindable(true)]
        public string SpCode 
	    {
		    get
		    {
			    return GetColumnValue<string>("spCode");
		    }
            set 
		    {
			    SetColumnValue("spCode", value);
            }
        }
	      
        [XmlAttribute("SpDesc")]
        [Bindable(true)]
        public string SpDesc 
	    {
		    get
		    {
			    return GetColumnValue<string>("spDesc");
		    }
            set 
		    {
			    SetColumnValue("spDesc", value);
            }
        }
	      
        [XmlAttribute("SpName")]
        [Bindable(true)]
        public string SpName 
	    {
		    get
		    {
			    return GetColumnValue<string>("spName");
		    }
            set 
		    {
			    SetColumnValue("spName", value);
            }
        }
	      
        [XmlAttribute("SpURL")]
        [Bindable(true)]
        public string SpURL 
	    {
		    get
		    {
			    return GetColumnValue<string>("spURL");
		    }
            set 
		    {
			    SetColumnValue("spURL", value);
            }
        }
	      
        [XmlAttribute("DataSchemaID")]
        [Bindable(true)]
        public Guid? DataSchemaID 
	    {
		    get
		    {
			    return GetColumnValue<Guid?>("DataSchemaID");
		    }
            set 
		    {
			    SetColumnValue("DataSchemaID", value);
            }
        }
	      
        [XmlAttribute("DataSourceID")]
        [Bindable(true)]
        public Guid DataSourceID 
	    {
		    get
		    {
			    return GetColumnValue<Guid>("DataSourceID");
		    }
            set 
		    {
			    SetColumnValue("DataSourceID", value);
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
	      
        [XmlAttribute("StationID")]
        [Bindable(true)]
        public Guid StationID 
	    {
		    get
		    {
			    return GetColumnValue<Guid>("StationID");
		    }
            set 
		    {
			    SetColumnValue("StationID", value);
            }
        }
	      
        [XmlAttribute("PhName")]
        [Bindable(true)]
        public string PhName 
	    {
		    get
		    {
			    return GetColumnValue<string>("phName");
		    }
            set 
		    {
			    SetColumnValue("phName", value);
            }
        }
	      
        [XmlAttribute("StName")]
        [Bindable(true)]
        public string StName 
	    {
		    get
		    {
			    return GetColumnValue<string>("stName");
		    }
            set 
		    {
			    SetColumnValue("stName", value);
            }
        }
	      
        [XmlAttribute("DsName")]
        [Bindable(true)]
        public string DsName 
	    {
		    get
		    {
			    return GetColumnValue<string>("dsName");
		    }
            set 
		    {
			    SetColumnValue("dsName", value);
            }
        }
	      
        [XmlAttribute("DschemaName")]
        [Bindable(true)]
        public string DschemaName 
	    {
		    get
		    {
			    return GetColumnValue<string>("dschemaName");
		    }
            set 
		    {
			    SetColumnValue("dschemaName", value);
            }
        }
	      
        [XmlAttribute("OffName")]
        [Bindable(true)]
        public string OffName 
	    {
		    get
		    {
			    return GetColumnValue<string>("offName");
		    }
            set 
		    {
			    SetColumnValue("offName", value);
            }
        }
	      
        [XmlAttribute("OffID")]
        [Bindable(true)]
        public Guid OffID 
	    {
		    get
		    {
			    return GetColumnValue<Guid>("offID");
		    }
            set 
		    {
			    SetColumnValue("offID", value);
            }
        }
	      
        [XmlAttribute("PsName")]
        [Bindable(true)]
        public string PsName 
	    {
		    get
		    {
			    return GetColumnValue<string>("psName");
		    }
            set 
		    {
			    SetColumnValue("psName", value);
            }
        }
	      
        [XmlAttribute("PsID")]
        [Bindable(true)]
        public Guid PsID 
	    {
		    get
		    {
			    return GetColumnValue<Guid>("psID");
		    }
            set 
		    {
			    SetColumnValue("psID", value);
            }
        }
	      
        [XmlAttribute("OrgName")]
        [Bindable(true)]
        public string OrgName 
	    {
		    get
		    {
			    return GetColumnValue<string>("orgName");
		    }
            set 
		    {
			    SetColumnValue("orgName", value);
            }
        }
	      
        [XmlAttribute("OrgID")]
        [Bindable(true)]
        public Guid OrgID 
	    {
		    get
		    {
			    return GetColumnValue<Guid>("orgID");
		    }
            set 
		    {
			    SetColumnValue("orgID", value);
            }
        }
	      
        [XmlAttribute("UomUnit")]
        [Bindable(true)]
        public string UomUnit 
	    {
		    get
		    {
			    return GetColumnValue<string>("uomUnit");
		    }
            set 
		    {
			    SetColumnValue("uomUnit", value);
            }
        }
	      
        [XmlAttribute("UomSymbol")]
        [Bindable(true)]
        public string UomSymbol 
	    {
		    get
		    {
			    return GetColumnValue<string>("uomSymbol");
		    }
            set 
		    {
			    SetColumnValue("uomSymbol", value);
            }
        }
	      
        [XmlAttribute("UserName")]
        [Bindable(true)]
        public string UserName 
	    {
		    get
		    {
			    return GetColumnValue<string>("UserName");
		    }
            set 
		    {
			    SetColumnValue("UserName", value);
            }
        }
	      
        [XmlAttribute("Expr2")]
        [Bindable(true)]
        public Guid Expr2 
	    {
		    get
		    {
			    return GetColumnValue<Guid>("Expr2");
		    }
            set 
		    {
			    SetColumnValue("Expr2", value);
            }
        }
	      
        [XmlAttribute("DateStart")]
        [Bindable(true)]
        public DateTime? DateStart 
	    {
		    get
		    {
			    return GetColumnValue<DateTime?>("DateStart");
		    }
            set 
		    {
			    SetColumnValue("DateStart", value);
            }
        }
	      
        [XmlAttribute("DateEnd")]
        [Bindable(true)]
        public DateTime? DateEnd 
	    {
		    get
		    {
			    return GetColumnValue<DateTime?>("DateEnd");
		    }
            set 
		    {
			    SetColumnValue("DateEnd", value);
            }
        }
	      
        [XmlAttribute("Expr5")]
        [Bindable(true)]
        public Guid Expr5 
	    {
		    get
		    {
			    return GetColumnValue<Guid>("Expr5");
		    }
            set 
		    {
			    SetColumnValue("Expr5", value);
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
            
            public static string SensorProcedureID = @"SensorProcedureID";
            
            public static string PhenonmenonOfferingID = @"PhenonmenonOfferingID";
            
            public static string PhenonmenonUOMID = @"PhenonmenonUOMID";
            
            public static string UserId = @"UserId";
            
            public static string RawValue = @"RawValue";
            
            public static string DataValue = @"DataValue";
            
            public static string ImportBatchID = @"ImportBatchID";
            
            public static string ValueDate = @"ValueDate";
            
            public static string SpCode = @"spCode";
            
            public static string SpDesc = @"spDesc";
            
            public static string SpName = @"spName";
            
            public static string SpURL = @"spURL";
            
            public static string DataSchemaID = @"DataSchemaID";
            
            public static string DataSourceID = @"DataSourceID";
            
            public static string PhenomenonID = @"PhenomenonID";
            
            public static string StationID = @"StationID";
            
            public static string PhName = @"phName";
            
            public static string StName = @"stName";
            
            public static string DsName = @"dsName";
            
            public static string DschemaName = @"dschemaName";
            
            public static string OffName = @"offName";
            
            public static string OffID = @"offID";
            
            public static string PsName = @"psName";
            
            public static string PsID = @"psID";
            
            public static string OrgName = @"orgName";
            
            public static string OrgID = @"orgID";
            
            public static string UomUnit = @"uomUnit";
            
            public static string UomSymbol = @"uomSymbol";
            
            public static string UserName = @"UserName";
            
            public static string Expr2 = @"Expr2";
            
            public static string DateStart = @"DateStart";
            
            public static string DateEnd = @"DateEnd";
            
            public static string Expr5 = @"Expr5";
            
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
