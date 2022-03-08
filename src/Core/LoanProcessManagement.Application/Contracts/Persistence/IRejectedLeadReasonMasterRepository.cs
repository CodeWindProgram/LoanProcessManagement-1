using LoanProcessManagement.Application.Features.RejectedLeadMaster.Commands.UpdateRejectLeadReasonMaster;
using LoanProcessManagement.Application.Features.RejectedLeadMaster.Queries.GetRejectedLeadMasterbyId;
using LoanProcessManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LoanProcessManagement.Application.Contracts.Persistence
{
    public interface IRejectedLeadReasonMasterRepository : IAsyncRepository<LpmRejectedLeadReasonMaster>
    {
        Task<UpdateRejectLeadReasonMasterDto> UpdateRejectLeadReasonMaster(long id, UpdateRejectLeadReasonMasterCommand request);
        Task GetByRejectLeadReason(string LostLead);

        Task <LpmRejectedLeadReasonMaster> GetRejectedLeadReasonMasterByIdAsync(long id);
    }
}
