using TaskManager.Communication.Requests.Tasks;
using TaskManager.Domain.Repositories.Tasks;
using MyTask = TaskManager.Domain.Entities.Tasks;

namespace TaskManager.Application.UseCases.Task;

public class CreateTaskUseCase
{
    private readonly ITaskRepository _taskRepository;

    public CreateTaskUseCase(ITaskRepository taskRepository)
    {
        _taskRepository = taskRepository;
    }

    public void Execute(TaskRequest request)
    {
        var task = new MyTask.Task
        (
            request.Title,
            request.Description,
            request.Priority,
            request.EndDate,
            request.Status
        );
        _taskRepository.Create(task);
    }
}
