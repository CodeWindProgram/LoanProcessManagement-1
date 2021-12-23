using LoanProcessManagement.Application.Features.Agency.Queries.GetAllAgency;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LoanProcessManagement.Application.Contracts.Persistence
{
    public interface IAgencyRepository
    {
        Task<GetAllAgencyDto> GetAllAgency();
    }
}
