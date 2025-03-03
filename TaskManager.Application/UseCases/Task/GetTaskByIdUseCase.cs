using MyTask = TaskManager.Domain.Entities.Tasks;
using TaskManager.Domain.Repositories.Tasks;

namespace TaskManager.Application.UseCases.Task;
public class GetTaskByIdUseCase
{
    private readonly ITaskRepository _taskRepository;

    public GetTaskByIdUseCase(ITaskRepository taskRepository)
    {
        _taskRepository = taskRepository;
    }

    public MyTask.Task? Execute(Guid id)
    {
        return _taskRepository.GetTaskById(id);
    }
}
