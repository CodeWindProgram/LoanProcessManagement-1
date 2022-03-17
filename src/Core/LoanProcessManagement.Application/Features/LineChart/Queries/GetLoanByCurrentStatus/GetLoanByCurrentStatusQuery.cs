using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoanProcessManagement.Application.Features.LineChart.Queries.GetLoanByCurrentStatus
{
    public class GetLoanByCurrentStatusQuery : IRequest<List<long?>>
    {
        public GetLoanByCurrentStatusQuery(long currentstatus)
        {
            CurrentStatus = currentstatus;
        }

        public long CurrentStatus { get; set; }
    }
}