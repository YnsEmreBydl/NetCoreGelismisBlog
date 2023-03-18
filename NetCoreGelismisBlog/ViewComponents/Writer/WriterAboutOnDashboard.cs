using BusinessLogicLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreGelismisBlog.ViewComponents.Writer
{

    public class WriterAboutOnDashboard:ViewComponent
    {
        WriterManager mn = new WriterManager(new EFWriterRepository());
        Context c = new Context();
        public IViewComponentResult Invoke()
        {
         
            var usermail = User.Identity.Name;
            var writerId = c.Writers.Where(x => x.WriterMail == usermail).Select(y => y.WriterID).FirstOrDefault();
            var values = mn.GetWriterById(writerId);
            return View(values);
        }

    }
}
