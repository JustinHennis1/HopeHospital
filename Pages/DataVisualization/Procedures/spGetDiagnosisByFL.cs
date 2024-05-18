using Microsoft.VisualBasic;
using System;
using System.ComponentModel.DataAnnotations;

namespace ProjectHennisJustin.Pages.DataVisualization.Views
{
    public class spGetDiagnosisByFL
    {
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Display(Name = "Disease Name")]
        public string DiseaseName { get; set; }
        public string Treatment { get; set; }
        public string Prescriber { get; set; }
        [Display(Name = "Date Diagnosed")]
        public DateOnly DiagnosisDate { get; set; }
    }
}