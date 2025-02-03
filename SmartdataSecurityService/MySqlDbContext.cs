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

        public DbSet<Role> Roles { get; set; }
        public DbSet<Tenant> Tenant { get; set; }
        public DbSet<AssignmentQuestions> AssignmentQuestions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure User entity
            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.EmployeeId)
                    .HasColumnName("employee_id")
                    .IsRequired();

                entity.Property(e => e.UserId)
                    .HasColumnName("user_id")
                    .IsRequired();
            });

            // Configure Employee entity
            modelBuilder.Entity<Employee>(entity =>
            {
                entity.Property(e => e.EmployeeId)
                    .HasColumnName("id")
                    .IsRequired();

                entity.Property(e => e.FirstName)
                    .HasColumnName("first_name")
                    .IsRequired();

                entity.Property(e => e.LastName)
                    .HasColumnName("last_name")
                    .IsRequired();

                entity.Property(e => e.MiddleName)
                    .HasColumnName("middle_name")
                    .IsRequired(false);

                entity.Property(e => e.TenantId)
                    .HasColumnName("tenant_id")
                    .IsRequired();

                entity.Property(e => e.Skills)
                    .HasColumnName("skills")
                    .IsRequired(false);

                entity.Property(e => e.Email)
                    .HasColumnName("email_id")
                    .IsRequired();

                entity.Property(e => e.RoleId)
                    .HasColumnName("role_id")
                    .IsRequired();

                entity.Property(e => e.CreatedDate)
                    .HasColumnName("created_date");

                // Configure the relationship between Employee and Role
                entity.HasOne(e => e.Role)  // Employee has one Role
                    .WithMany()  // Role can be associated with many Employees
                    .HasForeignKey(e => e.RoleId)  // Foreign key in Employee pointing to Role
                    .OnDelete(DeleteBehavior.Restrict);  // Optional: set up delete behavior
            });

            // Configure Role entity
            modelBuilder.Entity<Role>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .IsRequired();

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .IsRequired();
            });

            // Other entity configurations if needed...

            base.OnModelCreating(modelBuilder);
        }
    }
}
