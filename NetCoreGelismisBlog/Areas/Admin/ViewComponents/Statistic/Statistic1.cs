using BlogApi.DataAccessLayer;
using BusinessLogicLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreGelismisBlog.Areas.Admin.ViewComponents.Statistic
{
    public class Statistic1 :ViewComponent
    {
        BlogManager bm = new BlogManager(new EFBlogRepository());
        ContactManager ct = new ContactManager(new EFContactRepository());
        CommentManager cm = new CommentManager(new EFCommentRepository());
        
        public IViewComponentResult Invoke()
        {
          
            ViewBag.v1 = bm.GetList().Count();

            ViewBag.v2 = ct.GetList().Count();

            ViewBag.v3 = cm.GetList().Count();

            return View();
        }
    }
}
