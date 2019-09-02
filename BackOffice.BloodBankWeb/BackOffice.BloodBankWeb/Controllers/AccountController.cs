using BackOffice.BloodBankWeb.Models;
using BloodBankProvider.Controller;
using BloodBankProvider.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace BackOffice.BloodBankWeb.Controllers
{
    public class AccountController : Controller
    {
        //
        // GET: /Account/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login(AccountModel accountModel)
        {
            if (SystemUserController.Instance.loginSystem(accountModel.UserName, accountModel.Password))
            {
                FormsAuthentication.SignOut();
                FormsAuthentication.SetAuthCookie(accountModel.UserName, accountModel.RememberMe);
                SystemUserDTO systemUser = SystemUserController.Instance.getUserByUserName(accountModel.UserName);
                AccountModel userModel = new AccountModel
                {
                    FirstName = systemUser.Name.Trim(),
                    LastName = systemUser.Surname.Trim(),
                    UserName = systemUser.UserName.Trim(),
                    Password = systemUser.Password.Trim(),
                    IsLogin = true,
                    RememberMe = accountModel.RememberMe,
                    Role = systemUser.Role != null ? systemUser.Role.Trim() : "",
                    Valid = true

                };

                userModel.clearCurrentUser();
                userModel.setCurrentUser(userModel);

                Session["UserModel"] = userModel;

                HttpCookie currentCookie = Request.Cookies["Admin_User_Login"];
                if(currentCookie != null)
                {
                    Response.Cookies.Remove("Admin_User_Login");
                }

                HttpCookie cookie = new HttpCookie("Admin_User_Login");
                cookie.Value = userModel.UserName;
                DateTime dTime = DateTime.Now;
                if (accountModel.RememberMe)
                {
                    cookie.Expires = dTime.AddYears(3);
                }
                else
                {
                    cookie.Expires = dTime.AddDays(1);
                }
                Response.Cookies.Add(cookie);
                ViewBag.ErrorMessage = null;
            }
            else
            {
                ViewBag.ErrorMessage = "Bilgileriniz sisteme kayıtlı değildir";
                return View("Index");
            }
            return RedirectToAction("Index", "Home");
        }

        public ActionResult SignOut()
        {
            FormsAuthentication.SignOut();
            Session["UserModel"] = null;
            HttpCookie currentCookie = Request.Cookies["Admin_User_Login"];
            if (currentCookie != null)
            {
                Response.Cookies.Remove("Admin_User_Login");
            }
            return RedirectToAction("Index", "Account");
        }

    }
}
