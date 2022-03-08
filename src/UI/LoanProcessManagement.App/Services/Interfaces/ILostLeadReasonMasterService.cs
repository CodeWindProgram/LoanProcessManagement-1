using LoanProcessManagement.Application.Features.LostLeadMaster.Commands.CreateLostLeadReasonMaster;
using LoanProcessManagement.Application.Features.LostLeadMaster.Commands.DeleteLostLeadReasonMaster;
using LoanProcessManagement.Application.Features.LostLeadMaster.Commands.UpdateLostLeadReasonMaster;
using LoanProcessManagement.Application.Features.LostLeadMaster.Queries.GetLostLeadMasterbyId;
using LoanProcessManagement.Application.Features.LostLeadMaster.Queries.GetLostLeadMasterList;
using LoanProcessManagement.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoanProcessManagement.App.Services.Interfaces
{
    public interface ILostLeadReasonMasterService
    {
        public Task<Response<UpdateLostLeadReasonMasterDto>> UpdateLostLeadReasonMaster(UpdateLostLeadReasonMasterCommand lpmLostLeadReasonMaster);
        public Task<Response<IEnumerable<LostLeadMasterListVm>>> GetByLostLeadReason();

        public GetLostLeadReasonMasterByIdDto GetLostLeadReasonMasterByIdAsync(long id);

        public Task<Response<DeleteLostLeadReasonMasterDto>> DeleteLostLeadReasonMaster(long Id);
        public Task<Response<CreateLostLeadReasonMasterCommandDto>> CreateLostLeadReasonMaster(CreateLostLeadReasonMasterCommand createLostLeadReasonMasterCommand);


    }
}
