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
    public class IndexModel : PageModel
    {
        private readonly ProjectHennisJustin.Jhennis1Context _context;

        public IndexModel(ProjectHennisJustin.Jhennis1Context context)
        {
            _context = context;
        }

        public IList<TblBilling> TblBilling { get;set; } = default!;

        public async Task OnGetAsync()
        {
            TblBilling = await _context.TblBillings
                .Include(t => t.Patient).ToListAsync();
        }
    }
}
