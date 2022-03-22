using System;
using System.Collections.Generic;
using System.Text;

namespace LoanProcessManagement.Application.Features.InstitutionMasters.Queries.GetInstitutionMastersById
{
   public  class GetInstitutionMastersByIdQueryVm
    {
        public long Id { get; set; }
        public string Institution_Type { get; set; }
        public string Institution_Name { get; set; }
        public bool IsActive { get; set; }

    }
}
