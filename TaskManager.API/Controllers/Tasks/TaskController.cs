using Microsoft.AspNetCore.Mvc;
using TaskManager.Application.UseCases.Task;

using TaskManager.Communication.Requests.Tasks;
using TaskManager.Communication.Responses;

namespace TaskManager.API.Controllers.Tasks;

[Route("api/[controller]")]
[ApiController]
public class TaskController : ControllerBase
{
    private readonly CreateTaskUseCase _createTaskUseCase;
    private readonly FetchTasksUseCase _fetchTasksUseCase;
    private readonly GetTaskByIdUseCase _getTaskByIdUseCase;
    private readonly EditTaskUseCase _editTaskUseCase;
    private readonly RemoveTaskUseCase _removeTaskUseCase;

    public TaskController(
        CreateTaskUseCase createTaskUseCase,
        FetchTasksUseCase fetchTasksUseCase,
        GetTaskByIdUseCase getTaskByIdUseCase,
        EditTaskUseCase editTaskUseCase,
        RemoveTaskUseCase removeTaskUseCase
    )
    {
        _createTaskUseCase = createTaskUseCase;
        _fetchTasksUseCase = fetchTasksUseCase;
        _getTaskByIdUseCase = getTaskByIdUseCase;
        _editTaskUseCase = editTaskUseCase;
        _removeTaskUseCase = removeTaskUseCase;
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public IActionResult Create([FromBody] TaskRequest request)
    {
        _createTaskUseCase.Execute(request);
        return Created(string.Empty, new ApiResponse<object>(true));
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public IActionResult Update([FromRoute] Guid id, [FromBody] TaskRequest request)
    {
        _editTaskUseCase.Execute(id, request);
        return NoContent();
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public IActionResult Delete([FromRoute] Guid id)
    {
        _removeTaskUseCase.Execute(id);
        return Ok();
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public IActionResult Fetch()
    {
        var response = _fetchTasksUseCase.Execute();
        return Ok(response);
    }
    
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult GetById([FromRoute] Guid id)
    {
        var response = _getTaskByIdUseCase.Execute(id);
        if (response == null) return NotFound();
        return Ok(response);
    }
}
