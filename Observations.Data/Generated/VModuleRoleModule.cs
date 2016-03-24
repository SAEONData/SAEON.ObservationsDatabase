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
    /// Strongly-typed collection for the VModuleRoleModule class.
    /// </summary>
    [Serializable]
    public partial class VModuleRoleModuleCollection : ReadOnlyList<VModuleRoleModule, VModuleRoleModuleCollection>
    {        
        public VModuleRoleModuleCollection() {}
    }
    /// <summary>
    /// This is  Read-only wrapper class for the vModuleRoleModule view.
    /// </summary>
    [Serializable]
    public partial class VModuleRoleModule : ReadOnlyRecord<VModuleRoleModule>, IReadOnlyRecord
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
                TableSchema.Table schema = new TableSchema.Table("vModuleRoleModule", TableType.View, DataService.GetInstance("ObservationsDB"));
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
                
                TableSchema.TableColumn colvarRoleId = new TableSchema.TableColumn(schema);
                colvarRoleId.ColumnName = "RoleId";
                colvarRoleId.DataType = DbType.Guid;
                colvarRoleId.MaxLength = 0;
                colvarRoleId.AutoIncrement = false;
                colvarRoleId.IsNullable = false;
                colvarRoleId.IsPrimaryKey = false;
                colvarRoleId.IsForeignKey = false;
                colvarRoleId.IsReadOnly = false;
                
                schema.Columns.Add(colvarRoleId);
                
                TableSchema.TableColumn colvarModuleID = new TableSchema.TableColumn(schema);
                colvarModuleID.ColumnName = "ModuleID";
                colvarModuleID.DataType = DbType.Guid;
                colvarModuleID.MaxLength = 0;
                colvarModuleID.AutoIncrement = false;
                colvarModuleID.IsNullable = false;
                colvarModuleID.IsPrimaryKey = false;
                colvarModuleID.IsForeignKey = false;
                colvarModuleID.IsReadOnly = false;
                
                schema.Columns.Add(colvarModuleID);
                
                TableSchema.TableColumn colvarName = new TableSchema.TableColumn(schema);
                colvarName.ColumnName = "Name";
                colvarName.DataType = DbType.AnsiString;
                colvarName.MaxLength = 100;
                colvarName.AutoIncrement = false;
                colvarName.IsNullable = false;
                colvarName.IsPrimaryKey = false;
                colvarName.IsForeignKey = false;
                colvarName.IsReadOnly = false;
                
                schema.Columns.Add(colvarName);
                
                TableSchema.TableColumn colvarDescription = new TableSchema.TableColumn(schema);
                colvarDescription.ColumnName = "Description";
                colvarDescription.DataType = DbType.AnsiString;
                colvarDescription.MaxLength = 500;
                colvarDescription.AutoIncrement = false;
                colvarDescription.IsNullable = false;
                colvarDescription.IsPrimaryKey = false;
                colvarDescription.IsForeignKey = false;
                colvarDescription.IsReadOnly = false;
                
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
                
                schema.Columns.Add(colvarUrl);
                
                TableSchema.TableColumn colvarIcon = new TableSchema.TableColumn(schema);
                colvarIcon.ColumnName = "Icon";
                colvarIcon.DataType = DbType.Int32;
                colvarIcon.MaxLength = 0;
                colvarIcon.AutoIncrement = false;
                colvarIcon.IsNullable = false;
                colvarIcon.IsPrimaryKey = false;
                colvarIcon.IsForeignKey = false;
                colvarIcon.IsReadOnly = false;
                
                schema.Columns.Add(colvarIcon);
                
                TableSchema.TableColumn colvarBaseModuleID = new TableSchema.TableColumn(schema);
                colvarBaseModuleID.ColumnName = "BaseModuleID";
                colvarBaseModuleID.DataType = DbType.Guid;
                colvarBaseModuleID.MaxLength = 0;
                colvarBaseModuleID.AutoIncrement = false;
                colvarBaseModuleID.IsNullable = true;
                colvarBaseModuleID.IsPrimaryKey = false;
                colvarBaseModuleID.IsForeignKey = false;
                colvarBaseModuleID.IsReadOnly = false;
                
                schema.Columns.Add(colvarBaseModuleID);
                
                
                BaseSchema = schema;
                //add this schema to the provider
                //so we can query it later
                DataService.Providers["ObservationsDB"].AddSchema("vModuleRoleModule",schema);
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
	    public VModuleRoleModule()
	    {
            SetSQLProps();
            SetDefaults();
            MarkNew();
        }
        public VModuleRoleModule(bool useDatabaseDefaults)
	    {
		    SetSQLProps();
		    if(useDatabaseDefaults)
		    {
				ForceDefaults();
			}
			MarkNew();
	    }
	    
	    public VModuleRoleModule(object keyID)
	    {
		    SetSQLProps();
		    LoadByKey(keyID);
	    }
    	 
	    public VModuleRoleModule(string columnName, object columnValue)
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
	      
        [XmlAttribute("RoleId")]
        [Bindable(true)]
        public Guid RoleId 
	    {
		    get
		    {
			    return GetColumnValue<Guid>("RoleId");
		    }
            set 
		    {
			    SetColumnValue("RoleId", value);
            }
        }
	      
        [XmlAttribute("ModuleID")]
        [Bindable(true)]
        public Guid ModuleID 
	    {
		    get
		    {
			    return GetColumnValue<Guid>("ModuleID");
		    }
            set 
		    {
			    SetColumnValue("ModuleID", value);
            }
        }
	      
        [XmlAttribute("Name")]
        [Bindable(true)]
        public string Name 
	    {
		    get
		    {
			    return GetColumnValue<string>("Name");
		    }
            set 
		    {
			    SetColumnValue("Name", value);
            }
        }
	      
        [XmlAttribute("Description")]
        [Bindable(true)]
        public string Description 
	    {
		    get
		    {
			    return GetColumnValue<string>("Description");
		    }
            set 
		    {
			    SetColumnValue("Description", value);
            }
        }
	      
        [XmlAttribute("Url")]
        [Bindable(true)]
        public string Url 
	    {
		    get
		    {
			    return GetColumnValue<string>("Url");
		    }
            set 
		    {
			    SetColumnValue("Url", value);
            }
        }
	      
        [XmlAttribute("Icon")]
        [Bindable(true)]
        public int Icon 
	    {
		    get
		    {
			    return GetColumnValue<int>("Icon");
		    }
            set 
		    {
			    SetColumnValue("Icon", value);
            }
        }
	      
        [XmlAttribute("BaseModuleID")]
        [Bindable(true)]
        public Guid? BaseModuleID 
	    {
		    get
		    {
			    return GetColumnValue<Guid?>("BaseModuleID");
		    }
            set 
		    {
			    SetColumnValue("BaseModuleID", value);
            }
        }
	    
	    #endregion
    
	    #region Columns Struct
	    public struct Columns
	    {
		    
		    
            public static string Id = @"ID";
            
            public static string RoleId = @"RoleId";
            
            public static string ModuleID = @"ModuleID";
            
            public static string Name = @"Name";
            
            public static string Description = @"Description";
            
            public static string Url = @"Url";
            
            public static string Icon = @"Icon";
            
            public static string BaseModuleID = @"BaseModuleID";
            
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
