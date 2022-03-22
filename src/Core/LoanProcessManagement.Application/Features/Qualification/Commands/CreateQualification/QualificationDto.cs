using System;
using System.Collections.Generic;
using System.Text;

namespace LoanProcessManagement.Application.Features.Qualification.Commands.CreateQualification
{
     public class QualificationDto
    {
        public long Id { get; set; }
        public string Message { get; set; }
        public bool Succeeded { get; set; }
    }
}
