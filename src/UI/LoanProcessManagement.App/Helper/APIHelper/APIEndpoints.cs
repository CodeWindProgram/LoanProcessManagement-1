using System;
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

        public const string GetRoles = "api/v1/Role/GetRoles";
        public const string GetBranches = "api/v1/Branch/GetBranches";
        public const string RegisterUser = "api/v1/User/registerUser";
        public const string RemoveUser = "api/v1/User/removeUser/";
        public const string GetUser = "api/v1/User/getUser/";
        public const string UpdateUser = "api/v1/User/updateUser";
        public const string GetLeadByLeadId = "api/v1/LeadList/GetLeadById/";
        public const string GetStatus = "api/v1/LeadStatus/getLeadStatus/";
        public const string GetLoanProducts = "api/v1/Product/GetLoanProducts";
        public const string GetInsuranceProducts = "api/v1/Product/GetInsuranceProducts";
        public const string ModifyLead = "api/v1/LeadList/ModifyLead";
        public const string RoleList = "api/v1/RoleMaster";

        #region Maintaining the Url EndPoint for Menus - Saif Khan - 28/10/2021
        public const string MenuProcess = "api/v1/Menu";
        public const string MenuCreate = "api/v1/Menu/Create";
        public const string MenuUpdate = "api/v1/Menu/updateMenu/";
        public const string MenuDelete = "api/v1/Menu/removeMenu/";
        public const string MenuList = "api/v1/Menu/MenuList/";
        public const string MenuById = "api/v1/Menu/MenuById/";
        #endregion

        #region Maintaining the Url EndPoint for Users - Saif Khan - 28/10/2021
        public const string UserList = "api/v1/UserList";
        public const string AuthenticateUser = "api/v1/User/authenticateUser";
        #endregion

        #region Maintaining the Url EndPoint for Leads - Saif Khan - 01/11/2021
        public const string LeadList = "api/v1/LeadList";
        public const string LeadHistory = "api/v1/LeadList/GetLeadHistory/";
        #endregion

        #region added url Endpoints - Ramya Guduru -29/10/2021
        public const string UnlockUserAccount = "api/v1/UnlockUserAccount/UnlockUserAccount";
        public const string UnlockAndResetPassword = "api/v1/UnlockUserAccount/UnlockUserAndReset";
        public const string ActivateUserAccount = "api/v1/UnlockUserAccount/ActivateUser";
        #endregion

        #region added url Endpoints - Ramya Guduru -01/11/2021
        public const string ForgotPassword = "api/v1/ForgotPassword/ForgotPassword";
        #endregion

        public const string GetProperty = "api/v1/PropertyDetails/getProperty/";
        public const string GetPropertyType = "api/v1/PropertyType/GetPropertyTypes";
        public const string GetSanctionedPlan = "api/v1/SanctionedPlanReceived/GetSanctionedPlan";
        public const string UpdateProperties = "api/v1/PropertyDetails/updateProperty";

        public const string AllProductsList = "api/v1/Products/GetProductsList/";
        public const string LeadListing = "api/v1/GSTEnquiryLeadList/LeadListing/";
        public const string AddEnquiry = "api/v1/IncomeAssesment/";
    }
}
