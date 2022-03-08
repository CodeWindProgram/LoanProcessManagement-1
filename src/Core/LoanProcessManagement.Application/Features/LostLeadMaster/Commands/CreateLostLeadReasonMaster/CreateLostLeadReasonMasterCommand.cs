using LoanProcessManagement.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoanProcessManagement.Application.Features.LostLeadMaster.Commands.CreateLostLeadReasonMaster
{
    public class CreateLostLeadReasonMasterCommand : IRequest<Response<CreateLostLeadReasonMasterCommandDto>>
    {
        public string LostLeadReason { get; set; }
    }
}
