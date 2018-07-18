using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace APP.DAL.Interfaces
{
    public interface IComplianceConnection
    {
        SqlConnection OpenConnection();
    }
}
