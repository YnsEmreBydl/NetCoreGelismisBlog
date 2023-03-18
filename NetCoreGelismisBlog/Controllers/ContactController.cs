using BusinessLogicLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreGelismisBlog.Controllers
{
    public class ContactController : Controller
    {

        ContactManager c = new ContactManager(new EFContactRepository());
    

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(Contact co)
        {
            co.ContactStatus = true;
            co.ContactDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            c.Add(co);
            return RedirectToAction("Index","Blog");
        }
    }
}
