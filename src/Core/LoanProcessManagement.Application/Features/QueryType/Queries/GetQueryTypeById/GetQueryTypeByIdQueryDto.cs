using System;
using System.Collections.Generic;
using System.Text;

namespace LoanProcessManagement.Application.Features.QueryType.Queries.GetQueryTypeById
{
    public class GetQueryTypeByIdQueryDto
    {
        public long Id { get; set; }
        public Char QueryType { get; set; }
        public string QueryName { get; set; }
        public bool IsActive { get; set; }
    }
}
