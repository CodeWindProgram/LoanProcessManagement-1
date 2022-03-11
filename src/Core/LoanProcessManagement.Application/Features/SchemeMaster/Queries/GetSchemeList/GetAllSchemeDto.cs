using System;
using System.Collections.Generic;
using System.Text;

namespace LoanProcessManagement.Application.Features.SchemeMaster.Queries.GetSchemeList
{
    public class GetAllSchemeDto
    {
        public long Id { get; set; }
        public string SchemeName { get; set; }
        public bool IsActive { get; set; }
    }
}

