using AspMvc_CRUD_Dapper.Models;
using AspMvc_CRUD_Dapper.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AspMvc_CRUD_Dapper.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        public ActionResult Index()
        {
            return View();
        }

        //GET : Employee/GetAllEmpDetails
        public ActionResult GetAllEmpDetails()
        {
            EmpRepository EmpRepo = new EmpRepository();
            return View(EmpRepo.GetAllEmployee());
        }

        //GET : Employee/AddEmployee
        public ActionResult AddEmployee()
        {
            return View();
        }

        //POSt : Employee/AddEmployee
        [HttpPost]
        public ActionResult AddEmployee(EmpModel Emp)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    EmpRepository EmpRepo = new EmpRepository();
                    EmpRepo.AddEmployee(Emp);
                    ViewBag.Message = "Record added successfully";
                }
                return View();
            }
            catch 
            {
                return View();
            }
        }

        //GET: Bind control to Update details
        public ActionResult EditEmpDetails(int id)
        {
            EmpRepository EmpRepo = new EmpRepository();
            return View(EmpRepo.GetAllEmployee().Find(Emp => Emp.Empid == id));
        }

        //POST : Update the details into database
        [HttpPost]
        public ActionResult EditEmpDetails(int id ,EmpModel obj)
        {
            try
            {
                EmpRepository EmpRepo = new EmpRepository();
                EmpRepo.UpdateEmployee(obj);
                return RedirectToAction("GetAllEmpDetails");
            }
            catch
            {
                return View();
            }
        }

        //GET : Delete Employee details by Id
        public ActionResult DeleteEmp(int id)
        {
            try
            {
                EmpRepository EmpRepo = new EmpRepository();
                if (EmpRepo.DeleteEmployee(id))
                {
                    ViewBag.AlertMsg = "Employee details deleted successfuly";
                }
                return RedirectToAction("GetAllEmpDetails");
            }
            catch 
            {
                return View();
            }
        }
    }
}
