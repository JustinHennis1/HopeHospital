using System;
using System.Collections.Generic;
using ProjectHennisJustin.Pages.Billing;
using ProjectHennisJustin.Pages.Doctor;
using ProjectHennisJustin.Pages.Patient;

namespace ProjectHennisJustin.Pages.Diagnosis;

public partial class TblDiagnosis
{
    public int DiagnosisId { get; set; }

    public DateOnly DiagnosisDate { get; set; }

    public string? DiseaseName { get; set; }

    public string? DiseaseType { get; set; }

    public string? Treatment { get; set; }

    public int? PatientId { get; set; }

    public int? DoctorId { get; set; }

    public int? BillId { get; set; }

    public virtual TblBilling? Bill { get; set; }

    public virtual TblDoctor? Doctor { get; set; }

    public virtual TblPatient? Patient { get; set; }
}
