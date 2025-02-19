using Microsoft.AspNetCore.Mvc;
using MyBlogProject.Areas.Admin.Models;

namespace MyBlogProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ChartController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CategoryChart()
        {
            List<CategoryClass> list = new List<CategoryClass>();
            list.Add(new CategoryClass
            {
                categoryname = "Teknoloji",
                categorycount = 10
            });

            list.Add(new CategoryClass
            {
                categoryname = "Yazılım",
                categorycount = 20
            });

            list.Add(new CategoryClass
            {
                categoryname = "Spor",
                categorycount = 30
            });

            list.Add(new CategoryClass
            {
                categoryname = "Sanat",
                categorycount = 15
            });

            list.Add(new CategoryClass
            {
                categoryname = "Bilim",
                categorycount = 5
            });

            return Json(new { jsonlist = list });
        }
    }
}
