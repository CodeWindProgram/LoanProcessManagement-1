using LoanProcessManagement.Application.Features.CreditCibilDetails.CreditCibilCheckDetails.Queries;
using LoanProcessManagement.Application.Features.CreditCibilDetails.UserDetails.Queries;
using LoanProcessManagement.Application.Features.CreditGstDetails.CreditGstCheckDetails.Queries;
using LoanProcessManagement.Application.Features.CreditGstDetails.UserDetails.Queries;
using LoanProcessManagement.Application.Features.CreditITRDetails.UserDetails.Queries;
using LoanProcessManagement.Domain.CustomModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LoanProcessManagement.Application.Contracts.Persistence
{
    #region added methods to get cibil, ITR and GST details - Ramya Guduru - 15/02/2022
    public interface ICreditDetailsRepository : IAsyncRepository<IEnumerable<CreditITRDetailsListModel>>
    {
        Task<IEnumerable<CreditITRDetailsListModel>> GetCreditITRDetailsList();
        Task<IEnumerable<GetCreditITRUserDetailsVm>> GetCreditITRUserDetailsList(string FormNo);


        Task<IEnumerable<GetCreditCibilDetailsVm>> GetCreditCibilDetailsList();
        Task<IEnumerable<GetCreditCibilUserDetailsVm>> GetCreditCibilUserDetailsList(string FormNo);


        Task<IEnumerable<GetCreditGstDetailsVm>> GetCreditGstDetailsList();
        Task<IEnumerable<GetCreditGstUserDetailsVm>> GetCreditGstUserDetailsList(string FormNo);
    }
    #endregion
}
