using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EMS_DAL.DataModels;

[Table("Department")]
public partial class Department
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    [StringLength(50)]
    public string Name { get; set; } = null!;

    [InverseProperty("Dept")]
    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
}
