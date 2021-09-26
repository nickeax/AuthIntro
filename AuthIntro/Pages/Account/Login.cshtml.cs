using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using System.Threading.Tasks;

namespace AuthIntro.Pages.Account
{
    public class LoginModel : PageModel
    {
        [BindProperty]
        public Credential Credential { get; set; }
        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid) return Page();

            // Verify the credential
            if(Credential.UserName == "admin" && Credential.Password == "password")
            {
                // Creating the security context
                var claims = new List<Claim>()
                {
                    new Claim("Admin", "true"),
                    new Claim(ClaimTypes.Name, "admin"),
                    new Claim(ClaimTypes.Email, "admin@gmail.com"),
                    new Claim("Department", "HR"),
                    new Claim("Manager", "true"),
                    new Claim("EmploymentDate", "2021-06-01")
                };

                var identity = new ClaimsIdentity(claims, "MyCookieAuth");
                ClaimsPrincipal principal = new(identity);

                await HttpContext.SignInAsync("MyCookieAuth", principal);

                return RedirectToPage("/Index");
            }

            return Page();
        }

    }
    
    public class Credential
    {
        [Required]
        [Display(Name = "User Name")]
        public string UserName { get; set; }
        
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
