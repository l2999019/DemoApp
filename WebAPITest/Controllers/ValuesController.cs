using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPITest.Models;

namespace WebAPITest.Controllers
{
    public class ValuesController : ApiController
    {
        // GET api/values
        [HttpGet]
        public List<ContextTable> Get(int page,int count)
        {
            using (Models.School_TestEntities entites = new Models.School_TestEntities())
            {
               var date= entites.ContextTable.OrderBy(c => c.ID).Skip((page - 1) * count).Take(count).ToList();
                return date;
            }
                //return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }



        // PUT api/values/5
        public bool UpdateDate(Models.ContextTable datemodel)
        {
           // var date = JsonConvert.DeserializeObject<Models.ContextTable>(value);
            using (Models.School_TestEntities entites = new Models.School_TestEntities())
            {
                var model = entites.ContextTable.Where(a => a.ID == datemodel.ID).FirstOrDefault();
                model.Title = datemodel.Title;
                model.AddTime = datemodel.AddTime;
                model.Context = datemodel.Context;
                
                if (entites.SaveChanges() > 0)
                {
                    return true;
                }
                return false;

            }

        }

        public bool AddDate(Models.ContextTable model)
        {
            var date = model;
            using (Models.School_TestEntities entites = new Models.School_TestEntities())
            {
                entites.ContextTable.Add(date);
                if (entites.SaveChanges() >0)
                {
                    return true;
                }

            }
            return false;
        }
        // DELETE api/values/5
        public bool Delete(int id)
        {
            using (Models.School_TestEntities entites = new Models.School_TestEntities())
            {
                var date = entites.ContextTable.Where(a => a.ID == id).FirstOrDefault();
                entites.ContextTable.Remove(date);
                if (entites.SaveChanges() > 0)
                {
                    return true;
                }
                return false;

            }
        }
    }
}
