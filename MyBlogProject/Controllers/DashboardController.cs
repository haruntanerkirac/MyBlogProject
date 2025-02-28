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
            var userName = User.Identity.Name;
            var userMail = context.Users.Where(x => x.UserName == userName).Select(y => y.Email).FirstOrDefault();
            var writerId = context.Users.Where(x => x.Email == userMail).Select(y => y.Id).FirstOrDefault();

            ViewBag.value1 = context.Blogs.Count().ToString(); 
            ViewBag.value2 = context.Blogs.Where(x => x.WriterID == writerId).Count().ToString();
            ViewBag.value3 = context.Categories.Count().ToString();
            return View();
        }
    }
}
