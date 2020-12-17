using System;
using System.Threading.Tasks;
using App.Models;
using App.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace App.Components
{
    public class HeaderViewComponent : ViewComponent
    {
        private UserManager<Account> userManager;
        private SignInManager<Account> signInManager;

        public HeaderViewComponent(UserManager<Account> userManager, SignInManager<Account> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }


        public async Task<IViewComponentResult> InvokeAsync()
        {
            if (signInManager.IsSignedIn(HttpContext.User))
            {
                var currentUser = await userManager.GetUserAsync(HttpContext.User);
                return View(new HeaderViewModel { CurrentUser = currentUser });
            }

            return View(new HeaderViewModel());
        }
    }
}
