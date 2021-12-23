using LoanProcessManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoanProcessManagement.Application.Features.Agency.Queries.GetAllAgency
{
    public class GetAllAgencyDto
    {
        public IEnumerable<LpmAgencyMaster> ValuerAgency { get; set; }
        public IEnumerable<LpmAgencyMaster> FiAgency { get; set; }
        public IEnumerable<LpmAgencyMaster> LegalAgency { get; set; }


    }
}
