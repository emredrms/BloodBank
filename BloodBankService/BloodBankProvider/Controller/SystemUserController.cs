using BloodBankData;
using BloodBankProvider.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBankProvider.Controller
{
    public class SystemUserController
    {
        private static readonly SystemUserController _instance = new SystemUserController();

        public static SystemUserController Instance
        {
            get
            {
                return _instance;
            }
        }

        public bool loginSystem(string userName, string password)
        {
            return Repository.dbConnection.SystemUser.Any(s => s.UserName == userName && s.Password == password && s.Valid);
        }

        public SystemUserDTO getUserByUserName(string userName)
        {
            if (!string.IsNullOrEmpty(userName))
            {
                var user = Repository.dbConnection.SystemUser.Where(u => u.UserName == userName).FirstOrDefault();

                return new SystemUserDTO
                {
                    UserName = user.UserName,
                    Password = user.Password,
                    Role = user.Role,
                    SystemUserId = user.UserId,
                    Valid = true,
                    Name = user.Name,
                    Surname = user.Surname
                };
            }
            return null;
        }
    }
}
