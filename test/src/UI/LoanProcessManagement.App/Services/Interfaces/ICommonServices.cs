using LoanProcessManagement.Application.Features.Branch.Queries;
using LoanProcessManagement.Application.Features.LeadStatus.Queries;
using LoanProcessManagement.Application.Features.Product.Queries;
using LoanProcessManagement.Application.Features.Roles.Queries;
using LoanProcessManagement.Application.Responses;
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
        Task<Response<IEnumerable<GetLeadStatusDto>>> GetAllStatus(string role);
        Task<Response<IEnumerable<GetLoanProductsDto>>> GetAllLoanProduct();
        Task<Response<IEnumerable<GetInsuranceProductsDto>>> GetAllInsuranceProducts();



    }
}
