using LoanProcessManagement.Application.Features.Product.Commands.CreateProductCommand;
using LoanProcessManagement.Application.Features.Product.Commands.DeleteProductCommand;
using LoanProcessManagement.Application.Features.Product.Commands.UpdateProductCommand;
using LoanProcessManagement.Application.Features.Product.Queries.GetAllProducts;
using LoanProcessManagement.Application.Features.Product.Queries.GetProductById;
using LoanProcessManagement.Application.Features.ProductsList.Queries;
using LoanProcessManagement.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoanProcessManagement.App.Services.Interfaces
{
    #region added service to call propertyList api added by - Ramya Guduru - 15/11/2021
    public interface IProductService
    {
        //Task<Response<IEnumerable<GetProductsListQueryVm>>> ProductsListProcess(GetProductsListQuery productsList);
        Task<Response<IEnumerable<GetProductsListQueryVm>>> ProductsListProcess(string lead_Id);
        Task<Response<IEnumerable<GetAllProductsQueryDto>>> GetAllProducts();
        Task<Response<CreateProductCommandDto>> AddProduct(CreateProductCommand req);
        Task<Response<DeleteProductCommandDto>> DeleteProduct(long id);
        Task<Response<GetProductByIdQueryDto>> GetProductById(long id);
        Task<Response<UpdateProductCommandDto>> UpdateProduct(UpdateProductCommand req);

    }
    #endregion
}
