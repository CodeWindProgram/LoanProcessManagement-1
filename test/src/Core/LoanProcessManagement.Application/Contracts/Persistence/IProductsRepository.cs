using LoanProcessManagement.Domain.CustomModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LoanProcessManagement.Application.Contracts.Persistence
{
    public interface IProductsRepository : IAsyncRepository<IEnumerable<ProductsListModel>>
    {
        Task<IEnumerable<ProductsListModel>> GetProductsList(string Lead_Id);
    }
}
