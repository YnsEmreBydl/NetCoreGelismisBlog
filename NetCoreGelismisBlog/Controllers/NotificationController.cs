using BusinessLogicLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreGelismisBlog.Controllers
{
    public class NotificationController : Controller
    {

        NotificationManager nc = new NotificationManager(new EFNotificationRepository());
        public IActionResult Index()
        {
            var values = nc.GetList();
            return View(values);
        }

        [AllowAnonymous]
        public IActionResult AllNotification()
        {
            var values = nc.GetList();
            return View(values);
        }
    }
}
