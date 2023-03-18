using BusinessLogicLayer.Concrete;
using BusinessLogicLayer.ValidationRules;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using NetCoreGelismisBlog.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreGelismisBlog.Controllers
{

    public class WriterController : Controller
    {
        WriterManager wr = new WriterManager(new EFWriterRepository());
        Context c = new Context();
        [Authorize]
        public IActionResult Index()
        {
            var usermail = User.Identity.Name;
            ViewBag.v = usermail;
            var writer = c.Writers.Where(x => x.WriterMail == usermail).Select(y => y.WriterName).FirstOrDefault();
            ViewBag.v2 = writer;
            return View();
        }

        public IActionResult WriterProfile()
        {
            return View();
        }

        public IActionResult WriterMail()
        {
            return View();
        }
        [AllowAnonymous]
        public IActionResult Test()
        {
            return View();
        }

        public PartialViewResult WriterSideBar()
        {
            return PartialView();
        }

        public PartialViewResult WriterFooter()
        {
            return PartialView();
        }
        [AllowAnonymous]
        [HttpGet]
        public IActionResult WriterEditProfile()
        {
           
            var usermail = User.Identity.Name;
            var writerId = c.Writers.Where(x => x.WriterMail == usermail).Select(y => y.WriterID).FirstOrDefault();
            var writervalues = wr.GetById(writerId);

         

            return View(writervalues);
        }

        [HttpPost]
        public IActionResult WriterEditProfile(Writer w)
        {

            WriterValidator wl = new WriterValidator();

            ValidationResult result = wl.Validate(w);

            if (result.IsValid)
            {
                wr.Update(w);
                return RedirectToAction("Index", "DashboardController1");
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
       
        [HttpGet]
        public IActionResult WriterAdd()
        {
            return View();
        }
  
        [HttpPost]
        public IActionResult WriterAdd(AddWriterImage p)
        {
            Writer w = new Writer();
            if (p.WriterImage !=null)
            {
                var extension = Path.GetExtension(p.WriterImage.FileName);
                var newimage = Guid.NewGuid() + extension;
                var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Writer/WriterImage/", newimage);
                var stream = new FileStream(location, FileMode.Create);
                p.WriterImage.CopyTo(stream);
                w.WriterImage = newimage;
            }
            w.WriterMail = p.WriterMail;
            w.WriterName = p.WriterName;
            w.WriterAbout = p.WriterAbout;
            w.WriterStatus = true;
            w.WriterPassword = p.WriterPassword;

            wr.Add(w);
            return RedirectToAction("Index", "DashboardController1");
        }
    }
}
