using Error404_TLT.Models.Error404Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Error404_TLT.Areas.Areas.Models
{
    public class StaticManagerBUS
    {
        private AppleEntities db;

        public StaticManagerBUS()
        {
            db = new AppleEntities();
        }
        // Doanh thu
        public string Revenue()
        {
            var result = db.Order.Sum(p => p.TongDH);

            return result.ToString();
        }
        // Số lượng sản phẩm bán
        public string totalProduct()
        {
            var result = db.SanPham.Count();

            return result.ToString();
        }

       
        // Số lượng khách hàng
        public string totalCustomer()
        {
            var result = db.KhachHang.Count();

            return result.ToString();
        }
        //Tong discount
        public string sumDiscount()
        {
            var result = db.Discount.Sum(p => p.Giam);

            return result.ToString();
        }
        // SL dicount
        public string totalDiscount()
        {
            var result = db.Discount.Count();

            return result.ToString();
        }
    }
}