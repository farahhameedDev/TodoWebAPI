using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TodoApp.Model
{
    public class TodoModelDto
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public Boolean IsCompleted { get; set; }
    }
}
