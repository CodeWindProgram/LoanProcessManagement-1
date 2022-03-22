using System;
using System.Collections.Generic;
using System.Text;

namespace LoanProcessManagement.Application.Features.Product.Queries.GetAllProducts
{
    public class GetAllProductsQueryDto
    {
        public long Id { get; set; }

        public string ProductType { get; set; }

        public string ProductName { get; set; }

        public string ProducDescription { get; set; }

        public bool IsActive { get; set; }
    }
}
