using LoanProcessManagement.App.Helper.APIHelper;
using LoanProcessManagement.App.Services.Interfaces;
using LoanProcessManagement.Application.Features.ProductsList.Queries;
using LoanProcessManagement.Application.Responses;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text;

namespace LoanProcessManagement.App.Services.Implementation
{
    public class ProductService:IProductService
    {
        private string BaseUrl = "";
        private IHttpClientFactory clientfact;
        IOptions<APIConfiguration> _apiDetails;


        public ProductService(IHttpClientFactory client, IOptions<APIConfiguration> apiDetails)
        {
            clientfact = client;
            _apiDetails = apiDetails;
        }
        #region This method will call actual api and return response for GetProductsList API - Ramya Guduru - 15/11/2021
        /// <summary>
        /// 2021/11/15 - GetProductsList api
        //	commented by Ramya Guduru
        /// </summary>
        /// <param name="GetProductsList">lead_Id as a parameters</param>
        /// <returns>Response</returns>
        public async Task<Response<IEnumerable<GetProductsListQueryVm>>> ProductsListProcess(string lead_Id)
        {

            BaseUrl = _apiDetails.Value.LoanProcessAPIUrl;

            var content = JsonConvert.SerializeObject(lead_Id);

            var _client = clientfact.CreateClient("LoanService");

            var httpResponse = await _client.GetAsync
                (
                    BaseUrl + APIEndpoints.AllProductsList + lead_Id
                );

            var jsonString = httpResponse.Content.ReadAsStringAsync().Result;

            var options = new JsonSerializerOptions();

            var model = System.Text.Json.JsonSerializer.Deserialize<Response<IEnumerable<GetProductsListQueryVm>>>(jsonString, options);

            return model;

        }
        #endregion
    }
}
