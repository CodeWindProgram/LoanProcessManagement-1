﻿using LoanProcessManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LoanProcessManagement.Application.Contracts.Persistence
{
    public interface IProductRepository
    {
        Task<IEnumerable<LpmLoanProductMaster>> GetLoanProducts();
        Task<IEnumerable<LpmLoanProductMaster>> GetInsuranceProducts();

    }
}