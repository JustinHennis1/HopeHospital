using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProjectHennisJustin;

namespace ProjectHennisJustin.Pages.Insurance
{
    public class DetailsModel : PageModel
    {
        private readonly ProjectHennisJustin.Jhennis1Context _context;

        public DetailsModel(ProjectHennisJustin.Jhennis1Context context)
        {
            _context = context;
        }

        public TblInsurance TblInsurance { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblinsurance = await _context.TblInsurances.FirstOrDefaultAsync(m => m.InsuranceId == id);
            if (tblinsurance == null)
            {
                return NotFound();
            }
            else
            {
                TblInsurance = tblinsurance;
            }
            return Page();
        }
    }
}
