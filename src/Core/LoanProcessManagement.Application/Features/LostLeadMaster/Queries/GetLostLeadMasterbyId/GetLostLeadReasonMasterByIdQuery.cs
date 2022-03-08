using LoanProcessManagement.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoanProcessManagement.Application.Features.LostLeadMaster.Queries.GetLostLeadMasterbyId
{
    public class GetLostLeadReasonMasterByIdQuery : IRequest<GetLostLeadReasonMasterByIdDto>
    {
        public long id { get; set; }


    }
}
