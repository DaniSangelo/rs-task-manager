using TaskManager.Communication.Requests.Tasks;
using TaskManager.Domain.Repositories.Tasks;

namespace TaskManager.Application.UseCases.Task;
public class EditTaskUseCase
{
    private readonly ITaskRepository _taskRepository;

    public EditTaskUseCase(ITaskRepository taskRepository)
    {
        _taskRepository = taskRepository;
    }

    public void Execute(Guid id, TaskRequest request)
    {
        var task = _taskRepository.GetTaskById(id);
        if (task != null)
        {
            task.Status = request.Status;
            task.Title = request.Title;
            task.Description = request.Description;
            task.Priority = request.Priority;
            task.EndDate = request.EndDate;
            _taskRepository.Edit(task);
        }
    }
}
