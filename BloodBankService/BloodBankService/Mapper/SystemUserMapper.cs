using BloodBankProvider.Controller;
using BloodBankService.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BloodBankService.Mapper
{
    public class SystemUserMapper
    {
        private static readonly SystemUserMapper _instance = new SystemUserMapper();

        public static SystemUserMapper Instance
        {
            get
            {
                return _instance;
            }
        }

        public SystemUser getUserByUserName(string username)
        {
            var user = SystemUserController.Instance.getUserByUserName(username);

            return new SystemUser
            {
                Name = user.Name,
                Role = user.Role,
                Surname = user.Surname,
                SystemUserId = user.SystemUserId,
                UserName = user.UserName,
                Valid = user.Valid
            };
        }
    }
}