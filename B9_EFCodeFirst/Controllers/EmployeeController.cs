using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using B9_EFCodeFirst.Models;

namespace B9_EFCodeFirst.Controllers
{
    public class EmployeeController : Controller
    {
        //
        // GET: /Employee/
        MyCompanyDBContext db = new MyCompanyDBContext();
        public ActionResult Index( string SortBy, int page=1)
        {
            List<Employee> emp = db.Employees.ToList();
            //Sort
            switch(SortBy)
            {
                case "name":
                    emp = emp.OrderBy(row => row.Name).ToList();
                    break;
                case "gender":
                    emp = emp.OrderBy(row => row.Gender).ToList();
                    break;
                case "city":
                    emp = emp.OrderBy(row => row.City == null ? "" : row.City.ToLower().Trim()).ToList();
                    break;
                case "department":
                    emp = emp.OrderBy(row => row.Department.Name).ToList();
                    break;
                case "age":
                    emp = emp.OrderBy(row => row.Age).ToList();
                    break;
                default:
                    emp = emp.OrderBy(row => row.Id).ToList();
                    break;
            }
            //Paging
            int RecordsPerPage = 4;
            int NumbersOfRecords = emp.Count();
            int NumbersOfPage = (int)Math.Ceiling((double)NumbersOfRecords / RecordsPerPage);
            ViewBag.CurrentPage = page;
            ViewBag.TotalPage = NumbersOfPage;
            ViewBag.SortBy = SortBy;
            emp = emp.Skip((page - 1) * RecordsPerPage).Take(RecordsPerPage).ToList();
            return View(emp);
        }

        public ActionResult Insert()
        {
            ViewBag.Department = db.Departments.ToList();
            return View();
        }
        [HttpPost]
        public ActionResult Insert(Employee emp)
        {
            if(ModelState.IsValid)
            {
                db.Employees.Add(emp);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Department=db.Departments.ToList();
            return View(emp);
        }

        public ActionResult Edit(int id)
        {
            ViewBag.Department = db.Departments.ToList();
            Employee emp = db.Employees.Where(row => row.Id == id).FirstOrDefault();
            return View(emp);
        }

        [HttpPost]
        public ActionResult Edit(Employee emp)
        {
            Employee employee = db.Employees.Where(row => row.Id == emp.Id).FirstOrDefault();
            employee.Id = emp.Id;
            employee.Name = emp.Name;
            employee.City = emp.City;
            employee.Gender = emp.Gender;
            employee.DepID = emp.DepID;
            employee.Age = emp.Age;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            Employee emp = db.Employees.Where(row => row.Id == id).FirstOrDefault();
            return View(emp);
        }
        [HttpPost]
        public ActionResult Delete(int id, Employee emp)
        {
            Employee employee = db.Employees.Where(row => row.Id == id).FirstOrDefault();
            db.Employees.Remove(employee);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


	}
}