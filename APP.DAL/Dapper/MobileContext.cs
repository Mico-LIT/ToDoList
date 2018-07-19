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
        ToDoTaskRepository taskRepository;

        //public Repository<Phone> Phone { get; set; }
        public IRepository<ToDoTask> ToDoTask { get { return taskRepository; } }

        public MobileContext(string connstr) //: base(connstr)
        {
            //Phone = new Repository<Phone>(new SqlConnectionFactory(connstr));
            taskRepository = new ToDoTaskRepository(new SqlConnectionFactory(connstr));
        }
        
    }
}
