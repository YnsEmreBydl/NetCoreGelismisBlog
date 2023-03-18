using Microsoft.AspNetCore.Mvc;
using NetCoreGelismisBlog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreGelismisBlog.ViewComponents
{
    public class CommentsList : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var commentValues = new List<UserComment>
            {
                new UserComment
                {
                    ID=1,
                    UserName = "Emre"
                },

                new UserComment
                {
                    ID=2,
                    UserName = "Zeynep"
                },
            };
            return View(commentValues);
        }
    }
}
