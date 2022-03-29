using LoanProcessManagement.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoanProcessManagement.Application.Features.Agency.Commands.DeleteAgency
{
    public class DeleteAgencyCommand : IRequest<Response<DeleteAgencyDto>>
    {
        public long Id { get; set; }
        public DeleteAgencyCommand(long id)
        {
            this.Id = id;
        }
    }
}
