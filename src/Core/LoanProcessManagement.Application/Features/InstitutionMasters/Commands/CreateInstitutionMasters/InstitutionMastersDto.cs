using System;
using System.Collections.Generic;
using System.Text;

namespace LoanProcessManagement.Application.Features.InstitutionMasters.Commands.CreateInstitutionMasters
{
   public  class InstitutionMastersDto
    {
        public long Id { get; set; }
        public string Message { get; set; }
        public bool Succeeded { get; set; }
    }
}
