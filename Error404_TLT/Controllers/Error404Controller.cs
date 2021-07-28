using Error404_TLT.Models.BUS;
using Error404_TLT.Models.Error404Entity;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Error404_TLT.Controllers
{
    public class Error404Controller : Controller
    {
        private AppleEntities db;

        private ProductBUS productBUS;
        private AccountBUS accountBUS;

        public Error404Controller()
        {
            db = new AppleEntities();
            productBUS = new ProductBUS();
            accountBUS = new AccountBUS();
        }

        public ActionResult Home()
        {
            return View();
        }
        public ActionResult BaoHanh()
        {
            return View();
        }
        public ActionResult ThuCuDoiMoi()
        {
            return View();
        }

        //Load sản phẩm theo danh mục(iphone, ipad, macbook, airpod, ...)
        public ActionResult Category(string id, int page = 1, int pageSize = 12)
        {
            Session["CategoryId"] = id;
            Session["CategoryName"] = db.DanhMuc.Where(dm => dm.MaDM == id).Select(p => p.TenDM).SingleOrDefault();
            var list = productBUS.LoadProductByCategory(id).OrderBy(p => p.MaSP).ToPagedList(page, pageSize);
            return View(list);
        }

        //Chi tiết 1 sản phẩm
        public ActionResult Details(string id)
        {
            Session["ProductName"] = db.SanPham.Where(m => m.MaSP == id).Select(t => t.TenSP).SingleOrDefault();
            var p = productBUS.ChiTietSP(id);
            return View(p);
        }
        //Vào giỏ hàng
        public ActionResult Cart (string user)
        {
            var result = productBUS.loadProductCart(user);
            return View(result);
        }

        //Thanh toán
        public ActionResult CheckOut(string user)
        {
            var result = productBUS.loadProductCheckout(user);
            return View(result);
        }

        //Thông tin tài khoản
        public ActionResult Customer()
        {
            var user = Session["user"].ToString();
            var result = accountBUS.account(user);
            return View(result);
        }
    }
}