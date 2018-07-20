using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APP.DAL.Entities
{
    public class TaskList
    {
        public int Id { get; set; }
        public string Mess { get; set; }
        public string DeadLine { get; set; }
        public string DataStart { get; set; }
        public string DateEnd { get; set; }
        public TaskListPriority Priority { get; set; }
    }
}
