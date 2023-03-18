using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace NetCoreGelismisBlog.Controllers
{
    public class LoginController : Controller
    {
        [AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Index(Writer w)
        {
            Context c = new Context();
            var datavalues = c.Writers.FirstOrDefault(x => x.WriterMail == w.WriterMail && x.WriterPassword == w.WriterPassword);
            if (datavalues !=null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, w.WriterMail)
                };

                var userIdenty = new ClaimsIdentity(claims, "a");
                ClaimsPrincipal principal = new ClaimsPrincipal(userIdenty);
                await HttpContext.SignInAsync(principal);
                return RedirectToAction("Index", "DashboardController1");
            }
            else
            {
                return View();
            }
        }
    }
}
//Context c = new Context();
//var datavalues = c.Writers.FirstOrDefault(x => x.WriterMail == w.WriterMail && x.WriterPassword == w.WriterPassword);
//if (datavalues != null)
//{
//    HttpContext.Session.SetString("username", w.WriterMail);
//    return RedirectToAction("Index", "Writer");

//}
//else
//{
//    return View();
//}