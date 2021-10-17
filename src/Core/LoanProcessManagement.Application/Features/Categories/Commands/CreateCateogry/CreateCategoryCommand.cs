using LoanProcessManagement.Application.Responses;
using MediatR;

namespace LoanProcessManagement.Application.Features.Categories.Commands.CreateCateogry
{
    public class CreateCategoryCommand : IRequest<Response<CreateCategoryDto>>
    {
        public string Name { get; set; }
    }
}
