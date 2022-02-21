using System;
using System.Collections.Generic;
using System.Text;

namespace LoanProcessManagement.Application.Features.Menu.Commands.UpdateCommand.AlterMenuStatus
{
    public class AlterMenuStatusCommandDTO
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }

        public bool Status { get; set; }
    }
}
