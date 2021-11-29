using LoanProcessManagement.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoanProcessManagement.Application.Features.DSACorner.Query.TrainingVideosList
{
    public class TrainingVideosListQuery : IRequest<Response<IEnumerable<TrainingVideosListVm>>>
    {
        public long ParentId { get; set; }
    }
}
