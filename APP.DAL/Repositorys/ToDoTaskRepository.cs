using APP.DAL.Entities;
using APP.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace APP.DAL.Repositorys
{
    public class ToDoTaskRepository : IRepository<ToDoTask>
    {
        protected readonly IComplianceConnection Connection;
        public ToDoTaskRepository(IComplianceConnection conn)
        {
            Connection = conn;
        }
        public void Create(ToDoTask item)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public ToDoTask Get(int id)
        {
            ToDoTask toDoTask;
            using (var connection = Connection.OpenConnection())
            {
               toDoTask = connection.Query<ToDoTask,TaskType, ToDoTask>(
                   @" SELECT t.*,tt.* FROM Task t 
                        join TaskType tt on tt.Id = t.TypeTaskID
                        WHERE t.Id = @ID",(t,tt)=> { t.TaskType = tt; return t; } ,new {ID = id }).SingleOrDefault();
            }
            return toDoTask;
        }

        public IEnumerable<ToDoTask> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Update(ToDoTask item)
        {
            throw new NotImplementedException();
        }
    }
}
