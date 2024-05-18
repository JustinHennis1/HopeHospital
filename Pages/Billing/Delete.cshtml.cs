using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProjectHennisJustin;

namespace ProjectHennisJustin.Pages.Billing
{
    public class DeleteModel : PageModel
    {
        private readonly ProjectHennisJustin.Jhennis1Context _context;

        public DeleteModel(ProjectHennisJustin.Jhennis1Context context)
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

            var tblbilling = await _context.TblBillings.FirstOrDefaultAsync(m => m.BillId == id);

            if (tblbilling == null)
            {
                return NotFound();
            }
            else
            {
                TblBilling = tblbilling;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblbilling = await _context.TblBillings.FindAsync(id);
            if (tblbilling != null)
            {
                TblBilling = tblbilling;
                _context.TblBillings.Remove(TblBilling);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
