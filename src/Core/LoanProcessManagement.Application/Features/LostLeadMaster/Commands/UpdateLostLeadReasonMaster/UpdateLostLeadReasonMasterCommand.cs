using LoanProcessManagement.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoanProcessManagement.Application.Features.LostLeadMaster.Commands.UpdateLostLeadReasonMaster
{
   public class UpdateLostLeadReasonMasterCommand : IRequest<Response<UpdateLostLeadReasonMasterDto>>
    {
        public long LostLeadReasonId { get; set; }
        public string LostLeadReason { get; set; }
        public bool IsActive { get; set; }
    }
}
