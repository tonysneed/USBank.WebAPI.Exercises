using System.Collections.Generic;
using System.Web.Http;

namespace SwaggerDemo.Web.Controllers
{
    /// <summary>
    /// Return some values
    /// </summary>
    public class ValuesController : ApiController
    {
        // GET api/<controller>
        /// <summary>
        /// Get the values
        /// </summary>
        /// <returns></returns>
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        /// <summary>
        /// Get a value
        /// </summary>
        /// <param name="id">Value identifier</param>
        /// <returns></returns>
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        /// <summary>
        /// Insert a new value
        /// </summary>
        /// <param name="value">New value</param>
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        /// <summary>
        /// Update an existing value
        /// </summary>
        /// <param name="id">Value identifier</param>
        /// <param name="value"></param>
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        /// <summary>
        /// Delete a value
        /// </summary>
        /// <param name="id">Value identifier</param>
        public void Delete(int id)
        {
        }
    }
}