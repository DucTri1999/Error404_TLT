using Error404_TLT.Models.Error404Entity;
using Error404_TLT.Models.ViewsModel;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;

namespace Error404_TLT.Models.BUS
{
    public class ProductBUS
    {
        private AppleEntities db;

        public ProductBUS()
        {
            db = new AppleEntities();
        }

        public SanPham ChiTietSP(string id)
        {
            return db.SanPham.Where(p => p.MaSP == id).SingleOrDefault();
        }

        //Load sản phẩm theo danh mục
        public IEnumerable<SanPham> LoadProductByCategory(string id)
        {
            return db.SanPham.Where(p => p.LoaiSP.MaDM == id && p.SLTon > 0);
        }

        //Load sản phẩm mới
        public IEnumerable<SanPham> loadProductNew()
        {
            var result = db.SanPham.Where(p => p.LoaiHang == 1);
            return result;
        }

        //Load sản phẩm sale
        public IEnumerable<SanPham> loadProductSale()
        {
            var result = db.SanPham.Where(p => p.LoaiHang == 2);
            return result;
        }

        //Load sản phẩm nổi bật
        public IEnumerable<SanPham> loadProductNoiBat()
        {
            var result = db.SanPham.Where(p => p.LoaiHang == 3);
            return result;
        }

        //Load sản phẩm tương tự trong details(cùng mã loại)
        public IEnumerable<SanPham> loadProductOther(string id)
        {
            var result = db.SanPham.Where(p => p.MaLSP == id);
            return result;
        }

        //Thêm sản phẩm vào giỏ hàng
        public void insertCart(string id, string user)
        {
            Cart c = new Cart
            {
                User = user,
                MaSP = id,
                SL = 1,
            };
            db.Cart.Add(c);
            db.SaveChanges();
        }

        //Thêm sản phẩm vào giỏ hàng với số lượng tùy chọn
        public void insertCartWithSL(string id, string user, int sl)
        {
            Cart c = new Cart
            {
                User = user,
                MaSP = id,
                SL = sl,
            };
            db.Cart.Add(c);
            db.SaveChanges();
        }

        //Load sản phẩm vào trang giỏ hàng
        public IEnumerable<ProductOfCartModel> loadProductCart(string user)
        {
            var list = from a in db.SanPham
                       join b in db.Cart
                       on a.MaSP equals b.MaSP
                       where b.User == user
                       select new ProductOfCartModel
                       {
                           ProductId = a.MaSP,
                           ProductName = a.TenSP,
                           ProductImage = a.img,
                           ProductPrice = a.DonGia,
                           ProductAmount = b.SL,
                       };
            return list;
        }

        //Load sản phẩm vào trang checkout
        public IEnumerable<ProductOfCartModel> loadProductCheckout(string user)
        {
            var list = from a in db.SanPham
                       join b in db.Cart
                       on a.MaSP equals b.MaSP
                       where b.User == user
                       select new ProductOfCartModel
                       {
                           ProductId = a.MaSP,
                           ProductName = a.TenSP,
                           ProductImage = a.img,
                           ProductPrice = a.DonGia,
                           ProductAmount = b.SL,
                       };
            return list;
        }

        //Load danh sách sản phẩm vào giỏ hàng header
        public IEnumerable<Cart> loadCart(string user)
        {
            return db.Cart.Where(c => c.User == user);
        }

        // Cập nhật giỏ hàng
        public void change_Cart(string id, string user, int sl)
        {
            Cart c = new Cart()
            {
                User = user,
                MaSP = id,
                SL = sl,
            };
            db.Cart.AddOrUpdate(c);
            db.SaveChanges();
        }

        // Xóa sản phẩm ở giỏ hang                                                                                                                                                                                                                                                             
        public void delProduct_Cart(string id, string user)
        {
            Cart c = db.Cart.Where(p => p.MaSP == id && p.User == user).SingleOrDefault();
            db.Cart.Remove(c);
            db.SaveChanges();
        }
    }
}