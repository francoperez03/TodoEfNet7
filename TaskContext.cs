using Microsoft.EntityFrameworkCore;
using TodoEfNet7.Models;
using Task = TodoEfNet7.Models.Task;

namespace TodoEfNet7;

public class TaskContext : DbContext
{
  public DbSet<Category> Categories { get; set; }
  public DbSet<Task> Tasks { get; set; }

  public TaskContext(DbContextOptions<TaskContext> options) : base(options) { }

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    List<Category> categoriesInit = new List<Category>();
    categoriesInit.Add(new Category() { CategoryId = Guid.Parse("e3799547-fa23-450c-86a5-35dd27f685e9"), Name = "Actividades pendientes", Weight = 20 });
    categoriesInit.Add(new Category() { CategoryId = Guid.Parse("4d7c7344-73a4-4ced-9bd6-93591a400254"), Name = "Actividades personales", Weight = 50 });

    modelBuilder.Entity<Category>(category =>
    {
      category.ToTable("Category");
      category.HasKey(c => c.CategoryId);
      category.Property(c => c.Name).IsRequired().HasMaxLength(50);
      category.Property(c => c.Description).IsRequired(false);
      category.Property(c => c.Weight);
      category.HasData(categoriesInit);
    });

    List<Task> tasksInit = new List<Task>();
    tasksInit.Add(new Task() { TaskId = Guid.Parse("a4a744c3-e994-458d-b260-0b896b752192"), CategoryId = Guid.Parse("e3799547-fa23-450c-86a5-35dd27f685e9"), PriorityTask = Priority.Medium, Title = "Pago de servicios publicos", CreationDate = DateTime.Now });
    tasksInit.Add(new Task() { TaskId = Guid.Parse("673f244d-657b-46fe-a7fc-fe1fbe3e542e"), CategoryId = Guid.Parse("4d7c7344-73a4-4ced-9bd6-93591a400254"), PriorityTask = Priority.Low, Title = "Terminar de ver peliculas en Netflix", CreationDate = DateTime.Now });


    modelBuilder.Entity<Task>(task =>
    {
      task.ToTable("Task");
      task.HasKey(t => t.TaskId);
      task.HasOne(t => t.Category).WithMany(c => c.Tasks).HasForeignKey(t => t.CategoryId);
      task.Property(t => t.Title).IsRequired().HasMaxLength(200);
      task.Property(t => t.Description).IsRequired(false);
      task.Property(t => t.PriorityTask);
      task.Property(t => t.CreationDate);
      task.Ignore(t => t.Resume);
      task.HasData(tasksInit);
    });
  }

}