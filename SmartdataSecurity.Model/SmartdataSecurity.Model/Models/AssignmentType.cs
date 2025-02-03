namespace SmartdataSecurity.Model
{
    public class AssignmentType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }
        public virtual ICollection<Assignment> Assignments { get; set; } // Navigation property to Assignment
    }

}
