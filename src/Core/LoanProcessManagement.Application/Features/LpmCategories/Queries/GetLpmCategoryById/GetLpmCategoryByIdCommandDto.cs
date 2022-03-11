using System;
using System.Collections.Generic;
using System.Text;

namespace LoanProcessManagement.Application.Features.LpmCategories.Queries.GetLpmCategoryById
{
    public class GetLpmCategoryByIdCommandDto
    {
        public long Id { get; set; }
        public string categoryName { get; set; }
        public bool IsActive { get; set; }
    }
}
