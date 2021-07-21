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

        public void changePass(string user, string pass_new)
        {
            accountBUS.changePass(user, pass_new);
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

        [HttpPost]
        public bool Signup(string user, string pass, string fullname, string sdt)
        {
            if (checkUser(user) || checkSDT(sdt))
                return false;
            accountBUS.Signin(user, pass, fullname, sdt);
            return true;
        }

        public IEnumerable<Order> loadBill(string user)
        {
            var result = accountBUS.loadBill(user);

            return result;
        }


        public void changeInfo(string sdt, string fullname, string address, string user)
        {
            accountBUS.changeInfo(sdt, fullname, address, user);

            Session["fullname"] = fullname;
            Session["user"] = user;
        }


        // dùng thêm địa chỉ 
        public ActionResult formAddAddress()
        {
            return PartialView();
        }
    }
}