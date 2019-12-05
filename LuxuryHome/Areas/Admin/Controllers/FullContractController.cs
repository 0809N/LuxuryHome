using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LuxuryHome.Models;

namespace LuxuryHome.Areas.Admin.Controllers
{
    public class FullContractController : Controller
    {
        PPCDBEntities1 model = new PPCDBEntities1();
      
            // GET: Admin/FullContract
        public ActionResult Index()
        {
            var contract = model.Full_Contract.ToList();
            return View(contract);
        }
        public ActionResult Print(int id)
        {
            var contract = model.Full_Contract.FirstOrDefault(n => n.ID == id);
            if(contract != null)
            {
                FullContractPrintModel fc = new FullContractPrintModel();
                fc.Full_Contract_Code = contract.Full_Contract_Code;
                fc.Customer_Name = contract.Customer_Name;
                fc.Customer_Address = contract.Customer_Address;
                fc.Date_Of_Contract = contract.Date_Of_Contract;
                fc.Despoit = contract.Deposit;
                fc.Price = contract.Price;
                fc.SSN = contract.SSN;
                fc.Mobile = contract.Mobile;
                fc.Property_Code = contract.Property.Property_Code;
                fc.Address = contract.Property.Address;
                return View(fc);
            }
            else
            {
                return View();
            }
        }
    }
}