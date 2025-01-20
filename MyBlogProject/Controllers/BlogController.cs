using BusinessLayer.Concrete;
using DataAccessLayer.Concrete.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MyBlogProject.Controllers
{
    [AllowAnonymous]
    public class BlogController : Controller
    {
        BlogManager blogManager = new BlogManager(new EfBlogRepository());
        public IActionResult Index()
        {
            var values = blogManager.GetBlogListWithCategory();
            return View(values);
        }

        public IActionResult ReadAllBlogs(int id)
        {
            var writerID = blogManager.GetWriterWithBlog(id);
            ViewBag.writerId = writerID;
            ViewBag.i = id;
            var values = blogManager.GetBlogById(id);
            return View(values);
        }
    }
}
