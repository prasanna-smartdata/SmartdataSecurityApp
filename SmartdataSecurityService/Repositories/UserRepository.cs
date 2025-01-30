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
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(MySqlDbContext context) : base(context) {
        }

        public async Task<User?> ValidateLoginAsync(string userId)
        {
            return await _dbSet.FirstOrDefaultAsync(u => u.UserId == userId);
        }
    }

}
