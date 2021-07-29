using Error404_TLT.Models.BUS;
using Error404_TLT.Models.Error404Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Error404_TLT.Controllers
{
    public class AccountController : Controller
    {
        private AccountBUS accountBUS;

        public AccountController()
        {
            accountBUS = new AccountBUS();
        }

        public ActionResult Index()
        {
            return View();
        }

        public bool Login(string user, string pass){
            string checkLogin = accountBUS.checkLogin(user, pass);
            if(checkLogin == user)
            {
                Session["user"] = checkLogin;
                Session["fullname"] = accountBUS.getName(user);
                return true;
            }
            return false;
        }

        public bool checkPass(string user, string pass)
        {
            string checkLogin = accountBUS.checkLogin(user, pass);
            if (checkLogin == user)
            {
                return true;
            }
            return false;
        }

        public void changePass(string user, string new_pass)
        {
            accountBUS.changePass(user, new_pass);
        }

        [HttpPost]
        public ActionResult Logout()
        {
            Session["user"] = null;
            Session["fullname"] = null;

            return RedirectToAction("Home", "Error404");
        }

        public bool checkUser(string user)
        {
            var result = accountBUS.checkUser(user);
            return result;
        }

        public bool checkSDT(string sdt)
        {
            var result = accountBUS.checkSDT(sdt);
            return result;
        }

        public bool checkEmail(string email)
        {
            var result = accountBUS.checkEmail(email);
            return result;
        }

        [HttpPost]
        public bool Signup(string user, string pass, string fullname, string sdt, string email)
        {
            if (checkUser(user) || checkSDT(sdt) || checkEmail(email))
                return false;
            accountBUS.Signin(user, pass, fullname, sdt, email);
            return true;
        }

        public IEnumerable<Order> loadBill(string user)
        {
            var result = accountBUS.loadBill(user);

            return result;
        }


        public void changeInfo(string sdt, string fullname, string address, string ThanhPho, string Quan, string Phuong, string email)
        {
            string user = Session["user"].ToString();
            accountBUS.changeInfo(sdt, fullname, address, ThanhPho, Quan, Phuong, email, user);

            Session["fullname"] = fullname;
            
        }


        // dùng thêm địa chỉ 
        public ActionResult formAddAddress()
        {
            return PartialView();
        }
    }
}