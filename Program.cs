using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoEfNet7;
using TodoEfNet7.Models;
using Task = TodoEfNet7.Models.Task;

var builder = WebApplication.CreateBuilder(args);
// builder.Services.AddDbContext<TaskContext>(p => p.UseInMemoryDatabase("TareasDB"));
builder.Services.AddNpgsql<TaskContext>(builder.Configuration.GetConnectionString("cnToDo"));
AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");
app.MapGet("/dbconnection", ([FromServices] TaskContext dbContext) =>
{
  dbContext.Database.EnsureCreated();
  return Results.Ok("MemoryDb: " + dbContext.Database.IsInMemory());
});
app.MapGet("/api/tasks", ([FromServices] TaskContext dbContext) =>
{
  return Results.Ok(dbContext.Tasks.Include(t => t.Category));
});

app.MapPost("/api/tasks", async ([FromServices] TaskContext dbContext, [FromBody] Task task) =>
{
  task.TaskId = Guid.NewGuid();
  task.CreationDate = DateTime.Now;
  await dbContext.AddAsync(task);
  // await dbContext.Tasks.AddAsync(task);
  await dbContext.SaveChangesAsync();
  return Results.Ok();
});

app.MapPut("/api/tasks/{id}", async ([FromServices] TaskContext dbContext, [FromBody] Task task, [FromRoute] Guid id) =>
{
  var actualTask = dbContext.Tasks.Find(id);
  if (actualTask != null)
  {
    actualTask.CategoryId = task.CategoryId;
    actualTask.Title = task.Title;
    actualTask.PriorityTask = task.PriorityTask;
    actualTask.Description = task.Description;

    await dbContext.SaveChangesAsync();
    return Results.Ok();
  }
  return Results.NotFound();
});

app.MapDelete("/api/tasks/{id}", async ([FromServices] TaskContext dbContext, [FromRoute] Guid id) =>
{
  var actualTask = dbContext.Tasks.Find(id);
  if (actualTask != null)
  {
    dbContext.Remove(actualTask);
    await dbContext.SaveChangesAsync();
    return Results.Ok();
  }
  return Results.NotFound();
});


app.Run();
