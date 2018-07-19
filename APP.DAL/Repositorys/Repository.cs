using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using APP.DAL.Interfaces;
using Dapper;

namespace APP.DAL.Repositorys
{

    public class Repository<T> where T : class
    {
        protected readonly IComplianceConnection Connection;

        public Repository(IComplianceConnection connection)
        {
            Connection = connection;
        }
        public IEnumerable<T> Gets(string query)
        {
            IList<T> entities;

            using (var connection = Connection.OpenConnection())
            {
                entities = connection.Query<T>(query, CommandType.Text).ToList();
            }

            return entities;
        }

        public IEnumerable<T> Get(string query, object arguments)
        {
            IList<T> entities;

            using (var connection = Connection.OpenConnection())
            {
                entities = connection.Query<T>(query, arguments, commandType: CommandType.StoredProcedure).ToList();
            }

            return entities;
        }

        public T GetSingleOrDefault(string query, object arguments)
        {
            T entity;

            using (var connection = Connection.OpenConnection())
            {
                entity =
                    connection.Query<T>(query, arguments, commandType: CommandType.StoredProcedure).SingleOrDefault();
            }

            return entity;
        }

        public void Update(string query, object arguments)
        {
            using (var connection = Connection.OpenConnection())
            {
                connection.Execute(query, arguments, commandType: CommandType.StoredProcedure);
            }
        }

        public int ExecuteScalar(string query, object arguments)
        {
            var id = 0;
            using (var connection = Connection.OpenConnection())
            {
                id = connection.ExecuteScalar<int>(query, arguments, commandType: CommandType.StoredProcedure);
            }
            return id;
        }
    }
}

