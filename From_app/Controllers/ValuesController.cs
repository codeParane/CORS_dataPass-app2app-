using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using dbCore.Models;

namespace dbCore.Controllers
{
    [Route("api/[controller]")]
    // [ValuesController]
    public class ValuesController : ControllerBase
    {
        // retuen the all data from tb_data as list
        [HttpGet]
        public IEnumerable<Book> Get()
        {
            using (From_Context db = new From_Context())
            {
                return db.tb_data.ToList();
            }
        }
       
    }
}
