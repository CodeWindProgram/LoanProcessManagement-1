using System;
using System.Collections.Generic;
using System.Text;

namespace LoanProcessManagement.Application.Features.SchemeMaster.Queries.GetSchemeById
{
    public class GetSchemeByIdDto
    {
        public long Id { get; set; }
        public string SchemeName { get; set; }
        public bool IsActive { get; set; }
    }
}
