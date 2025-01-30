using Microsoft.EntityFrameworkCore;
using SmartdataSecurity.Model;
using SmartdataSecurityService.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartdataSecurityService.Repositories
{
    public class TenantRepository : RepositoryBase<Tenant>, ITenantRepository
    {
        public TenantRepository(MySqlDbContext context) : base(context) { }
    }

}
