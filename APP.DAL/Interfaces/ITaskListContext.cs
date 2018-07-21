using APP.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APP.DAL.Interfaces
{
    public interface ITaskListContext
    {
        IRepository<TaskList> ToDoTask { get; }
        IRepository<TaskListPriority> Priority { get; }
    }
}
