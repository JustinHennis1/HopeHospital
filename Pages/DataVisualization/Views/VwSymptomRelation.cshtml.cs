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
    public class VwSymptomRelationModel : PageModel
    {
        private readonly ProjectHennisJustin.Jhennis1Context _context;

        public VwSymptomRelationModel(ProjectHennisJustin.Jhennis1Context jhennis1Context)
        {
            _context = jhennis1Context;
        }

        public IList<VwSymptomRelation> VwSymptomRelation { get; set; }

        public async Task OnGetAsync()
        {
            VwSymptomRelation = await _context.VwSymptomRelations.ToListAsync();
        }
    }
}
