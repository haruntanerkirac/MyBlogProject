using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.Concrete.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MyBlogProject.Controllers
{
    public class DashboardController : Controller
    {
        BlogManager blogManager = new BlogManager(new EfBlogRepository());

        public IActionResult Index()
        {
            Context context = new Context();
            ViewBag.value1 = context.Blogs.Count().ToString(); 
            ViewBag.value2 = context.Blogs.Where(x => x.WriterID == 1).Count().ToString();
            ViewBag.value3 = context.Categories.Count().ToString();
            return View();
        }
    }
}
