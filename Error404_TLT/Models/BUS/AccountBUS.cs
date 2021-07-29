using Error404_TLT.Models.Error404Entity;
using Error404_TLT.Models.ViewsModel;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;

namespace Error404_TLT.Models.BUS
{
    public class AccountBUS
    {
        private AppleEntities db;

        public AccountBUS()
        {
            db = new AppleEntities();
        }

        public IEnumerable<TaiKhoan> listAccount()
        {
            return db.TaiKhoan;
        }

        public string checkLogin(string user, string pass)
        {
            return db.TaiKhoan.Where(e => e.User == user & e.Pass == pass).Select(p => p.User).SingleOrDefault();
        }

        public string getName(string user)
        {
            return db.KhachHang.Where(u => u.User == user).Select(p => p.FullName).SingleOrDefault();
        }


        public bool checkUser(string user)
        {
            var result = db.KhachHang.Where(k => k.User == user).SingleOrDefault();
            if(result == null)
            {
                return false;
            }
            return true;
        }

        public bool checkSDT(string sdt)
        {
            var result = db.KhachHang.Where(k => k.SDT == sdt).SingleOrDefault();
            if (result == null)
            {
                return false;
            }
            return true;
        }

        //đăng ký
        public void Signin(string user, string pass, string fullname, string sdt)
        {
            KhachHang kh = new KhachHang()
            {
                SDT = sdt,
                FullName = fullname,
                Address = "",
                User = user,
            };
            db.KhachHang.AddOrUpdate(kh);
            
            TaiKhoan tk = new TaiKhoan()
            {
                User = user,
                Pass = pass,
            };
            db.TaiKhoan.AddOrUpdate(tk);

            db.SaveChanges();
        }

        public CustomerViewModel account(string user)
        {
            var result = from k in db.KhachHang
                         where k.User == user
                         select new CustomerViewModel()
                         {
                             khachHang = k,
                         };
            return result.FirstOrDefault();
        }

        public IEnumerable<Rate> rating(string user)
        {
            return db.Rate.Where(p => p.User == user);
        }

        public IEnumerable<Order> loadBill(string user)
        {
            return db.Order.Where(p => p.User == user);
        }


        public void changeInfo(string sdt, string fullname, string address, string ThanhPho, string Quan, string Phuong, string user)
        {
            KhachHang a = db.KhachHang.Where(p => p.User == user).FirstOrDefault();
            a.SDT = sdt;
            a.FullName = fullname;
            a.Address = address;
            a.ThanhPho = ThanhPho;
            a.Quan = Quan;
            a.Phuong = Phuong;
            db.SaveChanges();
        }


        public void changePass(string user, string pass_new)
        {
            TaiKhoan a = db.TaiKhoan.Where(p => p.User == user).FirstOrDefault();
            a.Pass = pass_new;
            db.SaveChanges();
        }

        public string checkUserAdmin(string user, string pass)
        {
            string result = "";
            if (pass == "admin")
            {
                result = user;
            }
            return result;
        }
    }
}