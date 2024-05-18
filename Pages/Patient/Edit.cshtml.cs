using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjectHennisJustin;

namespace ProjectHennisJustin.Pages.Patient
{
    public class EditModel : PageModel
    {
        private readonly ProjectHennisJustin.Jhennis1Context _context;

        public EditModel(ProjectHennisJustin.Jhennis1Context context)
        {
            _context = context;
        }

        [BindProperty]
        public TblPatient TblPatient { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblpatient =  await _context.TblPatients.FirstOrDefaultAsync(m => m.PatientId == id);
            if (tblpatient == null)
            {
                return NotFound();
            }
            TblPatient = tblpatient;
           ViewData["InsuranceId"] = new SelectList(_context.TblInsurances, "InsuranceId", "InsuranceId");
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

            _context.Attach(TblPatient).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblPatientExists(TblPatient.PatientId))
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

        private bool TblPatientExists(int id)
        {
            return _context.TblPatients.Any(e => e.PatientId == id);
        }
    }
}
