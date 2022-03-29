using System;
using System.Collections.Generic;
using System.Text;

namespace LoanProcessManagement.Application.Features.Agency.Queries.GetAgencyById
{
   public  class GetAgencyByIdQueryVm
    {
        public long Id { get; set; }
        public string AgencyName { get; set; }
        public char Agency_type { get; set; }
        public bool IsActive { get; set; }
    }
}
