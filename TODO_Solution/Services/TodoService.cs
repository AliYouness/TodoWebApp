using Microsoft.Extensions.Options;
using MongoDB.Driver;
using TODO_Solution.Model;
using TODO_Solution.Repository;

namespace TODO_Solution.Services
{
    public class TodoService : ITodoService
    {
        private readonly ITodoDataStorage _dataStorage;

        public TodoService(ITodoDataStorage dataStorage)
        {
            _dataStorage = dataStorage;
        }

        public async Task CreateNewTodoAsync(TodoItem todo)
        {
            if (todo == null)
                throw new ArgumentNullException(nameof(todo));

            await _dataStorage.CreateAsync(todo);
        }

        public async Task<List<TodoItem>> GetAllTodosAsync()
        {
            return await _dataStorage.GetAllAsync();
        }

        public async Task<TodoItem> GetTodoByIdAsync(string id)
        {
            if (string.IsNullOrEmpty(id))
                throw new ArgumentException("Id cannot be null or empty.", nameof(id));

            return await _dataStorage.GetByIdAsync(id);
        }

        public async Task RemoveTodoAsync(string id)
        {
            if (string.IsNullOrEmpty(id))
                throw new ArgumentException("Id cannot be null or empty.", nameof(id));

            await _dataStorage.DeleteAsync(id);
        }

        public async Task UpdateTodoAsync(string id,TodoItem todo)
        {
            if (string.IsNullOrEmpty(id))
                throw new ArgumentNullException(nameof(todo));
            if (todo == null) 
                throw new ArgumentNullException(nameof(todo));
            await _dataStorage.UpdateAsync(id,todo);
        }
    }
}
