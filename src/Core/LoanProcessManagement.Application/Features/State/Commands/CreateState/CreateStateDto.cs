using System;
using System.Collections.Generic;
using System.Text;

namespace LoanProcessManagement.Application.Features.State.Commands.CreateState
{
   public  class CreateStateDto
    {
        public long Id { get; set; }
        public string Message { get; set; }
        public bool Succeeded { get; set; }
    }
}
