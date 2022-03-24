using LoanProcessManagement.App.Helper.APIHelper;
using LoanProcessManagement.App.Services.Interfaces;
using LoanProcessManagement.Application.Features.State.Commands.CreateState;
using LoanProcessManagement.Application.Features.State.Commands.DeleteState;
using LoanProcessManagement.Application.Features.State.Commands.UpdateState;
using LoanProcessManagement.Application.Features.State.Queries.GetStateById;
using LoanProcessManagement.Application.Features.State.Queries.GetStateList;
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
    public class StateService : IStateService
    {
        private string BaseUrl = "";
        private readonly IHttpClientFactory clientfact;
        readonly IOptions<APIConfiguration> _apiDetails;

        public StateService(IHttpClientFactory client, IOptions<APIConfiguration> apiDetails)
        {
            clientfact = client;
            _apiDetails = apiDetails;
        }
        #region  This method will call State CRUD api by - Dipti Pandhram - 23/03/2022

        public async Task<Response<CreateStateDto>> AddState(CreateStateCommand req)
        {
            BaseUrl = _apiDetails.Value.LoanProcessAPIUrl;

            var content = JsonConvert.SerializeObject(req);

            var _client = clientfact.CreateClient("LoanService");

            var httpResponse = await _client.PostAsync
                (
                    BaseUrl + APIEndpoints.AddState,
                    new StringContent(content, Encoding.Default,
                    "application/json")
                );

            var jsonString = httpResponse.Content.ReadAsStringAsync().Result;

            var options = new JsonSerializerOptions();

            var response = System.Text.Json.JsonSerializer.Deserialize<Response<CreateStateDto>>(jsonString, options);

            return response;

        }

        public async Task<Response<DeleteStateDto>> DeleteState(long id)
        {
            BaseUrl = _apiDetails.Value.LoanProcessAPIUrl;

            var _client = clientfact.CreateClient("LoanService");

            var httpResponse = await _client.DeleteAsync
                (
                    BaseUrl + APIEndpoints.DeleteState + id

                );

            var jsonString = httpResponse.Content.ReadAsStringAsync().Result;

            var options = new JsonSerializerOptions();

            var response = System.Text.Json.JsonSerializer.Deserialize<Response<DeleteStateDto>>(jsonString, options);

            return response;
        }

        public async Task<Response<GetStateByIdDto>> GetStateById(long id)
        {
            BaseUrl = _apiDetails.Value.LoanProcessAPIUrl;

            var _client = clientfact.CreateClient("LoanService");

            var httpResponse = await _client.GetAsync
                (
                    BaseUrl + APIEndpoints.GetStateById + id

                );

            var jsonString = httpResponse.Content.ReadAsStringAsync().Result;

            var options = new JsonSerializerOptions();

            var response = System.Text.Json.JsonSerializer.Deserialize<Response<GetStateByIdDto>>(jsonString, options);

            return response;

        }

        public async Task<Response<UpdateStateDto>> UpdateState(UpdateStateCommand req)
        {
            BaseUrl = _apiDetails.Value.LoanProcessAPIUrl;

            var content = JsonConvert.SerializeObject(req);

            var _client = clientfact.CreateClient("LoanService");

            var httpResponse = await _client.PutAsync
                (
                    BaseUrl + APIEndpoints.UpdateState,
                    new StringContent(content, Encoding.Default,
                    "application/json")
                );

            var jsonString = httpResponse.Content.ReadAsStringAsync().Result;

            var options = new JsonSerializerOptions();

            var response = System.Text.Json.JsonSerializer.Deserialize<Response<UpdateStateDto>>(jsonString, options);

            return response;

        }

        public async Task<Response<IEnumerable<GetStateListDto>>> GetAllState()
        {
            BaseUrl = _apiDetails.Value.LoanProcessAPIUrl;

            var _client = clientfact.CreateClient("LoanService");

            var httpResponse = await _client.GetAsync
                (
                    BaseUrl + APIEndpoints.GetAllState
                );

            var jsonString = httpResponse.Content.ReadAsStringAsync().Result;

            var options = new JsonSerializerOptions();

            var response = System.Text.Json.JsonSerializer.Deserialize<Response<IEnumerable<GetStateListDto>>>(jsonString, options);

            return response;
        } 
        #endregion
    }
}
