using System.ComponentModel.DataAnnotations;
using System.Reflection.Emit;

namespace SmartdataSecurity.Model
{
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? MiddleName { get; set; }
        public int TenantId { get; set; }
        public virtual Tenant Tenant { get; set; } // Navigation property to Tenant
        public int RoleId { get; set; }
        public virtual Role Role { get; set; } // Navigation property to Role
        public string? Skills { get; set; }
        public string Email { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Status { get; set; }
        public virtual ICollection<EmployeeAssignments> EmployeeAssignments { get; set; } // Navigation property to EmployeeAssignments
    }

}
