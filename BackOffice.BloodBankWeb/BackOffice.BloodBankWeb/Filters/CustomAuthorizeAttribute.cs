using BackOffice.BloodBankWeb.Models;
using BloodBankProvider.Controller;
using BloodBankProvider.Model;
using System.Web;
using System.Web.Mvc;

namespace BackOffice.BloodBankWeb.Filters
{
    public class CustomAuthorizeAttribute : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {

            AccountModel accountModel = new AccountModel();
            HttpCookie cookie = HttpContext.Current.Request.Cookies["Admin_User_Login"];
            if (HttpContext.Current.Session["UserModel"] != null)
            {
                accountModel = (AccountModel)HttpContext.Current.Session["UserModel"];
                accountModel.setCurrentUser(accountModel);
                return true;
            }
            else if (cookie != null && cookie.Value != null)
            {
                SystemUserDTO systemUser = SystemUserController.Instance.getUserByUserName(cookie.Value);

                if(systemUser == null)
                {
                    return false;
                }
                accountModel = new AccountModel
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

                accountModel.clearCurrentUser();
                accountModel.setCurrentUser(accountModel);

                HttpContext.Current.Session["UserModel"] = accountModel;
                return true;
            }

            return false;

        }

        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            if (!AuthorizeCore(filterContext.HttpContext))
            {
                HttpContext.Current.Response.Redirect("~/Account/Index");
            }
        }
    }
}