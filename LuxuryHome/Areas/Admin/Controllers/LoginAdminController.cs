using LuxuryHome.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LuxuryHome.Areas.Admin.Controllers
{
    public class LoginAdminController : Controller
    {
        // GET: Admin/LoginAdmin
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(User objUser)
        {
            if (ModelState.IsValid)
            {
                using (PPCDBEntities1 db = new PPCDBEntities1())
                {
                    var obj = db.Users.Where(a => a.UserName.Equals(objUser.UserName) && a.Password.Equals(objUser.Password)).FirstOrDefault();
                    if (obj != null)
                    {
                        Session["UserID"] = obj.ID.ToString();
                        Session["UserName"] = obj.UserName.ToString();
                        return RedirectToAction("Index", "PropertyManager");
                    }
                    else
                    {
                        return RedirectToAction("Index", "LoginAdmin");
                    }
                }
            }
            return View(objUser);
        }
    }

}
