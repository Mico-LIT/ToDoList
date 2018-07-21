using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace APP.Models
{
    public class TaskListViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Текст задачи")]
        [DataType(DataType.Text)]
        public string Mess { get; set; }

        [Display(Name = "Срок задачи до")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? DeadLine { get; set; }

        [Display(Name = "Дата начала")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? DateStart { get; set; }

        [Display(Name = "Дата завершения")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? DateEnd { get; set; }

        [Display(Name = "Приоритет задачи")]
        public TaskListPriorityViewModel Priority { get; set; }

        [Display(Name = "Приоритет задачи")]
        public string PriorityID { get; set; }
    }
}