Migrating to ASP.NET Core 1.0 - RC1

NOTE: To install ASP.NET Core, download and run the installer from https://get.asp.net.
   - Click the "Install for Windows" button.

1. Add a new Web project to the solution need HelloCoreWeb
   - Under ASP.NET 5 Templates, select Web API
   
2. Open project.json file and add the following to dependency:
   Microsoft.AspNet.Mvc.WebApiCompatShim

3. In the ConfigureServices method of Startup.cs,
   add the following code to services.AddMvc()
      .AddWebApiConventions();

4. Copy the contents of ValuesController from HelloOwinWeb
   to HelloCoreWeb
   - Change IHttpActionResult to IActionResult
   - Change [RoutePrefix] to just [Route]