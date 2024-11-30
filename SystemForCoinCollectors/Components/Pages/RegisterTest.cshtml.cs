using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace SystemForCoinCollectors.Components.Pages
{
    public class RegisterModel : PageModel
    {
        [BindProperty]
        [Required(ErrorMessage = "Username is required")]
        public string UserName { get; set; } = "";

        [BindProperty]
        [Required(ErrorMessage = "E-mail is required")]
        public string Email { get; set; } = "";

        public string ErrorMessage = "";
        //public string SuccessMessage = "";

        public void OnGet()
        {
            int x = 5;
        }

        public void OnPost()
        {
            if (!ModelState.IsValid)
            {
                ErrorMessage = "Data validation failed!";
                return;
            }

            UserName = "";
            Email = "";
            ModelState.Clear();
        }
    }
}
