using AutoMapper;
using LoanProcessManagement.Application.Features.Categories.Commands.CreateCateogry;
using LoanProcessManagement.Application.Features.Categories.Queries.GetCategoriesList;
using LoanProcessManagement.Application.Features.Categories.Queries.GetCategoriesListWithEvents;
using LoanProcessManagement.Application.Features.Events.Commands.CreateEvent;
using LoanProcessManagement.Application.Features.Events.Commands.UpdateEvent;
using LoanProcessManagement.Application.Features.Events.Queries.GetEventDetail;
using LoanProcessManagement.Application.Features.Events.Queries.GetEventsExport;
using LoanProcessManagement.Application.Features.Events.Queries.GetEventsList;
using LoanProcessManagement.Application.Features.Orders.Queries.GetOrdersForMonth;
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

            CreateMap<Category, CategoryDto>();
            CreateMap<Category, CategoryListVm>();
            CreateMap<Category, CategoryEventListVm>();
            CreateMap<Category, CreateCategoryCommand>();
            CreateMap<Category, CreateCategoryDto>();

            CreateMap<Order, OrdersForMonthDto>();

            CreateMap<Event, EventListVm>().ConvertUsing<EventVmCustomMapper>();
        }
    }
}
