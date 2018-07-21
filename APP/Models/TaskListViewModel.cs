using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APP.Models
{
    public class TaskListViewModel
    {
        public int Id { get; set; }
        public string Mess { get; set; }
        public DateTime DeadLine { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime? DateEnd { get; set; }
        public TaskListPriorityViewModel Priority { get; set; }
    }
}