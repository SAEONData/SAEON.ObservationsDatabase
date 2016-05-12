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
    /// Strongly-typed collection for the VSiteProject class.
    /// </summary>
    [Serializable]
    public partial class VSiteProjectCollection : ReadOnlyList<VSiteProject, VSiteProjectCollection>
    {        
        public VSiteProjectCollection() {}
    }
    /// <summary>
    /// This is  Read-only wrapper class for the vSiteProject view.
    /// </summary>
    [Serializable]
    public partial class VSiteProject : ReadOnlyRecord<VSiteProject>, IReadOnlyRecord
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
                TableSchema.Table schema = new TableSchema.Table("vSiteProject", TableType.View, DataService.GetInstance("ObservationsDB"));
                schema.Columns = new TableSchema.TableColumnCollection();
                schema.SchemaName = @"dbo";
                //columns
                
                TableSchema.TableColumn colvarId = new TableSchema.TableColumn(schema);
                colvarId.ColumnName = "ID";
                colvarId.DataType = DbType.Guid;
                colvarId.MaxLength = 0;
                colvarId.AutoIncrement = false;
                colvarId.IsNullable = false;
                colvarId.IsPrimaryKey = false;
                colvarId.IsForeignKey = false;
                colvarId.IsReadOnly = false;
                
                schema.Columns.Add(colvarId);
                
                TableSchema.TableColumn colvarSiteID = new TableSchema.TableColumn(schema);
                colvarSiteID.ColumnName = "SiteID";
                colvarSiteID.DataType = DbType.Guid;
                colvarSiteID.MaxLength = 0;
                colvarSiteID.AutoIncrement = false;
                colvarSiteID.IsNullable = false;
                colvarSiteID.IsPrimaryKey = false;
                colvarSiteID.IsForeignKey = false;
                colvarSiteID.IsReadOnly = false;
                
                schema.Columns.Add(colvarSiteID);
                
                TableSchema.TableColumn colvarProjectID = new TableSchema.TableColumn(schema);
                colvarProjectID.ColumnName = "ProjectID";
                colvarProjectID.DataType = DbType.Guid;
                colvarProjectID.MaxLength = 0;
                colvarProjectID.AutoIncrement = false;
                colvarProjectID.IsNullable = false;
                colvarProjectID.IsPrimaryKey = false;
                colvarProjectID.IsForeignKey = false;
                colvarProjectID.IsReadOnly = false;
                
                schema.Columns.Add(colvarProjectID);
                
                TableSchema.TableColumn colvarStartDate = new TableSchema.TableColumn(schema);
                colvarStartDate.ColumnName = "StartDate";
                colvarStartDate.DataType = DbType.DateTime;
                colvarStartDate.MaxLength = 0;
                colvarStartDate.AutoIncrement = false;
                colvarStartDate.IsNullable = true;
                colvarStartDate.IsPrimaryKey = false;
                colvarStartDate.IsForeignKey = false;
                colvarStartDate.IsReadOnly = false;
                
                schema.Columns.Add(colvarStartDate);
                
                TableSchema.TableColumn colvarEndDate = new TableSchema.TableColumn(schema);
                colvarEndDate.ColumnName = "EndDate";
                colvarEndDate.DataType = DbType.DateTime;
                colvarEndDate.MaxLength = 0;
                colvarEndDate.AutoIncrement = false;
                colvarEndDate.IsNullable = true;
                colvarEndDate.IsPrimaryKey = false;
                colvarEndDate.IsForeignKey = false;
                colvarEndDate.IsReadOnly = false;
                
                schema.Columns.Add(colvarEndDate);
                
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
                
                TableSchema.TableColumn colvarAddedAt = new TableSchema.TableColumn(schema);
                colvarAddedAt.ColumnName = "AddedAt";
                colvarAddedAt.DataType = DbType.DateTime;
                colvarAddedAt.MaxLength = 0;
                colvarAddedAt.AutoIncrement = false;
                colvarAddedAt.IsNullable = true;
                colvarAddedAt.IsPrimaryKey = false;
                colvarAddedAt.IsForeignKey = false;
                colvarAddedAt.IsReadOnly = false;
                
                schema.Columns.Add(colvarAddedAt);
                
                TableSchema.TableColumn colvarUpdatedAt = new TableSchema.TableColumn(schema);
                colvarUpdatedAt.ColumnName = "UpdatedAt";
                colvarUpdatedAt.DataType = DbType.DateTime;
                colvarUpdatedAt.MaxLength = 0;
                colvarUpdatedAt.AutoIncrement = false;
                colvarUpdatedAt.IsNullable = true;
                colvarUpdatedAt.IsPrimaryKey = false;
                colvarUpdatedAt.IsForeignKey = false;
                colvarUpdatedAt.IsReadOnly = false;
                
                schema.Columns.Add(colvarUpdatedAt);
                
                TableSchema.TableColumn colvarProjectName = new TableSchema.TableColumn(schema);
                colvarProjectName.ColumnName = "ProjectName";
                colvarProjectName.DataType = DbType.AnsiString;
                colvarProjectName.MaxLength = 150;
                colvarProjectName.AutoIncrement = false;
                colvarProjectName.IsNullable = false;
                colvarProjectName.IsPrimaryKey = false;
                colvarProjectName.IsForeignKey = false;
                colvarProjectName.IsReadOnly = false;
                
                schema.Columns.Add(colvarProjectName);
                
                TableSchema.TableColumn colvarSiteName = new TableSchema.TableColumn(schema);
                colvarSiteName.ColumnName = "SiteName";
                colvarSiteName.DataType = DbType.AnsiString;
                colvarSiteName.MaxLength = 150;
                colvarSiteName.AutoIncrement = false;
                colvarSiteName.IsNullable = false;
                colvarSiteName.IsPrimaryKey = false;
                colvarSiteName.IsForeignKey = false;
                colvarSiteName.IsReadOnly = false;
                
                schema.Columns.Add(colvarSiteName);
                
                
                BaseSchema = schema;
                //add this schema to the provider
                //so we can query it later
                DataService.Providers["ObservationsDB"].AddSchema("vSiteProject",schema);
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
	    public VSiteProject()
	    {
            SetSQLProps();
            SetDefaults();
            MarkNew();
        }
        public VSiteProject(bool useDatabaseDefaults)
	    {
		    SetSQLProps();
		    if(useDatabaseDefaults)
		    {
				ForceDefaults();
			}
			MarkNew();
	    }
	    
	    public VSiteProject(object keyID)
	    {
		    SetSQLProps();
		    LoadByKey(keyID);
	    }
    	 
	    public VSiteProject(string columnName, object columnValue)
        {
            SetSQLProps();
            LoadByParam(columnName,columnValue);
        }
        
	    #endregion
	    
	    #region Props
	    
          
        [XmlAttribute("Id")]
        [Bindable(true)]
        public Guid Id 
	    {
		    get
		    {
			    return GetColumnValue<Guid>("ID");
		    }
            set 
		    {
			    SetColumnValue("ID", value);
            }
        }
	      
        [XmlAttribute("SiteID")]
        [Bindable(true)]
        public Guid SiteID 
	    {
		    get
		    {
			    return GetColumnValue<Guid>("SiteID");
		    }
            set 
		    {
			    SetColumnValue("SiteID", value);
            }
        }
	      
        [XmlAttribute("ProjectID")]
        [Bindable(true)]
        public Guid ProjectID 
	    {
		    get
		    {
			    return GetColumnValue<Guid>("ProjectID");
		    }
            set 
		    {
			    SetColumnValue("ProjectID", value);
            }
        }
	      
        [XmlAttribute("StartDate")]
        [Bindable(true)]
        public DateTime? StartDate 
	    {
		    get
		    {
			    return GetColumnValue<DateTime?>("StartDate");
		    }
            set 
		    {
			    SetColumnValue("StartDate", value);
            }
        }
	      
        [XmlAttribute("EndDate")]
        [Bindable(true)]
        public DateTime? EndDate 
	    {
		    get
		    {
			    return GetColumnValue<DateTime?>("EndDate");
		    }
            set 
		    {
			    SetColumnValue("EndDate", value);
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
	      
        [XmlAttribute("AddedAt")]
        [Bindable(true)]
        public DateTime? AddedAt 
	    {
		    get
		    {
			    return GetColumnValue<DateTime?>("AddedAt");
		    }
            set 
		    {
			    SetColumnValue("AddedAt", value);
            }
        }
	      
        [XmlAttribute("UpdatedAt")]
        [Bindable(true)]
        public DateTime? UpdatedAt 
	    {
		    get
		    {
			    return GetColumnValue<DateTime?>("UpdatedAt");
		    }
            set 
		    {
			    SetColumnValue("UpdatedAt", value);
            }
        }
	      
        [XmlAttribute("ProjectName")]
        [Bindable(true)]
        public string ProjectName 
	    {
		    get
		    {
			    return GetColumnValue<string>("ProjectName");
		    }
            set 
		    {
			    SetColumnValue("ProjectName", value);
            }
        }
	      
        [XmlAttribute("SiteName")]
        [Bindable(true)]
        public string SiteName 
	    {
		    get
		    {
			    return GetColumnValue<string>("SiteName");
		    }
            set 
		    {
			    SetColumnValue("SiteName", value);
            }
        }
	    
	    #endregion
    
	    #region Columns Struct
	    public struct Columns
	    {
		    
		    
            public static string Id = @"ID";
            
            public static string SiteID = @"SiteID";
            
            public static string ProjectID = @"ProjectID";
            
            public static string StartDate = @"StartDate";
            
            public static string EndDate = @"EndDate";
            
            public static string UserId = @"UserId";
            
            public static string AddedAt = @"AddedAt";
            
            public static string UpdatedAt = @"UpdatedAt";
            
            public static string ProjectName = @"ProjectName";
            
            public static string SiteName = @"SiteName";
            
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
