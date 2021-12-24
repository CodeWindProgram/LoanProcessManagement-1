using LoanProcessManagement.App.Helper.APIHelper;
using LoanProcessManagement.App.Services.Interfaces;
using LoanProcessManagement.Application.Features.Agency.Queries.GetAllAgency;
using LoanProcessManagement.Application.Features.ThirdPartyCheckDetails.Queries;
using LoanProcessManagement.Application.Responses;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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
    }
}
