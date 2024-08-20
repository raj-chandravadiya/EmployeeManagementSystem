using EMS_DAL.DataModels;

namespace EMS_DAL.ViewModels
{
    public class CreateEmployeeViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int? Age { get; set; }
        public int Department { get; set; }
        public string Education { get; set; }
        public string CompanyName { get; set; }
        public int? Experience { get; set; }
        public int? Package { get; set; }
        public int EmplId { get; set; }
        public string? Gender { get; set; }

        public List<Department>? DepartmentList { get; set; }


        

    }
}
