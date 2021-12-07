using LoanProcessManagement.Application.Features.QueryHistory.Queries;
using LoanProcessManagement.Application.Responses;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LoanProcessManagement.Application.Contracts.Persistence
{
    public interface IQueryHistoryRepository
    {
        Task<IEnumerable<GetQueryHistoryDto>> GetQueryHistoryByLeadId(string lead_id);
    }
}
