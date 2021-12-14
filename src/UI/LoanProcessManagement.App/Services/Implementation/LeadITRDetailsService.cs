using LoanProcessManagement.App.Helper.APIHelper;
using LoanProcessManagement.App.Models;
using LoanProcessManagement.App.Services.Interfaces;
using LoanProcessManagement.Application.Features.LeadITRDetails.Command;
using LoanProcessManagement.Application.Features.LeadITRDetails.Queries.LeadITRDetails;
using LoanProcessManagement.Application.Responses;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace LoanProcessManagement.App.Services.Implementation
{
    public class LeadITRDetailsService:ILeadITRDetailsService
    {
        private string BaseUrl = "";
        private readonly IHttpClientFactory clientfact;
        readonly IOptions<APIConfiguration> _apiDetails;

        public LeadITRDetailsService(IHttpClientFactory client, IOptions<APIConfiguration> apiDetails)
        {
            clientfact = client;
            _apiDetails = apiDetails;
        }

        public async Task<Response<GetLeadITRDetailsDto>> GetLeadITRDetails(long lead_Id, int applicantType)
        {
            //throw new NotImplementedException();
            BaseUrl = _apiDetails.Value.LoanProcessAPIUrl;

            var _client = clientfact.CreateClient("LoanService");

            var httpResponse = await _client.GetAsync
                (
                    BaseUrl + APIEndpoints.GetLeadITRDetails.Replace("{0}", lead_Id.ToString()).Replace("{1}", applicantType.ToString())
                );

            var jsonString = httpResponse.Content.ReadAsStringAsync().Result;

            var options = new JsonSerializerOptions();

            var response = System.Text.Json.JsonSerializer.Deserialize<Response<GetLeadITRDetailsDto>>(jsonString, options);

            return response;
        }

        public async Task<Response<LeadITRDetailsDto>> UpdateLeadITRDetails(LeadITRDetailsVm leadITRDetailsVm)
        {
            //throw new NotImplementedException();
            BaseUrl = _apiDetails.Value.LoanProcessAPIUrl;

            var content = JsonConvert.SerializeObject(leadITRDetailsVm);

            var _client = clientfact.CreateClient("LoanService");

            var httpResponse = await _client.PostAsync
                (
                    BaseUrl + APIEndpoints.AddITRDetails,
                    new StringContent(content, Encoding.Default,
                    "application/json")
                );

            var jsonString = httpResponse.Content.ReadAsStringAsync().Result;

            var options = new JsonSerializerOptions();

            var response = System.Text.Json.JsonSerializer.Deserialize<Response<LeadITRDetailsDto>>(jsonString, options);

            return response;
        }
    }
}
