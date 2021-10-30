using AutoMapper;
using LoanProcessManagement.Application.Features.Categories.Commands.CreateCateogry;
using LoanProcessManagement.Application.Features.Categories.Queries.GetCategoriesList;
using LoanProcessManagement.Application.Features.Categories.Queries.GetCategoriesListWithEvents;
using LoanProcessManagement.Application.Features.ChangePassword.Commands.ChangePassword;
using LoanProcessManagement.Application.Features.Events.Commands.CreateEvent;
using LoanProcessManagement.Application.Features.Events.Commands.UpdateEvent;
using LoanProcessManagement.Application.Features.Events.Queries.GetEventDetail;
using LoanProcessManagement.Application.Features.Events.Queries.GetEventsExport;
using LoanProcessManagement.Application.Features.Events.Queries.GetEventsList;
using LoanProcessManagement.Application.Features.Menu.Query;
using LoanProcessManagement.Application.Features.Orders.Queries.GetOrdersForMonth;
using LoanProcessManagement.Application.Features.UserList.Query;
using LoanProcessManagement.Domain.CustomModels;
using LoanProcessManagement.Domain.Entities;

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


            CreateMap<ChangePasswordModel, ChangePasswordDto>().ReverseMap();


        }
    }
}
