using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace ProjectHennisJustin.Pages.DataVisualization.Views;

public partial class VwCostandTreat
{
    public string? Treatment { get; set; }

    [Display(Name = "Total Cost")]
    public decimal? TotalCost { get; set; }

    [Display(Name = "Payment Status")]
    public string Status { get; set; } = null!;
}
