using Error404_TLT.Areas.Areas.Models;
using Error404_TLT.Models.Error404Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Error404_TLT.Areas.Areas.Controllers
{
    public class CustomerManagerController : Controller
    {
        CustomerManagerBUS CB;

        public CustomerManagerController()
        {
            CB = new CustomerManagerBUS();
        }

        public ActionResult ListKH()
        {
            return View();
        }

        public IEnumerable<KhachHang> loadCustomer()
        {
            var result = CB.loadKH();
            return result;
        }
    }
}