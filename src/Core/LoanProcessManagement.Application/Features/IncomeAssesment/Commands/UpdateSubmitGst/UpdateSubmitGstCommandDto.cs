using System;
using System.Collections.Generic;
using System.Text;

namespace LoanProcessManagement.Application.Features.IncomeAssesment.Commands.UpdateSubmitGst
{
    public class UpdateSubmitGstCommandDto
    {
        public long Id { get; set; }
        public bool IsSubmit { get; set; }
    }
}
