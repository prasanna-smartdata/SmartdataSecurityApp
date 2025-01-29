using Microsoft.EntityFrameworkCore;
using SmartdataSecurity.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartdataSecurityService.Interfaces
{
    public interface IDepartmentRepository : IRepository<Department> { }

}
