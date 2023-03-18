using BusinessLogicLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreGelismisBlog.ViewComponents.Writer
{
    public class WriterNotification :ViewComponent
    {
        NotificationManager nc = new NotificationManager(new EFNotificationRepository());
        public IViewComponentResult Invoke()
        {
            var values = nc.GetList();
            return View(values);
        }
    }
}
