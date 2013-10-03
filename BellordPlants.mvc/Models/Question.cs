using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace BellordPlants.mvc.Models
{
    public class Question
    {
        public int QuestionId { get; set; }

        [Required(ErrorMessage="You must have a question title")]
        [Display(Name="Question Title",Description="Title of the question")]
        [DataType(DataType.Text)]
        public string Title { get; set; }

        [Display(Name = "Details", Description = "Details of the question")]
        [DataType(DataType.MultilineText)]
        public string Details { get; set; }

        public virtual List<Answer> Answers { get; set; }

        [Display(Name = "Question Author", Description = "Author of the question")]
        public virtual ApplicationUser QuestionAuthor { get; set; }
    }
}