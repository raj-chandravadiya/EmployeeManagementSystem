using Microsoft.AspNetCore.Mvc;
using EMS_DAL.ViewModels;
using EMS_BAL.Interface;
using AspNetCoreHero.ToastNotification.Abstractions;

namespace AssignmentTask.Controllers
{
    public class EmployeeDashboardController : Controller
    {
        private readonly IEmployeeDashboardRepo _employeeDashboardRepo;
        private readonly INotyfService _notyf;

        public EmployeeDashboardController(IEmployeeDashboardRepo employeeDashboardRepo, INotyfService notyf)
        {
            _employeeDashboardRepo = employeeDashboardRepo;
            _notyf = notyf;
        }

        #region EMPLOYEE DASHBOARD
        public IActionResult EmployeeDashboard()
        {
            try
            {
                CreateEmployeeViewModel model = _employeeDashboardRepo.EmployeeDashboard();

                return View(model);
            }
            catch
            {
                return RedirectToAction("Error");
            }
        }

        public IActionResult EmployeesList(string filterSearch, int page)
        {
            try
            {
                EmployeeDashboardViewModel model = _employeeDashboardRepo.EmployeesList(filterSearch, page);

                return PartialView("_EmployeeList", model);
            }
            catch
            {
                throw new Exception();
            }
        }
        #endregion

        #region CREATE EMPLOYEE
        public IActionResult CreateEmployee(CreateEmployeeViewModel model)
        {
            try
            {
                _employeeDashboardRepo.CreateEmployee(model);
                _notyf.Success("Employee is Created Successfully");
                return RedirectToAction("EmployeeDashboard");
            }
            catch
            {
                _notyf.Error("Something went Wrong or Ensure to enter a Valid Email Address.");
                return RedirectToAction("EmployeeDashboard");
            }
        }
        #endregion

        #region EDIT & UPDATE EMPLOYEE
        public IActionResult EditEmployee(int id)
        {
            try
            {
                CreateEmployeeViewModel model = _employeeDashboardRepo.EditEmployee(id);
                return PartialView("_EditEmployeeModal", model);
            }
            catch
            {
                _notyf.Error("Something went Wrong.");
                return Ok();
            }
        }

        public IActionResult UpdateEmployee(CreateEmployeeViewModel model)
        {
            try
            {
                _employeeDashboardRepo.UpdateEmployee(model);
                _notyf.Success("Employee details is Updated Successfully");
                return RedirectToAction("EmployeeDashboard");
            }
            catch
            {
                _notyf.Error("Something went Wrong or Ensure to enter a Valid Email Address.");
                return RedirectToAction("EmployeeDashboard");
            }
        }
        #endregion

        #region DELETE EMPLOYEE
        public IActionResult DeleteEmployee(int id)
        {
            try
            {
                _employeeDashboardRepo.DeleteEmployee(id);
                _notyf.Success("Employee is deleted Successfully.");
                return RedirectToAction("EmployeeDashboard");
            }
            catch
            {
                _notyf.Error("Something went Wrong.");
                return RedirectToAction("EmployeeDashboard");
            }
        }
        #endregion

        #region ERROR
        public IActionResult Error()
        {
            return View();
        }
        #endregion
    }
}
