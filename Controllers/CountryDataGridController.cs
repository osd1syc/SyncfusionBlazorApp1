using System.Collections;
using System.Collections.Generic;
using Syncfusion.Blazor;
using Newtonsoft.Json;
using System.Linq;
using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SyncfusionBlazorApp1.Models;
using SyncfusionBlazorApp1.Data;
using Microsoft.EntityFrameworkCore.SqlServer;

namespace SyncfusionBlazorApp1.Controllers
{

  
	    public class CountryDataGridController : ControllerBase
        {
         UniversityDbContext db=new UniversityDbContext();

        public CountryDataGridController(UniversityDbContext db)
        {
            this.db = db;
        }

        public DbSet<Country> GetAllCountry()
        {
			try
			{
				return db.Country;
			}
			catch
			{
				throw;
			}
        }
              
       // POST api/<controller>
        [HttpPost]
        [Route("api/[controller]")]
        public Object Post([FromBody]DataManagerRequest dm)
        {
            IEnumerable DataSource = GetAllCountry().ToList();
            if (dm.Search != null && dm.Search.Count > 0)
            {
                DataSource = DataOperations.PerformSearching(DataSource, dm.Search);  //Search
            }
            if (dm.Sorted != null && dm.Sorted.Count > 0) //Sorting
            {
                DataSource = DataOperations.PerformSorting(DataSource, dm.Sorted);
            }
            if (dm.Where != null && dm.Where.Count > 0) //Filtering
            {
                DataSource = DataOperations.PerformFiltering(DataSource, dm.Where, dm.Where[0].Operator);
            }
            int count = DataSource.Cast<Country>().Count();
            if (dm.Skip != 0)
            {
                DataSource = DataOperations.PerformSkip(DataSource, dm.Skip);   //Paging
            }
            if (dm.Take != 0)
            {
                DataSource = DataOperations.PerformTake(DataSource, dm.Take);
            }
           return dm.RequiresCounts ?  new { result = DataSource, count = count } : DataSource as object;
         
        }
				 [HttpPost]
        [Route("api/CountryDataGrid/Insert")]
        public void Insert([FromBody]CRUDModel<Country> Data)
        {
            try
            {
                if(Data.Value!=null)
                {
                    db.Country.Add(Data.Value);
                    db.SaveChanges();
                }
            }
            catch
            {
                throw;
            }
        }
        [HttpPost]
        [Route("api/CountryDataGrid/UpdateCountry")]
        public void UpdateCountry([FromBody]CRUDModel<Country> Data)
        {
            try
            {
                db.Entry(Data.Value!).State = EntityState.Modified;
                db.SaveChanges();
            }
            catch
            {
                throw;
            }
        }
        [HttpPost]
        [Route("api/CountryDataGrid/DeleteCountry")]
        public void DeleteCountry([FromBody]CRUDModel<Country> Data)
        {
            try
            {
              Country? ord = db.Country.Find(int.Parse(Data.Key!.ToString()!));
              db.Country.Remove(ord!);
              db.SaveChanges();
            }
            catch
            {
               throw;
             }
        }
		       
        public class CRUDModel<T> where T : class
        {
		 [JsonProperty("action")]
            public string? Action { get; set; }
            [JsonProperty("table")]
            public string? Table { get; set; }
            [JsonProperty("keyColumn")]
            public string? KeyColumn { get; set; }
            [JsonProperty("key")]
            public object? Key { get; set; }
            [JsonProperty("value")]
            public T? Value { get; set; }
            [JsonProperty("added")]
            public List<T>? Added { get; set; }
            [JsonProperty("changed")]
            public List<T>? Changed { get; set; }
            [JsonProperty("deleted")]
            public List<T>? Deleted { get; set; }
            [JsonProperty("params")]
            public IDictionary<string, object>? Params { get; set; }
        }
	 }	
   
}