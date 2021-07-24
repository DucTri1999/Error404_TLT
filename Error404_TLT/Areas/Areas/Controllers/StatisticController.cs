using Error404_TLT.Areas.Areas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Error404_TLT.Areas.Areas.Controllers
{
    public class StatisticController : Controller
    {
        StaticManagerBUS SB;
        public StatisticController()
        {
            SB = new StaticManagerBUS();
        }

        public ActionResult All()
        {
            return View();
        }
        // Doanh thu
        public string Revenue()
        {
            var result = SB.Revenue();
            if (result == "")
            {
                result = "0";
            }

            return result;
        }
        // Số lượng sản phẩm bán
        public string totalProduct()
        {
            return SB.totalProduct();
        }
        // Số lượng khách hàng
        public string totalCustomer()
        {
            return SB.totalCustomer();
        }
        //Tong discount
        public string totalDiscount()
        {
            return SB.totalDiscount();
        }

        // SL dicount
        public string sumDiscount()
        {
            return SB.sumDiscount();
        }
    }
}