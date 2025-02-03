using Microsoft.EntityFrameworkCore;
using SmartdataSecurity.Model;

namespace SmartdataSecurityService
{
    public class MySqlDbContext : DbContext
    {
        public MySqlDbContext(DbContextOptions<MySqlDbContext> options) : base(options) { }

        public DbSet<User> User { get; set; }
        public DbSet<Employee> Employee { get; set; }
        public DbSet<Department> Department { get; set; }
        public DbSet<Assignment> Assignment { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Tenant> Tenant { get; set; }
        public DbSet<AssignmentQuestions> AssignmentQuestions { get; set; }
        public DbSet<EmployeeAssignments> EmployeeAssignments { get; set; }
        public DbSet<AssignmentType> AssignmentTypes { get; set; }
        public DbSet<Address> Address { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure User entity
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.UserId); // Define primary key
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
                entity.HasKey(e => e.EmployeeId); // Define primary key

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

                entity.HasOne(e => e.Role)  // Employee has one Role
                    .WithMany()  // Role can be associated with many Employees
                    .HasForeignKey(e => e.RoleId)  // Foreign key in Employee pointing to Role
                    .OnDelete(DeleteBehavior.Restrict);  // Optional: set up delete behavior

                entity.HasOne(e => e.Tenant) // Employee has one Tenant
                    .WithMany() // Tenant can be associated with many Employees
                    .HasForeignKey(e => e.TenantId)  // Foreign key in Employee pointing to Tenant
                    .OnDelete(DeleteBehavior.Restrict);
            });

            // Configure Role entity
            modelBuilder.Entity<Role>(entity =>
            {
                entity.HasKey(e => e.Id); // Define primary key

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .IsRequired();

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .IsRequired();

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .IsRequired();
            });

            // Configure Department entity
            modelBuilder.Entity<Department>(entity =>
            {
                entity.HasKey(e => e.Id); // Define primary key

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .IsRequired();

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .IsRequired();

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .IsRequired(false);

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .IsRequired();
            });

            // Configure Assignment entity
            modelBuilder.Entity<Assignment>(entity =>
            {
                entity.HasKey(e => e.Id); // Define primary key

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .IsRequired();

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .IsRequired();

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .IsRequired();

                entity.Property(e => e.TypeId)
                    .HasColumnName("type_id")
                    .IsRequired();

                entity.Property(e => e.CertificateId)
                    .HasColumnName("certificate_id")
                    .IsRequired();

                entity.Property(e => e.HasQuestions)
                    .HasColumnName("has_questions")
                    .IsRequired();

                entity.Property(e => e.TotalQuestions)
                    .HasColumnName("total_questions")
                    .IsRequired();

                entity.Property(e => e.MinScore)
                    .HasColumnName("min_score")
                    .IsRequired();

                entity.Property(e => e.IsGlobal)
                    .HasColumnName("is_global")
                    .IsRequired();

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .IsRequired();

                // Foreign key to AssignmentTypes table
                entity.HasOne<AssignmentType>()
                    .WithMany()
                    .HasForeignKey(e => e.TypeId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            // Configure EmployeeAssignments entity
            modelBuilder.Entity<EmployeeAssignments>(entity =>
            {
                entity.HasKey(e => e.Id); // Define primary key

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .IsRequired();

                entity.Property(e => e.EmployeeId)
                    .HasColumnName("employee_id")
                    .IsRequired();

                entity.Property(e => e.AssignmentId)
                    .HasColumnName("assignment_id")
                    .IsRequired();

                entity.Property(e => e.EndDate)
                    .HasColumnName("end_date")
                    .IsRequired();

                entity.Property(e => e.AssignedDate)
                    .HasColumnName("assigned_date")
                    .IsRequired()
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.NoOfAttempts)
                    .HasColumnName("no_of_attempts")
                    .IsRequired();

                entity.Property(e => e.Result)
                    .HasColumnName("result")
                    .IsRequired();

                // Foreign key relationships
                entity.HasOne(e => e.Employee)
                    .WithMany()
                    .HasForeignKey(e => e.EmployeeId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(e => e.Assignment)
                    .WithMany()
                    .HasForeignKey(e => e.AssignmentId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            // Configure AssignmentTypes entity
            modelBuilder.Entity<AssignmentType>(entity =>
            {
                entity.HasKey(e => e.Id); // Define primary key

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .IsRequired();

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .IsRequired();

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .IsRequired();
            });

            // Configure Address entity
            modelBuilder.Entity<Address>(entity =>
            {
                entity.HasKey(e => e.Id); // Define primary key

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .IsRequired();

                entity.Property(e => e.Address1)
                    .HasColumnName("address1")
                    .IsRequired();

                entity.Property(e => e.Address2)
                    .HasColumnName("address2")
                    .IsRequired(false);

                entity.Property(e => e.City)
                    .HasColumnName("city")
                    .IsRequired();

                entity.Property(e => e.Street)
                    .HasColumnName("street")
                    .IsRequired();

                entity.Property(e => e.State)
                    .HasColumnName("state")
                    .IsRequired();

                entity.Property(e => e.Zip)
                    .HasColumnName("zip")
                    .IsRequired();

                entity.Property(e => e.Country)
                    .HasColumnName("country")
                    .IsRequired();
            });

            // Configure Tenant entity
            modelBuilder.Entity<Tenant>(entity =>
            {
                entity.HasKey(e => e.Id); // Define primary key

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .IsRequired();

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .IsRequired();

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .IsRequired(false);

                entity.Property(e => e.ContactPersonName)
                    .HasColumnName("contact_person_name")
                    .IsRequired();

                entity.Property(e => e.ContactPersonEmail)
                    .HasColumnName("contact_person_email")
                    .IsRequired();

                entity.Property(e => e.ContactPhoneNumber)
                    .HasColumnName("contact_phone_number")
                    .IsRequired();

                entity.Property(e => e.TenantConfig)
                    .HasColumnName("tenant_config")
                    .IsRequired();

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .IsRequired();

                // Foreign key to Address table
                entity.HasOne<Address>()
                    .WithMany()
                    .HasForeignKey(e => e.AddressId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            //Default data seed
            modelBuilder.Entity<Role>().HasData(
               new Role
               {
                   Id = 1,
                   Name = "superadmin",
                   Status = "1" // Assuming "1" represents active status
               },
               new Role
               {
                   Id = 2,
                   Name = "admin",
                   Status = "1" // Assuming "1" represents active status
               },
               new Role
               {
                   Id = 3,
                   Name = "employee",
                   Status = "1" // Assuming "1" represents active status
               }
            );

            // Seed data for the User table
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 1,  // Set your User ID
                    EmployeeId = 1000,  // Assuming EmployeeId is 1000
                    Password = "$2a$11$Nc/RPp/WSRJmVBmoeh3a5eE3/PPBa8k0ji94a1R.3n2O2iW432sOu",  // Provided password hash
                }
            );

            base.OnModelCreating(modelBuilder);
        }
    }
}
