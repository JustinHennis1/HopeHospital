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
    public class DeleteModel : PageModel
    {
        private readonly ProjectHennisJustin.Jhennis1Context _context;

        public DeleteModel(ProjectHennisJustin.Jhennis1Context context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblinsurance = await _context.TblInsurances.FindAsync(id);
            if (tblinsurance != null)
            {
                TblInsurance = tblinsurance;
                _context.TblInsurances.Remove(TblInsurance);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
