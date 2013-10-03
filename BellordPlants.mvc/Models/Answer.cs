using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace BellordPlants.mvc.Models
{
    public class Answer
    {
        public int AnswerId { get; set; }

        [Required(ErrorMessage="You must include an answer")]
        [Display(Name="Answer",Description="Answer to the gardener's question")]
        [DataType(DataType.MultilineText)]
        public string Response { get; set; }

        [Display(Name="Answer Author")]
        public virtual ApplicationUser AnswerAuthor { get; set; }
    }
}
