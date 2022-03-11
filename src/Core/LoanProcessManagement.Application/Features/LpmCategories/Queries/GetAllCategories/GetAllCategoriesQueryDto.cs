using System;
using System.Collections.Generic;
using System.Text;

namespace LoanProcessManagement.Application.Features.LpmCategories.Queries.GetAllCategories
{
    public class GetAllCategoriesQueryDto
    {
        public long Id { get; set; }
        public string categoryName { get; set; }
        public bool IsActive { get; set; }
    }
}
