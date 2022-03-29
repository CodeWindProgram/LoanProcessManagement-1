using LoanProcessManagement.App.Helper.APIHelper;
using LoanProcessManagement.App.Models;
using LoanProcessManagement.App.Services.Interfaces;
using LoanProcessManagement.Application.Features.Agency.Commands.CreateAgency;
using LoanProcessManagement.Application.Features.Agency.Commands.DeleteAgency;
using LoanProcessManagement.Application.Features.Agency.Commands.UpdateAgency;
using LoanProcessManagement.Application.Features.Agency.Queries.GetAgencyById;
using LoanProcessManagement.Application.Features.Agency.Queries.GetAgencyList;
using LoanProcessManagement.Application.Features.Agency.Queries.GetAllAgency;
using LoanProcessManagement.Application.Features.ThirdPartyCheckDetails.Command;
using LoanProcessManagement.Application.Features.ThirdPartyCheckDetails.Queries;
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
    public class AgencyService : IAgencyService
    {
        private string BaseUrl = "";
        private readonly IHttpClientFactory clientfact;
        readonly IOptions<APIConfiguration> _apiDetails;

        public AgencyService(IHttpClientFactory client, IOptions<APIConfiguration> apiDetails)
        {
            clientfact = client;
            _apiDetails = apiDetails;
        }

        #region This method will call GetAllAgencyName api method to fetch agency name by - Pratiksha Poshe - 23/12/2021
        /// <summary>
        /// 23/12/2021 - This method will call GetAllAgencyName api method to fetch agency name
        /// Commented by Pratiksha Poshe
        /// </summary>
        /// <returns>response</returns>
        public async Task<Response<GetAllAgencyDto>> GetAllAgencyName()
        {
            BaseUrl = _apiDetails.Value.LoanProcessAPIUrl;

            var _client = clientfact.CreateClient("LoanService");

            var httpResponse = await _client.GetAsync
                (
                    BaseUrl + APIEndpoints.GetAllAgencyName
                );

            var jsonString = httpResponse.Content.ReadAsStringAsync().Result;

            var options = new JsonSerializerOptions();

            var response = System.Text.Json.JsonSerializer.Deserialize<Response<GetAllAgencyDto>>(jsonString, options);

            return response;
        }
        #endregion

        #region This method will call third party details api method to fetch third party details by - Pratiksha Poshe - 23/12/2021
        /// <summary>
        /// 23/12/2021 - This method will call third party details api method to fetch third party details
        /// Commented by Pratiksha Poshe
        /// </summary>
        /// <param name="lead_Id"></param>
        /// <returns></returns>
        public async Task<Response<GetThirdPartyCheckDetailsByLeadIdDto>> GetThirdPartyCheckDetailsByLeadId(string lead_Id)
        {
            BaseUrl = _apiDetails.Value.LoanProcessAPIUrl;

            var _client = clientfact.CreateClient("LoanService");

            var httpResponse = await _client.GetAsync
                (
                    BaseUrl + APIEndpoints.GetThirdPartyCheckDetailsByLeadId + lead_Id
                );

            var jsonString = httpResponse.Content.ReadAsStringAsync().Result;

            var options = new JsonSerializerOptions();

            var response = System.Text.Json.JsonSerializer.Deserialize<Response<GetThirdPartyCheckDetailsByLeadIdDto>>(jsonString, options);

            return response;
        }


        #endregion

        public async Task<Response<AddThirdPartyCheckDetailsDto>> SubmitToAgency(ThirdPartyCheckDetailsVm req)
        {
            BaseUrl = _apiDetails.Value.LoanProcessAPIUrl;

            var content = JsonConvert.SerializeObject(req);

            var _client = clientfact.CreateClient("LoanService");

            var httpResponse = await _client.PostAsync
                (
                    BaseUrl + APIEndpoints.SubmitToAgency,
                    new StringContent(content, Encoding.Default,
                    "application/json")
                );

            var jsonString = httpResponse.Content.ReadAsStringAsync().Result;

            var options = new JsonSerializerOptions();

            var response = System.Text.Json.JsonSerializer.Deserialize<Response<AddThirdPartyCheckDetailsDto>>(jsonString, options);

            return response;
        }

        public async Task<Response<CreateAgencyDto>> AddAgency(CreateAgencyCommand req)
        {
            BaseUrl = _apiDetails.Value.LoanProcessAPIUrl;

            var content = JsonConvert.SerializeObject(req);

            var _client = clientfact.CreateClient("LoanService");

            var httpResponse = await _client.PostAsync
                (
                    BaseUrl + APIEndpoints.AddAgency,
                    new StringContent(content, Encoding.Default,
                    "application/json")
                );

            var jsonString = httpResponse.Content.ReadAsStringAsync().Result;

            var options = new JsonSerializerOptions();

            var response = System.Text.Json.JsonSerializer.Deserialize<Response<CreateAgencyDto>>(jsonString, options);

            return response;
        }

        public async Task<Response<DeleteAgencyDto>> DeleteAgency(long id)
        {
            BaseUrl = _apiDetails.Value.LoanProcessAPIUrl;

            var _client = clientfact.CreateClient("LoanService");

            var httpResponse = await _client.DeleteAsync
                (
                    BaseUrl + APIEndpoints.DeleteAgency + id

                );

            var jsonString = httpResponse.Content.ReadAsStringAsync().Result;

            var options = new JsonSerializerOptions();

            var response = System.Text.Json.JsonSerializer.Deserialize<Response<DeleteAgencyDto>>(jsonString, options);

            return response;
        }

        public async Task<Response<GetAgencyByIdQueryVm>> GetAgencyById(long id)
        {
            BaseUrl = _apiDetails.Value.LoanProcessAPIUrl;

            var _client = clientfact.CreateClient("LoanService");

            var httpResponse = await _client.GetAsync
                (
                    BaseUrl + APIEndpoints.GetAgencyeById + id

                );

            var jsonString = httpResponse.Content.ReadAsStringAsync().Result;

            var options = new JsonSerializerOptions();

            var response = System.Text.Json.JsonSerializer.Deserialize<Response<GetAgencyByIdQueryVm>>(jsonString, options);

            return response;

        }

        public async Task<Response<UpdateAgencyDto>> UpdateAgency(UpdateAgencyCommand req)
        {

            BaseUrl = _apiDetails.Value.LoanProcessAPIUrl;

            var content = JsonConvert.SerializeObject(req);

            var _client = clientfact.CreateClient("LoanService");

            var httpResponse = await _client.PutAsync
                (
                    BaseUrl + APIEndpoints.UpdateAgency,
                    new StringContent(content, Encoding.Default,
                    "application/json")
                );

            var jsonString = httpResponse.Content.ReadAsStringAsync().Result;

            var options = new JsonSerializerOptions();

            var response = System.Text.Json.JsonSerializer.Deserialize<Response<UpdateAgencyDto>>(jsonString, options);

            return response;

        }

        public async Task<Response<IEnumerable<GetAgencyListQueryVm>>> GetAgencyList()
        {
            BaseUrl = _apiDetails.Value.LoanProcessAPIUrl;

            var _client = clientfact.CreateClient("LoanService");

            var httpResponse = await _client.GetAsync
                (
                    BaseUrl + APIEndpoints.AgencyList
                );

            var jsonString = httpResponse.Content.ReadAsStringAsync().Result;

            var options = new JsonSerializerOptions();

            var response = System.Text.Json.JsonSerializer.Deserialize<Response<IEnumerable<GetAgencyListQueryVm>>>(jsonString, options);

            return response;

        }
    }
}
