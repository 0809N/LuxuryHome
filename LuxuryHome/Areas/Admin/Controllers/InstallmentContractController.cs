using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LuxuryHome.Models;
namespace LuxuryHome.Areas.Admin.Controllers
{
    public class InstallmentContractController : Controller
    {
        PPCDBEntities1 model =new PPCDBEntities1();
        // GET: Admin/InstallmentContract
        public ActionResult Index()
        {
            var contract = model.Installment_Contract.ToList();
            return View(contract);
        }
        public ActionResult Print(int id)
        {
            var contract = model.Installment_Contract.FirstOrDefault(n => n.ID == id);
            if (contract !=null)
            {
                InstallmentContractPrintModel ic = new InstallmentContractPrintModel();
                ic.Installment_Contract_Code = contract.Installment_Contract_Code;
                ic.Customer_Address = contract.Customer_Address;
                ic.Customer_Name = contract.Customer_Name;
                ic.Date_Of_Contract = contract.Date_Of_Contract;
                ic.Price = contract.Price;
                ic.Despoit = contract.Deposit;
                ic.SSN = contract.SSN;
                ic.Loan_Amount = contract.Loan_Amount;
                ic.Mobile = contract.Mobile;
                ic.Payment_Period = contract.Payment_Period;
                ic.Property_Code = contract.Property.Property_Code;
                ic.Address = contract.Property.Address;
                return View(ic);
            }
            else
            {
                return View();
            }
           
        }
    }
}