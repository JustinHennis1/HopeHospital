using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjectHennisJustin;

namespace ProjectHennisJustin.Pages.Diagnosis
{
    public class EditModel : PageModel
    {
        private readonly ProjectHennisJustin.Jhennis1Context _context;

        public EditModel(ProjectHennisJustin.Jhennis1Context context)
        {
            _context = context;
        }

        [BindProperty]
        public TblDiagnosis TblDiagnosis { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbldiagnosis =  await _context.TblDiagnoses.FirstOrDefaultAsync(m => m.DiagnosisId == id);
            if (tbldiagnosis == null)
            {
                return NotFound();
            }
            TblDiagnosis = tbldiagnosis;
           ViewData["BillId"] = new SelectList(_context.TblBillings, "BillId", "BillId");
           ViewData["DoctorId"] = new SelectList(_context.TblDoctors, "DoctorId", "DoctorId");
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

            _context.Attach(TblDiagnosis).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblDiagnosisExists(TblDiagnosis.DiagnosisId))
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

        private bool TblDiagnosisExists(int id)
        {
            return _context.TblDiagnoses.Any(e => e.DiagnosisId == id);
        }
    }
}
