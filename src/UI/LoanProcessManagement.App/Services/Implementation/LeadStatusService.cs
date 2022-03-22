using LoanProcessManagement.App.Helper.APIHelper;
using LoanProcessManagement.App.Services.Interfaces;
using LoanProcessManagement.Application.Features.LeadStatus.Commands.CreateLeadStatus;
using LoanProcessManagement.Application.Features.LeadStatus.Commands.DeleteLeadStatus;
using LoanProcessManagement.Application.Features.LeadStatus.Commands.UpdateLeadStatus;
using LoanProcessManagement.Application.Features.LeadStatus.Queries.GetLeadStatusList;
using LoanProcessManagement.Application.Features.LeadStatus.Queries.GetLeadStautsById;
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
    public class LeadStatusService : ILeadStatusService
    {
        private string BaseUrl = "";
        private readonly IHttpClientFactory clientfact;
        readonly IOptions<APIConfiguration> _apiDetails;

        public LeadStatusService(IHttpClientFactory client, IOptions<APIConfiguration> apiDetails)
        {
            clientfact = client;
            _apiDetails = apiDetails;
        }

        public async Task<Response<LeadStatusDto>> AddLeadSt(CreateLeadStatusCommand req)
        {
            BaseUrl = _apiDetails.Value.LoanProcessAPIUrl;

            var content = JsonConvert.SerializeObject(req);

            var _client = clientfact.CreateClient("LoanService");

            var httpResponse = await _client.PostAsync
                (
                    BaseUrl + APIEndpoints.AddLeadStatus,
                    new StringContent(content, Encoding.Default,
                    "application/json")
                );

            var jsonString = httpResponse.Content.ReadAsStringAsync().Result;

            var options = new JsonSerializerOptions();

            var response = System.Text.Json.JsonSerializer.Deserialize<Response<LeadStatusDto>>(jsonString, options);

            return response;    
        }

        public async Task<Response<DeleteLeadStatusDto>> DeleteLeadSt(long id)
        {
            BaseUrl = _apiDetails.Value.LoanProcessAPIUrl;

            var _client = clientfact.CreateClient("LoanService");

            var httpResponse = await _client.DeleteAsync
                (
                    BaseUrl + APIEndpoints.DeleteLeadStatus + id

                );

            var jsonString = httpResponse.Content.ReadAsStringAsync().Result;

            var options = new JsonSerializerOptions();

            var response = System.Text.Json.JsonSerializer.Deserialize<Response<DeleteLeadStatusDto>>(jsonString, options);

            return response;
        }

        public async Task<Response<GetLeadStatusByIdQueryVm>> GetLeadStatusById(long id)
        {
            BaseUrl = _apiDetails.Value.LoanProcessAPIUrl;

            var _client = clientfact.CreateClient("LoanService");

            var httpResponse = await _client.GetAsync
                (
                    BaseUrl + APIEndpoints.GetByIdLeadStatus + id

                );

            var jsonString = httpResponse.Content.ReadAsStringAsync().Result;

            var options = new JsonSerializerOptions();

            var response = System.Text.Json.JsonSerializer.Deserialize<Response<GetLeadStatusByIdQueryVm>>(jsonString, options);

            return response;
        }

        public async Task<Response<UpdateLeadStatusDto>> UpdateLeadStatus(UpdateLeadStatusCommand req)
        {
            BaseUrl = _apiDetails.Value.LoanProcessAPIUrl;

            var content = JsonConvert.SerializeObject(req);

            var _client = clientfact.CreateClient("LoanService");

            var httpResponse = await _client.PutAsync
                (
                    BaseUrl + APIEndpoints.UpdateLeadStatus,
                    new StringContent(content, Encoding.Default,
                    "application/json")
                );

            var jsonString = httpResponse.Content.ReadAsStringAsync().Result;

            var options = new JsonSerializerOptions();

            var response = System.Text.Json.JsonSerializer.Deserialize<Response<UpdateLeadStatusDto>>(jsonString, options);

            return response;
        }
        public async Task<Response<IEnumerable<GetAllLeadStatusQueryDto>>> GetAllLeadStatus()
        {
            BaseUrl = _apiDetails.Value.LoanProcessAPIUrl;

            var _client = clientfact.CreateClient("LoanService");

            var httpResponse = await _client.GetAsync
                (
                    BaseUrl + APIEndpoints.GetAllLeadStatus
                );

            var jsonString = httpResponse.Content.ReadAsStringAsync().Result;

            var options = new JsonSerializerOptions();

            var response = System.Text.Json.JsonSerializer.Deserialize<Response<IEnumerable<GetAllLeadStatusQueryDto>>>(jsonString, options);

            return response;
        }

    }
}
