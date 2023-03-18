using BusinessLogicLayer.Concrete;
using BusinessLogicLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;


namespace NetCoreGelismisBlog.Areas.Admin.Controllers
{
    public class CategoryController : Controller
    {
       
        CategoryManager cm = new CategoryManager(new EFCategoryRepository());
        [Area("Admin")]
        public IActionResult Index(int page = 1)
        {
            var values = cm.GetList().ToPagedList(page, 10);
            return View(values);
        }
        [Area("Admin")]
        [HttpGet]
        public IActionResult AddCategory()
        {
            return View();
        }
        [Area("Admin")]
        [HttpPost]
        public IActionResult AddCategory(Category c)
        {
            CategoryValidator cv = new CategoryValidator();
            ValidationResult result = cv.Validate(c);
            if (result.IsValid)
            {

                c.CategoryStatus = true;
                cm.Add(c);
                return RedirectToAction("Index", "Category");
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
        [Area("Admin")]
        public IActionResult DeleteCategory(int id)
        {
            var values = cm.GetById(id);
            cm.Delete(values);
            return RedirectToAction("Index");
        }

     
    }
}
