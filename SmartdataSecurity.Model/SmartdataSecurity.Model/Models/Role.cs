﻿namespace SmartdataSecurity.Model
{
    public class Role
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }
        public virtual ICollection<Employee> Employees { get; set; } // Navigation property to Employee
    }

}
