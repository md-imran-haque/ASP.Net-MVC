using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace ProjectWork_M8_1247624.Models
{
    public enum Grade
    {
        M01 = 1, M02, M03, G01, G02, S01, S02
    }
    public class Department
    {
        public Department()
        {
            this.Employees = new HashSet<Employee>();
        }
        [Display(Name = "Department Id")]
        public int DepartmentId { get; set; }
        [Required, StringLength(50), Display(Name = "Department Name")]
        public string DepartmentName { get; set; }
        //Navigation
        public virtual ICollection<Employee> Employees { get; set; }
    }
    public class Employee
    {
        [Display(Name = "Employee Id")]
        public int EmployeeId { get; set; }
        [Required, StringLength(50), Display(Name = "Employee Name")]
        public string EmployeeName { get; set; }
        [Required,
        Column(TypeName = "date"),
        Display(Name = "Joining Date"),
        DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime JoinDate { get; set; }
        [Required, EnumDataType(typeof(Grade)), Display(Name = "Grade")]
        public Grade Grade { get; set; }
        //FK
        [Required, ForeignKey("Department"), Display(Name = "Department Id")]
        public int DepartmentId { get; set; }
        //Navigation
        public virtual Department Department { get; set; }

    }
    public class ProjectDbContext : DbContext
    {
        public ProjectDbContext()
        {
            Database.SetInitializer(new DbInitilizer());
        }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }
    }
    public class DbInitilizer : DropCreateDatabaseIfModelChanges<ProjectDbContext>
    {
        protected override void Seed(ProjectDbContext context)
        {
            Department d1 = new Department { DepartmentName = "Accounts" };
            d1.Employees.Add(new Employee { EmployeeName = "Md. Abul Hasan", JoinDate = DateTime.Parse("2008-02-01"), Grade = Grade.M02 });
            Department d2 = new Department { DepartmentName = "Finance" };
            d2.Employees.Add(new Employee { EmployeeName = "Jobair Hossain", JoinDate = DateTime.Parse("2009-07-03"), Grade = Grade.M03 });
            context.Departments.AddRange(new Department[] { d1, d2 });
            context.SaveChanges();
            base.Seed(context);
        }
    }
}