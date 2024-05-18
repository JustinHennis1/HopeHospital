using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProjectHennisJustin;

namespace ProjectHennisJustin.Pages.Doctor
{
    public class DetailsModel : PageModel
    {
        private readonly ProjectHennisJustin.Jhennis1Context _context;

        public DetailsModel(ProjectHennisJustin.Jhennis1Context context)
        {
            _context = context;
        }

        public TblDoctor TblDoctor { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbldoctor = await _context.TblDoctors.FirstOrDefaultAsync(m => m.DoctorId == id);
            if (tbldoctor == null)
            {
                return NotFound();
            }
            else
            {
                TblDoctor = tbldoctor;
            }
            return Page();
        }
    }
}
