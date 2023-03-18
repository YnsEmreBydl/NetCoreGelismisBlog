using BusinessLogicLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreGelismisBlog.Controllers
{
    public class DashboardController1 : Controller
    {
        BlogManager bm = new BlogManager(new EFBlogRepository());
        WriterManager wm = new WriterManager(new EFWriterRepository());
        public IActionResult Index()
        {
            Context c = new Context();
            ViewBag.v1 = c.Blogs.Count().ToString();
            ViewBag.v2 = c.Blogs.Where(x=>x.WriterID == 1).Count();
            ViewBag.v3 = c.Categories.Count().ToString();

            var usermail = User.Identity.Name;
            ViewBag.v = usermail;
            var writer = c.Writers.Where(x => x.WriterMail == usermail).Select(y => y.WriterName).FirstOrDefault();
            ViewBag.v2 = writer;
            return View();
        }

       
    }
}
