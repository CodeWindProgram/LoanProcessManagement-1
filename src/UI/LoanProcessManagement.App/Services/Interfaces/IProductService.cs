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

    }
    #endregion
}
