using System;
using System.Collections.Generic;
using System.Text;

namespace LoanProcessManagement.Application.Features.State.Queries.GetStateById
{
   public  class GetStateByIdDto
    {
        public long Id { get; set; }
        public string StateName { get; set; }
        public bool IsActive { get; set; }
    }
}
