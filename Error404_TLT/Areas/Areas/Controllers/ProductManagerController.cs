using Error404_TLT.Areas.Areas.Models;
using Error404_TLT.Models.Error404Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Error404_TLT.Areas.Areas.Controllers
{
    public class ProductManagerController : Controller
    {
        ProductManagerBUS PS;

        public ProductManagerController()
        {
            PS = new ProductManagerBUS();
        }
        public ActionResult ListProduct()
        {
            return View();
        }
        public IEnumerable<SanPham> loadProduct()
        {
            var result = PS.loadProduct();

            return result;
        }

        public ActionResult ChiTietSP(string id)
        {
            var result = PS.ChiTietSP(id);

            return PartialView(result);
        }

        public ActionResult delProduct(string id)
        {
            PS.delSanPham(id);

            return PartialView("ListProduct");
        }

        public void delSanPham(string id)
        {
            PS.delSanPham(id);
        }

        public ActionResult editProduct(string id)
        {
            var result = PS.ChiTietSP(id);

            return PartialView(result);
            //return PartialView();
        }

        public IEnumerable<LoaiSP> loadLoaiSP()
        {
            return PS.loadLoaiSP();
        }

        public string DanhMuc(string MaLSP)
        {
            return PS.DanhMuc(MaLSP);
        }

        [HttpPost]
        public void upSanPham(string MaSP, string MaLSP, string img, string img2, string img3, string img4, string TenSP, int DonGia, int GiaKM, int SLTon, string description, string moreInfo, int Views, int LoaiHang)
        {
            PS.editSanPham(MaSP, MaLSP, img, img2, img3, img4, TenSP, DonGia, GiaKM, SLTon, description, moreInfo, Views, LoaiHang);
        }

        public ActionResult addProduct()
        {
            return PartialView();
        }

        [HttpPost]
        public void addSanPham(string MaSP, string MaLSP, string img, string img2, string img3, string img4, string TenSP, int DonGia, int GiaKM, int SLTon, string description, string moreInfo, int Views, int LoaiHang)
        {
            PS.addSanPham(MaSP, MaLSP, img, img2, img3, img4, TenSP, DonGia, GiaKM, SLTon, description, moreInfo, Views, LoaiHang);
        }
    }
}