using System;
using System.Collections.Generic;
using System.Text;

namespace LoanProcessManagement.Application.Features.ThirdPartyCheckDetails.Command
{
    public class AddThirdPartyCheckDetailsDto
    {
        public long lead_Id { get; set; }
        public string Message { get; set; }
        public bool Succeeded { get; set; }
    }
}
