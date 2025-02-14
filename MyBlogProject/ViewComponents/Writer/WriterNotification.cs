using BusinessLayer.Concrete;
using DataAccessLayer.Concrete.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MyBlogProject.ViewComponents.Writer
{
    public class WriterNotification : ViewComponent
    {
        NotificationManager notificationManager = new NotificationManager(new EfNotificationRepository());
        public IViewComponentResult Invoke()
        {
            var values = notificationManager.GetAll();
            return View(values);
        }
    }
}
