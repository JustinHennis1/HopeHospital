using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProjectHennisJustin;

namespace ProjectHennisJustin.Pages.Patient
{
    public class DetailsModel : PageModel
    {
        private readonly ProjectHennisJustin.Jhennis1Context _context;

        public DetailsModel(ProjectHennisJustin.Jhennis1Context context)
        {
            _context = context;
        }

        public TblPatient TblPatient { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblpatient = await _context.TblPatients.FirstOrDefaultAsync(m => m.PatientId == id);
            if (tblpatient == null)
            {
                return NotFound();
            }
            else
            {
                TblPatient = tblpatient;
            }
            return Page();
        }
    }
}
