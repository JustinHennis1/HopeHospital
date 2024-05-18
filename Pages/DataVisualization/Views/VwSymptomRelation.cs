using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace ProjectHennisJustin.Pages.DataVisualization.Views;

public partial class VwSymptomRelation
{
    [Display(Name = "Number of Patients")]
    public int? PatientCount { get; set; }

    [Display(Name = "Disease")]
    public string? DiseaseName { get; set; }

    [Display(Name = "Symptom")]
    public string SymptomCode { get; set; } = null!;
}
