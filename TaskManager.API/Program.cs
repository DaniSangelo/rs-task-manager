using TaskManager.Application.UseCases.Task;
using TaskManager.Domain.Repositories.Tasks;
using TaskManager.Infra.Repositories.InMemory;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<ITaskRepository, InMemoryTaskRepository>();
builder.Services.AddScoped<CreateTaskUseCase>();
builder.Services.AddScoped<FetchTasksUseCase>();
builder.Services.AddScoped<GetTaskByIdUseCase>();
builder.Services.AddScoped<EditTaskUseCase>();
builder.Services.AddScoped<RemoveTaskUseCase>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
