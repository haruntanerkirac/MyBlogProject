using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete;
using DataAccessLayer.Concrete.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyBlogProject.Models;
using NuGet.Protocol;

namespace MyBlogProject.Controllers
{
    public class WriterController : Controller
    {
        WriterManager writerManager = new WriterManager(new EfWriterRepository());
        UserManager userManager = new UserManager(new EfUserRepository());

        private readonly UserManager<AppUser> _userManager;
        public WriterController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        [Authorize]
        public IActionResult Index()
        {
            Context context = new Context();
            var userMail = User.Identity.Name;
            ViewBag.UserMail = userMail;
            var writerName = context.Writers.Where(x => x.WriterMail == userMail).Select(y => y.WriterName).FirstOrDefault();
            ViewBag.WriterName = writerName;
            return View();
        }

        public PartialViewResult WriterNavbarPartial()
        {
            return PartialView();
        }

        public PartialViewResult WriterFooterPartial()
        {
            return PartialView();
        }

        [HttpGet]
        public async Task<IActionResult> WriterEditProfile()
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            UserUpdateViewModel model = new UserUpdateViewModel();
            model.Mail = values.Email;
            model.Namesurname = values.NameSurname;
            model.ImageURL = values.ImageUrl;
            model.Username = values.UserName;
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> WriterEditProfile(UserUpdateViewModel model)
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            values.NameSurname = model.Namesurname;
            values.ImageUrl = model.ImageURL;
            values.Email = model.Mail;
            if (model.Password != null)
            {
                values.PasswordHash = _userManager.PasswordHasher.HashPassword(values, model.Password);
                var result = await _userManager.UpdateAsync(values);
            }
            else
            {
                return RedirectToAction("WriterEditProfile", "Writer");
            }
            return RedirectToAction("Index", "Dashboard");
        }

        [HttpGet]
        public IActionResult AddWriter()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddWriter(AddProfileImage image)
        {
            Writer writer = new Writer();
            if (image.WriterImage != null)
            {
                var extension = Path.GetExtension(image.WriterImage.FileName);
                var newImageName = Guid.NewGuid() + extension;
                var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/WriterImageFiles/" + newImageName);
                var stream = new FileStream(location, FileMode.Create);
                image.WriterImage.CopyTo(stream);
                writer.WriterImage = newImageName;
            }
            writer.WriterName = image.WriterName;
            writer.WriterAbout = image.WriterAbout;
            writer.WriterMail = image.WriterMail;
            writer.WriterPassword = image.WriterPassword;
            writer.WriterStatus = true;
            writerManager.TAdd(writer);
            return RedirectToAction("Index", "Dashboard");
        } 
    }
}
