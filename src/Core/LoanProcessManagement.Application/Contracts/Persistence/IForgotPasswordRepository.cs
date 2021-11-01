using LoanProcessManagement.Domain.CustomModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LoanProcessManagement.Application.Contracts.Persistence
{
    #region IForgotPasswordRepository By - Ramya Guduru - on - 01/11/2021
    /// <summary>
    /// 01/11/2021-IForgotPasswordRepository
    /// Commented by Ramya Guduru
    /// </summary>
    /// It Inherited from IAsynchronous Repository 
    public interface IForgotPasswordRepository : IAsyncRepository<ForgotPasswordModel>
    {
        Task<ForgotPasswordModel> ForgotPasswordWithEvents(ForgotPasswordModel forgotPassword);
    }
    #endregion
}
