using LoanProcessManagement.Application.Features.LeadStatus.Commands.DeleteLeadStatus;
using LoanProcessManagement.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoanProcessManagement.Application.Features.LeadStatusMaster.Commands.DeleteLeadStatus
{
    public class DeleteLeadStatusCommand : IRequest<Response<DeleteLeadStatusDto>>
    {
        public long Id { get; set; }
        public DeleteLeadStatusCommand(long id)
        {
            this.Id = id;
        }
    }
}
