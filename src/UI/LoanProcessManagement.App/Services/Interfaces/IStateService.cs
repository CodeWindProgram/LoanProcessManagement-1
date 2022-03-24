using LoanProcessManagement.Application.Features.State.Commands.CreateState;
using LoanProcessManagement.Application.Features.State.Commands.DeleteState;
using LoanProcessManagement.Application.Features.State.Commands.UpdateState;
using LoanProcessManagement.Application.Features.State.Queries.GetStateById;
using LoanProcessManagement.Application.Features.State.Queries.GetStateList;
using LoanProcessManagement.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoanProcessManagement.App.Services.Interfaces
{
    public interface IStateService
    {
        #region  added service to call state api added by - Dipti Pandhram - 23/03/2022
        Task<Response<CreateStateDto>> AddState(CreateStateCommand req);
        Task<Response<DeleteStateDto>> DeleteState(long id);
        Task<Response<GetStateByIdDto>> GetStateById(long id);
        Task<Response<UpdateStateDto>> UpdateState(UpdateStateCommand req);
        Task<Response<IEnumerable<GetStateListDto>>> GetAllState();
       

        #endregion
    }
}
