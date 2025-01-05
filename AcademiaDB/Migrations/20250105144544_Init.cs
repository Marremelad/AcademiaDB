using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AcademiaDB.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    CourseID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseName = table.Column<string>(type: "nvarchar(35)", maxLength: 35, nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Courses__C92D718724BF5B27", x => x.CourseID);
                });

            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    DepartmentID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DepartmentName = table.Column<string>(type: "nvarchar(35)", maxLength: 35, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Departme__B2079BCD65F30F76", x => x.DepartmentID);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    RoleID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleName = table.Column<string>(type: "nvarchar(35)", maxLength: 35, nullable: false),
                    DepartmentID_FK = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Roles__8AFACE3A367B7819", x => x.RoleID);
                    table.ForeignKey(
                        name: "FK__Roles__Departmen__267ABA7A",
                        column: x => x.DepartmentID_FK,
                        principalTable: "Departments",
                        principalColumn: "DepartmentID");
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    EmployeeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeFirstName = table.Column<string>(type: "nvarchar(35)", maxLength: 35, nullable: false),
                    EmployeeLastName = table.Column<string>(type: "nvarchar(35)", maxLength: 35, nullable: false),
                    EmployeeSSN = table.Column<string>(type: "char(13)", unicode: false, fixedLength: true, maxLength: 13, nullable: false),
                    EmployeeStartDate = table.Column<DateOnly>(type: "date", nullable: false),
                    EmployeeSalary = table.Column<decimal>(type: "money", nullable: false),
                    DepartmentID_FK = table.Column<int>(type: "int", nullable: false),
                    RoleID_FK = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Employee__7AD04FF1F9A331FA", x => x.EmployeeID);
                    table.ForeignKey(
                        name: "FK__Employees__Depar__29572725",
                        column: x => x.DepartmentID_FK,
                        principalTable: "Departments",
                        principalColumn: "DepartmentID");
                    table.ForeignKey(
                        name: "FK__Employees__RoleI__2A4B4B5E",
                        column: x => x.RoleID_FK,
                        principalTable: "Roles",
                        principalColumn: "RoleID");
                });

            migrationBuilder.CreateTable(
                name: "Classes",
                columns: table => new
                {
                    ClassID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClassName = table.Column<string>(type: "nvarchar(35)", maxLength: 35, nullable: false),
                    EmployeeID_FK = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Classes__CB1927A062ADE826", x => x.ClassID);
                    table.ForeignKey(
                        name: "FK__Classes__Employe__2D27B809",
                        column: x => x.EmployeeID_FK,
                        principalTable: "Employees",
                        principalColumn: "EmployeeID");
                });

            migrationBuilder.CreateTable(
                name: "CourseAssignments",
                columns: table => new
                {
                    AssignmentID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeID_FK = table.Column<int>(type: "int", nullable: false),
                    CourseID_FK = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__CourseAs__32499E57F6BC71B4", x => x.AssignmentID);
                    table.ForeignKey(
                        name: "FK__CourseAss__Cours__3B75D760",
                        column: x => x.CourseID_FK,
                        principalTable: "Courses",
                        principalColumn: "CourseID");
                    table.ForeignKey(
                        name: "FK__CourseAss__Emplo__3A81B327",
                        column: x => x.EmployeeID_FK,
                        principalTable: "Employees",
                        principalColumn: "EmployeeID");
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    StudentID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentFirstName = table.Column<string>(type: "nvarchar(35)", maxLength: 35, nullable: false),
                    StudentLastName = table.Column<string>(type: "nvarchar(35)", maxLength: 35, nullable: false),
                    StudentSSN = table.Column<string>(type: "varchar(13)", unicode: false, maxLength: 13, nullable: false),
                    ClassID_FK = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Students__32C52A79434FC887", x => x.StudentID);
                    table.ForeignKey(
                        name: "FK__Students__ClassI__300424B4",
                        column: x => x.ClassID_FK,
                        principalTable: "Classes",
                        principalColumn: "ClassID");
                });

            migrationBuilder.CreateTable(
                name: "CourseEnrolments",
                columns: table => new
                {
                    EnrolmentID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentID_FK = table.Column<int>(type: "int", nullable: false),
                    CourseID_FK = table.Column<int>(type: "int", nullable: false),
                    Grade = table.Column<string>(type: "char(1)", unicode: false, fixedLength: true, maxLength: 1, nullable: true),
                    GradeSetter_FK = table.Column<int>(type: "int", nullable: true),
                    GradingDate = table.Column<DateOnly>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__CourseEn__5C0E5FEF3B22BD9F", x => x.EnrolmentID);
                    table.ForeignKey(
                        name: "FK__CourseEnr__Cours__36B12243",
                        column: x => x.CourseID_FK,
                        principalTable: "Courses",
                        principalColumn: "CourseID");
                    table.ForeignKey(
                        name: "FK__CourseEnr__Grade__37A5467C",
                        column: x => x.GradeSetter_FK,
                        principalTable: "Employees",
                        principalColumn: "EmployeeID");
                    table.ForeignKey(
                        name: "FK__CourseEnr__Gradi__35BCFE0A",
                        column: x => x.StudentID_FK,
                        principalTable: "Students",
                        principalColumn: "StudentID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Classes_EmployeeID_FK",
                table: "Classes",
                column: "EmployeeID_FK");

            migrationBuilder.CreateIndex(
                name: "IX_CourseAssignments_CourseID_FK",
                table: "CourseAssignments",
                column: "CourseID_FK");

            migrationBuilder.CreateIndex(
                name: "IX_CourseAssignments_EmployeeID_FK",
                table: "CourseAssignments",
                column: "EmployeeID_FK");

            migrationBuilder.CreateIndex(
                name: "IX_CourseEnrolments_CourseID_FK",
                table: "CourseEnrolments",
                column: "CourseID_FK");

            migrationBuilder.CreateIndex(
                name: "IX_CourseEnrolments_GradeSetter_FK",
                table: "CourseEnrolments",
                column: "GradeSetter_FK");

            migrationBuilder.CreateIndex(
                name: "IX_CourseEnrolments_StudentID_FK",
                table: "CourseEnrolments",
                column: "StudentID_FK");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_DepartmentID_FK",
                table: "Employees",
                column: "DepartmentID_FK");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_RoleID_FK",
                table: "Employees",
                column: "RoleID_FK");

            migrationBuilder.CreateIndex(
                name: "IX_Roles_DepartmentID_FK",
                table: "Roles",
                column: "DepartmentID_FK");

            migrationBuilder.CreateIndex(
                name: "IX_Students_ClassID_FK",
                table: "Students",
                column: "ClassID_FK");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CourseAssignments");

            migrationBuilder.DropTable(
                name: "CourseEnrolments");

            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Classes");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Departments");
        }
    }
}
