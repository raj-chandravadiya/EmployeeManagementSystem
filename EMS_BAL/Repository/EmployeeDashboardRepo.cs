using EMS_BAL.Interface;
using EMS_DAL.DataContext;
using EMS_DAL.DataModels;
using EMS_DAL.ViewModels;

namespace EMS_BAL.Repository
{
    public class EmployeeDashboardRepo : IEmployeeDashboardRepo
    {
        private readonly ApplicationDbContext _context;

        public EmployeeDashboardRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        #region EMPLOYEE DASHBOARD
        public CreateEmployeeViewModel EmployeeDashboard()
        {
            List<EMS_DAL.DataModels.Department> departments = _context.Departments.ToList();

            CreateEmployeeViewModel model = new()
            {
                DepartmentList = departments,
            };

            return model;
        }

        public EmployeeDashboardViewModel EmployeesList(string filterSearch, int page)
        {
            int pageSize = 5;
            int pageNumber = 1;
            if (page > 0)
            {
                pageNumber = page;
            }

            EmployeeDashboardViewModel model = new();

            var empl = from e in _context.Employees
                       join d in _context.Departments on e.DeptId equals d.Id
                       where (string.IsNullOrEmpty(filterSearch) || (e.FirstName + " " + e.LastName).ToUpper().Contains(filterSearch.ToUpper()))
                       select new EmployeeList
                       {
                           Id = e.Id,
                           FirstName = e.FirstName,
                           LastName = e.LastName,
                           Email = e.Email,
                           Age = e.Age,
                           Department = d.Name,
                           Education = e.Education,
                           CompanyName = e.Company,
                           Experience = e.Experience,
                           Package = e.Package,
                           Gender = e.Gender,
                       };

            model.totalPage = (int)Math.Ceiling(empl.Count() / (double)pageSize);
            model.EmployeeList = empl.ToList().Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();
            model.currentPage = pageNumber;
            model.pageSize = pageSize;

            return model;
        }
        #endregion

        #region CREATE EMPLOYEE
        public void CreateEmployee(CreateEmployeeViewModel model)
        {
            Employee employee = new Employee()
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                Age = model.Age,
                DeptId = model.Department,
                Education = model.Education,
                Company = model.CompanyName,
                Experience = model.Experience,
                Package = model.Package,
                Gender = model.Gender,

            };
            _context.Add(employee);
            _context.SaveChanges();
        }
        #endregion

        #region EDIT & UPDATE EMPLOYEE
        public CreateEmployeeViewModel EditEmployee(int id)
        {
            Employee? employee = _context.Employees.FirstOrDefault(x => x.Id == id);
            CreateEmployeeViewModel model = new CreateEmployeeViewModel();

            if (employee != null)
            {

                model.FirstName = employee.FirstName;
                model.LastName = employee.LastName;
                model.Email = employee.Email;
                model.Age = employee.Age;
                model.Department = employee.DeptId;
                model.Education = employee.Education;
                model.CompanyName = employee.Company;
                model.Experience = employee.Experience;
                model.Package = employee.Package;
                model.EmplId = id;
                model.Gender = employee.Gender;
            }

            model.DepartmentList = _context.Departments.ToList();

            return model;
        }

        public void UpdateEmployee(CreateEmployeeViewModel model)
        {
            Employee? person = _context.Employees.FirstOrDefault(e => e.Id == model.EmplId);

            if (person != null)
            {
                person.FirstName = model.FirstName;
                person.LastName = model.LastName;
                person.Email = model.Email;
                person.Age = model.Age;
                person.DeptId = model.Department;
                person.Education = model.Education;
                person.Company = model.CompanyName;
                person.Experience = model.Experience;
                person.Package = model.Package;
                person.Gender = model.Gender;

                _context.Update(person);
            }
            _context.SaveChanges();
        }
        #endregion

        #region DELETE EMPLOYEE
        public void DeleteEmployee(int id)
        {
            Employee? person = _context.Employees.FirstOrDefault(e => e.Id == id);

            if (person != null)
            {
                _context.Remove(person);
            }
            _context.SaveChanges();
        }
        #endregion

    }
}
