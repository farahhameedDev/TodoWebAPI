using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoApp.Model;

namespace TodoApp.Interfaces
{
    public interface ITodoService
    {
        List<TodoModelDto> GetAllTodo();
        TodoModelDto GetTodo(int id);
        MessageDto SaveTodo([FromBody]TodoModelDto value);
        MessageDto UpdateTodo(int id, [FromBody]TodoUpdateModel value);
        MessageDto Delete(int id);
    }
}
