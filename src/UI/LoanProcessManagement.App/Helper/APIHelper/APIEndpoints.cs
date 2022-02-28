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
        public const string GetStatusCount = "api/v1/LeadStatus/GetStatusCount";

        public const string GetLoanProducts = "api/v1/Product/GetLoanProducts";
        public const string GetInsuranceProducts = "api/v1/Product/GetInsuranceProducts";
        public const string ModifyLead = "api/v1/LeadList/ModifyLead";
        public const string RoleList = "api/v1/RoleMaster";
        public const string GetAllMenuMaps = "api/v1/Menu/GetAllMenuMaps";
        public const string RoleMap = "api/v1/Menu/CreateMenuMaps";
        public const string DeleteRoleMapById = "api/v1/Menu/DeleteMenuMapsById/";
        public const string SubmitToAgency = "api/v1/Agency/SubmitToAgency";
        //ChangePassword/VerifyOldPassword?OldPassword=Welcome2loan&LgId=LG_99
        public const string VerifyOldPassword = "api/v1/ChangePassword/VerifyOldPassword?OldPassword={0}&LgId={1}";

        public const string MailService = "api/EmailService/SendMail?api-version=1";

        #region Maintaining the Url EndPoint - Pratiksha Poshe - 10/11/2021
        public const string GetAllLoanProducts = "api/v1/LoanProducts/GetAllLoanProducts";
        public const string AddLead = "api/v1/LeadList/AddLead";
        public const string AddApplicantDetails = "api/v1/ApplicantDetails/AddApplicantDetails";
        public const string GetApplicantDetailsByLeadId = "api/v1/ApplicantDetails/GetApplicantDetailsByLeadId?lead_Id={0}&applicantType={1}";
        public const string GetQueryHistoryByLeadId = "api/v1/QueryHistory/GetQueryHistoryByLeadId?lead_Id={0}";
        public const string GetAllLoanSchemes = "api/v1/LoanSchemes/GetAllLoanSchemes";
        public const string GetAllLoanSchemesByProductId = "api/v1/LoanSchemes/GetLoanSchemesByProductId";
        public const string UnlockUserAccountOnToggleSwitch = "api/v1/UnlockUserAccount/UnlockUserAccountOnToggleSwitch";
        public const string ActivateUserAccountOnToggleSwitch = "api/v1/UnlockUserAccount/ActivateUserAccountOnToggleSwitch";
        public const string LockedUserList = "api/v1/UserList/GetLockedUserList";
        public const string GetAllAgencyName = "api/v1/Agency/getAllAgency";
        public const string GetThirdPartyCheckDetailsByLeadId = "api/v1/Agency/getThirdPartyCheckDetails/";
        public const string GetIncomeAssessmentDetails = "api/v1/IncomeAssesment/GetIncomeAssessmentDetailsByLeadId?applicantType={0}&lead_Id={1}";
        public const string AddIncomeAssessmentDetails = "api/v1/IncomeAssesment/AddIncomeAssessmentDetailsByLeadId/";
        #endregion

        #region Maintaining the Url EndPoint - Saif Khan - 28/10/2021
        public const string MenuProcess = "api/v1/Menu";
        public const string MenuCreate = "api/v1/Menu/Create";
        public const string MenuUpdate = "api/v1/Menu/updateMenu/";
        public const string MenuDelete = "api/v1/Menu/removeMenu/";
        public const string MenuList = "api/v1/Menu/MenuList/";
        public const string MenuById = "api/v1/Menu/MenuById/";
        public const string ParentMenu = "api/v1/Menu/GetAllMenus";
        public const string ChildMenu = "api/v1/Menu/GetChildMenu/";
        public const string AlterStatus = "api/v1/Menu/AlterMenuStatus";

    #endregion

        #region Maintaining the Url EndPoint for Users - Saif Khan - 28/10/2021
        public const string UserList = "api/v1/UserList";
        public const string AuthenticateUser = "api/v1/User/authenticateUser";
        #endregion

        #region Maintaining the Url EndPoint for Leads - Saif Khan - 01/11/2021
        public const string LeadList = "api/v1/LeadList";
        public const string LeadListById = "api/v1/LeadList/GetLeadListById";
        public const string LeadHistory = "api/v1/LeadList/GetLeadHistory/";
        #endregion

        #region added url Endpoints - Ramya Guduru -29/10/2021
        public const string UnlockUserAccount = "api/v1/UnlockUserAccount/UnlockUserAccount";
        public const string UnlockAndResetPassword = "api/v1/UnlockUserAccount/UnlockUserAndReset";
        public const string ActivateUserAccount = "api/v1/UnlockUserAccount/ActivateUser";
        public const string UnlockAccountUsersList = "api/v1/UnlockUserAccount";
        #endregion

        #region added url Endpoints - Ramya Guduru -01/11/2021
        public const string ForgotPassword = "api/v1/ForgotPassword/ForgotPassword";
        #endregion

        #region added url Endpoints for Update property details - Ramya Guduru -25/11/2021
        public const string GetProperty = "api/v1/PropertyDetails/getProperty/";
        public const string GetPropertyType = "api/v1/PropertyType/GetPropertyTypes";
        public const string GetSanctionedPlan = "api/v1/SanctionedPlanReceived/GetSanctionedPlan";
        public const string UpdateProperties = "api/v1/PropertyDetails/updateProperty";
        #endregion

        #region added url Endpoints Products List- Ramya Guduru -25/11/2021
        public const string AllProductsList = "api/v1/Products/GetProductsList/";
        #endregion

        #region added url Endpoints for GST Lead List- Ramya Guduru -25/11/2021
        public const string LeadListing = "api/v1/GSTEnquiryLeadList/LeadListing/";
        #endregion

        #region Added Url Endpoints for Ho-InPrinciple List Report- Raj Bhosale - 15-02-2022
        public const string InPrincipleList = "api/v1/LeadStatus/GetSanctionList";
        #endregion

        #region Added Url Endpoints for Ho-InPrinciple List Report- Raj Bhosale - 15-02-2022
        public const string HOSanctionList = "api/v1/LeadStatus/GetHOSanctionList";
        #endregion

        public const string AddEnquiry = "api/v1/IncomeAssesment/";
        public const string CreateEnquiry = "api/v1/IncomeAssesment";

        #region added url Endpoints for DSA corner  - Ramya Guduru -25/11/2021
        public const string DSACornerList = "api/v1/DSACorner/DSACorner/";   
        public const string TrainingVideosList = "api/v1/DSACorner/TrainingVideos/";
        public const string CircularList = "api/v1/DSACorner/Circular/";
        #endregion

        #region added url Endpoints for GST Lead List- Ramya Guduru -25/11/2021
        public const string ReportsLeadListing = "api/v1/Reports/ReportsLeadListing/";
        public const string ReportsList = "api/v1/Reports/Reports/";
        #endregion

        public const string GetLeadITRDetails = "api/v1/LeadITRDetails/GetLeadITRDetails?lead_Id={0}&applicantType={1}";
        public const string AddITRDetails = "api/v1/LeadITRDetails/AddLeadITRDetails";

        public const string GetCibilCheckDetails = "api/v1/CibilCheck/GetCibilCheckDetailsByLeadId?lead_Id={0}&applicantType={1}";
        public const string AddCibilCheckDetails = "api/v1/CibilCheck/AddCibilCheckDetails";
        public const string AllBranches = "api/v1/Branch/GetBranches";
        public const string BrancheById = "api/v1/Branch/GetBrancheById/";
        public const string LeadByBranchId = "api/v1/LeadList/LeadStatus/";
        public const string LeadByLgId = "api/v1/LeadList/LeadByName/";
        public const string FormNo = "api/v1/LeadList/VerifyFormNo?formNo=";


        #region added url Endpoints ITR, GST and Cibil enquiry Details List- Ramya Guduru - 14/02/2022
        public const string CreditITRDetailsList = "api/v1/CreditITRDetails/GetCreditITRDetailsList";
        public const string CreditITRUserDetailsList = "api/v1/CreditITRDetails/GetCreditITRUserDetailsList/";

        public const string CreditCibilDetailsList = "api/v1/CreditCibilDetails/GetCreditCibilDetailsList";
        public const string CreditCibilUserDetailsList = "api/v1/CreditCibilDetails/GetCreditCibilUserDetailsList/";

        public const string CreditGstDetailsList = "api/v1/CreditGstDetails/GetCreditGstDetailsList";
        public const string CreditGstUserDetailsList = "api/v1/CreditGstDetails/GetCreditGstUserDetailsList/";
        #endregion
        public const string resetPassword = "api/v1/ChangePassword/ResetPasswords";

        public const string GetSubmit = "api/v1/IncomeAssesment/GetSubmit/";
        public const string PostSubmit = "api/v1/IncomeAssesment/UpdateSubmitGst";
    }
}
