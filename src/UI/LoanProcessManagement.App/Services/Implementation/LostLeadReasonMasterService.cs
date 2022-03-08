using LoanProcessManagement.App.Helper.APIHelper;
using LoanProcessManagement.App.Services.Interfaces;
using LoanProcessManagement.Application.Features.LostLeadMaster.Commands.CreateLostLeadReasonMaster;
using LoanProcessManagement.Application.Features.LostLeadMaster.Commands.DeleteLostLeadReasonMaster;
using LoanProcessManagement.Application.Features.LostLeadMaster.Commands.UpdateLostLeadReasonMaster;
using LoanProcessManagement.Application.Features.LostLeadMaster.Queries.GetLostLeadMasterbyId;
using LoanProcessManagement.Application.Features.LostLeadMaster.Queries.GetLostLeadMasterList;
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
    public class LostLeadReasonMasterService : ILostLeadReasonMasterService
    {
        private string BaseUrl = "";
        private readonly IHttpClientFactory clientfact;
        readonly IOptions<APIConfiguration> _apiDetails;
        public LostLeadReasonMasterService(IHttpClientFactory client, IOptions<APIConfiguration> apiDetails)
        {
            clientfact = client;
            _apiDetails = apiDetails;
        }
        public async Task<Response<UpdateLostLeadReasonMasterDto>> UpdateLostLeadReasonMaster(UpdateLostLeadReasonMasterCommand lpmLostLeadReasonMaster)
        {
            BaseUrl = _apiDetails.Value.LoanProcessAPIUrl;

            var content = JsonConvert.SerializeObject(lpmLostLeadReasonMaster);

            var _client = clientfact.CreateClient("LoanService");

            var httpResponse = await _client.PutAsync
                (
                    BaseUrl + APIEndpoints.Lost,
                    new StringContent(content, Encoding.Default,
                    "application/json")
                );

            var jsonString = httpResponse.Content.ReadAsStringAsync().Result;

            var options = new JsonSerializerOptions();

            var model = System.Text.Json.JsonSerializer.Deserialize<Response<UpdateLostLeadReasonMasterDto>>(jsonString, options);

            return model;
        }

        public async Task<Response<IEnumerable<LostLeadMasterListVm>>> GetByLostLeadReason()
        {
            BaseUrl = _apiDetails.Value.LoanProcessAPIUrl;

            var _client = clientfact.CreateClient("LoanService");

            var httpResponse = await _client.GetAsync
                (
                    BaseUrl + APIEndpoints.Lost
                );

            var jsonString = httpResponse.Content.ReadAsStringAsync().Result;

            var options = new JsonSerializerOptions();

            var response = System.Text.Json.JsonSerializer.Deserialize<Response<IEnumerable<LostLeadMasterListVm>>>(jsonString, options);

            return response;
        }

        public GetLostLeadReasonMasterByIdDto GetLostLeadReasonMasterByIdAsync(long id)
        {
            BaseUrl = _apiDetails.Value.LoanProcessAPIUrl;
            var _client = clientfact.CreateClient("LoanService");
            var result = new GetLostLeadReasonMasterByIdDto();
            var uri = BaseUrl + APIEndpoints.LostDelete + id;
            HttpResponseMessage response = _client.GetAsync(uri).Result;
            if (response.IsSuccessStatusCode)
            {
                var jsonDataStatus = response.Content.ReadAsStringAsync().Result;
                var data = JsonConvert.DeserializeObject<GetLostLeadReasonMasterByIdDto>(jsonDataStatus);
                return data;
            }
            return result;
        }

        public async Task<Response<DeleteLostLeadReasonMasterDto>> DeleteLostLeadReasonMaster(long Id)
        {
            BaseUrl = _apiDetails.Value.LoanProcessAPIUrl;

            var _client = clientfact.CreateClient("LoanService");

            var httpResponse = await _client.DeleteAsync
                (
                    BaseUrl + APIEndpoints.LostDelete + Id
                );

            var jsonString = httpResponse.Content.ReadAsStringAsync().Result;

            var options = new JsonSerializerOptions();

            var response = System.Text.Json.JsonSerializer.Deserialize<Response<DeleteLostLeadReasonMasterDto>>(jsonString, options);

            return response;
        }
        public async Task<Response<CreateLostLeadReasonMasterCommandDto>> CreateLostLeadReasonMaster(CreateLostLeadReasonMasterCommand createLostLeadReasonMasterCommand)
        {
            BaseUrl = _apiDetails.Value.LoanProcessAPIUrl;

            var content = JsonConvert.SerializeObject(createLostLeadReasonMasterCommand);

            var _client = clientfact.CreateClient("LoanService");

            var httpResponse = await _client.PostAsync
                (
                    BaseUrl + APIEndpoints.Lost,
                    new StringContent(content, Encoding.Default,
                    "application/json")
                );

            var jsonString = httpResponse.Content.ReadAsStringAsync().Result;

            var options = new JsonSerializerOptions();

            var model = System.Text.Json.JsonSerializer.Deserialize<Response<CreateLostLeadReasonMasterCommandDto>>(jsonString, options);

            return model;
        }
    }
}
