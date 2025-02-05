using System.ComponentModel.DataAnnotations;

namespace SmartdataSecurity.Model
{
    public class AssignmentType
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }
        public virtual ICollection<Assignment> Assignments { get; set; } // Navigation property to Assignment
    }

}
