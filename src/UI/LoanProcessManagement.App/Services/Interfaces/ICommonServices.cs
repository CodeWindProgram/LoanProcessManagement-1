using LoanProcessManagement.Application.Features.Branch.Queries;
using LoanProcessManagement.Application.Features.LeadStatus.Queries;
using LoanProcessManagement.Application.Features.Product.Queries;
using LoanProcessManagement.Application.Features.LoanProducts.Queries;
using LoanProcessManagement.Application.Features.Roles.Queries;
using LoanProcessManagement.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LoanProcessManagement.Application.Features.LoanSchemes;
using LoanProcessManagement.Application.Features.LoanSchemes.Queries;

namespace LoanProcessManagement.App.Services.Interfaces
{
    public interface ICommonServices
    {
        Task<IEnumerable<GetAllRolesDto>> GetAllRoles();
        Task<IEnumerable<GetAllBranchesDto>> GetAllBranches();
        Task<IEnumerable<GetAllLoanProductsDto>> GetAllLoanProducts();
        Task<Response<IEnumerable<GetLeadStatusDto>>> GetAllStatus(string role);
        Task<Response<GetLeadStatusCountDto>> GetAllStatusCount(GetLeadStatusCountQuery req);
        Task<Response<IEnumerable<GetLoanProductsDto>>> GetAllLoanProduct();
        Task<Response<IEnumerable<GetInsuranceProductsDto>>> GetAllInsuranceProducts();
        Task<Response<IEnumerable<GetAllLoanSchemeDto>>> GetAllLoanScheme();
        Task<Response<IEnumerable<GetLoanSchemesByProductIdDto>>> GetAllLoanSchemeByProductId(long Product_Id);
    }
}
