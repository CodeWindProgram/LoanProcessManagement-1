using LoanProcessManagement.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoanProcessManagement.Application.Features.Menu.Commands.DeleteCommand
{
    public class DeleteMenuCommand : IRequest<Response<DeleteMenuCommandDto>>
    {
        public DeleteMenuCommand( long id)
        {
            Id = id;
        }
        public long Id { get; set; }
    }
}