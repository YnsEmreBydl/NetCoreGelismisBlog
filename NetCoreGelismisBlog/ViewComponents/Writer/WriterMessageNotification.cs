using BusinessLogicLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreGelismisBlog.ViewComponents.Writer
{
    public class WriterMessageNotification :ViewComponent
    {
        Message2Manager mn = new Message2Manager(new EFMessage2Repostory());
        public IViewComponentResult Invoke()
        {
            int id = 1;
      
            var values = mn.GetInboxWithByWriter(id);
            return View(values);
        }
    }
}
