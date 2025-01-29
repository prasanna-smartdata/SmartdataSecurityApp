namespace SmartdataSecurity.Model
{
    public class AssignmentQuestions
    {
        public int Id { get; set; }
        public int QuestionId { get; set; } 
        public int AssignmentId {  get; set; }
        public bool Status { get; set; }
    }
}
