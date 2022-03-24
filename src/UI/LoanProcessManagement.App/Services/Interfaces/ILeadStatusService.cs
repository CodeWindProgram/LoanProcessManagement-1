using LoanProcessManagement.Application.Features.LeadStatus.Commands.CreateLeadStatus;
using LoanProcessManagement.Application.Features.LeadStatus.Commands.DeleteLeadStatus;
using LoanProcessManagement.Application.Features.LeadStatus.Commands.UpdateLeadStatus;
using LoanProcessManagement.Application.Features.LeadStatus.Queries.GetLeadStatusList;
using LoanProcessManagement.Application.Features.LeadStatus.Queries.GetLeadStautsById;
using LoanProcessManagement.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoanProcessManagement.App.Services.Interfaces
{
    public interface ILeadStatusService
    {
        #region  added service to call Lead status api added by - Dipti Pandhram - 23/03/2022
  
        Task<Response<LeadStatusDto>> AddLeadSt(CreateLeadStatusCommand req);
        Task<Response<DeleteLeadStatusDto>> DeleteLeadSt(long id);
        Task<Response<GetLeadStatusByIdQueryVm>> GetLeadStatusById(long id);
        Task<Response<UpdateLeadStatusDto>> UpdateLeadStatus(UpdateLeadStatusCommand req);
        Task<Response<IEnumerable<GetAllLeadStatusQueryDto>>> GetAllLeadStatus();
        #endregion

    }
}
