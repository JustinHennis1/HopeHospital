using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProjectHennisJustin.Pages.DataVisualization.Views;

namespace ProjectHennisJustin.Pages.DataVisualization.Procedures
{
    public class GetDiagnosisByFLModel : PageModel
    {
        private readonly ProjectHennisJustin.Jhennis1Context _jhennis1Context;

        public GetDiagnosisByFLModel(ProjectHennisJustin.Jhennis1Context context)
        {
            _jhennis1Context = context;
        }

        public IList<spGetDiagnosisByFL> spGetDiagnosisByFL { get; set; }

        public async Task OnGetAsync()
        {
            try
            {
                var fNameSQLParam = new Microsoft.Data.SqlClient.SqlParameter("@FirstName", "");
                var lNameSQLParam = new Microsoft.Data.SqlClient.SqlParameter("@LastName", "");
                spGetDiagnosisByFL = await _jhennis1Context.spGetDiagnosisByFLs
                    .FromSqlRaw("EXEC GetDiagnosisbyFandL @FirstName={0}, @LastName={1}", fNameSQLParam, lNameSQLParam)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                // Handle the exception
            }
        }

        public async Task OnPostAsync()
        {
            string myFirst = HttpContext.Request.Form["fName"];
            string myLast = HttpContext.Request.Form["lName"];
            var fNameSQLParam = new Microsoft.Data.SqlClient.SqlParameter("@FirstName", myFirst);
            var lNameSQLParam = new Microsoft.Data.SqlClient.SqlParameter("@LastName", myLast);
            spGetDiagnosisByFL = await _jhennis1Context.spGetDiagnosisByFLs
                .FromSqlRaw("EXEC GetDiagnosisbyFandL @FirstName={0}, @LastName={1}", fNameSQLParam, lNameSQLParam)
                .ToListAsync();
        }
    }
}