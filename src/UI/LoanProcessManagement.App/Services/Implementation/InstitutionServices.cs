using LoanProcessManagement.App.Helper.APIHelper;
using LoanProcessManagement.App.Services.Interfaces;
using LoanProcessManagement.Application.Features.InstitutionMasters.Commands.CreateInstitutionMasters;
using LoanProcessManagement.Application.Features.InstitutionMasters.Commands.DeleteInstitutionMasters;
using LoanProcessManagement.Application.Features.InstitutionMasters.Commands.UpdateInstitutionMasters;
using LoanProcessManagement.Application.Features.InstitutionMasters.Queries.GetInstitutionMasters;
using LoanProcessManagement.Application.Features.InstitutionMasters.Queries.GetInstitutionMastersById;
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
    public class InstitutionServices : IInstitutionServices
    {
        private string BaseUrl = "";
        private readonly IHttpClientFactory clientfact;
        readonly IOptions<APIConfiguration> _apiDetails;

        public InstitutionServices(IHttpClientFactory client, IOptions<APIConfiguration> apiDetails)
        {
            clientfact = client;
            _apiDetails = apiDetails;
        }

        #region  This method will call Institution Master CRUD api by - Dipti Pandhram - 23/03/2022
        public async Task<Response<IEnumerable<GetInstitutionMastersQueryDto>>> GetAllInstitutions()
        {
            BaseUrl = _apiDetails.Value.LoanProcessAPIUrl;

            var _client = clientfact.CreateClient("LoanService");

            var httpResponse = await _client.GetAsync
                (
                    BaseUrl + APIEndpoints.GetInstitution
                );

            var jsonString = httpResponse.Content.ReadAsStringAsync().Result;

            var options = new JsonSerializerOptions();

            var response = System.Text.Json.JsonSerializer.Deserialize<Response<IEnumerable<GetInstitutionMastersQueryDto>>>(jsonString, options);

            return response;
        }

        public async Task<Response<InstitutionMastersDto>> CreateInstitutionMastersCommand(CreateInstitutionMastersCommand req)
        {
            BaseUrl = _apiDetails.Value.LoanProcessAPIUrl;

            var content = JsonConvert.SerializeObject(req);

            var _client = clientfact.CreateClient("LoanService");

            var httpResponse = await _client.PostAsync
                (
                    BaseUrl + APIEndpoints.AddInstitution,
                    new StringContent(content, Encoding.Default,
                    "application/json")
                );

            var jsonString = httpResponse.Content.ReadAsStringAsync().Result;

            var options = new JsonSerializerOptions();

            var response = System.Text.Json.JsonSerializer.Deserialize<Response<InstitutionMastersDto>>(jsonString, options);

            return response;
        }

        public async Task<Response<DeleteInstitutionMastersDto>> DeleteInstitutionMasters(long id)
        {
            BaseUrl = _apiDetails.Value.LoanProcessAPIUrl;

            var _client = clientfact.CreateClient("LoanService");

            var httpResponse = await _client.DeleteAsync
                (
                    BaseUrl + APIEndpoints.DeleteInstitution + id

                );

            var jsonString = httpResponse.Content.ReadAsStringAsync().Result;

            var options = new JsonSerializerOptions();

            var response = System.Text.Json.JsonSerializer.Deserialize<Response<DeleteInstitutionMastersDto>>(jsonString, options);

            return response;
        }

        public async Task<Response<GetInstitutionMastersByIdQueryVm>> GetInstitutionMastersById(long id)
        {
            BaseUrl = _apiDetails.Value.LoanProcessAPIUrl;

            var _client = clientfact.CreateClient("LoanService");

            var httpResponse = await _client.GetAsync
                (
                    BaseUrl + APIEndpoints.GetByIdInstitution + id

                );

            var jsonString = httpResponse.Content.ReadAsStringAsync().Result;

            var options = new JsonSerializerOptions();

            var response = System.Text.Json.JsonSerializer.Deserialize<Response<GetInstitutionMastersByIdQueryVm>>(jsonString, options);

            return response;
        }

        public async Task<Response<UpdateInstitutionMastersDto>> UpdateInstitutionMasters(UpdateInstitutionMastersCommand req)
        {
            BaseUrl = _apiDetails.Value.LoanProcessAPIUrl;

            var content = JsonConvert.SerializeObject(req);

            var _client = clientfact.CreateClient("LoanService");

            var httpResponse = await _client.PutAsync
                (
                    BaseUrl + APIEndpoints.UpdateInstitution,
                    new StringContent(content, Encoding.Default,
                    "application/json")
                );

            var jsonString = httpResponse.Content.ReadAsStringAsync().Result;

            var options = new JsonSerializerOptions();

            var response = System.Text.Json.JsonSerializer.Deserialize<Response<UpdateInstitutionMastersDto>>(jsonString, options);

            return response;
        } 
        #endregion
    
    }
}
