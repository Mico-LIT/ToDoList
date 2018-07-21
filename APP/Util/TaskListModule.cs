using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ninject.Modules;
using APP.BLL.Interfaces;
using APP.BLL.Service;

namespace APP.Util
{
    public class TaskListModule : NinjectModule
    {
        public override void Load()
        {
            Bind<ITaskListService>().To<TaskListService>();
        }
    }
}