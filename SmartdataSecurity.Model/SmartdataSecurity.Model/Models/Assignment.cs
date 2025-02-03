namespace SmartdataSecurity.Model
{
    public class Assignment
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int TypeId { get; set; }
        public virtual AssignmentType Type { get; set; } // Navigation property to AssignmentTypes
        public int CertificateId { get; set; }
        public bool HasQuestions { get; set; }
        public int TotalQuestions { get; set; }
        public int MinScore { get; set; }
        public bool IsGlobal { get; set; }
        public string Status { get; set; }
        public virtual ICollection<EmployeeAssignments> EmployeeAssignments { get; set; } // Navigation property to EmployeeAssignments
    }

}
