using LoanProcessManagement.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoanProcessManagement.Application.Features.LostLeadMaster.Commands.DeleteLostLeadReasonMaster
{
    public class DeleteLostLeadReasonMasterCommand : IRequest<Response<DeleteLostLeadReasonMasterDto>>
    {
        public long LostLeadReasonId { get; set; }
    }
}
