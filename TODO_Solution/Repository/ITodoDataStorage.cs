using TODO_Solution.Model;

namespace TODO_Solution.Repository
{
    public interface ITodoDataStorage
    {
        Task<List<TodoItem>> GetAllAsync();
        Task<TodoItem> GetByIdAsync(string id);
        Task CreateAsync(TodoItem todo);
        Task UpdateAsync(string Id, TodoItem todo);
        Task DeleteAsync(string id);
    }
}
