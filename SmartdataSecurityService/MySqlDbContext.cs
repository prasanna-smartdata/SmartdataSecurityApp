using Microsoft.EntityFrameworkCore;
using SmartdataSecurity.Model;


namespace SmartdataSecurityService
{
    public class MySqlDbContext : DbContext
    {
        public MySqlDbContext(DbContextOptions<MySqlDbContext> options) : base(options) { }

        public DbSet<User> User { get; set; }
        public DbSet<Employee> Employee { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Assignment> Assignments { get; set; }
        public DbSet<AssignmentQuestions> AssignmentQuestions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Use Fluent API to map EmployeeId to employee_id column

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.EmployeeId)
                    .HasColumnName("employee_id")
                    .IsRequired();

                entity.Property(e => e.UserId)
                    .HasColumnName("user_id")
                    .IsRequired();

                
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.Property(e => e.EmployeeId)
                    .HasColumnName("id")                    
                    .IsRequired();

                entity.Property(e => e.EmployeeFirstName)
                    .HasColumnName("first_name")
                    .IsRequired();

                entity.Property(e => e.EmployeeLastName)
                   .HasColumnName("last_name")
                   .IsRequired();

                entity.Property(e => e.EmployeeMiddleName)
                   .HasColumnName("middle_name")
                   .IsRequired(false);

                entity.Property(e => e.TenantId)
                  .HasColumnName("tenant_id")
                  .IsRequired();

                entity.Property(e => e.Email)
                  .HasColumnName("email_id")
                  .IsRequired();

                entity.Property(e => e.RoleId)
                  .HasColumnName("role_id")
                  .IsRequired();

                entity.Property(e => e.CreatedDate)
                  .HasColumnName("created_date");

            });
            base.OnModelCreating(modelBuilder);
        }
    }

}
