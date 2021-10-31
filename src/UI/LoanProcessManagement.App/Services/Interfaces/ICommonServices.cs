using LoanProcessManagement.Application.Features.Branch.Queries;
using LoanProcessManagement.Application.Features.Roles.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoanProcessManagement.App.Services.Interfaces
{
    public interface ICommonServices
    {
        Task<IEnumerable<GetAllRolesDto>> GetAllRoles();
        Task<IEnumerable<GetAllBranchesDto>> GetAllBranches();


    }
}
