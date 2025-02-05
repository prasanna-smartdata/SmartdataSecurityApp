using SmartdataSecurity.Model.Models;
using System.ComponentModel.DataAnnotations;

namespace SmartdataSecurity.Model
{
    public class AssignmentQuestions
    {
        [Key]
        public int Id { get; set; }
        public int QuestionId { get; set; } 
        public int AssignmentId {  get; set; }
        public Question Question { get; set; }
        public Assignment Assignment { get; set; }
        public bool Status { get; set; }
    }
}
