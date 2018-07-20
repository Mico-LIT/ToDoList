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
    public class MobileContext
    {
        TaskListRepository taskRepository;

        public IRepository<TaskList> ToDoTask { get { return taskRepository; } }

        public MobileContext(string connstr) //: base(connstr)
        {
            taskRepository = new TaskListRepository(new SqlConnectionFactory(connstr));
        }
        
    }
}
