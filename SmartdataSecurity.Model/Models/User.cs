using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartdataSecurity.Model
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string UserId {  get; set; }
        public string Password { get; set; }
        public int EmployeeId {  get; set; }

        public Employee Employee { get; set; }
    }
}
