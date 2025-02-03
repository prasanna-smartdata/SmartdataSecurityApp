using System.Reflection.Emit;

namespace SmartdataSecurity.Model
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string MiddleName { get; set; } = string.Empty;
        public required string Email { get; set; }
        public string Skills { get; set; }=string.Empty;

        public DateTime CreatedDate { get; set; }= DateTime.Now;
        public int TenantId { get; set; }
        public int RoleId { get; set; }

        public virtual Role Role { get; set; }
        public int Status { get; set; } = 1;
    }
}
