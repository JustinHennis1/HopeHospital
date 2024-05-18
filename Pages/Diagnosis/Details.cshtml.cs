using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProjectHennisJustin;

namespace ProjectHennisJustin.Pages.Diagnosis
{
    public class DetailsModel : PageModel
    {
        private readonly ProjectHennisJustin.Jhennis1Context _context;

        public DetailsModel(ProjectHennisJustin.Jhennis1Context context)
        {
            _context = context;
        }

        public TblDiagnosis TblDiagnosis { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbldiagnosis = await _context.TblDiagnoses.FirstOrDefaultAsync(m => m.DiagnosisId == id);
            if (tbldiagnosis == null)
            {
                return NotFound();
            }
            else
            {
                TblDiagnosis = tbldiagnosis;
            }
            return Page();
        }
    }
}
