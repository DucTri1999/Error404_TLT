using Error404_TLT.Models.Error404Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;

namespace Error404_TLT.Areas.Areas.Models
{
    public class ProductManagerBUS
    {
        private AppleEntities db;

        public ProductManagerBUS()
        {
            db = new AppleEntities();
        }
        public IEnumerable<SanPham> loadProduct()
        {
            var result = from a in db.SanPham
                         select a;

            return result.ToList();
        }
        public SanPham ChiTietSP(string id)
        {
            var result = db.SanPham.Where(p => p.MaSP == id).SingleOrDefault();

            return result;
        }
        public void delSanPham(string id)
        {
            var product = db.SanPham.Where(t => t.MaSP == id).FirstOrDefault();
            db.SanPham.Remove(product);
            db.SaveChanges();
        }

        public IEnumerable<LoaiSP> loadLoaiSP()
        {
            return db.LoaiSP;
        }

        public string DanhMuc(string MaLSP)
        {
            var result = db.LoaiSP.Where(t => t.MaLSP == MaLSP).Select(c => c.MaDM).FirstOrDefault();
            return result;
        }

        public void editSanPham(string MaSP, string MaLSP, string img, string img2, string img3, string img4, string TenSP, int DonGia, int GiaKM, int SLTon, string Description, string moreInfo,int Views, int LoaiHang)
        {
            var dateadd = db.SanPham.Where(t => t.MaSP == MaSP).Select(c => c.DataAdd).FirstOrDefault();
            SanPham p = new SanPham
            {
                MaSP = MaSP,
                MaLSP = MaLSP,
                img = img,
                img2 = img2,
                img3 = img3,
                img4 = img4,
                TenSP = TenSP,
                DonGia = DonGia,
                GiaKM = GiaKM,
                SLTon = (short?)SLTon,
                Description = Description,
                MoreInfo = moreInfo,
                Views = Views,
                LoaiHang = LoaiHang,
                DataAdd = dateadd
            };
            db.SanPham.AddOrUpdate(p);
            db.SaveChanges();
        }

        public void addSanPham(string MaSP, string MaLSP, string img, string img2, string img3, string img4, string TenSP, int DonGia, int GiaKM, int SLTon, string Description, string moreInfo,int Views,int LoaiHang)
        {
            DateTime time = DateTime.Now;
            SanPham p = new SanPham
            {
                MaSP = MaSP,
                MaLSP = MaLSP,
                img = img,
                img2 = img2,
                img3 = img3,
                img4 = img4,
                TenSP = TenSP,
                DonGia = DonGia,
                GiaKM = GiaKM,
                SLTon = (short?)SLTon,
                Description = Description,
                MoreInfo = moreInfo,
                Views = Views,
                LoaiHang = LoaiHang,
                DataAdd = time
            };
            db.SanPham.AddOrUpdate(p);
            db.SaveChanges();
        }
    }
}