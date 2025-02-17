using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.Concrete.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace MyBlogProject.Areas.Admin.ViewComponents.Statistics
{
    public class Statistics2 : ViewComponent
    {
        Context context = new Context();
        public IViewComponentResult Invoke()
        {
            ViewBag.lastBlog = context.Blogs.OrderByDescending(x=>x.BlogID).Select(x => x.BlogTitle).FirstOrDefault();
            return View();
        }
    }
}
