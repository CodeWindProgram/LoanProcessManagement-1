using System;
using System.Collections.Generic;
using System.Text;

namespace LoanProcessManagement.Application.Features.Qualification.Queries.GetQualificationById
{
    public class GetQualificationByIdDto
    {
        public long Id { get; set; }
        public string QualificationName { get; set; }
        public bool IsActive { get; set; }
    }
}
