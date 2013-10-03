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
        [DataType(DataType.Text)]
        public string Title { get; set; }
        
        [Required(ErrorMessage="Task Item must have a description")]
        [Display(Name="Task Description",Description="Description of the task")]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        [Display(Name = "Task Channel", Description = "Subscription channel for push notifications")]
        [DataType(DataType.Text)]
        public string Channel { get; set; }

        [Display(Name="Notification Time",Description="Time for notification to be sent")]
        [DisplayFormat(DataFormatString="dd/MM/yyyy hh:mm:ss", ApplyFormatInEditMode=true)]
        [DataType(DataType.DateTime)]
        public DateTime NotificationPoint { get; set; }

        [Required(ErrorMessage="Task item must have a start time")]
        [Display(Name="Start Time",Description="Time to start task")]
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        [DataType(DataType.DateTime)]
        public DateTime StartTime { get; set; }

        [Required(ErrorMessage="Task item must have an end time")]
        [Display(Name = "End Time", Description = "Time to finish task")]
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        [DataType(DataType.DateTime)]
        public DateTime EndTime { get; set; }


    }
}