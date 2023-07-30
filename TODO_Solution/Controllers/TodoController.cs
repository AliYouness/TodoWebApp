using Microsoft.AspNetCore.Mvc;
using TODO_Solution.Model;
using TODO_Solution.Services;

namespace TODO_Solution.Controllers
{
    [ApiController]
    [Route("api/controller")]
    public class TodoController : Controller
    {
        private readonly ITodoService _todoService;

        public TodoController(ITodoService todoService)
        {
            _todoService = todoService;
        }

        [HttpGet]
        public async Task<List<TodoItem>> Get() => 
            await _todoService.GetAllTodosAsync();


        [HttpGet("{id:length(24)}")]
        public async Task<ActionResult<TodoItem>> Get(string id)
        {
            var todo = await _todoService.GetTodoByIdAsync(id);

            if (todo is null)
            {
                return NotFound();
            }

            return todo;
        }

        [HttpPost]
        public async Task<IActionResult> Post(TodoItem newTodo)
        {
            await _todoService.CreateNewTodoAsync(newTodo);

            return CreatedAtAction(nameof(Get), new { id = newTodo.Id }, newTodo);
        }

        [HttpPut("{id:length(24)}")]
        public async Task<IActionResult> Update(string id, TodoItem updatedTodo)
        {
            var todo = await _todoService.GetTodoByIdAsync(id);

            if (todo is null)
            {
                return NotFound();
            }

            updatedTodo.Id = todo.Id;

            await _todoService.UpdateTodoAsync(id, updatedTodo);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public async Task<IActionResult> Delete(string id)
        {
            var todo = await _todoService.GetTodoByIdAsync(id);

            if (todo is null)
            {
                return NotFound();
            }

            await _todoService.RemoveTodoAsync(id);

            return NoContent();
        }
    }
}
