using BusinessLogicLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreGelismisBlog.Controllers
{
    public class MessageController : Controller
    {

        Message2Manager mn = new Message2Manager(new EFMessage2Repostory());
        [AllowAnonymous]
        public IActionResult Inbox()
        {
            int id = 1;
            var values = mn.GetInboxWithByWriter(id);
            return View(values);
        }
        [AllowAnonymous]
        public IActionResult DeleteMessage(Message2 m)
        {
            mn.Delete(m);
            
            return RedirectToAction("Inbox","Message");
        }
    }
}
