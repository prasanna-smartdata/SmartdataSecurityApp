using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartdataSecurity.Model
{
    public class TenantAssignments
    {
        [Key]
        public int Id { get; set; }
        public int TenantId { get; set; }
        public int AssignmentId { get; set; }
        public virtual Tenant Tenant { get; set; }
        public virtual Assignment Assignment { get; set; }

    }
}
