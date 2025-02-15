using BusinessLayer.Concrete;
using DataAccessLayer.Concrete.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace MyBlogProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        CategoryManager categoryManager = new CategoryManager(new EfCategoryRepository());
        public IActionResult Index()
        {
            var values = categoryManager.GetAll();
            return View(values);
        }
    }
}
