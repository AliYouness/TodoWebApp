using MongoDB.Driver;
using SharpCompress.Common;
using TODO_Solution.Model;

namespace TODO_Solution.Repository
{
    public class InMemoryTodoDataStorage : ITodoDataStorage
    {
        
        private readonly IMongoCollection<TodoItem> _todoCollection;

        public InMemoryTodoDataStorage(IDatabaseSettings settings)
        {
            var client = new MongoClient(settings.connectionString);
            var database = client.GetDatabase(settings.databaseName);
            _todoCollection = database.GetCollection<TodoItem>(settings.tododCollectionName);
        }

        public async Task<List<TodoItem>> GetAllAsync()
        {
            await Task.Delay(100);
            return _todoCollection.Find(_ => true).ToList();
        }

        public async Task<TodoItem> GetByIdAsync(string id)
        {
            await Task.Delay(100); // Simulate an asynchronous operation
            return _todoCollection.Find(x => x.Id == id).FirstOrDefault();
        }

        public async Task CreateAsync(TodoItem todo)
        {
            await Task.Delay(100); // Simulate an asynchronous operation
            _todoCollection.InsertOne(todo);
        }

        public async Task UpdateAsync(string Id,TodoItem todo)
        {
            await Task.Delay(100); // Simulate an asynchronous operation
            var filter = Builders<TodoItem>.Filter.Eq(x => x.Id, Id);
            await _todoCollection.ReplaceOneAsync(filter, todo);
        }

        public async Task DeleteAsync(string id)
        {
            await Task.Delay(100); // Simulate an asynchronous operation
            var todoToRemove = _todoCollection.DeleteOne(x => x.Id == id);
            
        }
    }
            
}
