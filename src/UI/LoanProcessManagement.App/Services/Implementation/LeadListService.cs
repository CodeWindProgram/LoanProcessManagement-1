using LoanProcessManagement.App.Helper.APIHelper;
using LoanProcessManagement.App.Services.Interfaces;
using LoanProcessManagement.Application.Features.LeadList.Commands;
using LoanProcessManagement.Application.Responses;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace LoanProcessManagement.App.Services.Implementation
{
    public class LeadListService : ILeadListService
    {
        #region Lead List Service created with inheriring the ILeadListService - Saif Khan - 02/11/2021
        /// <summary>
        /// Lead List Service created with inheriring the ILeadListService  - 02/11/2021
        /// Commented By - Saif Khan
        /// <Return>Model</Return>
        /// </summary>
        private string BaseUrl = "";
        private IHttpClientFactory clientfact;
        IOptions<APIConfiguration> _apiDetails;
        public LeadListService(IHttpClientFactory client, IOptions<APIConfiguration> apiDetails)
        {
            clientfact = client;
            _apiDetails = apiDetails;
        }
        public async Task<Response<IEnumerable<LeadListCommandDto>>> LeadListProcess(LeadListCommand leadListCommand)
        {
            BaseUrl = _apiDetails.Value.LoanProcessAPIUrl;

            var content = JsonConvert.SerializeObject(leadListCommand);

            var _client = clientfact.CreateClient("LoanService");

            var httpResponse = await _client.PostAsync
                (
                    BaseUrl + APIEndpoints.LeadList, new StringContent(content, Encoding.Default,
                    "application/json")
                );

            var jsonString = httpResponse.Content.ReadAsStringAsync().Result;

            var options = new JsonSerializerOptions();

            var model = System.Text.Json.JsonSerializer.Deserialize<Response<IEnumerable<LeadListCommandDto>>>(jsonString, options);

            return model;
        } 
        #endregion
    }
}
