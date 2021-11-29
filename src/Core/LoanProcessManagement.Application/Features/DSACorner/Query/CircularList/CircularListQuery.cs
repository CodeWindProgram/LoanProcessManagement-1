using LoanProcessManagement.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoanProcessManagement.Application.Features.DSACorner.Query.CircularList
{
    public class CircularListQuery : IRequest<Response<IEnumerable<CircularListVm>>>
    {

        public long ParentId { get; set; }

    }
}
