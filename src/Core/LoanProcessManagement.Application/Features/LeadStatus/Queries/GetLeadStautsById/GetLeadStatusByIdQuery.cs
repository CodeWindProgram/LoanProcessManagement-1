using LoanProcessManagement.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoanProcessManagement.Application.Features.LeadStatus.Queries.GetLeadStautsById
{
   public  class GetLeadStatusByIdQuery : IRequest<Response<GetLeadStatusByIdQueryVm>>
    {
        public GetLeadStatusByIdQuery(long id)
        {
            Id = id;
        }

        public long Id { get; set; }
    }
}
