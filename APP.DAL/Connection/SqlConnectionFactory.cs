using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using APP.DAL.Interfaces;

namespace APP.DAL.Connection
{
    public class SqlConnectionFactory : IComplianceConnection
    {
        private readonly string _sqlconn;
        
        public SqlConnectionFactory(string connstr)
        {
            _sqlconn = connstr;
        }

        public SqlConnection OpenConnection()
        {
            return new SqlConnection(_sqlconn);
        }
    }
}
