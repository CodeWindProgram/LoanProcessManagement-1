using LoanProcessManagement.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoanProcessManagement.Application.Features.LpmCategories.Queries.GetLpmCategoryById
{
    public class GetLpmCategoryByIdCommand : IRequest<Response<GetLpmCategoryByIdCommandDto>>
    {
        public long Id { get; set; }
        public GetLpmCategoryByIdCommand(long id)
        {
            this.Id = id;
        }
    }
}
