using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using APP.BLL.DTO;
using APP.DAL.Entities;
using APP.DAL.Dapper;
using APP.BLL.Interfaces;
using APP.BLL.Infrastructure;
using APP.DAL.Interfaces;

namespace APP.BLL.Service
{
    public class TaskListService : ITaskListService
    {
        ITaskListContext DB { get; set; }

        public TaskListService(ITaskListContext tlc)
        {
            DB = tlc;
        }

        public void CreateNewTask(TaskListDTO taskListDTO)
        {
            if (taskListDTO.Priority == null)
                throw new ValidationException("Приоритет не указан","");
            TaskList taskList = new TaskList()
            {
                Mess = taskListDTO.Mess,
                DateStart = taskListDTO.DateStart,
                DateEnd = taskListDTO.DateEnd,
                DeadLine = taskListDTO.DeadLine,
                Priority = new TaskListPriority()
                {
                    Id = taskListDTO.Priority.Id
                }
            };

            DB.ToDoTask.Create(taskList);
        }

        public TaskListDTO GetTask(int? id)
        {
            if (id == null)
                throw new ValidationException("нет ID","");

            var result = DB.ToDoTask.Get(id.Value);
            if (result == null)
                throw new ValidationException("нет результатов","");

            var mapper = new AutoMapper.MapperConfiguration(
                    cfg => cfg.CreateMap<TaskList, TaskListDTO>()).CreateMapper();

            return mapper.Map<TaskList, TaskListDTO>(DB.ToDoTask.Get(id.Value));

        }

        public IEnumerable<TaskListDTO> GetTasks()
        {
            var mapper = 
                new AutoMapper.MapperConfiguration(
                    cfg => cfg.CreateMap<TaskList, TaskListDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<TaskList>, List<TaskListDTO>>(DB.ToDoTask.GetAll());
        }
    }
}
