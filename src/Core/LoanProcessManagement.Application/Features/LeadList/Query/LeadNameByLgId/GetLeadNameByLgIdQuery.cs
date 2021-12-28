using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoanProcessManagement.Application.Features.LeadList.Query.LeadNameByLgId
{
    public class GetLeadNameByLgIdQuery : IRequest<IEnumerable<GetLeadNameByLgIdQueryVm>>
    {
        public GetLeadNameByLgIdQuery(string lgId)
        {
            LgId = lgId;
        }

        public string LgId { get; set; }
    }
}
