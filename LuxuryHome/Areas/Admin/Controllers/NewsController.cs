using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LuxuryHome.Models;

namespace LuxuryHome.Areas.Admin.Controllers
{
    public class NewsController : Controller
    {
        PPCDBEntities1 model = new PPCDBEntities1();
        // GET: Admin/News
        public ActionResult Index()

        {
            var news = model.News.ToList();
            return View(news);
        }
    }
}