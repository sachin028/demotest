using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KPITDemoTest.Models;

namespace KPITDemoTest.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        public ActionResult Employee()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Employee(Employee objEmp)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (var ctx = new TestDBEntities())
                    {
                        ctx.Employees.Add(objEmp);
                        ctx.SaveChanges();
                        ModelState.Clear();
                    }
                    return Employee();
                }
                else
                {
                    return Employee();
                }
            }
            catch (Exception ex)
            {
                return Employee();
            }
        }

        public ActionResult _EmployeeDetails()
        {
            List<view_employee_details> lstEmployee = new List<view_employee_details>();
            using (var ctx = new TestDBEntities())
            {
                lstEmployee = (from i in ctx.view_employee_details
                               select i).ToList();
                return PartialView(lstEmployee);
            }
        }

        [HttpPost]
        public ActionResult DeleteEmployeeDetails(string id)
        {
            try
            {
                int Record_ID = Convert.ToInt32(id);
                using (var ctx = new TestDBEntities())
                {
                    Employee emp = ctx.Employees.Find(Record_ID);
                    ctx.Employees.Remove(emp);
                    ctx.SaveChanges();
                }
                return Redirect(Request.UrlReferrer.ToString());
                //return RedirectToAction("Employee", "Employee");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
    }
}