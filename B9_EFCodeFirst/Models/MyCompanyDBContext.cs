using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace B9_EFCodeFirst.Models
{
    public class MyCompanyDBContext : DbContext
    {
        public MyCompanyDBContext(): base("MyConnectionString")
        { }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }
    }
}