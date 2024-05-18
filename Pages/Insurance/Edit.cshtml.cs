using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjectHennisJustin;

namespace ProjectHennisJustin.Pages.Insurance
{
    public class EditModel : PageModel
    {
        private readonly ProjectHennisJustin.Jhennis1Context _context;

        public EditModel(ProjectHennisJustin.Jhennis1Context context)
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

            var tblinsurance =  await _context.TblInsurances.FirstOrDefaultAsync(m => m.InsuranceId == id);
            if (tblinsurance == null)
            {
                return NotFound();
            }
            TblInsurance = tblinsurance;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(TblInsurance).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblInsuranceExists(TblInsurance.InsuranceId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool TblInsuranceExists(int id)
        {
            return _context.TblInsurances.Any(e => e.InsuranceId == id);
        }
    }
}
