using Error404_TLT.Models.Error404Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Error404_TLT.Areas.Areas.Models
{
    public class OrderManagerBUS
    {
        private AppleEntities db;

        public OrderManagerBUS()
        {
            db = new AppleEntities();
        }

        public IEnumerable<Order> loadOrder()
        {
            var result = from a in db.Order
                         select a;

            return result.ToList();
        }

        public IEnumerable<CTOrder> ChiTietOrder(int id)
        {
            var result = db.CTOrder.Where(p => p.MaDH == id);

            return result.ToList();
        }

        public IEnumerable<SanPham> loadSanPham()
        {
            return db.SanPham;
        }
    }
}