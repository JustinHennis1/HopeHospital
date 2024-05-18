using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProjectHennisJustin;

namespace ProjectHennisJustin.Pages.DataVisualization.Views
{
    public class VwCostandTreatModel : PageModel
    {
        private readonly ProjectHennisJustin.Jhennis1Context _context;

        public VwCostandTreatModel(ProjectHennisJustin.Jhennis1Context jhennis1Context) 
        {
            _context = jhennis1Context;
        }

        public IList<VwCostandTreat> VwCostandTreat { get; set; }
        
        public async Task OnGetAsync() 
        {
            VwCostandTreat = await _context.VwCostandTreats.ToListAsync();
        }
        
    }
}
