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
    public class TaskListRepository : IRepository<TaskList>
    {
        protected readonly IComplianceConnection Connection;

        public TaskListRepository(IComplianceConnection conn)
        {
            Connection = conn;
        }
        public void Create(TaskList item)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public TaskList Get(int id)
        {
            TaskList toDoTask;
            using (var connection = Connection.OpenConnection())
            {
               toDoTask = connection.Query<TaskList,TaskListPriority, TaskList>(
                   @" SELECT t.*,tt.* FROM TaskList t 
                        left join TaskListPriority tt on tt.Id = t.TaskListPriorityID
                        WHERE t.Id = @ID", (t,tt)=> 
                   {
                       t.Priority = tt;
                       return t;
                   } ,new {ID = id }
                   ).SingleOrDefault();
            }
            return toDoTask;
        }

        public IEnumerable<TaskList> GetAll()
        {
            IEnumerable<TaskList> toDoTask;
            using (var connection = Connection.OpenConnection())
            {
                toDoTask = connection.Query<TaskList, TaskListPriority, TaskList>(
                    @" SELECT t.*,tt.* FROM TaskList t 
                        left join TaskListPriority tt on tt.Id = t.TaskListPriorityID",
                    (t, tt) =>
                    {
                        t.Priority = tt;
                        return t;
                    });
            }
            return toDoTask;
        }

        public void Update(TaskList item)
        {
            using (var connection = Connection.OpenConnection())
            {
                connection.Execute(
                    @"UPDATE TaskList 
                SET Mess = N''
                   ,DeadLine = GETDATE()
                   ,DateStart = DEFAULT
                   ,DateEnd = GETDATE()
                   ,TaskListPriorityID = 0
                WHERE ID = @ID;");
            };
        }
    }
}
