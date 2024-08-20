using EMS_DAL.ViewModels;

namespace EMS_BAL.Interface
{
    public interface IEmployeeDashboardRepo
    {
        #region EMPLOYEE DASHBOARD
        public CreateEmployeeViewModel EmployeeDashboard();

        public EmployeeDashboardViewModel EmployeesList(string filterSearch, int page);
        #endregion

        #region CREATE EMPLOYEE
        public void CreateEmployee(CreateEmployeeViewModel model);
        #endregion

        #region EDIT & UPDATE EMPLOYEE
        public CreateEmployeeViewModel EditEmployee(int id);

        public void UpdateEmployee(CreateEmployeeViewModel model);
        #endregion

        #region DELETE EMPLOYEE
        public void DeleteEmployee(int id);
        #endregion
    }
}
