using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EMS_DAL.DataModels;

[Table("Employee")]
[Index("Email", Name = "EmailUnique", IsUnique = true)]
public partial class Employee
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    [StringLength(30)]
    public string FirstName { get; set; } = null!;

    [StringLength(30)]
    public string? LastName { get; set; }

    public int DeptId { get; set; }

    public int? Age { get; set; }

    [StringLength(40)]
    public string Email { get; set; } = null!;

    [StringLength(30)]
    public string? Education { get; set; }

    [StringLength(30)]
    public string? Company { get; set; }

    public int? Experience { get; set; }

    public int? Package { get; set; }

    [StringLength(10)]
    public string? Gender { get; set; }

    [ForeignKey("DeptId")]
    [InverseProperty("Employees")]
    public virtual Department Dept { get; set; } = null!;
}
