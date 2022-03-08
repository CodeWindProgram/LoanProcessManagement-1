using LoanProcessManagement.Application.Features.LostLeadMaster.Commands.UpdateLostLeadReasonMaster;
using LoanProcessManagement.Application.Features.LostLeadMaster.Queries.GetLostLeadMasterbyId;
using LoanProcessManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LoanProcessManagement.Application.Contracts.Persistence
{
    public interface ILostLeadReasonMasterRepository : IAsyncRepository<LpmLostLeadReasonMaster>
    {
        Task <UpdateLostLeadReasonMasterDto>UpdateLostLeadReasonMaster(long id, UpdateLostLeadReasonMasterCommand request);
        Task GetByLostLeadReason(string LostLead);
        Task<LpmLostLeadReasonMaster> GetLostLeadReasonMasterByIdAsync(long id);
    }
}
