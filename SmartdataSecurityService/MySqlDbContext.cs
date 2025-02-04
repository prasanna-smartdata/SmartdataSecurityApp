using Microsoft.EntityFrameworkCore;
using SmartdataSecurity.Model;
using SmartdataSecurity.Model.Models;
using System.Text.Json;

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
        public DbSet<EmployeeDepartments> EmployeeDepartments { get; set; }

        public DbSet<TenantAssignments> TenantAssginments   { get; set; }
        public DbSet<AssignmentType> AssignmentType { get; set; }
        public DbSet<Address> Address { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure User entity
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.Id); // Define primary key

                entity.Property(e => e.EmployeeId)
                    .HasColumnName("employee_id")
                    .IsRequired();

                entity.Property(e => e.UserId)
                    .HasColumnName("user_id")
                    .IsRequired();

                entity.Property(e => e.Password)
                    .HasColumnName("password")
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
                    .HasColumnType("json")
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
                // Map to the table 'employee_assignments'
                entity.ToTable("employee_assignments");

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
                    .HasDefaultValueSql("CURRENT_TIMESTAMP(6)");

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


            // Configure EmployeeDepartments entity
            modelBuilder.Entity<EmployeeDepartments>(entity =>
            {
                // Map to the table 'employee_departments'
                entity.ToTable("employee_departments");

                entity.HasKey(e => e.Id); // Define primary key

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .IsRequired();

                entity.Property(e => e.EmployeeId)
                    .HasColumnName("employee_id")
                    .IsRequired();

                entity.Property(e => e.DepartmentId)
                    .HasColumnName("department_id")
                    .IsRequired();
 

                // Foreign key relationships
                entity.HasOne(e => e.Employee)
                    .WithMany()
                    .HasForeignKey(e => e.EmployeeId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(e => e.Department)
                    .WithMany()
                    .HasForeignKey(e => e.DepartmentId)
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
                entity.ToTable("tenants");

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

                entity.Property(e => e.AddressId)
                       .HasColumnName("address_id")
                       .IsRequired(false);

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .IsRequired();

              
            });

            //Configure DepartmentAssignments entity
            modelBuilder.Entity<TenantAssignments>(entity =>
               {
                   // Map to the table 'tenant_assignments'
                   entity.ToTable("tenant_assignments");

                   entity.HasKey(e => e.Id); // Define primary key

                   entity.Property(e => e.Id)
                        .HasColumnName("id")
                        .IsRequired();

                   entity.Property(e => e.TenantId)
                           .HasColumnName("tenant_id")   
                           .IsRequired();

                   entity.Property(e => e.AssignmentId)
                           .HasColumnName("assignment_id")
                           .IsRequired();

               });

            // Configure Question entity
            modelBuilder.Entity<Question>(entity =>
            {
                entity.HasKey(q => q.Id); // Define primary key

                entity.Property(q => q.Id)
                    .HasColumnName("id")
                    .IsRequired();

                entity.Property(q => q.QuestionText)
                    .HasColumnName("question_text")
                    .IsRequired()
                    .HasMaxLength(5000);   

                entity.Property(q => q.Options)
                    .HasColumnName("options")
                    .HasColumnType("json")   
                    .IsRequired(false);  

                entity.Property(q => q.Answers)
                    .HasColumnName("answers")
                    .HasColumnType("json")  
                    .IsRequired(false); 

                entity.Property(q => q.Status)
                    .HasColumnName("status")                      
                    .IsRequired();

                entity.HasOne(q => q.QuestionType)   
                    .WithMany()  
                    .HasForeignKey(q => q.QuestionTypeId)  
                    .OnDelete(DeleteBehavior.Restrict);  
            });


            //Relationships mapping        

            modelBuilder.Entity<Employee>()
                .HasMany(e => e.EmployeeAssignments)
                .WithOne(a => a.Employee) 
                .HasForeignKey(a => a.EmployeeId)
                .OnDelete(DeleteBehavior.Cascade);


            modelBuilder.Entity<TenantAssignments>()
                .HasOne(ta => ta.Tenant)
                .WithMany(t => t.TenantAssignments)
                .HasForeignKey(ta => ta.TenantId);

            modelBuilder.Entity<TenantAssignments>()
                .HasOne(ta => ta.Assignment)
                .WithMany(a => a.TenantAssignments)
                .HasForeignKey(ta => ta.AssignmentId);


            modelBuilder.Entity<EmployeeDepartments>()
                .HasOne(ed => ed.Employee)
                .WithMany()  
                .HasForeignKey(ed => ed.EmployeeId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<EmployeeDepartments>()
                .HasOne(ed => ed.Department)
                .WithMany()
                .HasForeignKey(ed => ed.DepartmentId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<AssignmentQuestions>()
               .HasOne(aq => aq.Assignment)
               .WithMany(a => a.AssignmentQuestions)
               .HasForeignKey(aq => aq.AssignmentId);

            modelBuilder.Entity<Tenant>()
              .HasOne(t => t.Address)
              .WithMany()
              .HasForeignKey(t => t.AddressId)
              .OnDelete(DeleteBehavior.Restrict);


            //Default data seed
            modelBuilder.Entity<Role>().HasData(
               new Role
               {
                   Id = 1,
                   Name = "superadmin",
                   Status = "1" 
               },
               new Role
               {
                   Id = 2,
                   Name = "admin",
                   Status = "1"  
               },
               new Role
               {
                   Id = 3,
                   Name = "employee",
                   Status = "1" 
               }
            );

            // Seed data for the User table
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 1,  // Set your User ID
                    UserId= "superadmin",
                    EmployeeId = 1000,  // Super admin EmployeeId is 1000
                    Password = "$2a$11$Nc/RPp/WSRJmVBmoeh3a5eE3/PPBa8k0ji94a1R.3n2O2iW432sOu",  
                }
            );
            modelBuilder.Entity<Tenant>().HasData(
               new Tenant
                   {
                       Id = 1,
                       Name = "superadmin",
                       Description = "superadmin",
                       ContactPersonName = "superadmin",
                       ContactPersonEmail = "superadmin",
                       ContactPhoneNumber = "999999999",
                       TenantConfig = "{}",
                       Status = "1",
                       AddressId = null // Assuming AddressId is nullable
                   }
               );
            modelBuilder.Entity<Employee>().HasData(
               new Employee
               {
                   EmployeeId = 1000,
                   FirstName = "superadmin",
                   LastName = "superadmin",
                   MiddleName = null, // No middle name provided
                   TenantId = 1,
                   Email = "admin@smartdataglobal.in",
                   RoleId = 1,
                   CreatedDate = new DateTime(2025, 1, 29),
                   Skills = JsonSerializer.Serialize(new { Programming = "C#", Database = "MySQL" }),
                   Status = "1"
               }
           );

            base.OnModelCreating(modelBuilder);
        }
    }
}
