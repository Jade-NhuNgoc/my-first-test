using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using B9_EFCodeFirst.Models;

namespace B9_EFCodeFirst.Controllers
{
    public class DepartmentController : Controller
    {
        //
        // GET: /Department/
        MyCompanyDBContext db = new MyCompanyDBContext();
        public ActionResult Index()
        {
            List<Department> dep = db.Departments.ToList(); 
            return View(dep);
        }

        public ActionResult Detail(int id)
        {
            Department dep = db.Departments.Where(row=> row.DepID == id).FirstOrDefault();
            if(dep==null)
            {
                return View("NotFound");
            }
            List<Employee> emp = db.Employees.Where(row => row.DepID == id).ToList();
            ViewBag.emp = emp;
            return View(dep);
        }
	}
}