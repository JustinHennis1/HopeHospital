using System;
using System.Collections.Generic;
using ProjectHennisJustin.Pages.Diagnosis;
using ProjectHennisJustin.Pages.Patient;
using System.ComponentModel.DataAnnotations;

namespace ProjectHennisJustin.Pages.Billing;

public partial class TblBilling
{
    public int BillId { get; set; }

    public decimal Cost { get; set; }

    public string Status { get; set; } = null!;

    [Display(Name = "Billing Date")]
    public DateOnly BillDate { get; set; }

    [Display(Name = "Patient Number")]
    public int? PatientId { get; set; }

    public virtual TblPatient? Patient { get; set; }

    public virtual ICollection<TblDiagnosis> TblDiagnoses { get; set; } = new List<TblDiagnosis>();
}
