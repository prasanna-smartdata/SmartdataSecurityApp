using System.ComponentModel.DataAnnotations;

namespace SmartdataSecurity.Model
{
    public class Tenant
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public string ContactPersonName { get; set; }
        public string ContactPersonEmail { get; set; }
        public string ContactPhoneNumber { get; set; }
        public string TenantConfig { get; set; }
        public string Status { get; set; }
        public int? AddressId { get; set; }
       
        public virtual Address? Address { get; set; } // Navigation property to Address
        public virtual ICollection<Employee> Employees { get; set; }  = new List<Employee>();

        // Add the TenantAssignments collection for the many-to-many relationship
        public virtual ICollection<TenantAssignments> TenantAssignments { get; set; }= new List<TenantAssignments>();

        public virtual ICollection<Assignment>  Assignments { get; set; }=new List<Assignment>();



    }

}
