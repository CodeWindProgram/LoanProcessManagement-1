using LoanProcessManagement.App.Services.Interfaces;
using LoanProcessManagement.Application.Features.ProductsList.Queries;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoanProcessManagement.App.Controllers
{
    [Route("[controller]/[action]")]
    public class ProductsListController : Controller
    {
        private readonly IProductService _productService;
        public ProductsListController(IProductService productService)
        {
            _productService = productService;
        }

        #region This method will call get products api by - Ramya Guduru - 15/11/2021
        /// <summary>
        /// 15/11/2021 - This method will call get products api
        //	commented by Ramya Guduru
        /// </summary>
        /// <param name="lead_Id">lead_Id</param>
        /// <returns>view</returns>
        [HttpGet("{lead_Id}")]
        public async Task<IActionResult> AllProductsList(string lead_Id)
        {
            var productListServiceResponse = await _productService.ProductsListProcess(lead_Id);
            ViewBag.lead_Id = lead_Id;
            if (productListServiceResponse != null && productListServiceResponse.Data != null && productListServiceResponse.Succeeded)
            {
                return View(productListServiceResponse.Data);
            }
            return View("Error");
        }
        #endregion
    }
}
