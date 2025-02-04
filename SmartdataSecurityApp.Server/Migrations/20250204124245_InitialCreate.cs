using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SmartdataSecurityApp.Server.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    address1 = table.Column<string>(type: "longtext", nullable: false),
                    address2 = table.Column<string>(type: "longtext", nullable: true),
                    city = table.Column<string>(type: "longtext", nullable: false),
                    street = table.Column<string>(type: "longtext", nullable: false),
                    state = table.Column<string>(type: "longtext", nullable: false),
                    zip = table.Column<string>(type: "longtext", nullable: false),
                    country = table.Column<string>(type: "longtext", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AssignmentType",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(type: "longtext", nullable: false),
                    status = table.Column<string>(type: "longtext", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssignmentType", x => x.id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Department",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(type: "longtext", nullable: false),
                    description = table.Column<string>(type: "longtext", nullable: true),
                    status = table.Column<string>(type: "longtext", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Department", x => x.id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "QuestionType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Type = table.Column<string>(type: "longtext", nullable: false),
                    Status = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestionType", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(type: "longtext", nullable: false),
                    status = table.Column<string>(type: "longtext", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "tenants",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(type: "longtext", nullable: false),
                    description = table.Column<string>(type: "longtext", nullable: true),
                    contact_person_name = table.Column<string>(type: "longtext", nullable: false),
                    contact_person_email = table.Column<string>(type: "longtext", nullable: false),
                    contact_phone_number = table.Column<string>(type: "longtext", nullable: false),
                    tenant_config = table.Column<string>(type: "longtext", nullable: false),
                    status = table.Column<string>(type: "longtext", nullable: false),
                    address_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tenants", x => x.id);
                    table.ForeignKey(
                        name: "FK_tenants_Address_address_id",
                        column: x => x.address_id,
                        principalTable: "Address",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Assignment",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(type: "longtext", nullable: false),
                    description = table.Column<string>(type: "longtext", nullable: false),
                    type_id = table.Column<int>(type: "int", nullable: false),
                    TypeId1 = table.Column<int>(type: "int", nullable: false),
                    certificate_id = table.Column<int>(type: "int", nullable: false),
                    has_questions = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    total_questions = table.Column<int>(type: "int", nullable: false),
                    min_score = table.Column<int>(type: "int", nullable: false),
                    is_global = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    status = table.Column<string>(type: "longtext", nullable: false),
                    TenantId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Assignment", x => x.id);
                    table.ForeignKey(
                        name: "FK_Assignment_AssignmentType_TypeId1",
                        column: x => x.TypeId1,
                        principalTable: "AssignmentType",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Assignment_AssignmentType_type_id",
                        column: x => x.type_id,
                        principalTable: "AssignmentType",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Assignment_tenants_TenantId",
                        column: x => x.TenantId,
                        principalTable: "tenants",
                        principalColumn: "id");
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    first_name = table.Column<string>(type: "longtext", nullable: false),
                    last_name = table.Column<string>(type: "longtext", nullable: false),
                    middle_name = table.Column<string>(type: "longtext", nullable: true),
                    tenant_id = table.Column<int>(type: "int", nullable: false),
                    role_id = table.Column<int>(type: "int", nullable: false),
                    skills = table.Column<string>(type: "json", nullable: true),
                    email_id = table.Column<string>(type: "longtext", nullable: false),
                    created_date = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Status = table.Column<string>(type: "longtext", nullable: false),
                    RoleId1 = table.Column<int>(type: "int", nullable: true),
                    TenantId1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.id);
                    table.ForeignKey(
                        name: "FK_Employee_Roles_RoleId1",
                        column: x => x.RoleId1,
                        principalTable: "Roles",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_Employee_Roles_role_id",
                        column: x => x.role_id,
                        principalTable: "Roles",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Employee_tenants_TenantId1",
                        column: x => x.TenantId1,
                        principalTable: "tenants",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_Employee_tenants_tenant_id",
                        column: x => x.tenant_id,
                        principalTable: "tenants",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Question",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    question_text = table.Column<string>(type: "varchar(5000)", maxLength: 5000, nullable: false),
                    QuestionTypeId = table.Column<int>(type: "int", nullable: false),
                    options = table.Column<string>(type: "json", nullable: true),
                    answers = table.Column<string>(type: "json", nullable: true),
                    status = table.Column<string>(type: "longtext", nullable: false),
                    AssignmentId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Question", x => x.id);
                    table.ForeignKey(
                        name: "FK_Question_Assignment_AssignmentId",
                        column: x => x.AssignmentId,
                        principalTable: "Assignment",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_Question_QuestionType_QuestionTypeId",
                        column: x => x.QuestionTypeId,
                        principalTable: "QuestionType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "tenant_assignments",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    tenant_id = table.Column<int>(type: "int", nullable: false),
                    assignment_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tenant_assignments", x => x.id);
                    table.ForeignKey(
                        name: "FK_tenant_assignments_Assignment_assignment_id",
                        column: x => x.assignment_id,
                        principalTable: "Assignment",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tenant_assignments_tenants_tenant_id",
                        column: x => x.tenant_id,
                        principalTable: "tenants",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "employee_assignments",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    employee_id = table.Column<int>(type: "int", nullable: false),
                    assignment_id = table.Column<int>(type: "int", nullable: false),
                    end_date = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    assigned_date = table.Column<DateTime>(type: "datetime(6)", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP(6)"),
                    no_of_attempts = table.Column<int>(type: "int", nullable: false),
                    result = table.Column<string>(type: "longtext", nullable: false),
                    AssignmentId1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_employee_assignments", x => x.id);
                    table.ForeignKey(
                        name: "FK_employee_assignments_Assignment_AssignmentId1",
                        column: x => x.AssignmentId1,
                        principalTable: "Assignment",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_employee_assignments_Assignment_assignment_id",
                        column: x => x.assignment_id,
                        principalTable: "Assignment",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_employee_assignments_Employee_employee_id",
                        column: x => x.employee_id,
                        principalTable: "Employee",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "employee_departments",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    employee_id = table.Column<int>(type: "int", nullable: false),
                    department_id = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<string>(type: "longtext", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_employee_departments", x => x.id);
                    table.ForeignKey(
                        name: "FK_employee_departments_Department_department_id",
                        column: x => x.department_id,
                        principalTable: "Department",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_employee_departments_Employee_employee_id",
                        column: x => x.employee_id,
                        principalTable: "Employee",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    user_id = table.Column<string>(type: "longtext", nullable: false),
                    password = table.Column<string>(type: "longtext", nullable: false),
                    employee_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                    table.ForeignKey(
                        name: "FK_User_Employee_employee_id",
                        column: x => x.employee_id,
                        principalTable: "Employee",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AssignmentQuestions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    QuestionId = table.Column<int>(type: "int", nullable: false),
                    AssignmentId = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssignmentQuestions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AssignmentQuestions_Assignment_AssignmentId",
                        column: x => x.AssignmentId,
                        principalTable: "Assignment",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AssignmentQuestions_Question_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "Question",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "id", "name", "status" },
                values: new object[,]
                {
                    { 1, "superadmin", "1" },
                    { 2, "admin", "1" },
                    { 3, "employee", "1" }
                });

            migrationBuilder.InsertData(
                table: "tenants",
                columns: new[] { "id", "address_id", "contact_person_email", "contact_person_name", "contact_phone_number", "description", "name", "status", "tenant_config" },
                values: new object[] { 1, null, "superadmin", "superadmin", "999999999", "superadmin", "superadmin", "1", "{}" });

            migrationBuilder.InsertData(
                table: "Employee",
                columns: new[] { "id", "created_date", "email_id", "first_name", "last_name", "middle_name", "role_id", "RoleId1", "skills", "Status", "tenant_id", "TenantId1" },
                values: new object[] { 1000, new DateTime(2025, 1, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "admin@smartdataglobal.in", "superadmin", "superadmin", null, 1, null, "{\"Programming\":\"C#\",\"Database\":\"MySQL\"}", "1", 1, null });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "employee_id", "password", "user_id" },
                values: new object[] { 1, 1000, "$2a$11$Nc/RPp/WSRJmVBmoeh3a5eE3/PPBa8k0ji94a1R.3n2O2iW432sOu", "superadmin" });

            migrationBuilder.CreateIndex(
                name: "IX_Assignment_TenantId",
                table: "Assignment",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_Assignment_type_id",
                table: "Assignment",
                column: "type_id");

            migrationBuilder.CreateIndex(
                name: "IX_Assignment_TypeId1",
                table: "Assignment",
                column: "TypeId1");

            migrationBuilder.CreateIndex(
                name: "IX_AssignmentQuestions_AssignmentId",
                table: "AssignmentQuestions",
                column: "AssignmentId");

            migrationBuilder.CreateIndex(
                name: "IX_AssignmentQuestions_QuestionId",
                table: "AssignmentQuestions",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_role_id",
                table: "Employee",
                column: "role_id");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_RoleId1",
                table: "Employee",
                column: "RoleId1");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_tenant_id",
                table: "Employee",
                column: "tenant_id");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_TenantId1",
                table: "Employee",
                column: "TenantId1");

            migrationBuilder.CreateIndex(
                name: "IX_employee_assignments_assignment_id",
                table: "employee_assignments",
                column: "assignment_id");

            migrationBuilder.CreateIndex(
                name: "IX_employee_assignments_AssignmentId1",
                table: "employee_assignments",
                column: "AssignmentId1");

            migrationBuilder.CreateIndex(
                name: "IX_employee_assignments_employee_id",
                table: "employee_assignments",
                column: "employee_id");

            migrationBuilder.CreateIndex(
                name: "IX_employee_departments_department_id",
                table: "employee_departments",
                column: "department_id");

            migrationBuilder.CreateIndex(
                name: "IX_employee_departments_employee_id",
                table: "employee_departments",
                column: "employee_id");

            migrationBuilder.CreateIndex(
                name: "IX_Question_AssignmentId",
                table: "Question",
                column: "AssignmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Question_QuestionTypeId",
                table: "Question",
                column: "QuestionTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_tenant_assignments_assignment_id",
                table: "tenant_assignments",
                column: "assignment_id");

            migrationBuilder.CreateIndex(
                name: "IX_tenant_assignments_tenant_id",
                table: "tenant_assignments",
                column: "tenant_id");

            migrationBuilder.CreateIndex(
                name: "IX_tenants_address_id",
                table: "tenants",
                column: "address_id");

            migrationBuilder.CreateIndex(
                name: "IX_User_employee_id",
                table: "User",
                column: "employee_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AssignmentQuestions");

            migrationBuilder.DropTable(
                name: "employee_assignments");

            migrationBuilder.DropTable(
                name: "employee_departments");

            migrationBuilder.DropTable(
                name: "tenant_assignments");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Question");

            migrationBuilder.DropTable(
                name: "Department");

            migrationBuilder.DropTable(
                name: "Employee");

            migrationBuilder.DropTable(
                name: "Assignment");

            migrationBuilder.DropTable(
                name: "QuestionType");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "AssignmentType");

            migrationBuilder.DropTable(
                name: "tenants");

            migrationBuilder.DropTable(
                name: "Address");
        }
    }
}
