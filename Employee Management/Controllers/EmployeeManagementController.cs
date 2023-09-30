using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccessLayer;

namespace Employee_Management.Controllers
{
    public class EmployeeManagementController : Controller
    {
        public EmployeeRepository obj;
        public EmployeeManagementController()
        {
            obj = new EmployeeRepository();
        }
        public ActionResult List()
        {
            try
            {
                return View("List", obj.GetAllEmployeeData());
            }
            catch(Exception ex)
            {
                throw ex;
            }
            
        }

        // GET: EmployeeManagementController/Details/5
        public ActionResult Details(int Id)
        {
            var result = obj.GetEmployeeData(Id);
            return View("Details", result);
        }
       
        public ActionResult Create()
        {
            var result = new EmployeeModel();
            return View("Create", result);
           
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(EmployeeModel data)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    obj.InsertEmployeeData(data);
                    return RedirectToAction(nameof(List));
                }
                else
                {
                    return View("Create", data);

                }
            }
            catch
            {
                return View("Error");
            }
        }

       
        public ActionResult Edit(int Id)
        {
            try
            {
                var result = obj.GetEmployeeData(Id);
                return View("Edit", result);
            }
            catch
            {
                return View("Error");
            }

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int Id, EmployeeModel data)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    obj.UpdateEmployeeData(data);
                    return RedirectToAction(nameof(List));
                }
                else
                {
                    return View("Edit", data);

                }
            }
            catch
            {
                return View("Error");
            }
        }

        
        public ActionResult Delete(int Id)
        {
            var result = obj.GetEmployeeData(Id);
            return View("Delete", result);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Remove(int Id)
        {
            try
            {
                obj.DeleteEmployeeData(Id);
                return RedirectToAction(nameof(List));
            }
            catch
            {
                return View("Error");
            }
        }
    }
}
