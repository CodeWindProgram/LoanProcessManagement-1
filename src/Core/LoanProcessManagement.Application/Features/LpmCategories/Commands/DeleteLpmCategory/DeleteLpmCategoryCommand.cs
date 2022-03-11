using LoanProcessManagement.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoanProcessManagement.Application.Features.LpmCategories.Commands.DeleteLpmCategory
{
    public class DeleteLpmCategoryCommand : IRequest<Response<DeleteLpmCategoryCommandDto>>
    {
        public long Id { get; set; }
        public DeleteLpmCategoryCommand(long id)
        {
            this.Id = id;
        }
    }
}
