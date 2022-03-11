using LoanProcessManagement.App.Helper.APIHelper;
using LoanProcessManagement.App.Services.Interfaces;
using LoanProcessManagement.Application.Features.LpmCategories.Commands.CreateLpmCategory;
using LoanProcessManagement.Application.Features.LpmCategories.Commands.DeleteLpmCategory;
using LoanProcessManagement.Application.Features.LpmCategories.Commands.UpdateLpmCategory;
using LoanProcessManagement.Application.Features.LpmCategories.Queries.GetAllCategories;
using LoanProcessManagement.Application.Features.LpmCategories.Queries.GetLpmCategoryById;
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
    public class LpmCategoryServices : ILpmCategoryServices
    {
        private string BaseUrl = "";
        private readonly IHttpClientFactory clientfact;
        readonly IOptions<APIConfiguration> _apiDetails;

        public LpmCategoryServices(IHttpClientFactory client, IOptions<APIConfiguration> apiDetails)
        {
            clientfact = client;
            _apiDetails = apiDetails;
        }
        public async Task<Response<IEnumerable<GetAllCategoriesQueryDto>>> GetAllLpmCategories()
        {
            BaseUrl = _apiDetails.Value.LoanProcessAPIUrl;

            var _client = clientfact.CreateClient("LoanService");

            var httpResponse = await _client.GetAsync
                (
                    BaseUrl + APIEndpoints.GetLpmCategories
                );

            var jsonString = httpResponse.Content.ReadAsStringAsync().Result;

            var options = new JsonSerializerOptions();

            var response = System.Text.Json.JsonSerializer.Deserialize<Response<IEnumerable<GetAllCategoriesQueryDto>>>(jsonString, options);

            return response;
        }

        public async Task<Response<CreateLpmCategoryCommandDto>> AddLpmCategory(CreateLpmCategoryCommand req)
        {
            BaseUrl = _apiDetails.Value.LoanProcessAPIUrl;

            var content = JsonConvert.SerializeObject(req);

            var _client = clientfact.CreateClient("LoanService");

            var httpResponse = await _client.PostAsync
                (
                    BaseUrl + APIEndpoints.AddLpmCategory,
                    new StringContent(content, Encoding.Default,
                    "application/json")
                );

            var jsonString = httpResponse.Content.ReadAsStringAsync().Result;

            var options = new JsonSerializerOptions();

            var response = System.Text.Json.JsonSerializer.Deserialize<Response<CreateLpmCategoryCommandDto>>(jsonString, options);

            return response;
        }

        public async Task<Response<DeleteLpmCategoryCommandDto>> DeleteLpmCategory(long id)
        {
            BaseUrl = _apiDetails.Value.LoanProcessAPIUrl;

            var _client = clientfact.CreateClient("LoanService");

            var httpResponse = await _client.DeleteAsync
                (
                    BaseUrl + APIEndpoints.DeleteLpmCategory + id

                );

            var jsonString = httpResponse.Content.ReadAsStringAsync().Result;

            var options = new JsonSerializerOptions();

            var response = System.Text.Json.JsonSerializer.Deserialize<Response<DeleteLpmCategoryCommandDto>>(jsonString, options);

            return response;
        }

        public async Task<Response<GetLpmCategoryByIdCommandDto>> GetLpmCategoryById(long id)
        {
            BaseUrl = _apiDetails.Value.LoanProcessAPIUrl;

            var _client = clientfact.CreateClient("LoanService");

            var httpResponse = await _client.GetAsync
                (
                    BaseUrl + APIEndpoints.GetLpmCategoryById + id
                );

            var jsonString = httpResponse.Content.ReadAsStringAsync().Result;

            var options = new JsonSerializerOptions();

            var response = System.Text.Json.JsonSerializer.Deserialize<Response<GetLpmCategoryByIdCommandDto>>(jsonString, options);

            return response;
        }

        public async Task<Response<UpdateLpmCategoryCommandDto>> UpdateLpmCategory(UpdateLpmCategoryCommand req)
        {
            BaseUrl = _apiDetails.Value.LoanProcessAPIUrl;

            var content = JsonConvert.SerializeObject(req);

            var _client = clientfact.CreateClient("LoanService");

            var httpResponse = await _client.PutAsync
                (
                    BaseUrl + APIEndpoints.UpdateLpmCategory,
                    new StringContent(content, Encoding.Default,
                    "application/json")
                );

            var jsonString = httpResponse.Content.ReadAsStringAsync().Result;

            var options = new JsonSerializerOptions();

            var response = System.Text.Json.JsonSerializer.Deserialize<Response<UpdateLpmCategoryCommandDto>>(jsonString, options);

            return response;
        }
    }
}
