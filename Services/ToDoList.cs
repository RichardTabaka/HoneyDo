using HoneyDo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HoneyDo.Services
{
    public class ToDoList : IToDoList
    {
        public List<ToDoItem> ToDoItems { get; set; }
        public ToDoList()
        {
            ToDoItems = new List<ToDoItem>();

            ToDoItems.Add(new ToDoItem() { Completed = false, Description = "Check out your first to do item, then use the Edit button to mark it as Completed!", Title = "Check Out an Item" });
            ToDoItems.Add(new ToDoItem() { Title = "Check Useful Links", Description = "Head to the 'Useful Links' section and check some of them out. There's a lot to learn!", Completed = true });
        }
    }
}
