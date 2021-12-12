using LoanProcessManagement.Application.Features.LoanSchemes.Queries;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LoanProcessManagement.Application.Contracts.Persistence
{
    public interface ILoanSchemesRepository
    {
        Task<IEnumerable<GetLoanSchemesByProductIdDto>> GetLoanSchemesByProductId(long Product_ID);
    }
}
