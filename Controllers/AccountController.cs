using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Security.Claims;
using VLPMall.Data;
using VLPMall.Interfaces;
using VLPMall.Models;
using VLPMall.ViewModels;

namespace VLPMall.Controllers
{
    public class AccountController : Controller
    {
        private readonly IPhotoService _photoService;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public AccountController(IPhotoService photoService , UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _photoService = photoService;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public IActionResult Login()
        {
            var response = new LoginViewModel();
            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginVM)
        {
            if (!ModelState.IsValid) return View();

            var user = await _userManager.FindByEmailAsync(loginVM.EmailAddress);

            if (user != null)
            {
                //User found, check password
                var passwordCheck = await _userManager.CheckPasswordAsync(user, loginVM.Password);

                if (passwordCheck)
                {
                    // Password correct, sign in
                    var result = await _signInManager.PasswordSignInAsync(user, loginVM.Password, false, false);
                    await _signInManager.SignInAsync(user, false);

                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index", "Home");
                    }

                    // Password is incorrect
                    TempData["Error"] = "Sai thông tin đăng nhập. Xin vui lòng thử lại.";
                }
            }

            //User not found
            TempData["Error"] = "Sai thông tin đăng nhập. Xin vui lòng thử lại.";

            return View(loginVM);
        }

        public IActionResult Register()
        {
            var response = new RegisterViewModel();
            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel registerVM)
        {
            if (!ModelState.IsValid) return View(registerVM);

            var user = await _userManager.FindByEmailAsync(registerVM.Email);
            if (user != null)
            {
                TempData["Error"] = "Email này đã được sử dụng bởi tài khoản khác";
                return View(registerVM);
            }

            var result = await _photoService.AddPhotoAsync(registerVM.AnhDaiDien);

            var newUser = new User()
            {
                Email = registerVM.Email,
                UserName = registerVM.Email,
                HoTen = registerVM.HoTen,
                ProfileImageUrl = result.Url.ToString(),
                GioiTinh = registerVM.GioiTinh,
                NgaySinh = registerVM.NgaySinh,
                PhoneNumber = registerVM.SoDienThoai,
                DiaChi = new DiaChi
                {
                    Duong = registerVM.DiaChi.Duong,
                    Phuong = registerVM.DiaChi.Phuong,
                    Quan = registerVM.DiaChi.Quan,
                    ThanhPho = registerVM.DiaChi.ThanhPho
                }
            };

            var newUserResponse = await _userManager.CreateAsync(newUser, registerVM.MatKhau);

            if (newUserResponse.Succeeded)
            {
                await _userManager.AddToRoleAsync(newUser, UserRoles.User);
                return RedirectToAction("Index", "Home");
            }

            return View(registerVM);
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public IActionResult ExternalLogin(string provider, string returnUrl)
        {
            var redirectUrl = Url.Action(nameof(ExternalLoginCallback), "Account", new { ReturnUrl = returnUrl });
            var properties = _signInManager.ConfigureExternalAuthenticationProperties(provider, redirectUrl);
            return Challenge(properties, provider);
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> ExternalLoginCallback(string returnUrl = null, string remoteError = null)
        {
            returnUrl ??= Url.Content("~/");

            var info = await _signInManager.GetExternalLoginInfoAsync();
            if (info == null)
            {
                return RedirectToAction(nameof(Login));
            }

            var email = info.Principal.FindFirstValue(ClaimTypes.Email);
            User user;

            if (email != null)
            {
                user = await _userManager.FindByEmailAsync(email);

                if (user == null)
                {
                    user = new User { UserName = email, Email = email };
                    await _userManager.CreateAsync(user);
                }
                await _signInManager.SignInAsync(user, isPersistent: false);
                return LocalRedirect(returnUrl);
            }
            else
            {
                return RedirectToAction(nameof(Login));
            }
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();

            return RedirectToAction("Index", "Home");
        }
    }
}
