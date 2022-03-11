using LoanProcessManagement.App.Helper.APIHelper;
using LoanProcessManagement.App.Services.Interfaces;
using LoanProcessManagement.Application.Features.SchemeMaster.Commands.CreateScheme;
using LoanProcessManagement.Application.Features.SchemeMaster.Commands.DeleteScheme;
using LoanProcessManagement.Application.Features.SchemeMaster.Commands.UpdateScheme;
using LoanProcessManagement.Application.Features.SchemeMaster.Queries.GetSchemeById;
using LoanProcessManagement.Application.Features.SchemeMaster.Queries.GetSchemeList;
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
    public class SchemeService : ISchemeService
    {
        private string BaseUrl = "";
        private readonly IHttpClientFactory clientfact;
        readonly IOptions<APIConfiguration> _apiDetails;

        public SchemeService(IHttpClientFactory client, IOptions<APIConfiguration> apiDetails)
        {
            clientfact = client;
            _apiDetails = apiDetails;
        }

        public async Task<Response<IEnumerable<GetAllSchemeDto>>> GetAllScheme()
        {
            BaseUrl = _apiDetails.Value.LoanProcessAPIUrl;

            var _client = clientfact.CreateClient("LoanService");

            var httpResponse = await _client.GetAsync
                (
                    BaseUrl + APIEndpoints.GetScheme
                );

            var jsonString = httpResponse.Content.ReadAsStringAsync().Result;

            var options = new JsonSerializerOptions();

            var response = System.Text.Json.JsonSerializer.Deserialize<Response<IEnumerable<GetAllSchemeDto>>>(jsonString, options);

            return response;
        }

        public async Task<Response<CreateSchemeCommandDto>> AddScheme(CreateSchemeCommand req)
        {
            BaseUrl = _apiDetails.Value.LoanProcessAPIUrl;

            var content = JsonConvert.SerializeObject(req);

            var _client = clientfact.CreateClient("LoanService");

            var httpResponse = await _client.PostAsync
                (
                    BaseUrl + APIEndpoints.AddScheme,
                    new StringContent(content, Encoding.Default,
                    "application/json")
                );

            var jsonString = httpResponse.Content.ReadAsStringAsync().Result;

            var options = new JsonSerializerOptions();

            var response = System.Text.Json.JsonSerializer.Deserialize<Response<CreateSchemeCommandDto>>(jsonString, options);

            return response;
        }

        public async Task<Response<DeleteSchemeDto>> DeleteScheme(long id)
        {
            BaseUrl = _apiDetails.Value.LoanProcessAPIUrl;

            var _client = clientfact.CreateClient("LoanService");

            var httpResponse = await _client.DeleteAsync
                (
                    BaseUrl + APIEndpoints.DeleteScheme + id

                );

            var jsonString = httpResponse.Content.ReadAsStringAsync().Result;

            var options = new JsonSerializerOptions();

            var response = System.Text.Json.JsonSerializer.Deserialize<Response<DeleteSchemeDto>>(jsonString, options);

            return response;
        }

        public async Task<Response<GetSchemeByIdDto>> GetSchemeById(long id)
        {
            BaseUrl = _apiDetails.Value.LoanProcessAPIUrl;

            var _client = clientfact.CreateClient("LoanService");

            var httpResponse = await _client.GetAsync
                (
                    BaseUrl + APIEndpoints.GetSchemeById + id
                );

            var jsonString = httpResponse.Content.ReadAsStringAsync().Result;

            var options = new JsonSerializerOptions();

            var response = System.Text.Json.JsonSerializer.Deserialize<Response<GetSchemeByIdDto>>(jsonString, options);

            return response;
        }

        public async Task<Response<UpdateSchemeCommandDto>> UpdateScheme(UpdateSchemeCommand req)
        {
            BaseUrl = _apiDetails.Value.LoanProcessAPIUrl;

            var content = JsonConvert.SerializeObject(req);

            var _client = clientfact.CreateClient("LoanService");

            var httpResponse = await _client.PutAsync
                (
                    BaseUrl + APIEndpoints.UpdateScheme,
                    new StringContent(content, Encoding.Default,
                    "application/json")
                );

            var jsonString = httpResponse.Content.ReadAsStringAsync().Result;

            var options = new JsonSerializerOptions();

            var response = System.Text.Json.JsonSerializer.Deserialize<Response<UpdateSchemeCommandDto>>(jsonString, options);

            return response;
        }
    }
}
