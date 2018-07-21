using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using APP.DAL.Connection;
using APP.DAL.Entities;
using APP.DAL.Repositorys;
using APP.DAL.Interfaces;


namespace APP.DAL.Dapper
{
    public class TaskListContext : ITaskListContext
    {
        readonly string Connection;

        TaskListRepository taskRepository;

        public IRepository<TaskList> ToDoTask {
            get
            {
                if (taskRepository == null)
                    taskRepository = new TaskListRepository(new SqlConnectionFactory(Connection));
                return taskRepository;
            }
        }

        public TaskListContext(string connstr) //: base(connstr)
        {
            Connection = connstr;
        }
        
    }
}
