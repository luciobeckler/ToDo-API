using Microsoft.EntityFrameworkCore;
using ToDo_API.Startup;

var builder = WebApplication.CreateBuilder(args);

builder.Services.RegisterDbContext(builder.Configuration, builder.Environment);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.RegisterServices();

var app = builder.Build();

// Configura middleware
app.ConfigureCors();
app.UseSwaggerDocs();

app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();
app.Run();
