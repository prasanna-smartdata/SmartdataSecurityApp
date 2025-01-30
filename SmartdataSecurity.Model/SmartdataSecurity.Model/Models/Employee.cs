namespace SmartdataSecurity.Model
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string EmployeeFirstName { get; set; } = string.Empty;
        public string EmployeeLastName { get; set; } = string.Empty;
        public string EmployeeMiddleName { get; set; } = string.Empty;
        public required string Email { get; set; }
        public DateTime CreatedDate { get; set; }= DateTime.Now;
        public int TenantId { get; set; }
        public int RoleId { get; set; }
        public int Status { get; set; } = 1;
    }
}
