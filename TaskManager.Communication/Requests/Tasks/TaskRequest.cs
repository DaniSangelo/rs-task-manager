using MyTaskEnums = TaskManager.Domain.Entities.Task.Enums;

namespace TaskManager.Communication.Requests.Tasks;

public class TaskRequest
{
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public MyTaskEnums.TaskPriority Priority { get; set; }
    public DateTime EndDate { get; set; }
    public MyTaskEnums.TaskStatus Status { get; set; }
}
