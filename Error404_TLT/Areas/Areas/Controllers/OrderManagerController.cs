using Error404_TLT.Areas.Areas.Models;
using Error404_TLT.Models.Error404Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Error404_TLT.Areas.Areas.Controllers
{
    public class OrderManagerController : Controller
    {
        OrderManagerBUS OB;
        public OrderManagerController()
        {
            OB = new OrderManagerBUS();
        }
        // GET: Admin/OrderManager
        public ActionResult ListOrder()
        {
            return View();
        }

        public IEnumerable<Order> loadOrder()
        {
            var result = OB.loadOrder();

            return result;
        }

        [HttpPost]
        public ActionResult CTOrder(int id)
        {
            var result = OB.ChiTietOrder(id);

            return PartialView(result);
        }

        public IEnumerable<SanPham> loadSanPham()
        {
            return OB.loadSanPham();
        }
    }
}