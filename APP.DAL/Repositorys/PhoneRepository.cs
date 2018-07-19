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
    public class PhoneRepository : IRepository<Phone>
    {
        protected readonly IComplianceConnection Connection;

        public PhoneRepository(IComplianceConnection connection)
        {
            this.Connection = connection;
        }

        public void Create(Phone item)
        {
            using (var connection = Connection.OpenConnection())
            {
            }
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Phone Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Phone> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Update(Phone item)
        {
            throw new NotImplementedException();
        }
    }
}
