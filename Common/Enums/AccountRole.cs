using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Enums
{
    public class AccountRole
    {
        public enum RoleEnum
        {
            Customer,
            Admin
        }

        public static readonly Dictionary<RoleEnum, string> RoleDictionary = new Dictionary<RoleEnum, string>
        {
            { RoleEnum.Customer, Constants.Customer },
            { RoleEnum.Admin, Constants.Admin }
        };

        public struct Constants
        {
            public const string Customer = "Customer";
            public const string Admin = "Admin";
        }
    }
}
