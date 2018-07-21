using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject.Modules;
using APP.DAL.Dapper;
using APP.DAL.Interfaces;

namespace APP.BLL.Infrastructure
{
    public class ServiceModule : NinjectModule
    {
        private readonly string Connection;

        public ServiceModule(string str)
        {
            Connection = str;
        }

        public override void Load()
        {
            Bind<ITaskListContext>().To<TaskListContext>().WithConstructorArgument(Connection);
        }
    }
}
