using System.ComponentModel.DataAnnotations;

namespace SmartdataSecurity.Model
{
    public class QuestionType
    {
        [Key]
        public int Id { get; set; }
        public string Type { get; set; } = string.Empty;

        public bool Status { get; set; }
    }
}
