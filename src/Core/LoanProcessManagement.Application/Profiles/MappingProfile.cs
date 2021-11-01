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
using LoanProcessManagement.Application.Features.User.Queries;

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
        }
    }
}
