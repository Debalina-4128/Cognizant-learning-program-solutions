using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerUI;
using WebApi_Handson_3.Filters;

var builder = WebApplication.CreateBuilder(args);

// Services
builder.Services.AddScoped<CustomAuthFilter>();

builder.Services.AddControllers();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Title = "Swagger Demo",
        Version = "v1"
    });
});

var app = builder.Build();

// Middleware
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Swagger Demo");
});

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
