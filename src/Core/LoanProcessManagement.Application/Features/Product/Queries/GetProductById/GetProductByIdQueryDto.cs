using LoanProcessManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoanProcessManagement.Application.Features.Product.Queries.GetProductById
{
    public class GetProductByIdQueryDto
    {
        public long Id { get; set; }

        public string ProductType { get; set; }

        public string ProductName { get; set; }

        public string ProducDescription { get; set; }
        public List<long> Schemes { get; set; }
        //public ICollection<LpmLoanProductSchemeMapping> LpmLoanProductSchemeMappings { get; set; }

        public bool IsActive { get; set; }
    }
}
