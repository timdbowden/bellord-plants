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
        public string Name { get; set; }

        public virtual TaskListItem Tasks { get; set; }
    }
}