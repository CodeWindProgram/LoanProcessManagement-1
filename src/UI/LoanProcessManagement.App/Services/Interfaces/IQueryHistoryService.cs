using LoanProcessManagement.App.Models;
using LoanProcessManagement.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoanProcessManagement.App.Services.Interfaces
{
    public interface IQueryHistoryService
    {
        Task<Response<IEnumerable<QueryHistoryCommandVM>>> GetQueryHistoryByLeadId(string lead_Id);
    }
}
