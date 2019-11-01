using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TodoApp.Model
{
    public class TodoUpdateModel
    {
        public string Description { get; set; }
        public bool IsCompleted { get; set; }
    }
}
