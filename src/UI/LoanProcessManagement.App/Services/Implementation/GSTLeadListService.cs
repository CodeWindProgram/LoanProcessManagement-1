using LoanProcessManagement.App.Helper.APIHelper;
using LoanProcessManagement.App.Services.Interfaces;
using LoanProcessManagement.Application.Features.GSTLeadList.Queries;
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
    public class GSTLeadListService : IGSTLeadListService
    {

        private string BaseUrl = "";
        private readonly IHttpClientFactory clientfact;
        readonly IOptions<APIConfiguration> _apiDetails;


        public GSTLeadListService(IHttpClientFactory client, IOptions<APIConfiguration> apiDetails)
        {
            clientfact = client;
            _apiDetails = apiDetails;
        }
        #region This method will call actual api and return response for GSTLeadListService API - Ramya Guduru - 17/11/2021
        /// <summary>
        /// 2021/11/17 - GSTLeadListService api
        //	commented by Ramya Guduru
        /// </summary>
        /// <param name="GSTLeadListService">BranchID as a parameters</param>
        /// <returns>Response</returns>
        public async Task<Response<IEnumerable<GetGSTLeadListQueryVm>>> GSTLeadListingProcess(long BranchID)
        {

            BaseUrl = _apiDetails.Value.LoanProcessAPIUrl;

            var content = JsonConvert.SerializeObject(BranchID);

            var _client = clientfact.CreateClient("LoanService");

            var httpResponse = await _client.GetAsync
                (
                    BaseUrl + APIEndpoints.LeadListing + BranchID
                );

            var jsonString = httpResponse.Content.ReadAsStringAsync().Result;

            var options = new JsonSerializerOptions();

            var model = System.Text.Json.JsonSerializer.Deserialize<Response<IEnumerable<GetGSTLeadListQueryVm>>>(jsonString, options);

            return model;
        }
        #endregion
    }
}
