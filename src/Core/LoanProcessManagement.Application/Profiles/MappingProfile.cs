using AutoMapper;
using LoanProcessManagement.Application.Features.Branch.Queries;
using LoanProcessManagement.Application.Features.Categories.Commands.CreateCateogry;
using LoanProcessManagement.Application.Features.Categories.Queries.GetCategoriesList;
using LoanProcessManagement.Application.Features.Categories.Queries.GetCategoriesListWithEvents;
using LoanProcessManagement.Application.Features.ChangePassword.Commands.ChangePassword;
using LoanProcessManagement.Application.Features.Events.Commands.CreateEvent;
using LoanProcessManagement.Application.Features.Events.Commands.UpdateEvent;
using LoanProcessManagement.Application.Features.Events.Queries.GetEventDetail;
using LoanProcessManagement.Application.Features.Events.Queries.GetEventsExport;
using LoanProcessManagement.Application.Features.Events.Queries.GetEventsList;
using LoanProcessManagement.Application.Features.ForgotPassword.Commands.ForgotPassword;
using LoanProcessManagement.Application.Features.Menu.Query;
using LoanProcessManagement.Application.Features.Orders.Queries.GetOrdersForMonth;
using LoanProcessManagement.Application.Features.Roles.Queries;
using LoanProcessManagement.Application.Features.User.Commands.CreateUser;
using LoanProcessManagement.Application.Models.Authentication;
using LoanProcessManagement.Application.Features.UnlockUserAccountAdmin.Commands.ActivateUserAccount;
using LoanProcessManagement.Application.Features.UnlockUserAccountAdmin.Commands.UnlockAndResetPassword;
using LoanProcessManagement.Application.Features.UnlockUserAccountAdmin.Commands.UnlockUserAccount;
using LoanProcessManagement.Application.Features.UserList.Query;
using LoanProcessManagement.Domain.CustomModels;
using LoanProcessManagement.Domain.Entities;
using System.Collections.Generic;
using LoanProcessManagement.Application.Features.LeadList.Commands;
using LoanProcessManagement.Application.Features.User.Queries;
using LoanProcessManagement.Application.Features.LeadList.Commands.AddLead;
using LoanProcessManagement.Application.Features.LoanProducts.Queries;
using LoanProcessManagement.Application.Features.RoleMaster.Commands.CreateRoleMaster;
using LoanProcessManagement.Application.Features.RoleMaster.Commands.UpdateRoleMaster;
using LoanProcessManagement.Application.Features.RoleMaster.Commands.DeleteRoleMaster;
using LoanProcessManagement.Application.Features.RoleMaster.Queries.GetRoleMasterList;
using LoanProcessManagement.Application.Features.PropertyDetails.Queries;
using LoanProcessManagement.Application.Features.PropertyType.Queries;
using LoanProcessManagement.Application.Features.SanctionedPlanReceived.Queries;
using LoanProcessManagement.Application.Features.ProductsList.Queries;
using LoanProcessManagement.Application.Features.LeadList.Queries;
using LoanProcessManagement.Application.Features.LeadStatus.Queries;
using LoanProcessManagement.Application.Features.Product.Queries;
using LoanProcessManagement.Application.Features.Menu.Commands.CreateCommands;
using LoanProcessManagement.Application.Features.GSTLeadList.Queries;
using LoanProcessManagement.Application.Features.LeadList.Query.LeadHistory;
using LoanProcessManagement.Application.Features.IncomeAssesment.Commands.GSTAddEnuiry;
using LoanProcessManagement.Application.Features.IncomeAssesment.Commands.GSTCreateEnquiry;
using LoanProcessManagement.Application.Features.Menu.Query.MenuList;
using LoanProcessManagement.Application.Features.Menu.Query.GetMenuByID;
using LoanProcessManagement.Application.Features.DSACorner.Query.DSACornerList;
using LoanProcessManagement.Application.Features.DSACorner.Query.TrainingVideosList;
using LoanProcessManagement.Application.Features.DSACorner.Query.CircularList;
using LoanProcessManagement.Application.Features.ApplicantDetails.Command;
using LoanProcessManagement.Application.Features.Menu.Query.GetAllMenuMaps.Query;
using LoanProcessManagement.Application.Features.Menu.Query.GetAllMenuMaps.GetAllMenuMaps;
using LoanProcessManagement.Application.Features.Menu.Commands.DeleteMenuMapById;
using LoanProcessManagement.Application.Features.ReportsLeadList.Queries;
using LoanProcessManagement.Application.Features.UnlockUserAccountAdmin.Queries.UnlockedAndLockedUsers;
using LoanProcessManagement.Application.Features.Menu.Query.GetAllMenus;
using LoanProcessManagement.Application.Features.UserList.Query.GetLockedUserList;
using LoanProcessManagement.Application.Features.LoanSchemes;
using LoanProcessManagement.Application.Features.LeadITRDetails.Command;
using LoanProcessManagement.Application.Features.CibilCheck.Commands.AddCibilCheckDetails;
using LoanProcessManagement.Application.Features.LeadList.Query.LeadStatus;
using LoanProcessManagement.Application.Features.LeadList.Query.LeadByLGID;
using LoanProcessManagement.Application.Features.LeadList.Query.LeadNameByLgId;
using LoanProcessManagement.Application.Features.Branch.GetBranchNameById;
using LoanProcessManagement.Application.Features.CreditITRDetails.Queries;
using LoanProcessManagement.Application.Features.CreditITRDetails.UserDetails.Queries;
using LoanProcessManagement.Application.Features.CreditCibilDetails.CreditCibilCheckDetails.Queries;
using LoanProcessManagement.Application.Features.CreditCibilDetails.UserDetails.Queries;
using LoanProcessManagement.Application.Features.CreditGstDetails.CreditGstCheckDetails.Queries;
using LoanProcessManagement.Application.Features.CreditGstDetails.UserDetails.Queries;
using LoanProcessManagement.Application.Features.IncomeAssesment.Commands.AddIncomeAssessment;
using LoanProcessManagement.Application.Features.Branch.Commands.CreateBranch;
using LoanProcessManagement.Application.Features.Branch.Commands.UpdateBranch;
using LoanProcessManagement.Application.Features.QueryType.Commands.CreateQuery;
using LoanProcessManagement.Application.Features.QueryType.Queries.GetQueryType;
using LoanProcessManagement.Application.Features.QueryType.Queries.GetQueryTypeById;
using LoanProcessManagement.Application.Features.LostLeadMaster.Queries.GetLostLeadMasterList;
using LoanProcessManagement.Application.Features.LostLeadMaster.Commands.CreateLostLeadReasonMaster;
using LoanProcessManagement.Application.Features.LostLeadMaster.Commands.UpdateLostLeadReasonMaster;
using LoanProcessManagement.Application.Features.RejectedLeadMaster.Queries.GetRejectedLeadMasterbyId;
using LoanProcessManagement.Application.Features.RejectedLeadMaster.Commands.CreateRejectedLeadReasonMaster;
using LoanProcessManagement.Application.Features.RejectedLeadMaster.Queries.GetRejectLeadMasterList;
using LoanProcessManagement.Application.Features.InstitutionMasters.Queries.GetInstitutionMasters;
using LoanProcessManagement.Application.Features.SchemeMaster.Queries.GetSchemeList;
using LoanProcessManagement.Application.Features.SchemeMaster.Queries.GetSchemeById;
using LoanProcessManagement.Application.Features.SchemeMaster.Commands.CreateScheme;

namespace LoanProcessManagement.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Event, CreateEventCommand>().ReverseMap();
            CreateMap<Event, UpdateEventCommand>().ReverseMap();
            CreateMap<Event, EventDetailVm>().ReverseMap();
            CreateMap<Event, CategoryEventDto>().ReverseMap();
            CreateMap<Event, EventExportDto>().ReverseMap();
            #region Mapping Created for Menu Master Services - Saif Khan - 28/10/2021
            ///28/10/2021-Mapping Created for Menu Master Services
            //Commented By Saif Khan
            ///entity Name = LpmMenuMaster
            ///Class Name = GetMenuMasterServicesVm
            CreateMap<LpmMenuMaster, GetMenuMasterServicesVm>().ReverseMap();
            #endregion
            CreateMap<LpmUserMaster, GetUserListQueryVm>().ReverseMap();
            CreateMap<LeadListModel, LeadListCommandDto>().ReverseMap();

            CreateMap<LpmMenuMaster, CreateMenuCommandDto>().ReverseMap();
            CreateMap<LpmMenuMaster, CreateMenuCommand>().ReverseMap();
            CreateMap<LpmMenuMaster, MenuListQuery>().ReverseMap();
            CreateMap<LpmMenuMaster, MenuListQueryVm>().ReverseMap();
            CreateMap<LpmMenuMaster, GetMenuByIdQueryVm>().ReverseMap();
            CreateMap<LpmMenuMaster, GetAllMenusQueryVm>().ReverseMap();
            CreateMap<LpmMenuMaster, GetAllMenusQuery>().ReverseMap();

            CreateMap<Category, CategoryDto>();
            CreateMap<Category, CategoryListVm>();
            CreateMap<Category, CategoryEventListVm>();
            CreateMap<Category, CreateCategoryCommand>();
            CreateMap<Category, CreateCategoryDto>();

            CreateMap<Order, OrdersForMonthDto>();

            CreateMap<Event, EventListVm>().ConvertUsing<EventVmCustomMapper>();

            #region Changepassword mapping has created by-Ramya Guduru-28-10-2021
            CreateMap<ChangePasswordModel, ChangePasswordDto>().ReverseMap();
            #endregion

            CreateMap<ChangePasswordModel, ChangePasswordDto>().ReverseMap();
            CreateMap<CreateUserCommand, LpmUserMaster>().ReverseMap();
            CreateMap<LpmUserRoleMaster, GetAllRolesDto>().ReverseMap();
            CreateMap<LpmBranchMaster, GetAllBranchesDto>().ReverseMap();
            CreateMap<LpmUserMaster, GetUserByLgIdDto>().ReverseMap();
            CreateMap<LpmLeadProcessCycle, LeadHistoryQueryVm>().ReverseMap();
            CreateMap<LpmLoanProductMaster, LeadHistoryQueryVm>().ReverseMap();
            CreateMap<LpmLeadStatusMaster, LeadHistoryQueryVm>().ReverseMap();
            CreateMap<LpmLeadMaster, LeadHistoryQueryVm>().ReverseMap();
            CreateMap<LpmLeadMaster, GetLeadStatusQueryVm>().ReverseMap();
            CreateMap<LpmLeadMaster, GetLeadStatusListQuery>().ReverseMap();
            CreateMap<LpmLeadMaster, GetLeadByLeadAssigneeIdQueryVm>().ReverseMap();
            CreateMap<LpmLeadMaster, GetLeadByLeadAssigneeIdQuery>().ReverseMap();
            CreateMap<LpmLeadMaster, GetLeadNameByLgIdQuery>().ReverseMap();
            CreateMap<LpmLeadMaster, GetLeadNameByLgIdQueryVm>().ReverseMap();

            CreateMap<LpmLeadProcessCycle, LeadHistoryQuery>().ReverseMap();
            CreateMap<LpmLoanProductMaster, LeadHistoryQuery>().ReverseMap();
            CreateMap<LpmLeadStatusMaster, LeadHistoryQuery>().ReverseMap();
            CreateMap<LpmLeadMaster, LeadHistoryQuery>().ReverseMap();
            CreateMap<LPMGSTEnquiryDetail, GstAddEnquiryCommandDto>().ReverseMap();
            CreateMap<LpmLeadApplicantsDetails, GstAddEnquiryCommandDto>().ReverseMap();
            #region GetAllLoanProducts mapping has created by - Pratiksha Poshe - 10/11/2021
            CreateMap<LpmLoanProductMaster, GetAllLoanProductsDto>().ReverseMap();
            #endregion
            #region GetAllLoanSchemes mapping has created by - Pratiksha Poshe - 10/11/2021
            CreateMap<LpmLoanSchemeMaster, GetAllLoanSchemeDto>().ReverseMap();
            #endregion
            #region AddApplicantDetails mapping has created by - Pratiksha Poshe - 19/11/2021
            CreateMap<AddApplicantDetailsCommand, LpmLeadApplicantsDetails>().ReverseMap();
            #endregion
            #region Add Lead mapping has created by - Pratiksha Poshe - 09/11/2021
            CreateMap<AddLeadCommand, LpmLeadMaster>().ReverseMap();
            #endregion
            #region GetLockedUserList mapping has created by - Pratiksha Poshe - 12/12/2021
            CreateMap<LpmUserMaster, GetLockedUserListQueryVm>().ReverseMap();
            CreateMap<UserMasterListModel, GetLockedUserListQueryVm>().ReverseMap();
            #endregion
            #region AddIncomeDetails mapping has created by - Pratiksha Poshe - 14/02/2022
            CreateMap<LpmLeadIncomeAssessmentDetails, AddIncomeAssessmentDetailsDto>().ReverseMap();
            CreateMap<IncomeAssessmentDetailsModel, AddIncomeAssessmentDetailsDto>().ReverseMap();
            #endregion

            CreateMap<LPMGSTEnquiryDetail, GstCreateEnquiryCommand>().ReverseMap();
            CreateMap<LpmLeadApplicantsDetails, GstCreateEnquiryCommand>().ReverseMap();
            CreateMap<LPMGSTEnquiryDetail, GstCreateEnquiryCommandDto>().ReverseMap();
            CreateMap<LpmLeadApplicantsDetails, GstCreateEnquiryCommandDto>().ReverseMap();

            #region forgotpassword mapping has created by - Ramya Guduru -01/11/2021
            CreateMap<ForgotPasswordModel, ForgotPasswordDto>().ReverseMap();
            #endregion

            CreateMap<UserMasterListModel, GetUserListQueryVm>().ReverseMap();
            CreateMap<LpmUserRoleMenuMap, GetAllMenuMapsQueryVm>().ReverseMap();
            CreateMap<LpmUserRoleMenuMap, GetAllMenuMapsQuery>().ReverseMap();
            CreateMap<LpmUserRoleMenuMap, GetTheMenuMapsCommand>().ReverseMap();
            CreateMap<LpmUserRoleMenuMap, GetTheMenuMapsCommandDto>().ReverseMap();
            CreateMap<LpmUserRoleMenuMap, DeleteMenuMapByIdCommandDto>().ReverseMap();
            CreateMap<LpmBranchMaster, GetBranchNameByIdQueryVm>().ReverseMap();


            #region UnlockUserAccount mapping has created by-Ramya Guduru-29-10-2021
            CreateMap<UnlockUserAccountModel, UnlockUserAccountDto>().ReverseMap();
            #endregion
            #region ActivateUserAccount mapping has created by-Ramya Guduru-29-10-2021
            CreateMap<UnlockUserAccountModel, ActivateUserAccountDto>().ReverseMap();
            #endregion
            #region UnlockUserAccountAndResetPassword mapping has created by-Ramya Guduru-29-10-2021
            CreateMap<UnlockUserAccountModel, UnlockAndResetPasswordDto>().ReverseMap();
            #endregion

            #region added role master CRUD operations mapping - by Ramya Guduru - 15/11/2021
            CreateMap<LpmUserRoleMaster, CreateRoleMasterCommandDto>();
            CreateMap<LpmUserRoleMaster, UpdateRoleMasterDto>();
            CreateMap<LpmUserRoleMaster, DeleteRoleMasterCommand>();
            CreateMap<LpmUserRoleMaster, RoleMasterListVm>().ReverseMap();
            #endregion

            #region added mapping to get property type, sanctionedPlan ID - Ramya Guduru -15/11/2021
            CreateMap<LpmLeadMaster, GetPropertyDetailsDto>().ReverseMap();
            CreateMap<LpmLoanPropertyType, GetAllpropertyTypeDto>().ReverseMap();
            CreateMap<LpmLoanSanctionedPlan, GetSanctionedPlanDto>().ReverseMap();
            #endregion

            #region added mapping to get product values - Ramya Guduru -15/11/2021
            CreateMap<ProductsListModel, GetProductsListQueryVm>().ReverseMap();
            #endregion

            #region added mapping to get GST lead list  - Ramya Guduru -16/11/2021
            CreateMap<GSTLeadListModel, GetGSTLeadListQueryVm>().ReverseMap();
            #endregion

            CreateMap<LpmLeadStatusMaster, GetLeadStatusDto>().ReverseMap();
            CreateMap<LpmLoanProductMaster, GetLoanProductsDto>().ReverseMap();
            CreateMap<LpmLoanProductMaster, GetInsuranceProductsDto>().ReverseMap();
            CreateMap<ReportsLeadListModel, GetReportsLeadListQueryVm>().ReverseMap();

            #region added mappers to get all dsa corener list, training videos list and circular list - Ramya Guduru - 25-11-2021
            CreateMap<LpmMenuMaster, DSACornerListVm>().ReverseMap();
            CreateMap<LpmMenuMaster, TrainingVideosListVm>().ReverseMap();
            CreateMap<LpmMenuMaster, CircularListVm>().ReverseMap();
            #endregion

            #region added mapper to get All users from database - Ramya Guduru - 06/12/2021
            CreateMap<LpmUserMaster, GetAllUsersQueryVm>().ReverseMap();
            #endregion   



            CreateMap<LeadITRDetailsCommand, LpmLeadITRDetails>().ReverseMap();
            CreateMap<AddCibilDetailsCommand, CibilCheckDetailsModel>().ReverseMap();
            CreateMap<CibilCheckDetailsModel, AddCibilDetailsDto>().ReverseMap();

            CreateMap<CreditITRDetailsListModel, GetCreditITRDetailsListVm>().ReverseMap();
            CreateMap<CreditITRDetailsListModel, GetCreditITRUserDetailsVm>().ReverseMap();
            CreateMap<CreditITRDetailsListModel, GetCreditCibilDetailsVm>().ReverseMap();
            CreateMap<CreditITRDetailsListModel, GetCreditCibilUserDetailsVm>().ReverseMap();
            CreateMap<CreditITRDetailsListModel, GetCreditGstDetailsVm>().ReverseMap();

            CreateMap<CreditITRDetailsListModel, GetCreditGstUserDetailsVm>().ReverseMap();

            CreateMap<LpmLostLeadReasonMaster, LostLeadMasterListVm>().ReverseMap();
            CreateMap<LpmLostLeadReasonMaster, CreateLostLeadReasonMasterCommandDto>().ReverseMap();
            CreateMap<LpmLostLeadReasonMaster, UpdateLostLeadReasonMasterDto>().ReverseMap();
            CreateMap<LpmRejectedLeadReasonMaster, RejectLeadMasterListVm>().ReverseMap();
            CreateMap<LpmRejectedLeadReasonMaster, CreateRejectedLeadReasonMasterCommandDto>().ReverseMap();
            CreateMap<LpmLostLeadReasonMaster, GetRejectedLeadReasonMasterByIdDto>().ReverseMap();

            
            CreateMap<CreateBranchCommand, LpmBranchMaster>().ReverseMap();
            CreateMap<UpdateBranchCommand, LpmBranchMaster>().ReverseMap();
            CreateMap<CreateQueryCommand, LpmQueryTypeMaster>().ReverseMap();

            CreateMap<GetAllQueryTypeQueryDto, LpmQueryTypeMaster>().ReverseMap();
            CreateMap<LpmQueryTypeMaster, GetQueryTypeByIdQueryDto>().ReverseMap();
            CreateMap<LpmLeadInstitutionMaster, GetInstitutionMastersQueryDto>().ReverseMap();

            CreateMap<GetAllSchemeDto, LpmLoanSchemeMaster>().ReverseMap();
            CreateMap<LpmLoanSchemeMaster, GetSchemeByIdDto>().ReverseMap();
            CreateMap<CreateSchemeCommand, LpmLoanSchemeMaster>().ReverseMap();


















        }
    }
}
