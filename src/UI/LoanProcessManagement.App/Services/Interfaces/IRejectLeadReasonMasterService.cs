using LoanProcessManagement.Application.Features.RejectedLeadMaster.Commands.CreateRejectedLeadReasonMaster;
using LoanProcessManagement.Application.Features.RejectedLeadMaster.Commands.DeleteRejectLeadReasonMaster;
using LoanProcessManagement.Application.Features.RejectedLeadMaster.Commands.UpdateRejectLeadReasonMaster;
using LoanProcessManagement.Application.Features.RejectedLeadMaster.Queries.GetRejectedLeadMasterbyId;
using LoanProcessManagement.Application.Features.RejectedLeadMaster.Queries.GetRejectLeadMasterList;
using LoanProcessManagement.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoanProcessManagement.App.Services.Interfaces
{
    public interface IRejectLeadReasonMasterService
    {
        public Task<Response<IEnumerable<RejectLeadMasterListVm>>> GetByRejectLeadReason();
        public Task<Response<UpdateRejectLeadReasonMasterDto>> UpdateRejectLeadReasonMaster(UpdateRejectLeadReasonMasterCommand lpmRejectLeadReasonMaster);

        public GetRejectedLeadReasonMasterByIdDto GetRejectLeadReasonMasterByIdAsync(long id);

        public Task<Response<DeleteRejectLeadReasonMasterDto>> DeleteRejectLeadReasonMaster(long Id);
        public Task<Response<CreateRejectedLeadReasonMasterCommandDto>> CreateRejectLeadReasonMaster(CreateRejectedLeadReasonMasterCommand createRejectLeadReasonMasterCommand);


    }
}
