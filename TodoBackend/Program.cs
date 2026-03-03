using Microsoft.EntityFrameworkCore;
using TodoBackend.Data;
using TodoBackend.Middlewares;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("AppDb")));

builder.Services.AddTransient<MyMiddleware>();

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.MapOpenApi();
}


///// Middleware
app.UseMiddleware<MyMiddleware>(); // MyMiddleware class
app.UseConventionalMiddleware(); // Conventional Middleware with UseConventionalMiddleware Extensions


app.UseHttpsRedirection(); 

app.UseAuthorization();

app.MapControllers();

app.Run();
