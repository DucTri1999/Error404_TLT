using Error404_TLT.Models.Error404Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Error404_TLT.Areas.Areas.Models
{
    public class CustomerManagerBUS
    {
        private AppleEntities db;

        public CustomerManagerBUS()
        {
            db = new AppleEntities();
        }

        public IEnumerable<KhachHang> loadKH()
        {
            var result = from a in db.KhachHang
                         select a;

            return result.ToList();
        }
    }
}