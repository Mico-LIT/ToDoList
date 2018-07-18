using APP.DAL.Dapper;
using APP.DAL.Entities;
using APP.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APP.DAL.Repositorys
{
    class DapperUnitOfWork : IUnitOfWork
    {
        private MobileContext db;

        public Repository<Phone> phones { get { return db.Phone; } }

        public DapperUnitOfWork(string str)
        {
            db = new MobileContext(str);
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
