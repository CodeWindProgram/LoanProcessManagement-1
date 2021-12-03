using System;
using System.Collections.Generic;
using System.Text;

namespace LoanProcessManagement.Application.Features.Product.Queries
{
    public class GetLoanProductsDto
    {
        public long Id { get; set; }

        public string ProductType { get; set; }

        public string ProductName { get; set; }

        public string ProducDescription { get; set; }

        public int SerialOrder { get; set; }

        public bool IsActive { get; set; }
    }
}
