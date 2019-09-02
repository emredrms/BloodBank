using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BackOffice.BloodBankWeb.Models
{
    public class RootModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public bool Valid { get; set; }
        public bool IsLogin { get; set; }

        private static RootModel currentUser;

        public void setCurrentUser(RootModel rootModel)
        {
            if (currentUser == null)
            {
                currentUser = new RootModel();
                currentUser.FirstName = rootModel.FirstName;
                currentUser.LastName = rootModel.LastName;
                currentUser.UserName = rootModel.UserName;
                currentUser.Password = rootModel.Password;
                currentUser.Role = rootModel.Role;
                currentUser.Valid = rootModel.Valid;
                currentUser.IsLogin = rootModel.IsLogin;

            }
            else if (currentUser.UserName.Equals(rootModel.UserName))
            {
                currentUser = new RootModel();
                currentUser.FirstName = rootModel.FirstName;
                currentUser.LastName = rootModel.LastName;
                currentUser.UserName = rootModel.UserName;
                currentUser.Password = rootModel.Password;
                currentUser.Role = rootModel.Role;
                currentUser.Valid = rootModel.Valid;
                currentUser.IsLogin = rootModel.IsLogin;
            }
        }

        public static RootModel getCurrentUser()
        {
            return currentUser;
        }

        public void clearCurrentUser()
        {
            currentUser = null;
        }

        public static string fullName
        {
            get
            {
                if (currentUser != null)
                {
                    return currentUser.FirstName + " " + currentUser.LastName;
                }
                else
                {
                    return String.Empty;
                }
            }
        }

    }
}