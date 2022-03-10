using System;
using System.Collections.Generic;
using System.Text;

namespace LoanProcessManagement.Application.Features.InstitutionMasters.Queries.GetInstitutionMasters
{
    public class GetInstitutionMastersQueryDto
    {
        public long Id { get; set; }
        public long Institution_Id { get; set; }
        public string Institution_Type { get; set; }
        public string Institution_Name { get; set; }
    }
}
