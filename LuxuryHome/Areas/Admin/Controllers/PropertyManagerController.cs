using LuxuryHome.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Transactions;
using System.Web;
using System.Web.Mvc;

namespace LuxuryHome.Areas.Admin.Controllers
{
    public class PropertyManagerController : Controller
    {
        PPCDBEntities1 model = new PPCDBEntities1();
        // GET: Admin/Admin
        public ActionResult Index()
        {
            var property = model.Properties.ToList();
            return View(property);
        }

        public ActionResult Create()
        {
            PoPularData();
            return View();
        }

        public void PoPularData(object propertyTypeSelected = null, object districtSelected = null, object propertyStatusSelectec = null)
        {
            ViewBag.Property_Type_ID = new SelectList(model.Property_Type.ToList(), "ID", "Property_Type_Name", propertyTypeSelected);
            ViewBag.District_ID = new SelectList(model.Districts.ToList(), "ID", "District_Name", districtSelected);
            ViewBag.Property_Status_ID = new SelectList(model.Property_Status.ToList(), "ID", "Property_Status_Name", propertyStatusSelectec);
        }
        [HttpPost]
        public ActionResult Create([Bind(Include = "Property_Name,Property_Type_ID,Description,District_ID,Address" +
            ",Area,Bed_Room,Bath_Room,Price,Installment_Rate,Avatar,Album,Property_Status_ID")]
        Property property,List< HttpPostedFileBase>files)
        {

            if (ModelState.IsValid)
            {
                string album = "";
                var file = Request.Files["file"];
                Random random = new Random();
                //Up Album
                if (files != null)
                {
                    foreach (var imageFile in files)
                    {
                        if (imageFile != null)
                        {
                            var fileName = random.Next(1, 99999).ToString() + Path.GetFileName(imageFile.FileName);
                            var physicalPath = Path.Combine(Server.MapPath("~/Images"), fileName);

                            // The files are not actually saved in this demo
                            imageFile.SaveAs(physicalPath);
                            album += album.Length > 0 ? ";" + fileName : fileName;
                        }
                    }
                }
                property.Album = album;
                //Avatar
                if (file != null)
                {
                    var avatar = random.Next(1, 99999).ToString() + Path.GetFileName(file.FileName);
                    var physicPath = Path.Combine(Server.MapPath("~/Images"), avatar);
                    file.SaveAs(physicPath);
                    property.Avatar = avatar;
                }

                model.Properties.Add(property);
                model.SaveChanges();
                PopularMessage(true);
            }
            else
                PopularMessage(false);
            return Redirect("Index");
        }



        public void PopularMessage(bool success)
        {
            if (success)
                Session["success"] = "Successfull";
            else
                Session["success"] = "Fail";
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var property = model.Properties.FirstOrDefault(x => x.ID == id);
            PoPularData(property.Property_Type_ID, property.District_ID, property.Property_Status_ID);
            return View(property);
        }
        [HttpPost]
        public ActionResult Edit(Property pp, int id)
        {
            var Property = model.Properties.ToList();
            try
            {
                var property = model.Properties.Select(p => p).Where(p => p.ID == id).FirstOrDefault();
                PoPularData(property.Property_Type_ID, property.Property_Status_ID);
                property.Property_Name = pp.Property_Name;
                property.Description = pp.Description;
                property.Address = pp.Address;
                property.Area = pp.Area;
                property.Bath_Room = pp.Bath_Room;
                property.Bed_Room = pp.Bed_Room;
                property.Price = pp.Price;
                model.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View(Property);
            }
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            var property = model.Properties.Select(p => p).Where(p => p.ID == id).FirstOrDefault();
            return View(property);
        }

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                var property = model.Properties.Select(p => p).Where(p => p.ID == id).FirstOrDefault();
                if (property != null)
                {
                    model.Properties.Remove(property);
                    model.SaveChanges();
                }
                return RedirectToAction("Index");

            }
            catch { return View(); }
        }


    }
}