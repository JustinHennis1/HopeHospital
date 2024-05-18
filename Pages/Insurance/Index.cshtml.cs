using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProjectHennisJustin;

namespace ProjectHennisJustin.Pages.Insurance
{
    public class IndexModel : PageModel
    {
        private readonly ProjectHennisJustin.Jhennis1Context _context;

        public IndexModel(ProjectHennisJustin.Jhennis1Context context)
        {
            _context = context;
        }

        public IList<TblInsurance> TblInsurance { get;set; } = default!;

        public async Task OnGetAsync()
        {
            TblInsurance = await _context.TblInsurances.ToListAsync();
        }
    }
}
