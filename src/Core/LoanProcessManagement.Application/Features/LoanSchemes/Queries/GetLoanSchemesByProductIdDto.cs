using System;
using System.Collections.Generic;
using System.Text;

namespace LoanProcessManagement.Application.Features.LoanSchemes.Queries
{
    public class GetLoanSchemesByProductIdDto
    {
        public long Id { get; set; }
        public long SchemeID { get; set; }
        public string SchemeName { get; set; }
        public long ProductID { get; set; }
    }
}
