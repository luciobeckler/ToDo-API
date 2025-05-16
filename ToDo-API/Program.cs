using ToDo_API.Startup;

var builder = WebApplication.CreateBuilder(args);

// 1) Registra servi�os
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.RegisterDbContext(builder.Configuration, builder.Environment);
builder.RegisterServices();

var app = builder.Build();

// 2) Pipeline de middlewares � esta ordem � obrigat�ria
app.UseSwaggerDocs();
app.UseHttpsRedirection();

app.UseRouting();

app.UseCors("FrontendPolicy"); 
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.Run();
