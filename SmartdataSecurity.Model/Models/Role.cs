using System.ComponentModel.DataAnnotations;

namespace SmartdataSecurity.Model
{
    public class Role
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }
        public virtual ICollection<Employee> Employees { get; set; } // Navigation property to Employee
    }

}
