using LoanProcessManagement.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoanProcessManagement.Application.Features.SchemeMaster.Commands.DeleteScheme
{
    public class DeleteSchemeCommand : IRequest<Response<DeleteSchemeDto>>
    {
        public long Id { get; set; }
        public DeleteSchemeCommand(long id)
        {
            this.Id = id;
        }
    }
}
