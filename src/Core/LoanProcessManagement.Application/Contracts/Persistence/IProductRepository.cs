using LoanProcessManagement.Application.Features.Product.Commands.CreateProductCommand;
using LoanProcessManagement.Application.Features.Product.Commands.DeleteProductCommand;
using LoanProcessManagement.Application.Features.Product.Commands.UpdateProductCommand;
using LoanProcessManagement.Domain.Entities;
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
        Task<IEnumerable<LpmLoanProductMaster>> GetAllProducts();
        Task<LpmLoanProductMaster> GetProductById(long id);

        Task<CreateProductCommandDto> CreateProduct(CreateProductCommand req);
        Task<DeleteProductCommandDto> DeleteProduct(long id);
        Task<UpdateProductCommandDto> UpdateProduct(UpdateProductCommand req);


    }
}
