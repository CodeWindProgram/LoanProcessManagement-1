using LoanProcessManagement.Application.Features.UnlockUserAccountAdmin.Commands.ActivateUserAccountToggleSwitch;
using LoanProcessManagement.Application.Features.UnlockUserAccountAdmin.Commands.UnlockUserAccountToggleSwitch;
using LoanProcessManagement.Domain.CustomModels;
using LoanProcessManagement.Domain.Entities;
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

        Task<UnlockUserAccountToggleSwitchDto> UpdateUnlockStatus(string EmployeeID, bool IsLocked);

        Task<ActivateUserAccountToggleSwitchDto> UpdateActivatedStatus(string EmployeeID, bool IsActive);
    }
    #endregion
}
