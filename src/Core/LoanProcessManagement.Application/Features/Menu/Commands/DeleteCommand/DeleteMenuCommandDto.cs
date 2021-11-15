using System;
using System.Collections.Generic;
using System.Text;

namespace LoanProcessManagement.Application.Features.Menu.Commands.DeleteCommand
{
    public class DeleteMenuCommandDto
    {
        public long Id { get; set; }
        public string Message { get; set; }
        public bool Succeeded { get; set; }
    }
}
