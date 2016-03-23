﻿using System.Collections.Generic;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;

namespace WebApiQuickstart.Controllers
{
    public class ValuesController : ApiController
    {
        private static readonly List<string> Values = new List<string>
            {
                "value1", "value2", "value3", "value4", "value5"
            };

        // GET api/values
        [ResponseType(typeof(IEnumerable<string>))]
        public IHttpActionResult Get()
        {
            return Ok(Values.ToArray());
        }

        // GET api/values/5
        [ResponseType(typeof(string))]
        public IHttpActionResult Get(int id)
        {
            if (id < 1 || id > Values.Count)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            return Ok(Values[id - 1]);
        }

        // POST api/values
        [ResponseType(typeof(string))]
        public IHttpActionResult Post([FromBody]string value)
        {
            Values.Add(value);
            return CreatedAtRoute("DefaultApi", new { id = Values.Count }, value);
        }

        // PUT api/values/5
        public IHttpActionResult Put(int id, [FromBody]string value)
        {
            if (id < 1 || id > Values.Count)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            Values[id - 1] = value;
            return Ok();
        }

        // DELETE api/values/5
        public IHttpActionResult Delete(int id)
        {
            if (id < 1 || id > Values.Count)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            Values.RemoveAt(id - 1);
            return Ok();
        }
    }
}
