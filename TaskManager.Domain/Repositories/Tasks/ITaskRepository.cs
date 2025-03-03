using MyTask = TaskManager.Domain.Entities.Tasks;

namespace TaskManager.Domain.Repositories.Tasks;

public interface ITaskRepository
{
    void Create(MyTask.Task task);
    List<MyTask.Task> FetchTasks();
    void Edit(MyTask.Task task);
    MyTask.Task? GetTaskById(Guid id);
    void Remove(MyTask.Task task);
}
