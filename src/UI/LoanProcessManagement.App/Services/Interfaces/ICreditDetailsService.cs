using LoanProcessManagement.Application.Features.CreditCibilDetails.CreditCibilCheckDetails.Queries;
using LoanProcessManagement.Application.Features.CreditCibilDetails.UserDetails.Queries;
using LoanProcessManagement.Application.Features.CreditGstDetails.CreditGstCheckDetails.Queries;
using LoanProcessManagement.Application.Features.CreditGstDetails.UserDetails.Queries;
using LoanProcessManagement.Application.Features.CreditIncomeDetails.Queries;
using LoanProcessManagement.Application.Features.CreditIncomeDetails.UserDetails.Queries;
using LoanProcessManagement.Application.Features.CreditITRDetails.Queries;
using LoanProcessManagement.Application.Features.CreditITRDetails.UserDetails.Queries;
using LoanProcessManagement.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoanProcessManagement.App.Services.Interfaces
{
    #region added service class to get  Cibil, ITR and GST enquiry and user credit details   - Ramya Guduru - 15/02/2022
    public interface ICreditDetailsService
    {
        Task<Response<IEnumerable<GetCreditITRDetailsListVm>>> CreditITRDetailsList();
        Task<Response<IEnumerable<GetCreditITRUserDetailsVm>>> userDetailsByFormNo(string FormNo);
        Task<Response<IEnumerable<GetCreditCibilDetailsVm>>> CreditCibilDetailsList();
        Task<Response<IEnumerable<GetCreditCibilUserDetailsVm>>> userCibilDetailsByFormNo(string FormNo);

        Task<Response<IEnumerable<GetCreditGstDetailsVm>>> CreditGstDetailsList();
        Task<Response<IEnumerable<GetCreditGstUserDetailsVm>>> userGstDetailsByFormNo(string FormNo);
        Task<Response<IEnumerable<GetIncomeDetailsVm>>> IncomeDetailsList();
        Task<Response<IEnumerable<GetIncomeUserDetailsVm>>> userIncomeDetailsByFormNo(string FormNo);
    }
    #endregion
}
