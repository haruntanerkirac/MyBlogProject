using Microsoft.AspNetCore.Mvc;

namespace MyBlogProject.ViewComponents.Writer
{
    public class WriterNotification : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
