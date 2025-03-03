using TaskManager.Domain.Repositories.Tasks;
using MyTask = TaskManager.Domain.Entities.Tasks;

namespace TaskManager.Application.UseCases.Task;
public class FetchTasksUseCase
{
    private readonly ITaskRepository _taskRepository;

    public FetchTasksUseCase(ITaskRepository taskRepository)
    {
        _taskRepository = taskRepository;
    }

    public List<MyTask.Task> Execute()
    {
        return _taskRepository.FetchTasks();
    }
}
