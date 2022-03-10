using LoanProcessManagement.Application.Features.InstitutionMasters.Queries.GetInstitutionMasters;
using LoanProcessManagement.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoanProcessManagement.App.Services.Interfaces
{
    public interface IInstitutionServices
    {
        Task<Response<IEnumerable<GetInstitutionMastersQueryDto>>> GetAllInstitutions();
    }
}
