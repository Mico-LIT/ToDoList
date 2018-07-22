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

        public int Create(TaskList item)
        {
            int ID = 0;
            using (var connection = Connection.OpenConnection())
            {
                ID = connection.Query<int>(@"
                        INSERT INTO dbo.TaskList
                        (
                          Mess
                         , DeadLine
                         , DateStart
                         , DateEnd
                         , TaskListPriorityID
                        )
                        VALUES
                        (
                          @Mess
                         , @DeadLine
                         , @DateStart
                         , @DateEnd
                         , @TaskListPriorityID
                        ); 
                        SELECT CAST(SCOPE_IDENTITY() as int)
                        ", new
                {
                    item.Mess,
                    item.DeadLine,
                    item.DateStart,
                    item.DateEnd,
                    TaskListPriorityID = item.Priority.Id
                }).Single();
            }
            return ID > 0 ? ID : 0;
        }

        public bool Delete(int id)
        {
            int result;
            using (var connection = Connection.OpenConnection())
            {
                result = connection.Execute(@"
                DELETE FROM dbo.TaskList
                WHERE
                ID = @ID",new { ID = id});
            }

            return result > 0 ? true : false;
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
                        left join TaskListPriority tt on tt.Id = t.TaskListPriorityID
                        order by tt.ID asc",
                    (t, tt) =>
                    {
                        t.Priority = tt;
                        return t;
                    });
            }
            return toDoTask;
        }

        public bool Update(TaskList item)
        {
            int result;
            using (var connection = Connection.OpenConnection())
            {
                result = connection.Execute(String.Format(
                    @"UPDATE TaskList 
                SET Mess = @Mess
                   ,DeadLine = @DeadLine
                   ,DateStart = @DateStart
                   ,DateEnd = @DateEnd
                   ,TaskListPriorityID = @TaskListPriorityID
                WHERE ID = @ID;", item.Mess),
                new {item.Id,item.Mess,item.DeadLine,item.DateStart,item.DateEnd, TaskListPriorityID=item.Priority.Id });
            };

            return result > 0 ? true : false;
        }
    }
}
