using Microsoft.EntityFrameworkCore;
using ToDo_API.Data;
using ToDo_API.Repositorys.Groups;
using ToDo_API.Repositorys.ToDoTasks;
using ToDo_API.Services.Groups;
using ToDo_API.Services.ToDoTasks;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Register DbContext
builder.Services.AddDbContext<ToDoDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DevConnection")));

// Register Dependencies
builder.Services.AddScoped<IToDoTasksService, ToDoTasksService>();
builder.Services.AddScoped<IToDoTasksRepository, ToDoTasksRepository>();
builder.Services.AddScoped<IGroupsService, GroupsService>();
builder.Services.AddScoped<IGroupsRepository, GroupsRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
