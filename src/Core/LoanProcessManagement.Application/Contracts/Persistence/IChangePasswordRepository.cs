using LoanProcessManagement.Domain.CustomModels;
using LoanProcessManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LoanProcessManagement.Application.Contracts.Persistence
{
    #region IChangePasswordRepository By - Ramya Guduru - on - 27/10/2021
    /// <summary>
    /// 27/10/2021-IChangePasswordRepository
    /// Commented by Ramya Guduru
    /// </summary>
    /// It Inherited from IAsynchronous Repository 

    public interface IChangePasswordRepository : IAsyncRepository<ChangePasswordModel>
    {
        Task<ChangePasswordModel> ChangePasswordWithEvents(ChangePasswordModel changePassword);
    }
    #endregion
}
