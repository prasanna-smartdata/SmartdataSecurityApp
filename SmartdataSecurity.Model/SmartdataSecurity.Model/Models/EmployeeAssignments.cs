namespace SmartdataSecurity.Model
{
    public class EmployeeAssignments
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; } 
        public int AssignmentId { get; set; }

        public DateTime EndDate { get; set; }
        public DateTime AssignedDate { get; set; } = DateTime.Now;

        public int NoOfAttempts { get; set; }

        public string Result { get; set; } = string.Empty; 


    }
}
