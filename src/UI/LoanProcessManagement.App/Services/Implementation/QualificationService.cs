using LoanProcessManagement.App.Helper.APIHelper;
using LoanProcessManagement.App.Services.Interfaces;
using LoanProcessManagement.Application.Features.Qualification.Commands.CreateQualification;
using LoanProcessManagement.Application.Features.Qualification.Commands.DeleteQualification;
using LoanProcessManagement.Application.Features.Qualification.Commands.UpdateQualification;
using LoanProcessManagement.Application.Features.Qualification.Queries.GetQualificationById;
using LoanProcessManagement.Application.Features.Qualification.Queries.GetQualificationList;
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
    public class QualificationService :IQualificationService
    {
        private string BaseUrl = "";
        private readonly IHttpClientFactory clientfact;
        readonly IOptions<APIConfiguration> _apiDetails;

        public QualificationService(IHttpClientFactory client, IOptions<APIConfiguration> apiDetails)
        {
            clientfact = client;
            _apiDetails = apiDetails;
        }

        public async Task<Response<QualificationDto>> AddQualification(CreateQualificationCommand req)
        {
            BaseUrl = _apiDetails.Value.LoanProcessAPIUrl;

            var content = JsonConvert.SerializeObject(req);

            var _client = clientfact.CreateClient("LoanService");

            var httpResponse = await _client.PostAsync
                (
                    BaseUrl + APIEndpoints.AddQualification,
                    new StringContent(content, Encoding.Default,
                    "application/json")
                );

            var jsonString = httpResponse.Content.ReadAsStringAsync().Result;

            var options = new JsonSerializerOptions();

            var response = System.Text.Json.JsonSerializer.Deserialize<Response<QualificationDto>>(jsonString, options);

            return response;
        }

        public async Task<Response<DeleteQualificationDto>> DeleteQualification(long id)
        {
            BaseUrl = _apiDetails.Value.LoanProcessAPIUrl;

            var _client = clientfact.CreateClient("LoanService");

            var httpResponse = await _client.DeleteAsync
                (
                    BaseUrl + APIEndpoints.DeleteQualification + id

                );

            var jsonString = httpResponse.Content.ReadAsStringAsync().Result;

            var options = new JsonSerializerOptions();

            var response = System.Text.Json.JsonSerializer.Deserialize<Response<DeleteQualificationDto>>(jsonString, options);

            return response;
        }

        public async Task<Response<GetQualificationByIdDto>> GetQualificationById(long id)
        {
            BaseUrl = _apiDetails.Value.LoanProcessAPIUrl;

            var _client = clientfact.CreateClient("LoanService");

            var httpResponse = await _client.GetAsync
                (
                    BaseUrl + APIEndpoints.GetByIdQualification + id

                );

            var jsonString = httpResponse.Content.ReadAsStringAsync().Result;

            var options = new JsonSerializerOptions();

            var response = System.Text.Json.JsonSerializer.Deserialize<Response<GetQualificationByIdDto>>(jsonString, options);

            return response;
        }

        public async Task<Response<UpdateQualificationDto>> UpdateQualification(UpdateQualificationCommand req)
        {
            BaseUrl = _apiDetails.Value.LoanProcessAPIUrl;

           var content = JsonConvert.SerializeObject(req);

            var _client = clientfact.CreateClient("LoanService");

            var httpResponse = await _client.PutAsync
                (
                    BaseUrl + APIEndpoints.UpdateQualification,
                    new StringContent(content, Encoding.Default,
                    "application/json")
                );

            var jsonString = httpResponse.Content.ReadAsStringAsync().Result;

            var options = new JsonSerializerOptions();

            var response = System.Text.Json.JsonSerializer.Deserialize<Response<UpdateQualificationDto>>(jsonString, options);

            return response;
        }

        public async Task<Response<IEnumerable<GetQualificationListDto>>> GetAllQualification()
        {
            BaseUrl = _apiDetails.Value.LoanProcessAPIUrl;

            var _client = clientfact.CreateClient("LoanService");

            var httpResponse = await _client.GetAsync
                (
                    BaseUrl + APIEndpoints.GetAllQualification
                );

            var jsonString = httpResponse.Content.ReadAsStringAsync().Result;

            var options = new JsonSerializerOptions();

            var response = System.Text.Json.JsonSerializer.Deserialize<Response<IEnumerable<GetQualificationListDto>>>(jsonString, options);

            return response;
        }
    }
}
