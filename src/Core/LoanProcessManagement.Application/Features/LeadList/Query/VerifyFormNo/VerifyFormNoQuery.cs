using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoanProcessManagement.Application.Features.LeadList.Query.VerifyFormNo
{
    public class VerifyFormNoQuery : IRequest<bool>
    {
        public string FormNo { get; set; }
    }
}
