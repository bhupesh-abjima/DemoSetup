
using Microsoft.OpenApi.Models;
using Xamplifier.Api;

var builder = WebApplication.CreateBuilder(args);

builder.Host.ConfigureAppConfiguration((builder, config) =>
{
    string environmentName = builder.HostingEnvironment.EnvironmentName;
    if (builder.HostingEnvironment.IsEnvironment("Local"))
    {
        environmentName = "Development";
    }
});
//    // Parameter Store prefix to pull configuration data from.
//    config.AddSystemsManager($"/Xamplifier-Microservices-Admin-{environmentName}", new TimeSpan(0, 5, 0));
//});
// Add services to the container.

builder.Services.AddCustomMvc();
builder.Services.AddCustomSwagger();
builder.Services.AddCustomAutoMapper();
builder.Services.AddCustomDatabase(builder.Configuration);
builder.Services.AddCustomAssemblies();
builder.Services.AddCustomHealthChecks(builder.Configuration);
builder.Services.AddCustomAuthentication(builder.Configuration);


var app = builder.Build();

// Configure the HTTP request pipeline.
var pathBase = builder.Configuration.GetValue<string>("PathBase"); 
//??
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger(options =>
    {
        options.RouteTemplate = $"{(!string.IsNullOrEmpty(pathBase) ? pathBase + "/" : string.Empty)}{options.RouteTemplate}";
        options.PreSerializeFilters.Add((swaggerDoc, httpReq) =>
        {
            swaggerDoc.Servers = new List<OpenApiServer>
                        {
                            new OpenApiServer
                            {
                                Url = $"{httpReq.Scheme}://{httpReq.Host.Value}{(!string.IsNullOrEmpty(pathBase) ? "/" + pathBase : string.Empty)}"
                            }
                        };
        });
    });
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint($"{(!string.IsNullOrEmpty(pathBase) ? "/" + pathBase : string.Empty)}/swagger/v1/swagger.json", " Xamplifier API");
        c.RoutePrefix = $"{(!string.IsNullOrEmpty(pathBase) ? pathBase + "/" : string.Empty)}{c.RoutePrefix}";
    });
}
if (!string.IsNullOrEmpty(pathBase))
{
    app.UsePathBase("/" + pathBase);
}
app.UseCors("CorsPolicy");
app.UseAuthentication();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
