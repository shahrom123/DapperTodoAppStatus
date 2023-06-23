using Domain.Dtos;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("controller")]
    public class TodoController
    {
        private TodoService _todoService;

        public TodoController(TodoService todoService)
        {
            _todoService = todoService;
        }

        [HttpGet("GetTodos")]
        public List<TodoDto> GetTodos()
        {
            return _todoService.GetTodo();
        }
        [HttpGet("GetTodoById")]
        public TodoDto GetTodoById(int id)
        {
            return _todoService.GetById(id);
        }
        [HttpPost("AddTodo")]
        public TodoDto AddTodo(TodoDto todo)
        {
            return _todoService.AddTodo(todo);
        }
        [HttpDelete("DeleteTodo")]
        public void DeleteTodo(int id)
        {
            _todoService.DeleteTodo(id);
        }
        [HttpPut("UpdateTodo")]
        public void UpdateTodo(TodoDto todo)
        {
            _todoService.UpdateTodo(todo);
        }
        [HttpGet("GetTodoByStatus")]
        public List<TodoDto> todoDtos( int status)
        {
            return _todoService.GetTodoByStatus(status);
        }
    }
}
