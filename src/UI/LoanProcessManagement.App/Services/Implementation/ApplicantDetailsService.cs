using LoanProcessManagement.App.Helper.APIHelper;
using LoanProcessManagement.App.Models;
using LoanProcessManagement.App.Services.Interfaces;
using LoanProcessManagement.Application.Features.ApplicantDetails.Command;
using LoanProcessManagement.Application.Features.ApplicantDetails.Queries.AddApplicantDetails;
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
    public class ApplicantDetailsService : IApplicantDetailsService
    {
        private string BaseUrl = "";
        private readonly IHttpClientFactory clientfact;
        readonly IOptions<APIConfiguration> _apiDetails;

        public ApplicantDetailsService(IHttpClientFactory client, IOptions<APIConfiguration> apiDetails)
        {
            clientfact = client;
            _apiDetails = apiDetails;
        }


        #region This method will get add applicant details api by - Pratiksha Poshe - 19/11/2021
        /// <summary>
        /// 19/11/2021 - This method will get add applicant details api
        //	commented by Pratiksha Poshe
        /// </summary>
        /// <param name="leadId">leadId</param>
        /// <returns>response</returns>
        public async Task<Response<GetApplicantDetailsByIdDto>> GetApplicantDetailsByLeadId(long lead_Id, int applicantType)
        {
            BaseUrl = _apiDetails.Value.LoanProcessAPIUrl;

            var _client = clientfact.CreateClient("LoanService");

            var httpResponse = await _client.GetAsync
                (
                    BaseUrl + APIEndpoints.GetApplicantDetailsByLeadId.Replace("{0}", lead_Id.ToString()).Replace("{1}", applicantType.ToString())
                );

            var jsonString = httpResponse.Content.ReadAsStringAsync().Result;

            var options = new JsonSerializerOptions();

            var response = System.Text.Json.JsonSerializer.Deserialize<Response<GetApplicantDetailsByIdDto>>(jsonString, options);

            return response;
        }
        #endregion

        #region This method will call get add applicant details api by - Pratiksha Poshe - 19/11/2021
        /// <summary>
        ///  19/11/2021 - This method will call get add applicant details api
        ///  Commented by Pratiksha
        /// </summary>
        /// <param name="applicantDetailsCommandVM"></param>
        /// <returns>Api response</returns>
        public async Task<Response<AddApplicantDetailsDto>> UpdateApplicantDetails(AddApplicantDetailsCommandVM applicantDetailsCommandVM)
        {
            BaseUrl = _apiDetails.Value.LoanProcessAPIUrl;

            var content = JsonConvert.SerializeObject(applicantDetailsCommandVM);

            var _client = clientfact.CreateClient("LoanService");

            var httpResponse = await _client.PostAsync
                (
                    BaseUrl + APIEndpoints.AddApplicantDetails,
                    new StringContent(content, Encoding.Default,
                    "application/json")
                );

            var jsonString = httpResponse.Content.ReadAsStringAsync().Result;

            var options = new JsonSerializerOptions();

            var response = System.Text.Json.JsonSerializer.Deserialize<Response<AddApplicantDetailsDto>>(jsonString, options);

            return response;
        } 
        #endregion
    }
}
