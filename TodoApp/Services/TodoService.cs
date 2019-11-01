using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoApp.Interfaces;
using TodoApp.Model;

namespace TodoApp.Services
{
    public class TodoService : ITodoService
    {
        private List<TodoModelDto> _lstTodo;
        public TodoService()
        {
            InitializeData();
        }

        private void InitializeData()
        {
            _lstTodo = new List<TodoModelDto>();
            for (int i = 1; i <= 10; i++)
            {
                TodoModelDto dto = new TodoModelDto()
                {
                    Id = i,
                    Description = String.Format("Todo item no : {0}", i),
                    IsCompleted = false
                };

                _lstTodo.Add(dto);
            }
        }
        public List<TodoModelDto> GetAllTodo()
        {
            return _lstTodo;
        }

        public TodoModelDto GetTodo(int id)
        {
            return _lstTodo.Find(x => x.Id == id);
        }

        public MessageDto SaveTodo(TodoModelDto modelDto)
        {
            MessageDto response = new MessageDto();

            if(String.IsNullOrEmpty(modelDto.Description))
            {
                response.IsSuccess = false;
                response.ReturnMessage = "Description is mandatory";
                return response;
            }

            modelDto.Id = _lstTodo.Max(x => x.Id) + 1;
            _lstTodo.Add(modelDto);
            response.IsSuccess = true;
            response.ReturnMessage = "Todo item save successfully.";

            return response;
        }

        public MessageDto UpdateTodo(int id, TodoUpdateModel value)
        {
            MessageDto response = new MessageDto();

            TodoModelDto model = _lstTodo.FirstOrDefault(x => x.Id == id);

            if (model == null)
            {
                response.IsSuccess = false;
                response.ReturnMessage = "Todo item not found";
                return response;
            }

            model.Description = value.Description;
            model.IsCompleted = value.IsCompleted;

            int index = _lstTodo.FindIndex(x => x.Id == id);
            _lstTodo[index] = model;

            response.IsSuccess = true;
            response.ReturnMessage = "Todo item updated successfully.";

            return response;
        }

        public MessageDto Delete(int id)
        {
            MessageDto response = new MessageDto();
            int deleteItemIndex = _lstTodo.FindIndex(x => x.Id == id);
            _lstTodo.RemoveAt(deleteItemIndex);
            response.IsSuccess = true;
            response.ReturnMessage = "Todo item deleted successfully.";

            return response;
        }

    }
}
