using BusinessLayer.Concrete;
using DataAccessLayer.Concrete.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace MyBlogProject.Controllers
{
    public class CategoryController : Controller
    {
        CategoryManager categoryManager = new CategoryManager(new EfCategoryRepository()); 
        public IActionResult Index()
        {
            var values = categoryManager.GetAllCategories();
            return View(values);
        }
    }
}
