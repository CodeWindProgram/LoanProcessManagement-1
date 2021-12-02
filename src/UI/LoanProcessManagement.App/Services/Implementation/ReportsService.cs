using LoanProcessManagement.App.Helper.APIHelper;
using LoanProcessManagement.App.Services.Interfaces;
using LoanProcessManagement.Application.Features.ReportsLeadList.Queries;
using LoanProcessManagement.Application.Features.ReportsLeadList.ReportsQueries;
using LoanProcessManagement.Application.Responses;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace LoanProcessManagement.App.Services.Implementation
{
    public class ReportsService : IReportsService
    {

        private string BaseUrl = "";
        private IHttpClientFactory clientfact;
        IOptions<APIConfiguration> _apiDetails;


        public ReportsService(IHttpClientFactory client, IOptions<APIConfiguration> apiDetails)
        {
            clientfact = client;
            _apiDetails = apiDetails;
        }

        
        #region This method will call actual api and return response for ReportsLeadListService API - Ramya Guduru - 1/12/2021
        /// <summary>
        /// 2021/12/1 - ReportsLeadListService api
        //	commented by Ramya Guduru
        /// </summary>
        /// <param name="ReportsLeadListService">LgId,BranchID as a parameters</param>
        /// <returns>Response</returns>
        public async Task<Response<IEnumerable<GetReportsLeadListQueryVm>>> GetReportsLeadList(string LgId,long BranchId)
        {
            BaseUrl = _apiDetails.Value.LoanProcessAPIUrl;

            var content = JsonConvert.SerializeObject(BranchId);

            var _client = clientfact.CreateClient("LoanService");

            var httpResponse = await _client.GetAsync
                (
                    BaseUrl + APIEndpoints.ReportsLeadListing + LgId + "/" + BranchId
                ) ;

            var jsonString = httpResponse.Content.ReadAsStringAsync().Result;

            var options = new JsonSerializerOptions();

            var model = System.Text.Json.JsonSerializer.Deserialize<Response<IEnumerable<GetReportsLeadListQueryVm>>>(jsonString, options);

            return model;
        }

        public async Task<Response<IEnumerable<ReportsListVm>>> ReportsList(long ParentId)
        {
            BaseUrl = _apiDetails.Value.LoanProcessAPIUrl;

            var _client = clientfact.CreateClient("LoanService");

            var httpResponse = await _client.GetAsync
                (
                    BaseUrl + APIEndpoints.ReportsList + ParentId
                );

            var jsonString = httpResponse.Content.ReadAsStringAsync().Result;

            var options = new JsonSerializerOptions();

            var response = System.Text.Json.JsonSerializer.Deserialize<Response<IEnumerable<ReportsListVm>>>(jsonString, options);

            return response;
        }


        #endregion
    }
}
