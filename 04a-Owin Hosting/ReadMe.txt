OWIN Lab - Revised

1. Start a Web Project (under C# in File, New Project.
   - Select Empty Web Project
   
2. Add the NuGet package for Owin web hosting
   Install-Package Microsoft.Owin.Host.SystemWeb
   
3. Install the NuGet package for Web API and OWIN
   Install-Package Microsoft.AspNet.WebApi.Owin
   
4. Add a new item to the project and select
   OWIN Startup Class (search for OWIN).
   
5. In Startup.Configuration enable Web API

    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // Enable attribute-based routing
            var config = new HttpConfiguration();
            config.MapHttpAttributeRoutes();

            // Add Web API to the OWIN pipeline
            app.UseWebApi(config);
        }
    }

6. Add a Controllers folder to the project
  - Add a new Web API 2 controller
  - Select with read/write actions option
  - Add Routing attributes to the class and Get methods
  
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
        
7. Press Ctrl + F5 to start the app
  - Enter the following url
    http://localhost:52460/api/values
  - Values should be returned
  - Enter the following url
    http://localhost:52460/api/values/1
  - A value should be returned  