using Error404_TLT.Areas.Areas.Models;
using Error404_TLT.Models.Error404Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Error404_TLT.Areas.Areas.Controllers
{
    public class DiscountManagerController : Controller
    {
        DiscountManagerBUS DB;

        public DiscountManagerController()
        {
            DB = new DiscountManagerBUS();  
        }

        public ActionResult ListDiscount()
        {
            return View();
        }

        public IEnumerable<Discount> loadDiscount()
        {
            var result = DB.loadDiscount();
            return result;
        }

        public void delDiscount(string id)
        {
            DB.delDC(id);
        }

        public ActionResult ChiTietDC(string id)
        {
            var result = DB.CTDC(id);

            return PartialView(result);
        }

        public ActionResult editDiscount(string id)
        {
            var result = DB.CTDC(id);

            return PartialView(result);
        }

        [HttpPost]
        public void upDiscount(string DCID, string TenDC, string MoTa, int Giam)
        {
            DB.editDC(DCID, TenDC, MoTa, Giam);
        }

        public ActionResult addDiscount()
        {
            return PartialView();
        }

        [HttpPost]
        public void addDC(string DCID, string TenDC, string MoTa, int Giam)
        {
            DB.addDC(DCID, TenDC, MoTa, Giam);
        }
    }
}