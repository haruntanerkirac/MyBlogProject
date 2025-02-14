using Microsoft.AspNetCore.Mvc;

namespace MyBlogProject.Controllers
{
    public class NotificationController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
