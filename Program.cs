using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoEfNet7;

var builder = WebApplication.CreateBuilder(args);
// builder.Services.AddDbContext<TaskContext>(p => p.UseInMemoryDatabase("TareasDB"));
builder.Services.AddNpgsql<TaskContext>(builder.Configuration.GetConnectionString("cnToDo"));
AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");
app.MapGet("/dbconnection", async ([FromServices] TaskContext dbContext) =>
{
  dbContext.Database.EnsureCreated();
  return Results.Ok("MemoryDb: " + dbContext.Database.IsInMemory());
});

app.Run();
