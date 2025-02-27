using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyBlogProject.Models;
using System.Security.Claims;

namespace MyBlogProject.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        private readonly SignInManager<AppUser> _signInManager;
        public LoginController(SignInManager<AppUser> signInManager)
        {
            _signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(UserSignInViewModel user)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(user.Username, user.PassWord, false, true);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index","Dashboard");
                }
                else
                {
                    return RedirectToAction("Index", "Login");
                }
            }
            return View();
        }

        //[HttpPost]
        //public async Task<IActionResult> Index(Writer writer)
        //{
        //    Context context = new Context();
        //    var dataValue = context.Writers.FirstOrDefault(x => x.WriterMail == writer.WriterMail && x.WriterPassword == writer.WriterPassword);
        //    if (dataValue != null)
        //    {
        //        var claims = new List<Claim>
        //        {
        //            new Claim(ClaimTypes.Name, writer.WriterMail)
        //        };
        //        var userIdentity = new ClaimsIdentity(claims, "login");
        //        ClaimsPrincipal principal = new ClaimsPrincipal(userIdentity);
        //        await HttpContext.SignInAsync(principal);

        //        return RedirectToAction("Index", "Dashboard");
        //    }
        //    else
        //    {
        //        return View();
        //    }
        //}
    }
}