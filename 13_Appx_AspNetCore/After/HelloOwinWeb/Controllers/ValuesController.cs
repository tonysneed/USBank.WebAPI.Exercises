using System.Collections.Generic;
using System.Net;
using System.Web.Http;

namespace HelloOwinWeb.Controllers
{
    [RoutePrefix("api/values")]
    public class ValuesController : ApiController
    {
        private static readonly List<string> Values = new List<string>
            {
                "value1", "value2", "value3", "value4", "value5"
            };

        // GET: api/Values
        [Route("")]
        public IHttpActionResult Get()
        {
            return Ok(Values.ToArray());
        }

        // GET: api/Values/5
        [Route("{id:int}")]
        public IHttpActionResult Get(int id)
        {
            if (id < 1 || id > Values.Count)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            return Ok(Values[id - 1]);
        }

        // POST: api/Values
        [Route("", Name = "DefaultApi")]
        public IHttpActionResult Post([FromBody]string value)
        {
            Values.Add(value);
            return CreatedAtRoute("DefaultApi", new { id = Values.Count }, value);
        }

        // PUT: api/Values/5
        [Route("{id:int}")]
        public IHttpActionResult Put(int id, [FromBody]string value)
        {
            Values[id - 1] = value;
            return Ok(value);
        }

        // DELETE: api/Values/5
        [Route("{id:int}")]
        public IHttpActionResult Delete(int id)
        {
            Values.RemoveAt(id - 1);
            return Ok();
        }
    }
}
