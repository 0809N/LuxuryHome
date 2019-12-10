using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LuxuryHome.Models;
using PagedList;
using PagedList.Mvc;

namespace LuxuryHome.Controllers
{
    public class HomeController : Controller
    {
        PPCDBEntities1 model =  new PPCDBEntities1();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Property()
        {
            var property = model.Properties.ToList();
            return View(property);
        }
        public ActionResult News( int? page)
        {
            if (page == null) page = 1;
            var links = (from l in model.Properties
                         select l).Take(3).OrderByDescending(x => x.ID);

            int pageSize = 6;
            int pageNumber = (page ?? 1);
            return View(links.ToPagedList(pageNumber, pageSize));
        }
        public ActionResult Contact()
        {
            return View();
        }

        public ActionResult propertyDetails(int id)
        {
            Property ppDetails = model.Properties.SingleOrDefault(p => p.ID == id );
            if(ppDetails == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(ppDetails);
        }
	}

}