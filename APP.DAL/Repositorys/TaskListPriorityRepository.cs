using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using APP.DAL.Interfaces;
using APP.DAL.Entities;
using Dapper;

namespace APP.DAL.Repositorys
{
    public class TaskListPriorityRepository : IRepository<TaskListPriority>
    {
        readonly IComplianceConnection connection;

        public TaskListPriorityRepository(IComplianceConnection conn)
        {
            connection = conn;
        }

        public int Create(TaskListPriority item)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public TaskListPriority Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TaskListPriority> GetAll()
        {
            IEnumerable<TaskListPriority> result;
            using (var conn = connection.OpenConnection())
            {
                result = conn.Query<TaskListPriority>("select * from TaskListPriority");
            }
            return result;
        }

        public bool Update(TaskListPriority item)
        {
            throw new NotImplementedException();
        }
    }
}
