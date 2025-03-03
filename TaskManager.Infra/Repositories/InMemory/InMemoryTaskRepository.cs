using MyTask = TaskManager.Domain.Entities.Tasks;
using TaskManager.Domain.Repositories.Tasks;

namespace TaskManager.Infra.Repositories.InMemory;

public class InMemoryTaskRepository : ITaskRepository
{
    private readonly List<MyTask.Task> _tasks = [];

    void ITaskRepository.Create(MyTask.Task task)
    {
        _tasks.Add(task);
    }

    void ITaskRepository.Edit(MyTask.Task task)
    {
        var existingTask = _tasks.Find(x => x.Id == task.Id);

        if (existingTask != null)
        {
            existingTask.Title = task.Title;
            existingTask.Description = task.Description;
            existingTask.Priority = task.Priority;
            existingTask.EndDate = task.EndDate;
            existingTask.Status = task.Status;
        }
    }

    List<MyTask.Task> ITaskRepository.FetchTasks()
    {
        return _tasks;
    }

    MyTask.Task? ITaskRepository.GetTaskById(Guid id)
    {
        return _tasks.Find(t => t.Id == id);
    }

    void ITaskRepository.Remove(MyTask.Task task)
    {
        _tasks.Remove(task);
    }
}
