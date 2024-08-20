namespace EMS_DAL.ViewModels
{
    public class EmployeeDashboardViewModel
    {
        public List<CreateEmployeeViewModel>? createEmployeeViewModels { get; set; }

        public int totalPage {  get; set; }
        public int pageSize {  get; set; }
        public int currentPage {  get; set; }

        public List<EmployeeList>? EmployeeList { get; set; }
    }
}
