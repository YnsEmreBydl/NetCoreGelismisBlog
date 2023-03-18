using BusinessLogicLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreGelismisBlog.Areas.Admin.ViewComponents.Statistic
{
    public class Statistic2 : ViewComponent
    {
   

        Context c = new Context();
        public IViewComponentResult Invoke()
        {

            ViewBag.v1 = c.Blogs.OrderByDescending(x => x.BlogID).Select(x=>x.BlogTitle).Take(1).FirstOrDefault();

            ViewBag.v2 = c.Categories.Count();

            ViewBag.v3 = c.Writers.Count();

            return View();
        }
    }
}
