using System;
using System.Collections.Generic;
using ProjectHennisJustin.Pages.Diagnosis;
using System.ComponentModel.DataAnnotations;
namespace ProjectHennisJustin.Pages.Doctor;

public partial class TblDoctor
{
    public int DoctorId { get; set; }

    [Display(Name = "NPI")]
    public int NpiNumber { get; set; }

    [Display(Name = "First Name")]
    public string FirstName { get; set; } = null!;

    [Display(Name = "Last Name")]
    public string LastName { get; set; } = null!;

    [Display(Name = "Date of Employment")]
    public DateOnly EmploymentDate { get; set; }

    [Display(Name = "Department")]
    public string CareUnit { get; set; } = null!;

    public virtual ICollection<TblDiagnosis> TblDiagnoses { get; set; } = new List<TblDiagnosis>();
}
