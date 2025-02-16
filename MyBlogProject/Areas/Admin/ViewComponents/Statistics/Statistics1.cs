using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.Concrete.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace MyBlogProject.Areas.Admin.ViewComponents.Statistics
{
    public class Statistics1 : ViewComponent
    {
        BlogManager blogManager = new BlogManager(new EfBlogRepository());
        Context context = new Context();
        public IViewComponentResult Invoke()
        {
            ViewBag.BlogCount = blogManager.GetAll().Count;
            ViewBag.MessageCount = context.Contacts.Count();
            ViewBag.CommentCount = context.Comments.Count();
            return View();
        }
    }
}
