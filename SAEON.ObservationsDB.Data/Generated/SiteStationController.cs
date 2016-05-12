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
namespace SAEON.ObservationsDB.Data
{
    /// <summary>
    /// Controller class for Site_Station
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class SiteStationController
    {
        // Preload our schema..
        SiteStation thisSchemaLoad = new SiteStation();
        private string userName = String.Empty;
        protected string UserName
        {
            get
            {
				if (userName.Length == 0) 
				{
    				if (System.Web.HttpContext.Current != null)
    				{
						userName=System.Web.HttpContext.Current.User.Identity.Name;
					}
					else
					{
						userName=System.Threading.Thread.CurrentPrincipal.Identity.Name;
					}
				}
				return userName;
            }
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public SiteStationCollection FetchAll()
        {
            SiteStationCollection coll = new SiteStationCollection();
            Query qry = new Query(SiteStation.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public SiteStationCollection FetchByID(object Id)
        {
            SiteStationCollection coll = new SiteStationCollection().Where("ID", Id).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public SiteStationCollection FetchByQuery(Query qry)
        {
            SiteStationCollection coll = new SiteStationCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object Id)
        {
            return (SiteStation.Delete(Id) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object Id)
        {
            return (SiteStation.Destroy(Id) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(Guid Id,Guid SiteID,Guid StationID,DateTime? StartDate,DateTime? EndDate,Guid UserId,DateTime? AddedAt,DateTime? UpdatedAt)
	    {
		    SiteStation item = new SiteStation();
		    
            item.Id = Id;
            
            item.SiteID = SiteID;
            
            item.StationID = StationID;
            
            item.StartDate = StartDate;
            
            item.EndDate = EndDate;
            
            item.UserId = UserId;
            
            item.AddedAt = AddedAt;
            
            item.UpdatedAt = UpdatedAt;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(Guid Id,Guid SiteID,Guid StationID,DateTime? StartDate,DateTime? EndDate,Guid UserId,DateTime? AddedAt,DateTime? UpdatedAt)
	    {
		    SiteStation item = new SiteStation();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.Id = Id;
				
			item.SiteID = SiteID;
				
			item.StationID = StationID;
				
			item.StartDate = StartDate;
				
			item.EndDate = EndDate;
				
			item.UserId = UserId;
				
			item.AddedAt = AddedAt;
				
			item.UpdatedAt = UpdatedAt;
				
	        item.Save(UserName);
	    }
    }
}
