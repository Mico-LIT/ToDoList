using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using APP.DAL.Connection;
using APP.DAL.Entities;
using APP.DAL.Repositorys;

namespace APP.DAL.Dapper
{
    class MobileContext : SqlConnectionFactory
    {
        public Repository<Phone> Phone { get; set; }

        public MobileContext(string connstr) : base(connstr)
        {
        }
        
    }
}
