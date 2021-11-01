using LoanProcessManagement.Domain.CustomModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LoanProcessManagement.Application.Contracts.Persistence
{
    #region IUnlockUserAccountRepository By - Ramya Guduru - on - 29/10/2021
    /// <summary>
    /// 29/10/2021-IUnlockUserAccountRepository
    /// Commented by Ramya Guduru
    /// </summary>
    /// It Inherited Asynchronous Repository 
    public interface IUnlockUserAccountRepository : IAsyncRepository<UnlockUserAccountModel>
    {
        Task<UnlockUserAccountModel> UnlockUserAccountWithEvents(UnlockUserAccountModel unlockUserAccount);

        Task<UnlockUserAccountModel> UnlockAndResetPasswordWithEvents(UnlockUserAccountModel unlockUserAccount);

        Task<UnlockUserAccountModel> ActivateUserAccountWithEvents(UnlockUserAccountModel unlockUserAccount);
    }
    #endregion
}
