using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AuthIntro.Pages
{
    [Authorize(Policy = "HRManagerOnly")]
    public class UserManagementModel : PageModel
    {
        public void OnGet()
        {
        }
    }
}
