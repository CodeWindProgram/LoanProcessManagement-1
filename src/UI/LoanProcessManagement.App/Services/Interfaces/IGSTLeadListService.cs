using LoanProcessManagement.Application.Features.GSTLeadList.Queries;
using LoanProcessManagement.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoanProcessManagement.App.Services.Interfaces
{
    public interface IGSTLeadListService
    {
        Task<Response<IEnumerable<GetGSTLeadListQueryVm>>> GSTLeadListingProcess(long BranchID);
    }
}
