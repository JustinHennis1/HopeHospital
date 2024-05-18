using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjectHennisJustin;

namespace ProjectHennisJustin.Pages.Billing
{
    public class EditModel : PageModel
    {
        private readonly ProjectHennisJustin.Jhennis1Context _context;

        public EditModel(ProjectHennisJustin.Jhennis1Context context)
        {
            _context = context;
        }

        [BindProperty]
        public TblBilling TblBilling { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblbilling =  await _context.TblBillings.FirstOrDefaultAsync(m => m.BillId == id);
            if (tblbilling == null)
            {
                return NotFound();
            }
            TblBilling = tblbilling;
           ViewData["PatientId"] = new SelectList(_context.TblPatients, "PatientId", "PatientId");
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

            _context.Attach(TblBilling).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblBillingExists(TblBilling.BillId))
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

        private bool TblBillingExists(int id)
        {
            return _context.TblBillings.Any(e => e.BillId == id);
        }
    }
}
