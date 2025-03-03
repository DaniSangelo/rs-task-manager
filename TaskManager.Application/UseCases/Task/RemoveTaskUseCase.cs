using TaskManager.Domain.Repositories.Tasks;

namespace TaskManager.Application.UseCases.Task;
public class RemoveTaskUseCase
{
    private readonly ITaskRepository _taskRepository;

    public RemoveTaskUseCase(ITaskRepository taskRepository)
    {
        _taskRepository = taskRepository;
    }

    public void Execute(Guid id)
    {
        var task = _taskRepository.GetTaskById(id);
        if (task != null)
        {
            _taskRepository.Remove(task);
        }
    }
}
