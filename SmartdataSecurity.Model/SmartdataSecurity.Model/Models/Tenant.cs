namespace SmartdataSecurity.Model
{
    public class Tenant
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public string ContactPersonName { get; set; }
        public string ContactPersonEmail { get; set; }
        public string ContactPhoneNumber { get; set; }
        public string TenantConfig { get; set; }
        public string Status { get; set; }
        public int AddressId { get; set; }
        public virtual Address Address { get; set; } // Navigation property to Address
        public virtual ICollection<Employee> Employees { get; set; } // Navigation property to Employee
    }

}
