using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TodoApp.Services;
using TodoApp.Model;
using TodoApp.Interfaces;
using Microsoft.AspNetCore.Cors;

namespace TodoApp.Controllers
{
    [Route("api/[controller]")]
    [EnableCors("TodoAppPolicy")]
    public class TodoController : Controller
    {
        private ITodoService _todoService;

        public TodoController(ITodoService todoService)
        {
            _todoService = todoService;
        }


        /// <summary>
        /// Get all Todo Items
        /// </summary>
        /// 
        /// <remarks>
        /// Get All Todo items
        /// </remarks>
        /// <returns>
        /// Json object with list of all Todo's
        /// </returns>
        /// 
        ///<response code="200"></response> 
        [HttpGet]
        public IActionResult GetAll()
        {
            return this.Ok(_todoService.GetAllTodo());
        }

        /// <summary>
        /// Get Todo Item for the given id
        /// </summary>
        /// 
        /// <remarks>
        ///  Get Todo Item for the given id
        /// </remarks>
        /// <returns>
        /// Json object with of Todo item
        /// </returns>
        /// 
        ///<response code="200"></response> 
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return this.Ok(_todoService.GetTodo(id));
        }

        /// <summary>
        /// Save new Todo Item 
        /// </summary>
        /// 
        /// <remarks>
        ///  Save Todo Item for the given id
        /// </remarks>
        /// <returns>
        /// Response entity 
        /// </returns>
        /// 
        ///<response code="200"></response> 
        [HttpPost]
        public IActionResult Post([FromBody]TodoModelDto value)
        {
            return this.Ok(_todoService.SaveTodo(value));
        }

        /// <summary>
        /// Update Todo Item 
        /// </summary>
        /// 
        /// <remarks>
        ///  Update Todo Item  for the given id
        /// </remarks>
        /// <returns>
        /// Response entity 
        /// </returns>
        /// 
        ///<response code="200"></response> 
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]TodoUpdateModel value)
        {
            return this.Ok(_todoService.UpdateTodo(id, value));
        }

        /// <summary>
        /// Delete Todo Item 
        /// </summary>
        /// 
        /// <remarks>
        ///  Delete Todo Item  for the given id
        /// </remarks>
        /// <returns>
        /// Response entity 
        /// </returns>
        /// 
        ///<response code="200"></response>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)

        {
            return this.Ok(_todoService.Delete(id));
        }
    }
}
