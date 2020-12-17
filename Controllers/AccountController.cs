using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Models;
using App.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace App.Controllers
{

    [Authorize]
    public class AccountController : Controller
    {
        private UserManager<Account> userManager;
        private SignInManager<Account> signInManager;

        public AccountController(UserManager<Account> userManager, SignInManager<Account> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }


        
        #region CREATING
        [HttpGet]
        [Authorize (Roles = Constants.SuperAdminRole)]
        public IActionResult CreateUser()
        {
            // 1.
            return View();
        }

        [HttpPost]
        [Authorize(Roles = Constants.SuperAdminRole)]
        public async Task<IActionResult> CreateUser(Account model)
        {

            // 1. tạo tài khoản
            if (ModelState.IsValid)
            {
                var result = await userManager.CreateAsync(model, model.Password);
                if (result.Succeeded)
                {
                    await signInManager.SignInAsync(model, isPersistent: false);
                    return RedirectToAction("Index", "Account");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
            }

            return View(model);
        }
        #endregion


        [Authorize(Roles = Constants.SuperAdminRole)]
        public async Task<IActionResult> DeleteUser(string id)
        {
            var user = await userManager.FindByIdAsync(id);

            // xóa tài khoản
            if(user == null)
            {
                ViewBag.ErrorMessage = $"User with Id = {id} cannot be found";
                return View("NotFound");
            }
            else
            {
                var result = await userManager.DeleteAsync(user);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }

                foreach(var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }

                return View("Index");
            }
        }


        #region EDITING
        [HttpGet]
        [Authorize(Roles = Constants.SuperAdminRole)]
        public async Task<IActionResult> EditUser(string id)
        {
            var user = await userManager.FindByIdAsync(id);

            // lấy thông tin tài khoản
            if (user == null)
            {
                ViewBag.ErrorMessage = $"User with Id = {id} cannot be found";
                return View("NotFound");
            }

            return View(user);

        }

        [HttpPost]
        [Authorize(Roles = Constants.SuperAdminRole)]
        public async Task<IActionResult> EditUser(Account model)
        {
            var user = await userManager.FindByIdAsync(model.Id);

            // cập nhật thông tin tài khoản
            if (user == null)
            {
                ViewBag.ErrorMessage = $"User with Id = {model.Id} cannot be found";
                return View("NotFound");
            }
            else
            {
                user.First_Name = model.First_Name;
                user.Last_Name = model.Last_Name;
                user.Email = model.Email;
                user.Password = model.Password;
                user.PhoneNumber = model.PhoneNumber;
                user.Date_Of_Birth = model.Date_Of_Birth;
                user.Address = model.City;
                user.City = model.City;
                user.State = model.State;
                user.Gender = model.Gender;

                var result = await userManager.UpdateAsync(user);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }

                return View(model);
            }
        }
        #endregion



        public IActionResult Index()
        {
            return View(userManager.Users);
        }


        public IActionResult Logout(string returnUrl)
        {
            // thực hiện Đăng xuất --- tương đương xoá Cookie đăng nhập
            HttpContext.SignOutAsync(IdentityConstants.ApplicationScheme);
            return Redirect("/");
        }


        public IActionResult AccessDenied(string returnUrl)
        {
            return View();
        }


        [AllowAnonymous]
        public IActionResult Login(string returnUrl)
        {
            return View(new LoginViewModel());
        }


        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var user = await userManager.FindByEmailAsync(viewModel.Email);
                if (user != null)   // tìm thấy user -- 
                {

                    var signInResult = await signInManager.PasswordSignInAsync(user, viewModel.Password, false, true);
                    if (signInResult.Succeeded)
                    {
                        return Redirect("/");
                    }


                    ModelState.AddModelError("", "Có lỗi trong quá trình Đăng nhập.");
                }
                else
                {
                    ModelState.AddModelError("", "E-mail chưa được đăng ký tài khoản.");
                }

                return View(viewModel);
            }
            else
            {
                return View(viewModel);
            }
        }


    }
}
