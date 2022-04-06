using LoanProcessManagement.App.Helper.APIHelper;
using LoanProcessManagement.App.Models;
using LoanProcessManagement.App.Services.Interfaces;
using LoanProcessManagement.Application.Features.IncomeAssesment.Commands.AddIncomeAssessment;
using LoanProcessManagement.Application.Features.IncomeAssesment.Commands.GSTAddEnuiry;
using LoanProcessManagement.Application.Features.IncomeAssesment.Commands.GSTCreateEnquiry;
using LoanProcessManagement.Application.Features.IncomeAssesment.Commands.UpdateSubmitGst;
using LoanProcessManagement.Application.Features.IncomeAssesment.Queries.GetIncomeAssessment;
using LoanProcessManagement.Application.Features.IncomeAssesment.Queries.GetIsSubmitFromGst;
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
    public class IncomeAssesmentService : IIncomeAssesmentService
    {
        private string BaseUrl = "";
        private readonly IHttpClientFactory clientfact;
        readonly IOptions<APIConfiguration> _apiDetails;

        public IncomeAssesmentService(IHttpClientFactory client, IOptions<APIConfiguration> apiDetails)
        {
            clientfact = client;
            _apiDetails = apiDetails;
        }

        public async Task<Response<GstAddEnquiryCommandDto>> AddEnquiry(int applicantType, int lead_Id)
        {
            BaseUrl = _apiDetails.Value.LoanProcessAPIUrl;

            var _client = clientfact.CreateClient("LoanService");

            var httpResponse = await _client.GetAsync
                (
                    $"{BaseUrl}{APIEndpoints.AddEnquiry}{applicantType}/{lead_Id}"
                );

            var jsonString = httpResponse.Content.ReadAsStringAsync().Result;

            var options = new JsonSerializerOptions();

            var response = System.Text.Json.JsonSerializer.Deserialize<Response<GstAddEnquiryCommandDto>>(jsonString, options);

            return response;
        }

        public async Task<Response<GstCreateEnquiryCommandDto>> CreateEnquiry(GstCreateEnquiryCommand gstCreateEnquiryCommand)
        {
            BaseUrl = _apiDetails.Value.LoanProcessAPIUrl;

            var content = JsonConvert.SerializeObject(gstCreateEnquiryCommand);

            var _client = clientfact.CreateClient("LoanService");

            var httpResponse = await _client.PostAsync
                (
                    BaseUrl + APIEndpoints.CreateEnquiry,
                    new StringContent(content, Encoding.Default,
                    "application/json")
                );

            var jsonString = httpResponse.Content.ReadAsStringAsync().Result;

            var options = new JsonSerializerOptions();

            var model = System.Text.Json.JsonSerializer.Deserialize<Response<GstCreateEnquiryCommandDto>>(jsonString, options);

            return model;
        }

        #region GetIncomeDetailsService - Pratiksha Poshe - 15/02/2022
        /// <summary>
        /// 15/02/2021 - GetIncomeDetailsService
        /// commented by Pratiksha Poshe
        /// </summary>
        /// <param name="applicantType"></param>
        /// <param name="lead_Id"></param>
        /// <returns></returns>
        public async Task<Response<GetIncomeAssessmentDetailsDto>> GetIncomeDetailsService(int applicantType, int lead_Id)
        {
            BaseUrl = _apiDetails.Value.LoanProcessAPIUrl;

            var _client = clientfact.CreateClient("LoanService");

            var httpResponse = await _client.GetAsync
                (
                    BaseUrl + APIEndpoints.GetIncomeAssessmentDetails.Replace("{0}", applicantType.ToString()).Replace("{1}", lead_Id.ToString())
                );

            var jsonString = httpResponse.Content.ReadAsStringAsync().Result;

            var options = new JsonSerializerOptions();

            var response = System.Text.Json.JsonSerializer.Deserialize<Response<GetIncomeAssessmentDetailsDto>>(jsonString, options);

            return response;
        }
        #endregion

        #region AddIncomeDetailsService - Pratiksha Poshe - 15/02/2022
        /// <summary>
        /// 15/02/2021 - AddIncomeDetailsService
        /// commented by Pratiksha Poshe
        /// </summary>
        /// <param name="addIncomeAssessmentDetailsDto"></param>
        /// <returns></returns>
        public async Task<Response<AddIncomeAssessmentDetailsDto>> AddIncomeAssessmentDetails(AddIncomeAssessmentDetailsDto addIncomeAssessmentDetailsDto)
        {
            BaseUrl = _apiDetails.Value.LoanProcessAPIUrl;

            var content = JsonConvert.SerializeObject(addIncomeAssessmentDetailsDto);

            var _client = clientfact.CreateClient("LoanService");

            var httpResponse = await _client.PostAsync
                (
                    BaseUrl + APIEndpoints.AddIncomeAssessmentDetails,
                    new StringContent(content, Encoding.Default,
                    "application/json")
                );

            var jsonString = httpResponse.Content.ReadAsStringAsync().Result;

            var options = new JsonSerializerOptions();

            var model = System.Text.Json.JsonSerializer.Deserialize<Response<AddIncomeAssessmentDetailsDto>>(jsonString, options);

            return model;
        }
        #endregion

        public async Task<Response<GetIsSubmitFromGstQueryDto>> GetIsSubmit(long Id)
        {
            BaseUrl = _apiDetails.Value.LoanProcessAPIUrl;

            var content = JsonConvert.SerializeObject(Id);

            var _client = clientfact.CreateClient("LoanService");

            var httpResponse = await _client.GetAsync
                (
                    BaseUrl + APIEndpoints.GetSubmit + Id
                );

            var jsonString = httpResponse.Content.ReadAsStringAsync().Result;

            var options = new JsonSerializerOptions();

            var model = System.Text.Json.JsonSerializer.Deserialize<Response<GetIsSubmitFromGstQueryDto>>(jsonString, options);

            return model;
        }

        public async Task<UpdateSubmitGstCommandDto> PostIsSubmit(UpdateSubmitGstCommand gstCreateEnquiryCommand)
        {
            BaseUrl = _apiDetails.Value.LoanProcessAPIUrl;

            var content = JsonConvert.SerializeObject(gstCreateEnquiryCommand);

            var _client = clientfact.CreateClient("LoanService");

            var httpResponse = await _client.PutAsync
                (
                    BaseUrl + APIEndpoints.PostSubmit,
                    new StringContent(content, Encoding.Default,
                    "application/json")
                );

            var jsonString = httpResponse.Content.ReadAsStringAsync().Result;

            var options = new JsonSerializerOptions();

            var model = System.Text.Json.JsonSerializer.Deserialize<UpdateSubmitGstCommandDto>(jsonString, options);

            return model;
        }

        #region GetIncomeAssessmentRecordsListService - Pratiksha - 03/03/2022
        /// <summary>
        /// 03/03/20222 - GetIncomeAssessmentRecordsListService
        /// commented by Pratiksha Poshe
        /// </summary>
        /// <param name="applicantType"></param>
        /// <param name="lead_Id"></param>
        /// <returns></returns>
        public async Task<Response<IEnumerable<IncomeAssessmentRecordsListVM>>> GetIncomeAssessmentRecordsList(int applicantType, long lead_Id)
        {
            BaseUrl = _apiDetails.Value.LoanProcessAPIUrl;

            var _client = clientfact.CreateClient("LoanService");

            var httpResponse = await _client.GetAsync
                (
                    BaseUrl + APIEndpoints.GetIncomeAssessmentRecordsList.Replace("{0}", applicantType.ToString()).Replace("{1}", lead_Id.ToString())
                );

            var jsonString = httpResponse.Content.ReadAsStringAsync().Result;

            var options = new JsonSerializerOptions();

            var response = System.Text.Json.JsonSerializer.Deserialize<Response<IEnumerable<IncomeAssessmentRecordsListVM>>>(jsonString, options);

            return response;
        }
        #endregion
    }
}
