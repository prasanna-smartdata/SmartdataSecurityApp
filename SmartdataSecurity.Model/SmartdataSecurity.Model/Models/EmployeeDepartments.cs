using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartdataSecurity.Model
{
    public class EmployeeDepartments
    {
        [Key]
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public virtual Employee Employee { get; set; }

        public int DepartmentId { get; set; }

        public virtual Department Department { get; set; }

        public string Status {  get; set; }
    }
}
