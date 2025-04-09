using ToDo_API.Startup;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.RegisterDbContext(builder.Configuration);
builder.Services.RegisterServices();

var app = builder.Build();

app.ConfigureCors();
app.UseSwaggerDocs();

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
