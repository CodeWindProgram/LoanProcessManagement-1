using LoanProcessManagement.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LoanProcessManagement.Application.Features.RejectedLeadMaster.Commands.CreateRejectedLeadReasonMaster
{
    public class CreateRejectedLeadReasonMasterCommand : IRequest<Response<CreateRejectedLeadReasonMasterCommandDto>>
    {
        public string RejectLeadReason { get; set; }
    }
}
