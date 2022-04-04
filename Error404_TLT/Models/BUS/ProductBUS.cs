using Error404_TLT.Models.Error404Entity;
using Error404_TLT.Models.ViewsModel;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Net;
using System.Net.Mail;
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
            db.Cart.AddOrUpdate(c);
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
            db.Cart.AddOrUpdate(c);
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

        //Tạo order
        public void insertOrder(string user, int total, string province, string district, string ward, string address)
        {
            DateTime time = DateTime.Now;

            Order order = new Order
            {
                User = user,
                TongDH = total,
                ThanhPho = province,
                Quan = district,
                Phuong = ward,
                Address = address,
                NgayDatHang = time
            };
            db.Order.Add(order);
            db.SaveChanges();
            int id = db.Order.Where(p => p.User == user).OrderByDescending(y => y.NgayDatHang).Select(t => t.MaDH).FirstOrDefault();
            IEnumerable<Cart> c = db.Cart.Where(p => p.User == user);
            string message = "";
            float sum = 0;
            foreach (var item in c)
            {
                CTOrder ct = new CTOrder
                {
                    MaDH = id,
                    MaSP = item.MaSP,
                    SL = item.SL,
                };
     
                db.CTOrder.Add(ct);
                SanPham p = db.SanPham.Where(t => t.MaSP == item.MaSP).FirstOrDefault();
                p.SLTon = p.SLTon - item.SL;
                message += "<br> Tên Khách Hàng :" + user;
                message += "<br> Tên Sản Phẩm :" + item.SanPham.TenSP;
                message += "<br> Giá Sản Phẩm :" + String.Format("{0:0,0 VND}", item.SanPham.DonGia);
                message += "<br> Số Lượng :" + item.SL;
                message += "<br> Địa Chỉ  : " + address; message += "<br> Phường/Xã :" + ward; message += "<br> Quận/Huyện :" + district; message += "<br> Tỉnh/Thành :" + province;
                message += "<br> Ngày Đặt Hàng  : " + time;
                sum += (float)(item.SanPham.DonGia);
                db.Cart.Remove(item);
            }
            message += "<br> => Tổng Tiền:" + String.Format("{0:0,0 VND}", sum);
            SendContactEmail("chauleductin1999@gmail.com", "Một đơn hàng đã được gửi đến cho bạn", message);
            db.SaveChanges();

        }
        public void SendContactEmail(string mailkh, string subject, string message)
        {
            // Your hard-coded email values (where the email will be sent from), this could be
            // define in a config file, etc.
            var email = "chauleductin1999@gmail.com";
            var password = "0932007274";

            // Your target (you may want to ensure that you have a property within your form so that you know
            // who to send the email to
            string address = mailkh;

            // Builds a message and necessary credentials (example using Gmail)
            var loginInfo = new NetworkCredential(email, password);
            var msg = new MailMessage();
            var smtpClient = new SmtpClient("smtp.gmail.com", 587);
            // This email will be sent from you
            msg.From = new MailAddress(email);
            // Your target email address
            msg.To.Add(new MailAddress(address));
            msg.Subject = subject;

            // Build the body of your email using the Body property of your message
            msg.Body = message;
            msg.IsBodyHtml = true;

            // Wires up and send the email
            smtpClient.EnableSsl = true;
            smtpClient.UseDefaultCredentials = false;
            smtpClient.Credentials = loginInfo;
            smtpClient.Send(msg);
        }



    }
}