using BusinessLogicLayer.Concrete;
using BusinessLogicLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using NetCoreGelismisBlog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreGelismisBlog.Controllers
{
    public class RegisterController : Controller
    {

        WriterManager wm = new WriterManager(new EFWriterRepository());

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Index()
        {
          
            
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public IActionResult Index(Writer w)
        {
            WriterValidator vl = new WriterValidator();
            ValidationResult result = vl.Validate(w);
            if (result.IsValid)
            {
                w.WriterStatus = true;
                w.WriterAbout = "Test";
                wm.Add(w);
                return RedirectToAction("Index", "Blog");
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

     
    }
}
