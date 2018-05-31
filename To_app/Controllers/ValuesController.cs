using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using dbCore.Models;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace dbCore.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : ControllerBase
    {
        [HttpGet]
        public void Post()
        {
            string _frmTblData = string.Empty;
            //retrive data from another app using httpClient
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:5000");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var response = client.GetAsync("api/values/").Result;
                if (response.IsSuccessStatusCode)
                {
                     _frmTblData = response.Content.ReadAsStringAsync().Result;
                }
            }

            //get data from Table toTbl and store as json 
            string _toTblData = String.Empty;
            using (To_Context db = new To_Context())
            {
                var _tblToDataC = db.tb_data.ToList();
                _toTblData = JsonConvert.SerializeObject(_tblToDataC, Formatting.None);
            }

            // convert both json string as list items
            var _lstToTbl = JsonConvert.DeserializeObject<List<Items>>(_toTblData);
            var _lstFromTbl = JsonConvert.DeserializeObject<List<Items>>(_frmTblData);

            //count the items in both lists
            int _totlItemToTbl = _lstToTbl.Count();
            int _totlItemFromTbl = _lstFromTbl.Count();

            //check count of both table if not add new records 
            if(_totlItemToTbl != _totlItemFromTbl){
                for(int i=_totlItemToTbl; i< _totlItemFromTbl;i++){
                    using (To_Context db = new To_Context())
                    {
                        var book = new Book {                 
                                            Books = _lstFromTbl[i].Books, Authors=_lstFromTbl[i].Authors
                                        };
                        db.Add(book);
                        db.SaveChanges();
                    }
                }
            }
        }
        // difine class for Items json object
         public class Items
            {              
                public string Books;
                public string Authors;
            }
    }
}
      


      
