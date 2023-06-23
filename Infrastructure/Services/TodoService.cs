using Dapper;
using Domain.Dtos;
using Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class TodoService
    {
        private DapperContext _context;

        public TodoService(DapperContext context)
        {
            _context = context;
        }

        public List<TodoDto> GetTodo()
        {
            using (var conn = _context.CreateConnection())
            {
                var sql = $" select id, task_name as TodoName,  status  from TodoApps ";
                var result = conn.Query<TodoDto>(sql).ToList();
                return result;
            }
        }
        public TodoDto GetById(int id)
        {
            using (var conn = _context.CreateConnection())
            {
                var sql = $" select id, task_name as TodoName,  status  from TodoApps where id = {id} ";
                var result = conn.QuerySingle<TodoDto>(sql);
                return result;
            }
        }
        public TodoDto AddTodo(TodoDto todo)
        {
            using (var conn = _context.CreateConnection())
            {
                var sql = $" insert into TodoApps(Task_name, status)values(@TodoName,@status) ";
                var result = conn.ExecuteScalar<TodoDto>(sql, todo); return todo;
            }
        }

        public void UpdateTodo(TodoDto todo)
        {
            using (var conn = _context.CreateConnection())
            {
                var sql = $" update TodoApps set task_name = '{todo.TodoName}', status = {(int)todo.Status} where id = {todo.Id}";
                var redult = conn.Execute(sql);
            }

        }
        public void DeleteTodo(int id)
        {
            using (var conn = _context.CreateConnection())
            {
                var sql = $" delete from TodoApps where id = {id}";
                var result = conn.Execute(sql);
            }
        }

        public List<TodoDto> GetTodoByStatus(int status)
        {
            using(var conn = _context.CreateConnection())
            {
                var sql = $" select  id, task_name as TodoName,  status from TodoApps where status = {status}";
                var result = conn.Query<TodoDto>(sql);
                return result.ToList();
            }
        }

    }
}
