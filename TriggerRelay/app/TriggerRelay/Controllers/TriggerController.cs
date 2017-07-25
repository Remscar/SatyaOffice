using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using TriggerRelay.Logic;

namespace TriggerRelay.Controllers
{
    [Route("api/[controller]/[action]")]
    public class TriggerController : Controller
    {
        //// GET api/trigger
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        // GET api/trigger/New/5
        [HttpGet("{id}")]
        public string New(int id)
        {
            RelayLogic rl = new RelayLogic();
            rl.HandleTrigger(id);
            return "value";
        }

        // GET api/trigger/List/5
        [HttpGet("{id}")]
        public string List(int id)
        {
            return "value";
        }

        // GET api/trigger/Clear/5
        [HttpGet("{id}")]
        public string Clear(int id)
        {
            return "value";
        }


        //// POST api/values
        //[HttpPost]
        //public void Post([FromBody]string value)
        //{
        //}

        //// PUT api/values/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE api/values/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
