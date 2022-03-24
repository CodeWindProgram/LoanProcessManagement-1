using System;
using System.Collections.Generic;
using System.Text;

namespace LoanProcessManagement.Application.Features.State.Queries.GetStateList
{
    public class GetStateListDto
    {
        public long Id { get; set; }
        public string StateName { get; set; }
        public bool IsActive { get; set; }
    }
}
