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
    public class IndexModel : PageModel
    {
        private readonly ProjectHennisJustin.Jhennis1Context _context;

        public IndexModel(ProjectHennisJustin.Jhennis1Context context)
        {
            _context = context;
        }

        public IList<TblDiagnosis> TblDiagnosis { get;set; } = default!;

        public async Task OnGetAsync()
        {
            TblDiagnosis = await _context.TblDiagnoses
                .Include(t => t.Bill)
                .Include(t => t.Doctor)
                .Include(t => t.Patient).ToListAsync();
        }
    }
}
