using MyTaskEnums = TaskManager.Domain.Entities.Task.Enums;

namespace TaskManager.Domain.Entities.Tasks;
public class Task
{
    public Guid Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public MyTaskEnums.TaskPriority Priority { get; set; }
    public DateTime EndDate { get; set; }
    public MyTaskEnums.TaskStatus Status { get; set; }

    public Task(string title, string description, MyTaskEnums.TaskPriority priority, DateTime endDate, MyTaskEnums.TaskStatus status)
    {
        Id = Guid.NewGuid();
        Title = title;
        Description = description;
        Priority = priority;
        EndDate = endDate;
        Status = status;
    }
}
