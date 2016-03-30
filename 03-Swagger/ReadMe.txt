Swagger Exercise ReadMe

1. Enable XML documentation
  - Open project properties, build tab
  - Check: XML documentation file
  - Add XML comments to your web api
    > Just insert /// and VS will auto-fill
  - Build the project

2. Install the Swashbuckle Nuget Package
   - Execute the following from the Package Manager Console:
     install-package Swashbuckle
   - Inspect the SwaggerConfig.cs file added to the App_Startup folder

3. Enable support for XML comments in SwaggerConfig
   - Uncomment: c.IncludeXmlComments(GetXmlCommentsPath());
   - Add GetXmlCommentsPath method

	private static string GetXmlCommentsPath()
	{
		return $@"{AppDomain.CurrentDomain.BaseDirectory}\bin\SwaggerDemo.Web.xml";
	}

4. Call the bootstrapper in “Startup” class
   - Place the following line of code just before app.UseWebApi

	SwaggerConfig.Register();
   
5. Run the service and append /token to the url
  - You should see the API documentation and be able to invoke operations as well
  
  