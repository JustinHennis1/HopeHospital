using System;
using System.Collections.Generic;
using ProjectHennisJustin.Pages.Billing;
using ProjectHennisJustin.Pages.Diagnosis;
using ProjectHennisJustin.Pages.Insurance;
using System.ComponentModel.DataAnnotations;
namespace ProjectHennisJustin.Pages.Patient;

public partial class TblPatient
{
    public int PatientId { get; set; }

    [Display(Name = "Date of Visit")]
    public DateOnly VisitDate { get; set; }

    [Display(Name = "First Name")]
    public string FirstName { get; set; } = null!;

    [Display(Name = "Last Name")]
    public string LastName { get; set; } = null!;

    public string Address { get; set; } = null!;

   
    public string FormattedPhoneNumber
    {
        get
        {
            if (string.IsNullOrEmpty(PhoneNumber))
                return string.Empty;

            return string.Format("{0:###-###-####}", long.Parse(PhoneNumber));
        }
    }
    [Display(Name = "Phone Number")]
    public string? PhoneNumber { get; set; }

    [Display(Name = "Insurance")]
    public int? InsuranceId { get; set; }

    [Display(Name = "Symptom")]
    public string SymptomCode { get; set; } = null!;

    public virtual TblInsurance? Insurance { get; set; }

    public virtual ICollection<TblBilling> TblBillings { get; set; } = new List<TblBilling>();

    public virtual ICollection<TblDiagnosis> TblDiagnoses { get; set; } = new List<TblDiagnosis>();
}
