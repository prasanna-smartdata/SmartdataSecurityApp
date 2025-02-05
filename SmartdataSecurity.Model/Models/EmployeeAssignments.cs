using System.ComponentModel.DataAnnotations;

namespace SmartdataSecurity.Model
{
    public class EmployeeAssignments
    {
        [Key]
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public virtual Employee Employee { get; set; } // Navigation property to Employee
        public int AssignmentId { get; set; }
        public virtual Assignment Assignment { get; set; } // Navigation property to Assignment
        public DateTime EndDate { get; set; }
        public DateTime AssignedDate { get; set; }
        public int NoOfAttempts { get; set; }
        public string Result { get; set; }
    }

}
