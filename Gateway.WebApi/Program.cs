using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Server.IISIntegration;
using Ocelot.DependencyInjection;
using Ocelot.JwtAuthorize;
using Ocelot.Middleware;
using Ocelot.Provider.Consul;
using Ocelot.Requester.Middleware;

var MyAllowSpecificOrigins = "TaskPolicy";

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
        policy =>
        {
            policy.WithOrigins("http://localhost:4200").AllowAnyHeader().AllowAnyMethod();
        });
});
builder.Configuration.AddJsonFile("ocelot.json");
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddOcelot(builder.Configuration).AddConsul();
// cors
var app = builder.Build();
app.UseHttpsRedirection();
app.UseRouting();
app.UseHttpsRedirection();
app.UseCors(MyAllowSpecificOrigins);
app.MapControllers();
app.UseOcelot().Wait();
app.Run();
