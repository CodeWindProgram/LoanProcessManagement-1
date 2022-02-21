using LoanProcessManagement.App.Helper.APIHelper;
using LoanProcessManagement.App.Services.Interfaces;
using LoanProcessManagement.Application.Features.CreditCibilDetails.CreditCibilCheckDetails.Queries;
using LoanProcessManagement.Application.Features.CreditCibilDetails.UserDetails.Queries;
using LoanProcessManagement.Application.Features.CreditGstDetails.CreditGstCheckDetails.Queries;
using LoanProcessManagement.Application.Features.CreditGstDetails.UserDetails.Queries;
using LoanProcessManagement.Application.Features.CreditITRDetails.Queries;
using LoanProcessManagement.Application.Features.CreditITRDetails.UserDetails.Queries;
using LoanProcessManagement.Application.Responses;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace LoanProcessManagement.App.Services.Implementation
{
    public class CreditDetailsService:ICreditDetailsService
    {
        private string BaseUrl = "";
        private IHttpClientFactory clientfact;
        IOptions<APIConfiguration> _apiDetails;


        public CreditDetailsService(IHttpClientFactory client, IOptions<APIConfiguration> apiDetails)
        {
            clientfact = client;
            _apiDetails = apiDetails;
        }
        #region added service class to implement to get  Cibil, ITR and GST enquiry and user credit details   - Ramya Guduru - 15/02/2022
        public async Task<Response<IEnumerable<GetCreditCibilDetailsVm>>> CreditCibilDetailsList()
        {
            BaseUrl = _apiDetails.Value.LoanProcessAPIUrl;

            var _client = clientfact.CreateClient("LoanService");

            var httpResponse = await _client.GetAsync
                (
                    BaseUrl + APIEndpoints.CreditCibilDetailsList
                );

            var jsonString = httpResponse.Content.ReadAsStringAsync().Result;

            var options = new JsonSerializerOptions();

            var model = System.Text.Json.JsonSerializer.Deserialize<Response<IEnumerable<GetCreditCibilDetailsVm>>>(jsonString, options);

            return model;
        }

        public async Task<Response<IEnumerable<GetCreditGstDetailsVm>>> CreditGstDetailsList()
        {
            BaseUrl = _apiDetails.Value.LoanProcessAPIUrl;

            var _client = clientfact.CreateClient("LoanService");

            var httpResponse = await _client.GetAsync
                (
                    BaseUrl + APIEndpoints.CreditGstDetailsList
                );

            var jsonString = httpResponse.Content.ReadAsStringAsync().Result;

            var options = new JsonSerializerOptions();

            var model = System.Text.Json.JsonSerializer.Deserialize<Response<IEnumerable<GetCreditGstDetailsVm>>>(jsonString, options);

            return model;
        }

        public async Task<Response<IEnumerable<GetCreditITRDetailsListVm>>> CreditITRDetailsList()
        {
            BaseUrl = _apiDetails.Value.LoanProcessAPIUrl;

            var _client = clientfact.CreateClient("LoanService");

            var httpResponse = await _client.GetAsync
                (
                    BaseUrl + APIEndpoints.CreditITRDetailsList
                );

            var jsonString = httpResponse.Content.ReadAsStringAsync().Result;

            var options = new JsonSerializerOptions();

            var model = System.Text.Json.JsonSerializer.Deserialize<Response<IEnumerable<GetCreditITRDetailsListVm>>>(jsonString, options);

            return model;
        }

        public async Task<Response<IEnumerable<GetCreditCibilUserDetailsVm>>> userCibilDetailsByFormNo(string FormNo)
        {
            BaseUrl = _apiDetails.Value.LoanProcessAPIUrl;

            var _client = clientfact.CreateClient("LoanService");

            var httpResponse = await _client.GetAsync
                (
                    BaseUrl + APIEndpoints.CreditCibilUserDetailsList + FormNo
                );

            var jsonString = httpResponse.Content.ReadAsStringAsync().Result;

            var options = new JsonSerializerOptions();

            var model = System.Text.Json.JsonSerializer.Deserialize<Response<IEnumerable<GetCreditCibilUserDetailsVm>>>(jsonString, options);

            return model;
        }

        public async Task<Response<IEnumerable<GetCreditITRUserDetailsVm>>> userDetailsByFormNo(string FormNo)
        {
            BaseUrl = _apiDetails.Value.LoanProcessAPIUrl;

            var _client = clientfact.CreateClient("LoanService");

            var httpResponse = await _client.GetAsync
                (
                    BaseUrl + APIEndpoints.CreditITRUserDetailsList+FormNo
                );

            var jsonString = httpResponse.Content.ReadAsStringAsync().Result;

            var options = new JsonSerializerOptions();

            var model = System.Text.Json.JsonSerializer.Deserialize<Response<IEnumerable<GetCreditITRUserDetailsVm>>>(jsonString, options);

            return model;
        }

        public async Task<Response<IEnumerable<GetCreditGstUserDetailsVm>>> userGstDetailsByFormNo(string FormNo)
        {
            BaseUrl = _apiDetails.Value.LoanProcessAPIUrl;

            var _client = clientfact.CreateClient("LoanService");

            var httpResponse = await _client.GetAsync
                (
                    BaseUrl + APIEndpoints.CreditGstUserDetailsList + FormNo
                );

            var jsonString = httpResponse.Content.ReadAsStringAsync().Result;

            var options = new JsonSerializerOptions();

            var model = System.Text.Json.JsonSerializer.Deserialize<Response<IEnumerable<GetCreditGstUserDetailsVm>>>(jsonString, options);

            return model;
        }

        #endregion
    }
}
