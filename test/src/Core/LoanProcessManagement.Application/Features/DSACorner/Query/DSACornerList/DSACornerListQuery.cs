using LoanProcessManagement.Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoanProcessManagement.Application.Features.DSACorner.Query.DSACornerList
{
    public class DSACornerListQuery : IRequest<Response<IEnumerable<DSACornerListVm>>>
    {
        
        public long ParentId { get; set; }
    }
}
