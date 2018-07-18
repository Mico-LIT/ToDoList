using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using APP.DAL.Entities;
using APP.DAL.Repositorys;

namespace APP.DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        Repository<Phone> phones { get; }
    }
}
