using LoanProcessManagement.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoanProcessManagement.Application.Features.Menu.Commands.DeleteMenuMapById
{
    public class DeleteMenuMapByIdCommand:IRequest<Response<DeleteMenuMapByIdCommandDto>>
    {
        public long Id { get; set; }
    }
}
