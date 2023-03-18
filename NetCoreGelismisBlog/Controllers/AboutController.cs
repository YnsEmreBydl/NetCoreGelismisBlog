using BusinessLogicLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreGelismisBlog.Controllers
{
    public class AboutController : Controller
    {

        AboutManager mn = new AboutManager(new EFAboutRepository());
        public IActionResult Index()
        {
            var values = mn.GetList();
            return View(values);
        }
    }
}
