using TODO_Solution.Model;

namespace TODO_Solution.Services
{
    public interface ITodoService
    {
        Task<List<TodoItem>> GetAllTodosAsync();
        Task<TodoItem> GetTodoByIdAsync(string id);
        Task CreateNewTodoAsync(TodoItem todo);
        Task UpdateTodoAsync(string id, TodoItem todo);
        Task RemoveTodoAsync(string id);

    }
}
