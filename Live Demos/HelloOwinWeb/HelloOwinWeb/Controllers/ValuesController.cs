using System.Collections.Generic;
using System.Web.Http;

namespace HelloOwinWeb.Controllers
{
    [RoutePrefix("api/values")]
    public class ValuesController : ApiController
    {
        // GET: api/Values
        [Route("")]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Values/5
        [Route("{id:int}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Values
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Values/5
        public void Delete(int id)
        {
        }
    }
}
