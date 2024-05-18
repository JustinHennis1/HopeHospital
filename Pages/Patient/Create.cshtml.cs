using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProjectHennisJustin;

namespace ProjectHennisJustin.Pages.Patient
{
    public class CreateModel : PageModel
    {
        private readonly ProjectHennisJustin.Jhennis1Context _context;

        public CreateModel(ProjectHennisJustin.Jhennis1Context context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["InsuranceId"] = new SelectList(_context.TblInsurances, "InsuranceId", "InsuranceId");
            return Page();
        }

        [BindProperty]
        public TblPatient TblPatient { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.TblPatients.Add(TblPatient);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
