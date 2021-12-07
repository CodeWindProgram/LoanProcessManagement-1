using LoanProcessManagement.App.Helper.APIHelper;
using LoanProcessManagement.App.Models;
using LoanProcessManagement.App.Services.Interfaces;
using LoanProcessManagement.Application.Features.QueryHistory.Queries;
using LoanProcessManagement.Application.Responses;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace LoanProcessManagement.App.Services.Implementation
{
    public class QueryHistoryService : IQueryHistoryService
    {
        private string BaseUrl = "";
        private readonly IHttpClientFactory clientfact;
        readonly IOptions<APIConfiguration> _apiDetails;

        public QueryHistoryService(IHttpClientFactory client, IOptions<APIConfiguration> apiDetails)
        {
            clientfact = client;
            _apiDetails = apiDetails;
        }


        #region This method will get add applicant details api by - Pratiksha Poshe - 19/11/2021
        /// <summary>
        /// 19/11/2021 - This method will get add applicant details api
        //	commented by Pratiksha Poshe
        /// </summary>
        /// <param name="leadId">leadId</param>
        /// <returns>response</returns>
        public async Task<Response<IEnumerable<QueryHistoryCommandVM>>> GetQueryHistoryByLeadId(string lead_Id)
        {
            BaseUrl = _apiDetails.Value.LoanProcessAPIUrl;

            var _client = clientfact.CreateClient("LoanService");

            var httpResponse = await _client.GetAsync
                (
                    BaseUrl + APIEndpoints.GetQueryHistoryByLeadId.Replace("{0}", lead_Id.ToString())
                );

            var jsonString = httpResponse.Content.ReadAsStringAsync().Result;

            var options = new JsonSerializerOptions();

            var response = System.Text.Json.JsonSerializer.Deserialize<Response<IEnumerable<QueryHistoryCommandVM>>>(jsonString, options);

            return response;
        }
        #endregion
    }
}
