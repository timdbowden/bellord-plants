using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace BellordPlants.mvc.Models
{
    public class TaskList
    {
        public int TaskListId { get; set; }

        [Required(ErrorMessage="Task list requires a name")]
        [Display(Name="Task List Name",Description="Name of the task list")]
        [DataType(DataType.Text)]
        public string Name { get; set; }

        [Display(Name = "Task List Description", Description = "Description of the task list")]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        public virtual TaskListItem Tasks { get; set; }
    }
}