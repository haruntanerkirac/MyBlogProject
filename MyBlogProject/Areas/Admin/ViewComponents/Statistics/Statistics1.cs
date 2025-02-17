using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.Concrete.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

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

            string api = "42be04f59b3b4c0fdbd95dbb7795f9d3";
            string connection = "https://api.openweathermap.org/data/2.5/weather?q=balikesir&mode=xml&lang=tr&units=metric&appid="+api;
            XDocument document = XDocument.Load(connection);
            ViewBag.Weather = document.Descendants("temperature").ElementAt(0).Attribute("value").Value;
            return View();
        }
    }
}
