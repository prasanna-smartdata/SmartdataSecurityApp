﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SmartdataSecurityService;

#nullable disable

namespace SmartdataSecurityApp.Server.Migrations
{
    [DbContext(typeof(MySqlDbContext))]
    partial class MySqlDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("SmartdataSecurity.Model.Address", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<string>("Address1")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("address1");

                    b.Property<string>("Address2")
                        .HasColumnType("longtext")
                        .HasColumnName("address2");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("city");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("country");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("state");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("street");

                    b.Property<string>("Zip")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("zip");

                    b.HasKey("Id");

                    b.ToTable("Address");
                });

            modelBuilder.Entity("SmartdataSecurity.Model.Assignment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<int>("CertificateId")
                        .HasColumnType("int")
                        .HasColumnName("certificate_id");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("description");

                    b.Property<bool>("HasQuestions")
                        .HasColumnType("tinyint(1)")
                        .HasColumnName("has_questions");

                    b.Property<bool>("IsGlobal")
                        .HasColumnType("tinyint(1)")
                        .HasColumnName("is_global");

                    b.Property<int>("MinScore")
                        .HasColumnType("int")
                        .HasColumnName("min_score");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("name");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("status");

                    b.Property<int?>("TenantId")
                        .HasColumnType("int");

                    b.Property<int>("TotalQuestions")
                        .HasColumnType("int")
                        .HasColumnName("total_questions");

                    b.Property<int>("TypeId")
                        .HasColumnType("int")
                        .HasColumnName("type_id");

                    b.Property<int>("TypeId1")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TenantId");

                    b.HasIndex("TypeId");

                    b.HasIndex("TypeId1");

                    b.ToTable("Assignment");
                });

            modelBuilder.Entity("SmartdataSecurity.Model.AssignmentQuestions", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("AssignmentId")
                        .HasColumnType("int");

                    b.Property<int>("QuestionId")
                        .HasColumnType("int");

                    b.Property<bool>("Status")
                        .HasColumnType("tinyint(1)");

                    b.HasKey("Id");

                    b.HasIndex("AssignmentId");

                    b.HasIndex("QuestionId");

                    b.ToTable("AssignmentQuestions");
                });

            modelBuilder.Entity("SmartdataSecurity.Model.AssignmentType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("name");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("status");

                    b.HasKey("Id");

                    b.ToTable("AssignmentType");
                });

            modelBuilder.Entity("SmartdataSecurity.Model.Department", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<string>("Description")
                        .HasColumnType("longtext")
                        .HasColumnName("description");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("name");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("status");

                    b.HasKey("Id");

                    b.ToTable("Department");
                });

            modelBuilder.Entity("SmartdataSecurity.Model.Employee", b =>
                {
                    b.Property<int>("EmployeeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("created_date");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("email_id");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("first_name");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("last_name");

                    b.Property<string>("MiddleName")
                        .HasColumnType("longtext")
                        .HasColumnName("middle_name");

                    b.Property<int>("RoleId")
                        .HasColumnType("int")
                        .HasColumnName("role_id");

                    b.Property<string>("Skills")
                        .HasColumnType("json")
                        .HasColumnName("skills");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("TenantId")
                        .HasColumnType("int")
                        .HasColumnName("tenant_id");

                    b.HasKey("EmployeeId");

                    b.HasIndex("RoleId");

                    b.HasIndex("TenantId");

                    b.ToTable("Employee");

                    b.HasData(
                        new
                        {
                            EmployeeId = 1000,
                            CreatedDate = new DateTime(2025, 1, 29, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "admin@smartdataglobal.in",
                            FirstName = "superadmin",
                            LastName = "superadmin",
                            RoleId = 1,
                            Skills = "{\"Programming\":\"C#\",\"Database\":\"MySQL\"}",
                            Status = "1",
                            TenantId = 1
                        });
                });

            modelBuilder.Entity("SmartdataSecurity.Model.EmployeeAssignments", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<DateTime>("AssignedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime(6)")
                        .HasColumnName("assigned_date")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP(6)");

                    b.Property<int>("AssignmentId")
                        .HasColumnType("int")
                        .HasColumnName("assignment_id");

                    b.Property<int?>("AssignmentId1")
                        .HasColumnType("int");

                    b.Property<int>("EmployeeId")
                        .HasColumnType("int")
                        .HasColumnName("employee_id");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("end_date");

                    b.Property<int>("NoOfAttempts")
                        .HasColumnType("int")
                        .HasColumnName("no_of_attempts");

                    b.Property<string>("Result")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("result");

                    b.HasKey("Id");

                    b.HasIndex("AssignmentId");

                    b.HasIndex("AssignmentId1");

                    b.HasIndex("EmployeeId");

                    b.ToTable("employee_assignments", (string)null);
                });

            modelBuilder.Entity("SmartdataSecurity.Model.EmployeeDepartments", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<int>("DepartmentId")
                        .HasColumnType("int")
                        .HasColumnName("department_id");

                    b.Property<int>("EmployeeId")
                        .HasColumnType("int")
                        .HasColumnName("employee_id");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("DepartmentId");

                    b.HasIndex("EmployeeId");

                    b.ToTable("employee_departments", (string)null);
                });

            modelBuilder.Entity("SmartdataSecurity.Model.Models.Question", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<string>("Answers")
                        .HasColumnType("json")
                        .HasColumnName("answers");

                    b.Property<int?>("AssignmentId")
                        .HasColumnType("int");

                    b.Property<string>("Options")
                        .HasColumnType("json")
                        .HasColumnName("options");

                    b.Property<string>("QuestionText")
                        .IsRequired()
                        .HasMaxLength(5000)
                        .HasColumnType("varchar(5000)")
                        .HasColumnName("question_text");

                    b.Property<int>("QuestionTypeId")
                        .HasColumnType("int");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("status");

                    b.HasKey("Id");

                    b.HasIndex("AssignmentId");

                    b.HasIndex("QuestionTypeId");

                    b.ToTable("Question");
                });

            modelBuilder.Entity("SmartdataSecurity.Model.QuestionType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<bool>("Status")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("QuestionType");
                });

            modelBuilder.Entity("SmartdataSecurity.Model.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("name");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("status");

                    b.HasKey("Id");

                    b.ToTable("Roles");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "superadmin",
                            Status = "1"
                        },
                        new
                        {
                            Id = 2,
                            Name = "admin",
                            Status = "1"
                        },
                        new
                        {
                            Id = 3,
                            Name = "employee",
                            Status = "1"
                        });
                });

            modelBuilder.Entity("SmartdataSecurity.Model.Tenant", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<int?>("AddressId")
                        .HasColumnType("int")
                        .HasColumnName("address_id");

                    b.Property<string>("ContactPersonEmail")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("contact_person_email");

                    b.Property<string>("ContactPersonName")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("contact_person_name");

                    b.Property<string>("ContactPhoneNumber")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("contact_phone_number");

                    b.Property<string>("Description")
                        .HasColumnType("longtext")
                        .HasColumnName("description");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("name");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("status");

                    b.Property<string>("TenantConfig")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("tenant_config");

                    b.HasKey("Id");

                    b.HasIndex("AddressId");

                    b.ToTable("tenants", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ContactPersonEmail = "superadmin",
                            ContactPersonName = "superadmin",
                            ContactPhoneNumber = "999999999",
                            Description = "superadmin",
                            Name = "superadmin",
                            Status = "1",
                            TenantConfig = "{}"
                        });
                });

            modelBuilder.Entity("SmartdataSecurity.Model.TenantAssignments", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<int>("AssignmentId")
                        .HasColumnType("int")
                        .HasColumnName("assignment_id");

                    b.Property<int>("TenantId")
                        .HasColumnType("int")
                        .HasColumnName("tenant_id");

                    b.HasKey("Id");

                    b.HasIndex("AssignmentId");

                    b.HasIndex("TenantId");

                    b.ToTable("tenant_assignments", (string)null);
                });

            modelBuilder.Entity("SmartdataSecurity.Model.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("EmployeeId")
                        .HasColumnType("int")
                        .HasColumnName("employee_id");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("password");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("user_id");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId");

                    b.ToTable("User");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            EmployeeId = 1000,
                            Password = "$2a$11$Nc/RPp/WSRJmVBmoeh3a5eE3/PPBa8k0ji94a1R.3n2O2iW432sOu",
                            UserId = "superadmin"
                        });
                });

            modelBuilder.Entity("SmartdataSecurity.Model.Assignment", b =>
                {
                    b.HasOne("SmartdataSecurity.Model.Tenant", null)
                        .WithMany("Assignments")
                        .HasForeignKey("TenantId");

                    b.HasOne("SmartdataSecurity.Model.AssignmentType", null)
                        .WithMany()
                        .HasForeignKey("TypeId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("SmartdataSecurity.Model.AssignmentType", "Type")
                        .WithMany("Assignments")
                        .HasForeignKey("TypeId1")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Type");
                });

            modelBuilder.Entity("SmartdataSecurity.Model.AssignmentQuestions", b =>
                {
                    b.HasOne("SmartdataSecurity.Model.Assignment", "Assignment")
                        .WithMany("AssignmentQuestions")
                        .HasForeignKey("AssignmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SmartdataSecurity.Model.Models.Question", "Question")
                        .WithMany()
                        .HasForeignKey("QuestionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Assignment");

                    b.Navigation("Question");
                });

            modelBuilder.Entity("SmartdataSecurity.Model.Employee", b =>
                {
                    b.HasOne("SmartdataSecurity.Model.Role", "Role")
                        .WithMany("Employees")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("SmartdataSecurity.Model.Tenant", "Tenant")
                        .WithMany("Employees")
                        .HasForeignKey("TenantId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Role");

                    b.Navigation("Tenant");
                });

            modelBuilder.Entity("SmartdataSecurity.Model.EmployeeAssignments", b =>
                {
                    b.HasOne("SmartdataSecurity.Model.Assignment", "Assignment")
                        .WithMany()
                        .HasForeignKey("AssignmentId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("SmartdataSecurity.Model.Assignment", null)
                        .WithMany("EmployeeAssignments")
                        .HasForeignKey("AssignmentId1");

                    b.HasOne("SmartdataSecurity.Model.Employee", "Employee")
                        .WithMany("EmployeeAssignments")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Assignment");

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("SmartdataSecurity.Model.EmployeeDepartments", b =>
                {
                    b.HasOne("SmartdataSecurity.Model.Department", "Department")
                        .WithMany()
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SmartdataSecurity.Model.Employee", "Employee")
                        .WithMany()
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Department");

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("SmartdataSecurity.Model.Models.Question", b =>
                {
                    b.HasOne("SmartdataSecurity.Model.Assignment", null)
                        .WithMany("Questions")
                        .HasForeignKey("AssignmentId");

                    b.HasOne("SmartdataSecurity.Model.QuestionType", "QuestionType")
                        .WithMany()
                        .HasForeignKey("QuestionTypeId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("QuestionType");
                });

            modelBuilder.Entity("SmartdataSecurity.Model.Tenant", b =>
                {
                    b.HasOne("SmartdataSecurity.Model.Address", "Address")
                        .WithMany()
                        .HasForeignKey("AddressId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("Address");
                });

            modelBuilder.Entity("SmartdataSecurity.Model.TenantAssignments", b =>
                {
                    b.HasOne("SmartdataSecurity.Model.Assignment", "Assignment")
                        .WithMany("TenantAssignments")
                        .HasForeignKey("AssignmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SmartdataSecurity.Model.Tenant", "Tenant")
                        .WithMany("TenantAssignments")
                        .HasForeignKey("TenantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Assignment");

                    b.Navigation("Tenant");
                });

            modelBuilder.Entity("SmartdataSecurity.Model.User", b =>
                {
                    b.HasOne("SmartdataSecurity.Model.Employee", "Employee")
                        .WithMany()
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("SmartdataSecurity.Model.Assignment", b =>
                {
                    b.Navigation("AssignmentQuestions");

                    b.Navigation("EmployeeAssignments");

                    b.Navigation("Questions");

                    b.Navigation("TenantAssignments");
                });

            modelBuilder.Entity("SmartdataSecurity.Model.AssignmentType", b =>
                {
                    b.Navigation("Assignments");
                });

            modelBuilder.Entity("SmartdataSecurity.Model.Employee", b =>
                {
                    b.Navigation("EmployeeAssignments");
                });

            modelBuilder.Entity("SmartdataSecurity.Model.Role", b =>
                {
                    b.Navigation("Employees");
                });

            modelBuilder.Entity("SmartdataSecurity.Model.Tenant", b =>
                {
                    b.Navigation("Assignments");

                    b.Navigation("Employees");

                    b.Navigation("TenantAssignments");
                });
#pragma warning restore 612, 618
        }
    }
}
