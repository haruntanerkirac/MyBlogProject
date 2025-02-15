﻿using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class BlogManager : IBlogService
    {
        IBlogDal _blogDal;
        public BlogManager(IBlogDal blogDal)
        {
            _blogDal = blogDal;
        }

        public List<Blog> GetBlogListWithCategory()
        {
            return _blogDal.GetListWithCategory();
        }

        public Blog TGetById(int id)
        {
            return _blogDal.GetById(id);
        }

        public List<Blog> GetBlogById(int id)
        {
            return _blogDal.GetAll(x=>x.BlogID == id);
        }

        public List<Blog> GetBlogListWithWriter(int id)
        {
            return _blogDal.GetAll(x=>x.WriterID == id);
        }

        public int GetWriterWithBlog(int blogID)
        {
            return _blogDal.GetAll(b => b.BlogID == blogID).Select(b => b.WriterID).FirstOrDefault();
        }

        public List<Blog> GetLastThreeBlogs()
        {
            return _blogDal.GetAll().TakeLast(3).ToList();
        }

        public void TAdd(Blog entity)
        {
            _blogDal.Insert(entity);
        }

        public void TDelete(Blog entity)
        {
            _blogDal.Delete(entity);
        }

        public void TUpdate(Blog entity)
        {
            _blogDal.Update(entity);
        }

        public List<Blog> GetAll()
        {
            return _blogDal.GetAll();
        }

        public List<Blog> GetListWithCategoryByWriter(int id)
        {
            return _blogDal.GetListWithCategoryByWriter(id);
        }
    }
}