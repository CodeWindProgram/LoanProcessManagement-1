using System;
using System.Collections.Generic;
using System.Text;

namespace LoanProcessManagement.Application.Features.LostLeadMaster.Commands.CreateLostLeadReasonMaster
{
    public class CreateLostLeadReasonMasterCommandResponse
    {
        public CreateLostLeadReasonMasterCommandResponse()
        {

        }

        public CreateLostLeadReasonMasterCommandDto reasonMaster { get; set; }
    }
}
