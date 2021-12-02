using LoanProcessManagement.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoanProcessManagement.Application.Features.ReportsLeadList.ReportsQueries
{

    #region added ReportsListQuery - Ramya Guduru - 02/12/2021
    public class ReportsListQuery : IRequest<Response<IEnumerable<ReportsListVm>>>
    {
        public long ParentId { get; set; }
    }
    #endregion
}
