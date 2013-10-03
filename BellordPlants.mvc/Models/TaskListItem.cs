using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace BellordPlants.mvc.Models
{
    public class TaskListItem
    {
        public int TaskListItemId { get; set; }

        [Required(ErrorMessage="Task Item must have a title")]
        [Display(Name="Task Title",Description="Title of the task")]
        public string Title { get; set; }
        
        [Required(ErrorMessage="Task Item must have a description")]
        [Display(Name="Task Description",Description="De of the task")]
        public string Description { get; set; }

        
        public string Channel { get; set; }

        [Display(Name="Notification Time",Description="Time for notification to be sent")]
        [DisplayFormat(DataFormatString="{dd/MM/yyyy hh:mm:ss}")]
        public DateTime NotificationPoint { get; set; }

        [Required(ErrorMessage="Task item must have a start time")]
        [Display(Name="Start Time",Description="Time to start task")]
        [DisplayFormat(DataFormatString = "{0:d}")]
        public DateTime StartTime { get; set; }

        [Required(ErrorMessage="Task item must have an end time")]
        [Display(Name = "End Time", Description = "Time to finish task")]
        [DisplayFormat(DataFormatString = "{0:d}")]
        public string EndTime { get; set; }


    }
}