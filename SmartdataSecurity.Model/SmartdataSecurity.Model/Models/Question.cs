using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartdataSecurity.Model.Models
{
    public class Question
    {
        [Key]
        public int Id { get; set; }
        public string QuestionText { get; set; }
        public int QuestionTypeId {  get; set; }
        public virtual QuestionType QuestionType { get; set; }

        public string Options { get; set; }
        public string Answers { get; set; }
        public string Status { get; set; }
    }
}
