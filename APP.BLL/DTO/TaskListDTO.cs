using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APP.BLL.DTO
{
    public class TaskListDTO
    {
        public int Id { get; set; }
        public string Mess { get; set; }
        public DateTime? DeadLine { get; set; }
        public DateTime? DateStart { get; set; }
        public DateTime? DateEnd { get; set; }
        public TaskListPriorityDTO Priority { get; set; }
    }
}
