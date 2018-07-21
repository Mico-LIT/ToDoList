using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using APP.BLL.DTO;

namespace APP.BLL.Interfaces
{
    public interface ITaskListService
    {
        void CreateNewTask(TaskListDTO taskList);
        TaskListDTO GetTask(int? id);
        IEnumerable<TaskListDTO> GetTaskAll();
        bool Delete(int ID);
        bool Update(TaskListDTO taskListDTO);
        IEnumerable<TaskListPriorityDTO> PriorityAll();
    }
}
