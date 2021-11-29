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

            CreateMap<LpmLeadProcessCycle, LeadHistoryQuery>().ReverseMap();
            CreateMap<LpmLoanProductMaster, LeadHistoryQuery>().ReverseMap();
            CreateMap<LpmLeadStatusMaster, LeadHistoryQuery>().ReverseMap();
            CreateMap<LpmLeadMaster, LeadHistoryQuery>().ReverseMap();
            CreateMap<LPMGSTEnquiryDetail, GstAddEnquiryCommandDto>().ReverseMap();

            CreateMap<LPMGSTEnquiryDetail, GstCreateEnquiryCommand>().ReverseMap();
            CreateMap<LPMGSTEnquiryDetail, GstCreateEnquiryCommandDto>().ReverseMap();

            #region forgotpassword mapping has created by - Ramya Guduru -01/11/2021
            CreateMap<ForgotPasswordModel, ForgotPasswordDto>().ReverseMap();
            #endregion

            CreateMap<UserMasterListModel, GetUserListQueryVm>().ReverseMap();


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

            #region added mappers to get all dsa corener list, training videos list and circular list - Ramya Guduru - 25-11-2021
            CreateMap<LpmMenuMaster, DSACornerListVm>().ReverseMap();
            CreateMap<LpmMenuMaster, TrainingVideosListVm>().ReverseMap();
            CreateMap<LpmMenuMaster, CircularListVm>().ReverseMap();
            #endregion
        }
    }
}
