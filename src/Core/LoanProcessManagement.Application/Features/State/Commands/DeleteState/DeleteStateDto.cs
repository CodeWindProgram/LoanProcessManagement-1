using System;
using System.Collections.Generic;
using System.Text;

namespace LoanProcessManagement.Application.Features.State.Commands.DeleteState
{
    public class DeleteStateDto
    {
        public string Message { get; set; }
        public bool Succeeded { get; set; }
    }
}
