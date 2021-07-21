using Error404_TLT.Models.BUS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Error404_TLT.Controllers
{
    public class ProductController : Controller
    {
        private ProductBUS productBUS;
        public ProductController()
        {
            productBUS = new ProductBUS();
        }

        // Thêm sản phẩm vào giỏ hàng
        [HttpPost]
        public ActionResult insertCart(string id, string user)
        {
            productBUS.insertCart(id, user);
            return PartialView();
        }

        //Thêm sản phẩm vào giỏ hàng với số lượng tùy chọn
        [HttpPost]
        public ActionResult insertCartWithSL(string id, string user, int sl)
        {
            productBUS.insertCartWithSL(id, user, sl);
            return PartialView();
        }

        // xóa sản phẩm trong giỏ hàng của khách hàng khi bấm remove trong bảng giỏ hàng
        public ActionResult delProduct_Cart(string id)
        {
            string user = Session["user"].ToString();
            productBUS.delProduct_Cart(id, user);

            return PartialView();
        }

        [HttpPost]
        public void change_Cart(string id, int sl)
        {
            string user = Session["user"].ToString();

            productBUS.change_Cart(id, user, sl);
        }

    }
}