using BusinessLayer.Concrete;
using DataAccessLayer.Concrete.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace MyBlogProject.Controllers
{
    public class RegisterController : Controller
    {
        WriterManager writerManager = new WriterManager(new EfWriterRepository());

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
         
        [HttpPost]
        public IActionResult Index(Writer writer)
        {
            writer.WriterStatus = true;
            writer.WriterAbout = "deneme";
            writerManager.WriterAdd(writer);
            return RedirectToAction("Index","Blog");
        }
    }
}
