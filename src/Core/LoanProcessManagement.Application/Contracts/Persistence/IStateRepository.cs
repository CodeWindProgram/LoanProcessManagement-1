using LoanProcessManagement.Application.Features.State.Commands.CreateState;
using LoanProcessManagement.Application.Features.State.Commands.DeleteState;
using LoanProcessManagement.Application.Features.State.Commands.UpdateState;
using LoanProcessManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LoanProcessManagement.Application.Contracts.Persistence
{
    public interface IStateRepository
    {
        #region Methods Of State -Dipti Pandhram- 23/03/2022
        Task<IEnumerable<LpmState>> GetAllState();
        Task<CreateStateDto> CreateStateCommand(LpmState request);
        Task<DeleteStateDto> DeleteState(long id);
        Task<UpdateStateDto> UpdateState(LpmState req);

        Task<LpmState> GetStateById(long id); 
        #endregion
    }
}
