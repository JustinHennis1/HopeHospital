using Microsoft.VisualBasic;
using System;
using System.ComponentModel.DataAnnotations;

namespace ProjectHennisJustin.Pages.DataVisualization.Views
{
    public class spGetMyBill
    {
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Display(Name = "Cost")]
        public decimal Cost { get; set; }
        public string Coverage { get; set; }
    }
}