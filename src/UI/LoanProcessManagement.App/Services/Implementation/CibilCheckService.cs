using LoanProcessManagement.App.Helper.APIHelper;
using LoanProcessManagement.App.Models;
using LoanProcessManagement.App.Services.Interfaces;
using LoanProcessManagement.Application.Features.CibilCheck.Commands.AddCibilCheckDetails;
using LoanProcessManagement.Application.Features.CibilCheck.Queries.ApplicantDetails;
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
    public class CibilCheckService:ICibilCheckService
    {
        private string BaseUrl = "";
        private readonly IHttpClientFactory clientfact;
        readonly IOptions<APIConfiguration> _apiDetails;

        public CibilCheckService(IHttpClientFactory client, IOptions<APIConfiguration> apiDetails)
        {
            clientfact = client;
            _apiDetails = apiDetails;
        }
        #region Calling Cibil check details and updating Cibil check details api - Ramya Guduru - 21/12/2021
        /// <summary>
        /// Calling Cibil check details api - Ramya Guduru - 21/12/2021
        /// </summary>
        /// <param name="cibilCheckDetailsVm"></param>
        /// <returns></returns>
        public async Task<Response<AddCibilDetailsDto>> UpdateCibilCheckDetailsDetails(CibilCheckDetailsVm cibilCheckDetailsVm)
        {
            BaseUrl = _apiDetails.Value.LoanProcessAPIUrl;

            var content = JsonConvert.SerializeObject(cibilCheckDetailsVm);

            var _client = clientfact.CreateClient("LoanService");

            var httpResponse = await _client.PostAsync
                (
                    BaseUrl + APIEndpoints.AddCibilCheckDetails,
                    new StringContent(content, Encoding.Default,
                    "application/json")
                );

            var jsonString = httpResponse.Content.ReadAsStringAsync().Result;

            var options = new JsonSerializerOptions();

            var response = System.Text.Json.JsonSerializer.Deserialize<Response<AddCibilDetailsDto>>(jsonString, options);

            return response;
        }

        public async Task<Response<GetCibilCheckDetailsDto>> GetCibilCheckDetails(long lead_Id, int applicantType)
        {
            BaseUrl = _apiDetails.Value.LoanProcessAPIUrl;

            var _client = clientfact.CreateClient("LoanService");

            var httpResponse = await _client.GetAsync
                (
                    BaseUrl + APIEndpoints.GetCibilCheckDetails.Replace("{0}", lead_Id.ToString()).Replace("{1}", applicantType.ToString())
                );

            var jsonString = httpResponse.Content.ReadAsStringAsync().Result;

            var options = new JsonSerializerOptions();

            var response = System.Text.Json.JsonSerializer.Deserialize<Response<GetCibilCheckDetailsDto>>(jsonString, options);

            return response;
        }
        #endregion
    }
}
