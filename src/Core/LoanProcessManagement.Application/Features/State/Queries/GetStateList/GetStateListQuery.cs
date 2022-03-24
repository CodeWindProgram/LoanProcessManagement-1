using LoanProcessManagement.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoanProcessManagement.Application.Features.State.Queries.GetStateList
{
   public  class GetStateListQuery : IRequest<Response<IEnumerable<GetStateListDto>>>
    {
    }
}
