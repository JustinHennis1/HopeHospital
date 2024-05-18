using System;
using System.Collections.Generic;
using ProjectHennisJustin.Pages.Patient;
using System.ComponentModel.DataAnnotations;
namespace ProjectHennisJustin.Pages.Insurance;

public partial class TblInsurance
{
    public int InsuranceId { get; set; }

    [Display(Name = "Company")]
    public string? CompanyName { get; set; }

    public string Coverage { get; set; } = null!;

    [Display(Name = "Group")]
    public int GroupId { get; set; }

    public virtual ICollection<TblPatient> TblPatients { get; set; } = new List<TblPatient>();
}
