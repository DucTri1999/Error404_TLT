using Error404_TLT.Models.Error404Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;

namespace Error404_TLT.Areas.Areas.Models
{
    public class DiscountManagerBUS
    {
        private AppleEntities db;

        public DiscountManagerBUS()
        {
            db = new AppleEntities();
        }

        public IEnumerable<Discount> loadDiscount()
        {
            var result = from a in db.Discount
                         select a;
            return result.ToList();
        }

        public Discount CTDC (string id)
        {
            var result = db.Discount.Where(p => p.DCID == id).SingleOrDefault();

            return result;
        }

        public void delDC(string id)
        {
            var discount = db.Discount.Where(t => t.DCID == id).FirstOrDefault();
            db.Discount.Remove(discount);
            db.SaveChanges();
        }

        public void editDC(string DCID, string TenDC, string MoTa, int Giam)
        {
            Discount d = new Discount
            {
                DCID = DCID,
                TenDC = TenDC,
                MoTa = MoTa,
                Giam = Giam
            };
            db.Discount.AddOrUpdate(d);
            db.SaveChanges();
        }

        public void addDC(string DCID, string TenDC, string MoTa, int Giam)
        {
            Discount d = new Discount
            {
                DCID = DCID,
                TenDC = TenDC,
                MoTa = MoTa,
                Giam = Giam
            };
            db.Discount.AddOrUpdate(d);
            db.SaveChanges();
        }
    }
}