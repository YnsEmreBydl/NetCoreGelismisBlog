using BusinessLogicLayer.Concrete;
using BusinessLogicLayer.ValidationRules;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreGelismisBlog.Controllers
{
    [AllowAnonymous]
    public class BlogController : Controller
    {
        BlogManager c = new BlogManager(new EFBlogRepository());
        CategoryManager ct = new CategoryManager(new EFCategoryRepository());
        WriterManager wr = new WriterManager(new EFWriterRepository());
        Context con = new Context();
        public IActionResult Index()
        {
            var values = c.GetBlogListWithCategory();
            return View(values);
        }

    

       
        public IActionResult BlogReadAll(int id)
        {
            ViewBag.i = id;
            var values = c.GetBlogListById(id);
            return View(values);
        }

        public IActionResult BlogListByWriter()
        {
            var usermail = User.Identity.Name;
            var writerId = con.Writers.Where(x => x.WriterMail == usermail).Select(y => y.WriterID).FirstOrDefault();
       
            var values = c.GetListWithCategoryByWriterBlogManager(writerId);
            return View(values);
        }

        [HttpGet]
        public IActionResult BlogAdd()
        {

            List<SelectListItem> categoryvalues = (from x in ct.GetList()
                                                   select new SelectListItem
                                                   {
                                                       Text = x.CategoryName,
                                                       Value = x.CategoryID.ToString()
                                                   }).ToList();

            ViewBag.v1 = categoryvalues;
            return View();
        }

        [HttpPost]
        public IActionResult BlogAdd(Blog blg)
        {
            var usermail = User.Identity.Name;
            var writerId = con.Writers.Where(x => x.WriterMail == usermail).Select(y => y.WriterID).FirstOrDefault();
            BlogValidator bv = new BlogValidator();
            ValidationResult result = bv.Validate(blg);
            if (result.IsValid)
            {
              
                blg.BlogCreateDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                blg.WriterID = writerId;
                blg.BlogStatus = true;
                c.Add(blg);
                return RedirectToAction("BlogListByWriter", "Blog");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }

            return View();
          


        }
      
        public IActionResult BlogDelete(int id)
        {
            var blogvalue = c.GetById(id);
            c.Delete(blogvalue);

            return RedirectToAction("BlogListByWriter", "Blog");
        }

        [HttpGet]
        public IActionResult EditBlog(int id)
        {
            var blogvalue = c.GetById(id);
            List<SelectListItem> categoryvalues = (from x in ct.GetList()
                                                   select new SelectListItem
                                                   {
                                                       Text = x.CategoryName,
                                                       Value = x.CategoryID.ToString()
                                                   }).ToList();

            ViewBag.v1 = categoryvalues;
            return View(blogvalue);
        }

        [HttpPost]
        public IActionResult EditBlog(Blog p)
        {
            var usermail = User.Identity.Name;
            var writerId = con.Writers.Where(x => x.WriterMail == usermail).Select(y => y.WriterID).FirstOrDefault();
            p.WriterID = writerId;
            p.BlogStatus = true;
            c.Update(p);

            return RedirectToAction("BlogListByWriter");
        }
    }
}
