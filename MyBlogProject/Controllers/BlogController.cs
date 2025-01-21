﻿using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MyBlogProject.Controllers
{
    [AllowAnonymous]
    public class BlogController : Controller
    {
        BlogManager blogManager = new BlogManager(new EfBlogRepository());
        CategoryManager categoryManager = new CategoryManager(new EfCategoryRepository());

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

        public IActionResult BlogListByWriter()
        {
            var values = blogManager.GetListWithCategoryByWriter(1);
            return View(values);
        }

        public List<SelectListItem> GetCategoriesToDropDown()
        {
            List<SelectListItem> categoryValues = (from x in categoryManager.GetAll()
                                                   select new SelectListItem
                                                   {
                                                       Text = x.CategoryName,
                                                       Value = x.CategoryID.ToString()
                                                   }).ToList();
            return categoryValues;
        }


        [HttpGet]
        public IActionResult AddBlog()
        {
            ViewBag.CategoryValues = GetCategoriesToDropDown();
            return View();
        }

        [HttpPost]
        public IActionResult AddBlog(Blog blog)
        {
            ViewBag.CategoryValues = GetCategoriesToDropDown();
            BlogValidator validator = new BlogValidator();
            ValidationResult results = validator.Validate(blog);
            if (results.IsValid)
            {
                blog.BlogStatus = true;
                blog.BlogCreatedDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                blog.WriterID = 1;
                blogManager.TAdd(blog);
                return RedirectToAction("BlogListByWriter", "Blog");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }

        public IActionResult DeleteBlog(int id)
        {
            var blogToDelete = blogManager.TGetById(id);
            blogManager.TDelete(blogToDelete);
            return RedirectToAction("BlogListByWriter");
        }

        [HttpGet]
        public IActionResult EditBlog(int id)
        {
            var blogToEdit = blogManager.TGetById(id);
            List<SelectListItem> categoryValues = (from x in categoryManager.GetAll()
                                                   select new SelectListItem
                                                   {
                                                       Text = x.CategoryName,
                                                       Value = x.CategoryID.ToString()
                                                   }).ToList();
            ViewBag.CategoryValues = categoryValues;
            return View(blogToEdit);
        }

        [HttpPost]
        public IActionResult EditBlog(Blog blog)
        {
            blog.WriterID = 1;
            blog.BlogCreatedDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            blog.BlogStatus = true;
            blogManager.TUpdate(blog);
            return RedirectToAction("BlogListByWriter");
        }
    }
}