using LoanProcessManagement.Domain.CustomModels;
using LoanProcessManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LoanProcessManagement.Application.Contracts.Persistence
{
    public interface IChangePasswordRepository : IAsyncRepository<ChangePasswordModel>
    {
        Task<ChangePasswordModel> ChangePasswordWithEvents(ChangePasswordModel changePassword);
    }
}
