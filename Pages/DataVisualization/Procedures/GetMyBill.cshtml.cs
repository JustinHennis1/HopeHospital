using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProjectHennisJustin.Pages.DataVisualization.Views;

namespace ProjectHennisJustin.Pages.DataVisualization.Procedures
{
    public class GetMyBillModel : PageModel
    {
        private readonly ProjectHennisJustin.Jhennis1Context _jhennis1Context;

        public GetMyBillModel(ProjectHennisJustin.Jhennis1Context context)
        {
            _jhennis1Context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public IList<spGetMyBill> spGetMyBill { get; set; }

        public async Task OnGetAsync()
        {
            try
            {
                var fNameSQLParam = new Microsoft.Data.SqlClient.SqlParameter("@FirstName", "");
                var lNameSQLParam = new Microsoft.Data.SqlClient.SqlParameter("@LastName", "");
                spGetMyBill = await _jhennis1Context.spGetMyBills
                    .FromSqlRaw("EXEC GetMyBill @FirstName={0}, @LastName={1}", fNameSQLParam, lNameSQLParam)
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
            spGetMyBill = await _jhennis1Context.spGetMyBills
                .FromSqlRaw("EXEC GetMyBill @FirstName={0}, @LastName={1}", fNameSQLParam, lNameSQLParam)
                .ToListAsync();
        }
    }
}
