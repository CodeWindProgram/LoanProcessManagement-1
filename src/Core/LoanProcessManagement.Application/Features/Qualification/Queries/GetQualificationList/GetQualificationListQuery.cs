using LoanProcessManagement.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoanProcessManagement.Application.Features.Qualification.Queries.GetQualificationList
{
   public  class GetQualificationListQuery : IRequest<Response<IEnumerable<GetQualificationListDto>>>
    {
    }
}
