using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MyBlogProject.Controllers
{
    public class RegisterController : Controller
    {
        WriterManager writerManager = new WriterManager(new EfWriterRepository());

        [AllowAnonymous]
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
         
        [HttpPost]
        public IActionResult Index(Writer writer)
        {
            WriterValidator validator = new WriterValidator();
            ValidationResult results = validator.Validate(writer);
            if (results.IsValid)
            {
                writer.WriterStatus = true;
                writer.WriterAbout = "deneme";
                writerManager.TAdd(writer);
                return RedirectToAction("Index", "Blog");
            }
            else {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }
    }
}
