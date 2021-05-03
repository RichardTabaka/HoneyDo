using HoneyDo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HoneyDo.Services
{
    public interface IToDoList
    {
        public List<ToDoItem> ToDoItems { get; set; }
    }
}
