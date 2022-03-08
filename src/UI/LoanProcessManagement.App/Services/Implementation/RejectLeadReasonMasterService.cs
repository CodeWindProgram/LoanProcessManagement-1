using LoanProcessManagement.App.Helper.APIHelper;
using LoanProcessManagement.App.Services.Interfaces;
using LoanProcessManagement.Application.Features.RejectedLeadMaster.Commands.CreateRejectedLeadReasonMaster;
using LoanProcessManagement.Application.Features.RejectedLeadMaster.Commands.DeleteRejectLeadReasonMaster;
using LoanProcessManagement.Application.Features.RejectedLeadMaster.Commands.UpdateRejectLeadReasonMaster;
using LoanProcessManagement.Application.Features.RejectedLeadMaster.Queries.GetRejectedLeadMasterbyId;
using LoanProcessManagement.Application.Features.RejectedLeadMaster.Queries.GetRejectLeadMasterList;
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
    public class RejectLeadReasonMasterService : IRejectLeadReasonMasterService
    {
        private string BaseUrl = "";
        private readonly IHttpClientFactory clientfact;
        readonly IOptions<APIConfiguration> _apiDetails;
        public RejectLeadReasonMasterService(IHttpClientFactory client, IOptions<APIConfiguration> apiDetails)
        {
            clientfact = client;
            _apiDetails = apiDetails;
        }
        public async Task<Response<CreateRejectedLeadReasonMasterCommandDto>> CreateRejectLeadReasonMaster(CreateRejectedLeadReasonMasterCommand createRejectLeadReasonMasterCommand)
        {
            BaseUrl = _apiDetails.Value.LoanProcessAPIUrl;

            var content = JsonConvert.SerializeObject(createRejectLeadReasonMasterCommand);

            var _client = clientfact.CreateClient("LoanService");

            var httpResponse = await _client.PostAsync
                (
                    BaseUrl + APIEndpoints.Reject,
                    new StringContent(content, Encoding.Default,
                    "application/json")
                );

            var jsonString = httpResponse.Content.ReadAsStringAsync().Result;

            var options = new JsonSerializerOptions();

            var model = System.Text.Json.JsonSerializer.Deserialize<Response<CreateRejectedLeadReasonMasterCommandDto>>(jsonString, options);

            return model;
        }

        public async Task<Response<DeleteRejectLeadReasonMasterDto>> DeleteRejectLeadReasonMaster(long Id)
        {
            BaseUrl = _apiDetails.Value.LoanProcessAPIUrl;

            var _client = clientfact.CreateClient("LoanService");

            var httpResponse = await _client.DeleteAsync
                (
                    BaseUrl + APIEndpoints.RejectDelete + Id
                );

            var jsonString = httpResponse.Content.ReadAsStringAsync().Result;

            var options = new JsonSerializerOptions();

            var response = System.Text.Json.JsonSerializer.Deserialize<Response<DeleteRejectLeadReasonMasterDto>>(jsonString, options);

            return response;
        }

        public async Task<Response<IEnumerable<RejectLeadMasterListVm>>> GetByRejectLeadReason()
        {
            {
                BaseUrl = _apiDetails.Value.LoanProcessAPIUrl;

                var _client = clientfact.CreateClient("LoanService");

                var httpResponse = await _client.GetAsync
                    (
                        BaseUrl + APIEndpoints.Reject
                    );

                var jsonString = httpResponse.Content.ReadAsStringAsync().Result;

                var options = new JsonSerializerOptions();

                var response = System.Text.Json.JsonSerializer.Deserialize<Response<IEnumerable<RejectLeadMasterListVm>>>(jsonString, options);

                return response;
            }

        }

        public async  Task<Response<UpdateRejectLeadReasonMasterDto>> UpdateRejectLeadReasonMaster(UpdateRejectLeadReasonMasterCommand lpmRejectLeadReasonMaster)
        {
            BaseUrl = _apiDetails.Value.LoanProcessAPIUrl;

            var content = JsonConvert.SerializeObject(lpmRejectLeadReasonMaster);

            var _client = clientfact.CreateClient("LoanService");

            var httpResponse = await _client.PutAsync
                (
                    BaseUrl + APIEndpoints.Reject,
                    new StringContent(content, Encoding.Default,
                    "application/json")
                );

            var jsonString = httpResponse.Content.ReadAsStringAsync().Result;

            var options = new JsonSerializerOptions();

            var model = System.Text.Json.JsonSerializer.Deserialize<Response<UpdateRejectLeadReasonMasterDto>>(jsonString, options);

            return model;
        }

        public GetRejectedLeadReasonMasterByIdDto GetRejectLeadReasonMasterByIdAsync(long id)
        {
            BaseUrl = _apiDetails.Value.LoanProcessAPIUrl;
            var _client = clientfact.CreateClient("LoanService");
            var result = new GetRejectedLeadReasonMasterByIdDto();
            var uri = BaseUrl + APIEndpoints.RejectDelete + id;
            HttpResponseMessage response = _client.GetAsync(uri).Result;
            if (response.IsSuccessStatusCode)
            {
                var jsonDataStatus = response.Content.ReadAsStringAsync().Result;
                var data = JsonConvert.DeserializeObject<GetRejectedLeadReasonMasterByIdDto>(jsonDataStatus);
                return data;
            }
            return result;
        }
    }
}
