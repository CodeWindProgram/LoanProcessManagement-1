﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoanProcessManagement.App.Helper.APIHelper
{
    public class APIEndpoints
    {
        #region added url Endpoints - Ramya Guduru -28/10/2021
        public const string ChangePassword = "api/v1/ChangePassword";
        #endregion

        public const string AuthenticateUser = "api/v1/User/authenticateUser";

        public const string GetRoles = "api/v1/Role/GetRoles";
        public const string GetBranches = "api/v1/Branch/GetBranches";
        public const string RegisterUser = "api/v1/User/registerUser";
        public const string RemoveUser = "api/v1/User/removeUser/";
        public const string GetUser = "api/v1/User/getUser/";
        public const string UpdateUser = "api/v1/User/updateUser";






        #region Maintaining the Url EndPoint - Saif Khan - 28/10/2021
        public const string MenuProcess = "api/v1/Menu";
        #endregion
        #region Maintaining the Url EndPoint - Saif Khan - 28/10/2021
        public const string UserList = "api/v1/UserList";
        #endregion
        #region added url Endpoints - Ramya Guduru -29/10/2021
        public const string UnlockUserAccount = "api/v1/UnlockUserAccount/UnlockUserAccount";
        public const string UnlockAndResetPassword = "api/v1/UnlockUserAccount/UnlockUserAndReset";
        public const string ActivateUserAccount = "api/v1/UnlockUserAccount/ActivateUser";
        #endregion

        #region added url Endpoints - Ramya Guduru -01/11/2021
        public const string ForgotPassword = "api/v1/ForgotPassword/ForgotPassword";
        #endregion
    }
}