using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoanProcessManagement.App.Helper.APIHelper
{
    public class APIEndpoints
    {
        public const string ChangePassword = "api/v1/ChangePassword";
        public const string AuthenticateUser = "api/v1/User/authenticateUser";
        public const string GetRoles = "api/v1/Role/GetRoles";
        public const string GetBranches = "api/v1/Branch/GetBranches";
        public const string RegisterUser = "api/v1/User/registerUser";
        public const string RemoveUser = "api/v1/User/removeUser/";




        #region Maintaining the Url EndPoint - Saif Khan - 28/10/2021
        public const string MenuProcess = "api/v1/Menu";
        #endregion
        #region Maintaining the Url EndPoint - Saif Khan - 28/10/2021
        public const string UserList = "api/v1/UserList";
        #endregion
    }
}
